// Copyright (c) 2021-2023 Ronald van Manen
//
// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with FFmpegSharp; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA

using System;
using System.Threading;
using FFmpegSharp.Extensions.ObjectPool;
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

            _outputStream = new ElementaryAudioStream(_codecContext, 16);

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
            var framePool = new ObjectPool<AVFrame>(() => new AVFrame());
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        using var packet = _inputStream.Read(cancellationToken);

                        if (_codecContext.TrySend(packet.Instance, out var error))
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
                        var frame = PooledObject.Allocate(framePool);

                        if (_codecContext.TryReceive(ref frame.Instance, out var error))
                        {
                            if (frame.Instance.Pts != AVTimeStamp.Undefined)
                            {
                                // Adjust presentation timestamp using packet timebase and sample rate:
                                //
                                //   pts = pts * packet time base * sample rate)
                                //
                                // or
                                //
                                //   pts = pts * packet time base / (1 / sample rate)
                                var packetTimeBase = _codecContext.PacketTimeBase;
                                var sampleTimeBase = new AVTimeBase(1, frame.Instance.SampleRate);
                                frame.Instance.Pts = frame.Instance.Pts.Rescale(packetTimeBase, sampleTimeBase);
                            }

                            if (frame.Instance.ChannelLayout == 0)
                            {
                                if (_codecContext.ChannelLayout != 0)
                                {
                                    frame.Instance.ChannelLayout = _codecContext.ChannelLayout;
                                }
                                else
                                {
                                    frame.Instance.ChannelLayout = AVUtil.GetDefaultChannelLayout(frame.Instance.ChannelCount);
                                }
                            }

                            _outputStream.Write(frame, cancellationToken);
                        }
                        else
                        {
                            try
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
                            finally
                            {
                                frame.Dispose();
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

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }
}
