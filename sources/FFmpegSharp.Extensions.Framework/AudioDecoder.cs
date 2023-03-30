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
using FFmpegSharp;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed partial class AudioDecoder
    {
        public sealed class AudioInputPort
        {
            private readonly AudioDecoder _owner;

            public AudioInputPort(AudioDecoder owner)
            {
                _owner = owner ?? throw new ArgumentNullException(nameof(owner));
            }

            public void Connect(MediaStream<AVPacket> stream, IPacketizedElementaryStreamInfo streamInfo)
            {
                _owner.OnInputConnected(stream, streamInfo);
            }

            public void Disconnect()
            {
                _owner.OnInputDisconnected();
            }
        }

        public sealed class AudioOutputPort
        {
            private readonly AudioDecoder _owner;

            private ElementaryAudioStreamInfo _streamInfo;

            public IElementaryAudioStreamInfo StreamInfo => _streamInfo ??= new ElementaryAudioStreamInfo(_owner._codecContext);

            public AudioOutputPort(AudioDecoder owner)
            {
                _owner = owner ?? throw new ArgumentNullException(nameof(owner));
                _streamInfo = null!;
            }

            public void Connect(MediaStream<AVFrame> stream)
            {
                _owner.OnOutputConnected(stream);
            }

            public void Disconnect()
            {
                _owner.OnOutputDisconnected();
            }
        }

        private readonly AudioInputPort _audioInput;

        private MediaStream<AVPacket> _audioInputStream;

        private readonly AudioOutputPort _audioOutput;

        private MediaStream<AVFrame> _audioOutputStream;

        private readonly Options _options;

        private AVCodec _codec;

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
            _audioInput = new AudioInputPort(this);
            _audioInputStream = null!;
            _audioOutput = new AudioOutputPort(this);
            _audioOutputStream = null!;
            _codec = null!;
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
                        using var packet = _audioInputStream.Read(cancellationToken);

                        if (_codecContext.TrySend(packet, out var error))
                        {
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
                        var frame = new AVFrame();

                        if (_codecContext.TryReceive(ref frame, out var error))
                        {
                            if (frame.Pts != AVTimeStamp.Undefined)
                            {
                                // Adjust presentation timestamp using packet timebase and sample rate:
                                //
                                //   pts = pts * packet time base * sample rate)
                                //
                                // or
                                //
                                //   pts = pts * packet time base / (1 / sample rate)
                                var packetTimeBase = _codecContext.PacketTimeBase;
                                var sampleTimeBase = new AVTimeBase(1, frame.SampleRate);
                                frame.Pts = frame.Pts.Rescale(packetTimeBase, sampleTimeBase);
                            }

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

                            _audioOutputStream.Write(frame, cancellationToken);
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

        private void OnInputConnected(MediaStream<AVPacket> stream, IPacketizedElementaryStreamInfo streamInfo)
        {
            _codec = AVCodec.FindDecoder(streamInfo.CodecInfo.CodecID) ?? throw new InvalidOperationException();
            _codecContext = new AVCodecContext(streamInfo.CodecInfo.ToCodecParameters());
            _codecContext.PacketTimeBase = streamInfo.TimeBase;
            _codecContext.Flags2 |= _options.Fast ? AVCodecFlags2.Fast : AVCodecFlags2.None;
            _codecContext.Open(_codec, new AVDictionary
            {
                { "threads", "auto" }
            });
            _audioInputStream = stream;
        }

        private void OnInputDisconnected()
        {
            _codec = null!;
            _codecContext.Dispose();
            _codecContext = null!;
            _audioInputStream = null!;
        }

        private void OnOutputConnected(MediaStream<AVFrame> stream)
        {
            _audioOutputStream = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        private void OnOutputDisconnected()
        {
            _audioOutputStream = null!;
        }
    }
}
