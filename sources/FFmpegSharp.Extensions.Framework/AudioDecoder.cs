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
    public sealed partial class AudioDecoder
    {
        private readonly PacketizedElementaryStream _audioInput;

        private readonly AudioElementaryStream _audioOutput;

        private readonly AVCodec _codec;

        private readonly AVCodecContext _codecContext;

        private CancellationTokenSource _cancellationTokenSource;

        private Thread _thread;

        public AudioElementaryStream AudioOutput => _audioOutput;

        public AudioDecoder(PacketizedElementaryStream audioInput)
        : this(audioInput, null)
        { }

        public AudioDecoder(PacketizedElementaryStream audioInput, Options? options)
        {
            _audioInput = audioInput ?? throw new ArgumentNullException(nameof(audioInput));

            _codec = AVCodec.FindDecoder(_audioInput.CodecID) ?? throw new InvalidOperationException();
            _codecContext = new AVCodecContext(_audioInput.CodecParameters);
            _codecContext.PacketTimeBase = _audioInput.TimeBase;
            _codecContext.Flags2 |= options is not null && options.Fast ? AVCodecFlags2.Fast : AVCodecFlags2.None;
            _codecContext.Open(_codec, new AVDictionary
            {
                { "threads", "auto" }
            });

            _audioOutput = new AudioElementaryStream(16)
            {
                TimeBase = _audioInput.TimeBase,
                ChannelCount = _codecContext.ChannelCount,
                ChannelLayout = _codecContext.ChannelLayout != 0 ? _codecContext.ChannelLayout : AVUtil.GetDefaultChannelLayout(_codecContext.ChannelCount),
                SampleRate = _codecContext.SampleRate,
                SampleFormat = _codecContext.SampleFormat
            };

            _thread = null!;
            _cancellationTokenSource = null!;
        }

        public void Start()
        {
            if (_cancellationTokenSource is not null)
            {
                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();
            _thread = new Thread(Decode);
            _thread.Name = "Audio Decoder Thread";
            _thread.Start(_cancellationTokenSource.Token);
        }

        public void Stop()
        {
            if (_cancellationTokenSource is null)
            {
                return;
            }

            _cancellationTokenSource.Cancel();
            _thread.Join();
            _thread = null!;
            _cancellationTokenSource = null!;
        }

        private void Decode(object? userState)
        {
            var cancellationToken = (CancellationToken)userState!;

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var packet = _audioInput.PeekReadable(cancellationToken);

                        if (_codecContext.TrySend(packet, out var error))
                        {
                            packet.Unref();
                            _audioInput.PushReadable();
                            break;
                        }
                        else
                        {
                            if (error.ErrorCode == AVERROR_EOF)
                            {
                                return;
                            }

                            if (error.ErrorCode == AVERROR_EAGAIN)
                            {
                                break;
                            }
                        }
                    };

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var frame = _audioOutput.PeekWritable(cancellationToken);

                        if (_codecContext.TryReceive(ref frame, out var error))
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

                            _audioOutput.PushWritable(cancellationToken);
                        }
                        else
                        {
                            if (error.ErrorCode == AVERROR_EOF)
                            {
                                _codecContext.FlushBuffers();
                                return;
                            }

                            if (error.ErrorCode == AVERROR_EAGAIN)
                            {
                                break;
                            }
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
