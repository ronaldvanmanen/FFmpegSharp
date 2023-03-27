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
using System.Collections.Generic;
using System.Threading;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed partial class MediaDemultiplexer : IDisposable
    {
        public sealed class OutputPort
        {
            private readonly MediaDemultiplexer _owner;

            private readonly AVStream _streamInfo;

            public AVStream StreamInfo => _streamInfo;

            public OutputPort(MediaDemultiplexer owner, AVStream streamInfo)
            {
                _owner = owner ?? throw new ArgumentNullException(nameof(owner));
                _streamInfo = streamInfo ?? throw new ArgumentNullException(nameof(streamInfo));
            }

            public void Connect(MediaStream<AVPacket> stream)
            {
                _owner.OnOutputConnected(this, stream);
            }

            public void Disconnect()
            {
                _owner.OnOutputDisconnected(this);
            }
        }

        private readonly AVFormatContext _formatContext;

        private readonly List<OutputPort> _outputs;

        private readonly Dictionary<int, MediaStream<AVPacket>> _outputStreams;

        private CancellationTokenSource _cancellationTokenSource;

        private Thread _thread;

        public OutputPort? BestAudioOutput
        {
            get
            {
                var index = _formatContext.FindBestStream(AVMediaType.Audio);
                if (index >= 0)
                {
                    return _outputs[index];
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
            _outputs = CreateOutputs(this, _formatContext);
            _outputStreams = new Dictionary<int, MediaStream<AVPacket>>();
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
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var packetRead = _formatContext.Read(ref packet);
                        if (packetRead)
                        {
                            if (_outputStreams.TryGetValue(packet.StreamIndex, out var outputStream))
                            {
                                var outputPacket = new AVPacket();
                                packet.MoveRef(ref outputPacket);
                                outputStream.Write(outputPacket, cancellationToken);
                            }
                        }
                        else
                        {
                            foreach (var outputStream in _outputStreams.Values)
                            {
                                outputStream.Write(AVPacket.Null, cancellationToken);
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

        private static List<OutputPort> CreateOutputs(MediaDemultiplexer owner, AVFormatContext formatContext)
        {
            var outputs = new List<OutputPort>();
            foreach (var streamInfo in formatContext.Streams)
            {
                streamInfo.Discard = AVDiscard.All;
                var output = CreateOutput(owner, streamInfo);
                outputs.Add(output);
            }
            return outputs;
        }

        private static OutputPort CreateOutput(MediaDemultiplexer owner, AVStream streamInfo)
        {
            return new OutputPort(owner, streamInfo);
        }

        private void OnOutputConnected(OutputPort output, MediaStream<AVPacket> outputStream)
        {
            _outputStreams.Add(output.StreamInfo.Index, outputStream);
        }

        private void OnOutputDisconnected(OutputPort output)
        {
            _outputStreams.Remove(output.StreamInfo.Index);
        }
    }
}
