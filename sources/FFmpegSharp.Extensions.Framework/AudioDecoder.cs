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
using static FFmpegSharp.Interop.FFmpeg;
using static FFmpegSharp.Interop.Std;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class AudioDecoder
    {
        private const int MaxQueueSize = 9;

        private readonly Channel<AVPacket> _audioInput;

        private readonly Channel<AVFrame> _audioOutput;

        private readonly AVCodec _codec;

        private readonly AVCodecContext _codecContext;

        private readonly Thread _thread;

        private readonly CancellationTokenSource _cancellationTokenSource;

        public Channel<AVFrame> AudioOutput => _audioOutput;

        public AudioDecoder(Channel<AVPacket> audioInput)
        : this(audioInput, AudioDecoderOptions.Default)
        { }

        public AudioDecoder(Channel<AVPacket> audioInput, AudioDecoderOptions options)
        {
            _audioInput = audioInput ?? throw new ArgumentNullException(nameof(audioInput));
            _audioOutput = new Channel<AVFrame>(MaxQueueSize);
            _audioOutput.MetaData.TimeBase = _audioInput.MetaData.TimeBase;

            _codec = AVCodec.FindDecoder((AVCodecID)_audioInput.MetaData.CodecID) ?? throw new InvalidOperationException();
            _codecContext = new AVCodecContext(_audioInput.MetaData.CodecParameters);
            _codecContext.PacketTimeBase = _audioInput.MetaData.TimeBase;
            _codecContext.Flags2 |= options.Fast ? AVCodecFlags2.Fast : AVCodecFlags2.None;
            _codecContext.Open(_codec, new AVDictionary
            {
                { "threads", "auto" }
            });

            _thread = new Thread(Decode);
            _thread.Name = "Audio Decoder Thread";
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public int ChannelCount => _codecContext.ChannelCount;

        public AVChannelLayout ChannelLayout => _codecContext.ChannelLayout != 0 ? _codecContext.ChannelLayout : AVUtil.GetDefaultChannelLayout(_codecContext.ChannelCount);

        public int SampleRate => _codecContext.SampleRate;

        public AVSampleFormat SampleFormat => _codecContext.SampleFormat;

        public void Start()
        {
            _thread.Start(_cancellationTokenSource.Token);
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
            _thread.Join();
        }

        private void Decode(object? userState)
        {
            var cancellationToken = (CancellationToken)userState!;

            try
            {
                AVPacket? packet = null;

                while (!cancellationToken.IsCancellationRequested)
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        if (packet != null || _audioInput.Reader.TryRead(out packet, Timeout.Infinite, cancellationToken))
                        {
                            try
                            {
                                var retval = _codecContext.Send(packet);
                                if (retval == AVERROR_EOF)
                                {
                                    return;
                                }

                                if (retval == AVERROR(EAGAIN))
                                {
                                    break;
                                }

                                if (retval == 0)
                                {
                                    packet.Unref();
                                    _audioInput.Reader.Return(packet);
                                    packet = null;
                                    break;
                                }
                            }
                            catch (AVError)
                            {
                            }
                        }
                        else
                        {
                            if (_audioInput.Reader.IsCompleted)
                            {
                                _codecContext.Send(AVPacket.Null);
                                break;
                            }
                        }
                    }

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var frame = _audioOutput.Writer.Get();
                        var retval = _codecContext.Receive(frame);
                        if (retval == AVERROR_EOF)
                        {
                            _codecContext.FlushBuffers();
                            _audioOutput.Writer.Complete();
                            return;
                        }

                        if (retval == AVERROR(EAGAIN))
                        {
                            break;
                        }

                        if (retval == 0)
                        {
                            if (frame.ChannelLayout == 0)
                            {
                                if (_codecContext.ChannelLayout != 0)
                                {
                                    frame.ChannelLayout = _codecContext.ChannelLayout;
                                }
                                else
                                {
                                    frame.ChannelLayout = AVUtil.GetDefaultChannelLayout(frame.ChannelCount);
                                }
                            }

                            _audioOutput.Writer.Write(frame, cancellationToken);
                        }
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
