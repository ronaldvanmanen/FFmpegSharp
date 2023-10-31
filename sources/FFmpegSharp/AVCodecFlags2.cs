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
