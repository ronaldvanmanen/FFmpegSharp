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
    public enum AVCodecFlags : uint
    {
        Unaligned = AV_CODEC_FLAG_UNALIGNED,
        QScale = AV_CODEC_FLAG_QSCALE,
        FourMV = AV_CODEC_FLAG_4MV,
        OutputCorrupt = AV_CODEC_FLAG_OUTPUT_CORRUPT,
        QPel = AV_CODEC_FLAG_QPEL,
        DropChanged = AV_CODEC_FLAG_DROPCHANGED,
        Pass1 = AV_CODEC_FLAG_PASS1,
        Pass2 = AV_CODEC_FLAG_PASS2,
        LoopFilter = AV_CODEC_FLAG_LOOP_FILTER,
        Gray = AV_CODEC_FLAG_GRAY,
        Psnr = AV_CODEC_FLAG_PSNR,
        Truncated = AV_CODEC_FLAG_TRUNCATED,
        InterlacedDct = AV_CODEC_FLAG_INTERLACED_DCT,
        LowDelay = AV_CODEC_FLAG_LOW_DELAY,
        GlobalHeader = AV_CODEC_FLAG_GLOBAL_HEADER,
        BitExact = AV_CODEC_FLAG_BITEXACT,
        AcPred = AV_CODEC_FLAG_AC_PRED,
        InterlacedMe = AV_CODEC_FLAG_INTERLACED_ME,
        ClosedGop = AV_CODEC_FLAG_CLOSED_GOP,
    }
}
