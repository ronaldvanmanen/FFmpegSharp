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

using Microsoft.Extensions.Logging;

namespace FFplaySharp
{
    internal sealed class CommandLineOptions
    {
        public string Input { get; set; }

        public LogLevel LogLevel { get; set; }

        public bool GenerateReport { get; set; }

        public long MaxAlloc { get; set; }

        public int CpuFlags { get; set; }

        public bool HideBanner { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string FrameSize { get; set; }

        public bool FullScreen { get; set; }

        public bool NoDisplay { get; set; }

        public bool NoBorder { get; set; }

        public bool AlwaysOnTop { get; set; }

        public int Volume { get; set; }

        public string Format { get; set; }

        public string PixelFormat { get; set; }

        public bool Status { get; set; }

        public bool Fast { get; set; }

        public bool GeneratePts { get; set; }

        public int ReorderPts { get; set; }

        public int LowRes { get; set; }

        public SyncType Sync { get; set; }

        public bool AutoExit { get; set; }

        public bool ExitOnKeyDown { get; set; }

        public bool ExitOnMouseDown { get; set; }

        public int Loop { get; set; }

        public bool DropFrames { get; set; }

        public bool InfiniteBuffer { get; set; }

        public string WindowTitle { get; set; }

        public int Left { get; set; }

        public int Top { get; set; }

        public int RdftSpeed { get; set; }

        public ShowMode ShowMode { get; set; }

        public string Codec { get; set; }

        public string AudioCodec { get; set; }

        public string SubtitleCodec { get; set; }

        public string VideoCodec { get; set; }

        public bool AutoRotate { get; set; }

        public bool FindStreamInfo { get; set; }

        public int FilterThreads { get; set; }

        public bool DisableAudio { get; set; }

        public bool DisableVideo { get; set; }

        public bool DisableSubtitling { get; set; }

        public string AudioStream { get; set; }

        public string VideoStream { get; set; }

        public string SubtitleStream { get; set; }

        public int Seek { get; set; }

        public int Duration { get; set; }

        public int Bytes { get; set; }

        public float SeekInterval { get; set; }

        public CommandLineOptions(string input,
                             LogLevel logLevel,
                             bool generateReport,
                             long maxAlloc,
                             int cpuFlags,
                             bool hideBanner,
                             int width,
                             int height,
                             string frameSize,
                             bool fullScreen,
                             bool disableAudio,
                             bool disableVideo,
                             bool disableSubtitling,
                             string audioStream,
                             string videoStream,
                             string subtitleStream,
                             int seek,
                             int duration,
                             int bytes,
                             float seekInterval,
                             bool noDisplay,
                             bool noBorder,
                             bool alwaysOnTop,
                             int volume,
                             string format,
                             string pixelFormat,
                             bool status,
                             bool fast,
                             bool generatePts,
                             int reorderPts,
                             int lowRes,
                             SyncType sync,
                             bool autoExit,
                             bool exitOnKeyDown,
                             bool exitOnMouseDown,
                             int loop,
                             bool dropFrames,
                             bool infiniteBuffer,
                             string windowTitle,
                             int left,
                             int top,
                             int rdftSpeed,
                             ShowMode showMode,
                             string codec,
                             string audioCodec,
                             string subtitleCodec,
                             string videoCodec,
                             bool autoRotate,
                             bool findStreamInfo,
                             int filterThreads)
        {
            Input = input;
            LogLevel = logLevel;
            GenerateReport = generateReport;
            MaxAlloc = maxAlloc;
            CpuFlags = cpuFlags;
            HideBanner = hideBanner;
            Width = width;
            Height = height;
            FrameSize = frameSize;
            FullScreen = fullScreen;
            NoDisplay = noDisplay;
            NoBorder = noBorder;
            AlwaysOnTop = alwaysOnTop;
            Volume = volume;
            Format = format;
            PixelFormat = pixelFormat;
            Status = status;
            Fast = fast;
            GeneratePts = generatePts;
            ReorderPts = reorderPts;
            LowRes = lowRes;
            Sync = sync;
            AutoExit = autoExit;
            ExitOnKeyDown = exitOnKeyDown;
            ExitOnMouseDown = exitOnMouseDown;
            Loop = loop;
            DropFrames = dropFrames;
            InfiniteBuffer = infiniteBuffer;
            WindowTitle = windowTitle;
            Left = left;
            Top = top;
            RdftSpeed = rdftSpeed;
            ShowMode = showMode;
            Codec = codec;
            AudioCodec = audioCodec;
            SubtitleCodec = subtitleCodec;
            VideoCodec = videoCodec;
            AutoRotate = autoRotate;
            FindStreamInfo = findStreamInfo;
            FilterThreads = filterThreads;
            DisableAudio = disableAudio;
            DisableVideo = disableVideo;
            DisableSubtitling = disableSubtitling;
            AudioStream = audioStream;
            VideoStream = videoStream;
            SubtitleStream = subtitleStream;
            Seek = seek;
            Duration = duration;
            Bytes = bytes;
            SeekInterval = seekInterval;
        }
    }
}
