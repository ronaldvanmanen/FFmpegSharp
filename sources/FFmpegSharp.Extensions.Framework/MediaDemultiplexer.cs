﻿// This file is part of FFmpegSharp.
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
using System.Collections.Generic;
using System.Threading;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed partial class MediaDemultiplexer : IDisposable
    {
        private readonly AVFormatContext _formatContext;

        private readonly List<PacketizedElementaryStream> _streams;

        private CancellationTokenSource _cancellationTokenSource;

        private Thread _thread;

        public PacketizedElementaryStream? BestAudioStream
        {
            get
            {
                var streamIndex = _formatContext.FindBestStream(AVMediaType.Audio);
                if (streamIndex >= 0)
                {
                    return _streams[streamIndex];
                }
                return null;
            }
        }

        public MediaDemultiplexer(string uri)
        : this(uri, null)
        { }

        public MediaDemultiplexer(string uri, Options? options)
        {
            _formatContext = CreateFormatContext(uri, options);
            _streams = CreateStreams(_formatContext);
            _cancellationTokenSource = null!;
            _thread = null!;
        }

        public void Dispose()
        {
            _formatContext?.Dispose();
        }

        public void Start()
        {
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
            if (_cancellationTokenSource is null)
            {
                return;
            }

            _cancellationTokenSource.Cancel();
            _thread.Join();
            _thread = null!;
            _cancellationTokenSource = null!;
        }

        private void Demultiplex(object? userState)
        {
            var cancellationToken = (CancellationToken)userState!;
            var packet = new AVPacket();
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var success = _formatContext.Read(ref packet);
                    if (success)
                    {
                        var stream = _streams[packet.StreamIndex];
                        var streamPacket = stream.PeekWritable(cancellationToken);
                        packet.MoveRef(ref streamPacket);
                        stream.PushWritable(cancellationToken);
                    }
                    else
                    {
                        foreach (var stream in _streams)
                        {
                            var streamPacket = stream.PeekWritable(cancellationToken);
                            streamPacket.Ref(AVPacket.Null);
                            stream.PushWritable(cancellationToken);
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

        private static List<PacketizedElementaryStream> CreateStreams(AVFormatContext formatContext)
        {
            var streams = new List<PacketizedElementaryStream>();
            foreach (var streamInfo in formatContext.Streams)
            {
                streamInfo.Discard = AVDiscard.All;
                var stream = CreateStream(streamInfo);
                streams.Add(stream);
            }
            return streams;
        }

        private static PacketizedElementaryStream CreateStream(AVStream streamInfo)
        {
            return new PacketizedElementaryStream(streamInfo, 256);
        }
    }
}
