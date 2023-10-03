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

namespace FFmpegSharp.Extensions.Framework
{
    public sealed partial class AudioDecoder : IDisposable
    {
        private readonly PacketizedElementaryStream _inputStream;

        private readonly ElementaryAudioStream _outputStream;

        private readonly AVCodec _codec;

        private readonly AVCodecContext _codecContext;

        private CancellationTokenSource _cancellationTokenSource;

        private Thread _thread;

        private bool _disposed;

        public PacketizedElementaryStream InputStream => _inputStream;

        public ElementaryAudioStream OutputStream => _outputStream;

        public AudioDecoder(PacketizedElementaryStream inputStream)
        : this(inputStream, new Options())
        { }

        public AudioDecoder(PacketizedElementaryStream inputStream, Options options)
        {
            _inputStream = inputStream ?? throw new ArgumentNullException(nameof(inputStream));

            _codec = AVCodec.FindDecoder(inputStream.CodecInfo.CodecID) ?? throw new InvalidOperationException();
            _codecContext = new AVCodecContext(inputStream.CodecInfo.ToCodecParameters());
            _codecContext.PacketTimeBase = inputStream.TimeBase;
            _codecContext.Flags2 |= options.Fast ? AVCodecFlags2.Fast : AVCodecFlags2.None;
            _codecContext.Open(_codec, new AVDictionary
            {
                    { "threads", "auto" }
            });

            _outputStream = new ElementaryAudioStream(_codecContext, 256);

            _cancellationTokenSource = null!;
            _thread = null!;
            _disposed = false;
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null!;
            _thread = null!;
            _disposed = true;
        }

        public void Start()
        {
            ThrowIfDisposed();

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
            ThrowIfDisposed();

            if (_cancellationTokenSource is null)
            {
                return;
            }

            try
            {
                _cancellationTokenSource.Cancel();
                _thread.Join();
                _cancellationTokenSource.Dispose();
            }
            finally
            {
                _thread = null!;
                _cancellationTokenSource = null!;
            }
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
                        using var packet = _inputStream.Read(cancellationToken);

                        if (_codecContext.TrySend(packet, out var error))
                        {
                            break;
                        }
                        else
                        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                            if (error.ErrorCode == AVERROR_EOF)
                            {
                                return;
                            }

                            if (error.ErrorCode == AVERROR_EAGAIN)
                            {
                                break;
                            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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

                            _outputStream.Write(frame, cancellationToken);
                        }
                        else
                        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                            if (error.ErrorCode == AVERROR_EOF)
                            {
                                _codecContext.FlushBuffers();
                                return;
                            }

                            if (error.ErrorCode == AVERROR_EAGAIN)
                            {
                                break;
                            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }
}
