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
using FFmpegSharp.Extensions.Collections;
using FFmpegSharp.Extensions.ComponentModel;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class MediaDemultiplexer : ObservableObject
    {
        private readonly string _uri;

        private readonly Thread _thread;

        private readonly ObservableList<Channel<AVPacket>> _videoOutputs;

        private Channel<AVPacket> _bestVideoOutput;

        private readonly ObservableList<Channel<AVPacket>> _audioOutputs;

        private Channel<AVPacket> _bestAudioOutput;

        private readonly ObservableList<Channel<AVPacket>> _subtitleOutputs;

        private Channel<AVPacket> _bestSubtitleOutput;

        private bool _running;

        public bool DisableVideo { get; set; }

        public bool DisableAudio { get; set; }

        public bool DisableSubtitling { get; set; }

        public long ProbeSize { get; set; }

        public long MaxAnalyzeDuration { get; set; }

        public bool FindStreamInfo { get; set; }

        public bool GeneratePts { get; set; }

        public bool InjectGlobalSideData { get; set; }

        public IObservableReadOnlyList<Channel<AVPacket>> VideoOutputs => _videoOutputs;

        public IObservableReadOnlyList<Channel<AVPacket>> AudioOutputs => _audioOutputs;

        public IObservableReadOnlyList<Channel<AVPacket>> SubtitleOutputs => _subtitleOutputs;

        public Channel<AVPacket> BestVideoOutput => _bestVideoOutput;

        public Channel<AVPacket> BestAudioOutput => _bestAudioOutput;

        public Channel<AVPacket> BestSubtitleOutput => _bestSubtitleOutput;

        public MediaDemultiplexer(string uri)
        {
            _uri = uri ?? throw new ArgumentNullException(nameof(uri));
            _videoOutputs = new ObservableList<Channel<AVPacket>>();
            _audioOutputs = new ObservableList<Channel<AVPacket>>();
            _subtitleOutputs = new ObservableList<Channel<AVPacket>>();
            _bestVideoOutput = null!;
            _bestAudioOutput = null!;
            _bestSubtitleOutput = null!;
            _thread = new Thread(Demultiplex);
            _thread.Name = "Media Demultiplexer Thread";
            _running = false;
        }

        public void Start()
        {
            _running = true;
            _thread.Start();
        }

        public void Stop()
        {
            _running = false;
            _thread.Join();
        }

        private void Demultiplex()
        {
            var options = new AVFormatContextOptions();

            if (GeneratePts)
            {
                options.Flags |= AVFormatFlags.GeneratePresentationTimeStamps;
            }

            using (var formatContext = new AVFormatContext(_uri, options))
            {
                if (InjectGlobalSideData)
                {
                    formatContext.InjectGlobalSideData();
                }

                if (FindStreamInfo)
                {
                    formatContext.FindStreamInfo();
                }

                var outputs = new Dictionary<int, Channel<AVPacket>>();
                foreach (var stream in formatContext.Streams)
                {
                    switch (stream.CodecParameters.CodecType)
                    {
                        case AVMediaType.Video:
                        {
                            if (DisableVideo)
                            {
                                stream.Discard = AVDiscard.All;
                            }
                            else
                            {
                                stream.Discard = AVDiscard.Default;
                                var videoOutput = new Channel<AVPacket>(8192);
                                videoOutput.MetaData.CodecID = stream.CodecParameters.CodecID;
                                videoOutput.MetaData.CodecParameters = stream.CodecParameters;
                                videoOutput.MetaData.TimeBase = stream.TimeBase;
                                videoOutput.MetaData.FrameRate = formatContext.GuessFrameRate(stream);
                                outputs.Add(stream.Index, videoOutput);
                                _videoOutputs.Add(videoOutput);
                            }
                            break;
                        }

                        case AVMediaType.Audio:
                        {
                            if (DisableAudio)
                            {
                                stream.Discard = AVDiscard.All;
                            }
                            else
                            {
                                stream.Discard = AVDiscard.Default;
                                var audioOutput = new Channel<AVPacket>(8192);
                                audioOutput.MetaData.CodecID = stream.CodecParameters.CodecID;
                                audioOutput.MetaData.CodecParameters = stream.CodecParameters;
                                audioOutput.MetaData.TimeBase = stream.TimeBase;
                                outputs.Add(stream.Index, audioOutput);
                                _audioOutputs.Add(audioOutput);
                            }
                            break;
                        }

                        case AVMediaType.Subtitle:
                        {
                            if (DisableSubtitling)
                            {
                                stream.Discard = AVDiscard.All;
                            }
                            else
                            {
                                stream.Discard = AVDiscard.Default;
                                var subtitleOutput = new Channel<AVPacket>(8192);
                                subtitleOutput.MetaData.CodecID = stream.CodecParameters.CodecID;
                                subtitleOutput.MetaData.CodecParameters = stream.CodecParameters;
                                subtitleOutput.MetaData.TimeBase = stream.TimeBase;
                                outputs.Add(stream.Index, subtitleOutput);
                                _subtitleOutputs.Add(subtitleOutput);
                            }
                            break;
                        }

                        default:
                        {
                            stream.Discard = AVDiscard.All;
                            break;
                        }
                    }
                }

                if (!DisableVideo)
                {
                    var bestVideoStream = formatContext.FindBestStream(AVMediaType.Video);
                    if (bestVideoStream >= 0)
                    {
                        OnPropertyChanging(nameof(BestVideoOutput));
                        _bestVideoOutput = outputs[bestVideoStream];
                        OnPropertyChanged(nameof(BestVideoOutput));
                    }
                }

                if (!DisableAudio)
                {
                    var bestAudioStream = formatContext.FindBestStream(AVMediaType.Audio);
                    if (bestAudioStream >= 0)
                    {
                        OnPropertyChanging(nameof(BestAudioOutput));
                        _bestAudioOutput = outputs[bestAudioStream];
                        OnPropertyChanged(nameof(BestAudioOutput));
                    }
                }

                if (!DisableVideo && !DisableSubtitling)
                {
                    var bestSubtitleStream = formatContext.FindBestStream(AVMediaType.Subtitle);
                    if (bestSubtitleStream >= 0)
                    {
                        OnPropertyChanging(nameof(BestSubtitleOutput));
                        _bestSubtitleOutput = outputs[bestSubtitleStream];
                        OnPropertyChanged(nameof(BestSubtitleOutput));
                    }
                }

                var packet = new AVPacket();
                while (_running)
                {
                    var readResult = formatContext.Read(packet);
                    if (readResult == AVERROR_EOF)
                    {
                        foreach (var output in outputs.Values)
                        {
                            output.Writer.Complete();
                        }
                        break;
                    }
                    else
                    {
                        if (outputs.TryGetValue(packet.StreamIndex, out var output))
                        {
                            var outputPacket = output.Writer.Get();
                            packet.MoveRef(outputPacket);
                            output.Writer.Write(outputPacket);
                        }
                    }
                }
            }
        }
    }
}
