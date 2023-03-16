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
using FFmpegSharp.Interop;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed partial class AudioDecoder
    {
        public sealed class AudioInputPort
        {
            public AVTimeBase PacketTimeBase { get; set; }

            public AVCodecParameters? CodecParameters { get; set; }

            public PacketizedElementaryStream? Stream { get; set; }
        }

        public sealed class AudioOutputPort
        {
            public AudioElementaryStream? Stream { get; set; }

            public AVTimeBase TimeBase { get; internal set; }
            public int ChannelCount { get; internal set; }
            public AVChannelLayout ChannelLayout { get; internal set; }
            public int SampleRate { get; internal set; }
            public AVSampleFormat SampleFormat { get; internal set; }
        }

        private readonly AudioInputPort _audioInput;

        private readonly AudioOutputPort _audioOutput;

        private readonly Options _options;

        private AVCodecContext _codecContext;

        private CancellationTokenSource _cancellationTokenSource;

        private Thread _thread;

        public AudioInputPort AudioInput => _audioInput;

        public AudioOutputPort AudioOutput => _audioOutput;

        public AudioDecoder()
        : this(null)
        { }

        public AudioDecoder(Options? options)
        {
            _options = options ?? new Options();
            _audioInput = new AudioInputPort();
            _audioOutput = new AudioOutputPort();
            _codecContext = null!;
            _cancellationTokenSource = null!;
            _thread = null!;
        }

        public void Start()
        {
            if (_cancellationTokenSource is not null)
            {
                return;
            }

            var codec = AVCodec.FindDecoder(_audioInput.CodecParameters!.CodecID) ?? throw new InvalidOperationException();
            _codecContext = new AVCodecContext(_audioInput.CodecParameters);
            _codecContext.PacketTimeBase = _audioInput.PacketTimeBase;
            _codecContext.Flags2 |= _options.Fast ? AVCodecFlags2.Fast : AVCodecFlags2.None;
            _codecContext.Open(codec, new AVDictionary
            {
                { "threads", "auto" }
            });

            _audioOutput.TimeBase = _audioInput.PacketTimeBase;
            _audioOutput.ChannelCount = _codecContext.ChannelCount;
            _audioOutput.ChannelLayout = _codecContext.ChannelLayout != 0 ? _codecContext.ChannelLayout : AVUtil.GetDefaultChannelLayout(_codecContext.ChannelCount);
            _audioOutput.SampleRate = _codecContext.SampleRate;
            _audioOutput.SampleFormat = _codecContext.SampleFormat;

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
            var audioInputStream = _audioInput.Stream!;
            var audioOutputStream = _audioOutput.Stream!;
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var packet = audioInputStream.PeekReadable(cancellationToken);

                        if (_codecContext.TrySend(packet, out var error))
                        {
                            packet.Unref();
                            audioInputStream.PushReadable();
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
                        var frame = audioOutputStream.PeekWritable(cancellationToken);

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

                            audioOutputStream.PushWritable(cancellationToken);
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
