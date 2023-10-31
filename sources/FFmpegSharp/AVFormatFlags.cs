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
    public enum AVFormatFlags
    {
        None = 0,
        GeneratePresentationTimeStamps = AVFMT_FLAG_GENPTS,
        IgnoreIndex = AVFMT_FLAG_IGNIDX,
        DontBlockPackets = AVFMT_FLAG_NONBLOCK,
        IgnoreDecodingTimeStamps = AVFMT_FLAG_IGNDTS,
        DontFillFrames = AVFMT_FLAG_NOFILLIN,
        DontParseFrames = AVFMT_FLAG_NOPARSE,
        DontBufferFrames = AVFMT_FLAG_NOBUFFER,
        CustomIO = AVFMT_FLAG_CUSTOM_IO,
        DiscardCorruptFrames = AVFMT_FLAG_DISCARD_CORRUPT,
        FlushPackets = AVFMT_FLAG_FLUSH_PACKETS,
        BitExact = AVFMT_FLAG_BITEXACT,
        Mp4aLatm = AVFMT_FLAG_MP4A_LATM,
        SortDecodingTimeStamps = AVFMT_FLAG_SORT_DTS,
        PrivateOptions = AVFMT_FLAG_PRIV_OPT,
        KeepSideData = AVFMT_FLAG_KEEP_SIDE_DATA,
        FastInaccurateSeek = AVFMT_FLAG_FAST_SEEK,
        StopMuxingWhenShortestStreamStops = AVFMT_FLAG_SHORTEST,
        AutoBitStreamFilters = AVFMT_FLAG_AUTO_BSF
    }
}
