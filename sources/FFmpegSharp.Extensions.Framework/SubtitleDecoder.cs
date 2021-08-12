// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with FFmpegSharp.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Threading;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class SubtitleDecoder
    {
        private readonly Channel<AVPacket> _subtitleInput;

        private readonly Channel<AVSubtitle> _subtitleOutput;

        private readonly AVCodecContext _codecContext;

        private readonly AVCodec _codec;

        private readonly Thread _decodeThread;

        private readonly CancellationTokenSource _cancellationTokenSource;

        public Channel<AVSubtitle> SubtitleOutput => _subtitleOutput;

        public SubtitleDecoder(Channel<AVPacket> subtitleInput)
        {
            _subtitleInput = subtitleInput ?? throw new ArgumentNullException(nameof(subtitleInput));

            _subtitleOutput = new Channel<AVSubtitle>();

            _codec = AVCodec.FindDecoder((AVCodecID)_subtitleInput.MetaData.CodecID) ?? throw new InvalidOperationException();
            _codecContext = new AVCodecContext(_subtitleInput.MetaData.CodecParameters);
            _codecContext.PacketTimeBase = _subtitleInput.MetaData.TimeBase;
            _codecContext.Open(_codec, new AVDictionary
            {
                { "threads", "auto" },
            });

            _decodeThread = new Thread(Decode);
            _decodeThread.Name = "Subtitle Decoder Thread";
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            _decodeThread.Start();
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
            _decodeThread.Join();
        }

        private void Decode()
        {
            try
            {
                while (true)
                {
                    if (_subtitleInput.Reader.TryRead(out var packet, Timeout.Infinite, _cancellationTokenSource.Token))
                    {
                        var subtitle = _subtitleOutput.Writer.Get();
                        var retval = _codecContext.DecodeSubtitle2(packet, subtitle, out var gotSubtitle);
                        if (retval >= 0 && gotSubtitle)
                        {
                            _subtitleOutput.MetaData.Width = _codecContext.Width;
                            _subtitleOutput.MetaData.Height = _codecContext.Height;
                            _subtitleOutput.Writer.Write(subtitle);
                        }

                        packet.Unref();

                        _subtitleInput.Reader.Return(packet);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }
    }
}
