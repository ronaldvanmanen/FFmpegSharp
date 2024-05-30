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
    public enum AVPixelFormatFlags
    {
        BigEndian = AV_PIX_FMT_FLAG_BE,
        Pal = AV_PIX_FMT_FLAG_PAL,
        Bitstream = AV_PIX_FMT_FLAG_BITSTREAM,
        HardwareAcceleration = AV_PIX_FMT_FLAG_HWACCEL,
        Planar = AV_PIX_FMT_FLAG_PLANAR,
        Rgb = AV_PIX_FMT_FLAG_RGB,
        PseudoPal = AV_PIX_FMT_FLAG_PSEUDOPAL,
        Alpha = AV_PIX_FMT_FLAG_ALPHA,
        Bayer = AV_PIX_FMT_FLAG_BAYER,
        Float = AV_PIX_FMT_FLAG_FLOAT
    }
}
