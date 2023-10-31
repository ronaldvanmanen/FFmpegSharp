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
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed partial class MediaDemultiplexer : IDisposable
    {
        private readonly AVFormatContext _formatContext;

        private readonly List<PacketizedElementaryStream> _outputs;

        private CancellationTokenSource _cancellationTokenSource;

        private Thread _thread;

        private bool _disposed;

        public AVRelativeTime StartTime => _formatContext.StartTime;

        public AVRelativeTime EndTime => _formatContext.EndTime;

        public PacketizedElementaryStream? BestAudioOutput
        {
            get
            {
                var index = _formatContext.FindBestStream(AVMediaType.Audio);
                if (index >= 0)
                {
                    return _outputs[index];
                }
                return _outputs.FirstOrDefault(e => e.CodecInfo.CodecType == AVMediaType.Audio);
            }
        }
        public IReadOnlyList<PacketizedElementaryStream> OutputStreams => _outputs;

        public MediaDemultiplexer(string uri)
        : this(uri, null)
        { }

        public MediaDemultiplexer(string uri, Options? options)
        {
            _formatContext = CreateFormatContext(uri, options);
            _outputs = CreateOutputs(_formatContext);
            _cancellationTokenSource = null!;
            _thread = null!;
            _disposed = false;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                try
                {
                    _formatContext?.Dispose();
                    _outputs.Clear();
                    _outputs.Clear();
                    _cancellationTokenSource?.Dispose();
                }
                finally
                {
                    _disposed = true;
                }
            }
        }

        public void Start()
        {
            ThrowIfDisposed();

            if (_cancellationTokenSource is not null)
            {
                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();
            _thread = new Thread(Demultiplex);
            _thread.Name = "Media Demultiplexer Thread";
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

        private void Demultiplex(object? userState)
        {
            var cancellationToken = (CancellationToken)userState!;
            var packet = new AVPacket();
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var packetRead = _formatContext.Read(ref packet);
                        if (packetRead)
                        {
                            var output = _outputs[packet.StreamIndex];
                            if (output is not null)
                            {
                                var outputPacket = new AVPacket();
                                packet.MoveRef(ref outputPacket);
                                output.Write(outputPacket, cancellationToken);
                            }
                        }
                        else
                        {
                            foreach (var output in _outputs)
                            {
                                output.Write(AVPacket.Null, cancellationToken);
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        return;
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
            finally
            {
                packet.Dispose();
            }
        }

        private static AVFormatContext CreateFormatContext(string uri, Options? options)
        {
            var formatContext = new AVFormatContext(uri, CreateFormatContextOptions(options));

            if (options is not null)
            {
                if (options.InjectGlobalSideData)
                {
                    formatContext.InjectGlobalSideData();
                }

                if (options.FindStreamInfo)
                {
                    formatContext.FindStreamInfo();
                }
            }

            return formatContext;
        }

        private static AVFormatContext.Options? CreateFormatContextOptions(Options? options)
        {
            if (options is null)
            {
                return null;
            }

            var result = new AVFormatContext.Options
            {
                MaxAnalyzeDuration = options.MaxAnalyzeDuration,
                ProbeSize = options.ProbeSize
            };

            if (options.GeneratePts)
            {
                result.Flags |= AVFormatFlags.GeneratePresentationTimeStamps;
            }
            else
            {
                result.Flags &= ~AVFormatFlags.GeneratePresentationTimeStamps;
            }

            return result;
        }

        private static List<PacketizedElementaryStream> CreateOutputs(AVFormatContext formatContext)
        {
            var outputs = new List<PacketizedElementaryStream>();
            foreach (var streamInfo in formatContext.Streams)
            {
                outputs.Add(CreateOutput(streamInfo));
            }
            return outputs;
        }

        private static PacketizedElementaryStream CreateOutput(AVStream streamInfo)
        {
            return new PacketizedElementaryStream(streamInfo, 256);
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
