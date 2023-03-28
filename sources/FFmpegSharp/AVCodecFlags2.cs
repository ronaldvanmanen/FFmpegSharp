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
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    [Flags]
    public enum AVCodecFlags2
    {
        None = 0,
        Fast = AV_CODEC_FLAG2_FAST,
        NoOutput = AV_CODEC_FLAG2_NO_OUTPUT,
        LocalHeader = AV_CODEC_FLAG2_LOCAL_HEADER,
        DropFrameTimecode = AV_CODEC_FLAG2_DROP_FRAME_TIMECODE,
        Chunks = AV_CODEC_FLAG2_CHUNKS,
        IgnoreCrop = AV_CODEC_FLAG2_IGNORE_CROP,
        ShowAll = AV_CODEC_FLAG2_SHOW_ALL,
        ExportMvs = AV_CODEC_FLAG2_EXPORT_MVS,
        SkipManual = AV_CODEC_FLAG2_SKIP_MANUAL,
        RoFlushNoop = AV_CODEC_FLAG2_RO_FLUSH_NOOP
    }
}
