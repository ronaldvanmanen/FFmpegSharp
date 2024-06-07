// Copyright (C) 2021-2024 Ronald van Manen
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

namespace FFmpegSharp
{
    public enum AVSampleFormat
    {
        None = Interop.AVSampleFormat.AV_SAMPLE_FMT_NONE,
        Unsigned8 = Interop.AVSampleFormat.AV_SAMPLE_FMT_U8,
        Signed16 = Interop.AVSampleFormat.AV_SAMPLE_FMT_S16,
        Signed32 = Interop.AVSampleFormat.AV_SAMPLE_FMT_S32,
        Float32 = Interop.AVSampleFormat.AV_SAMPLE_FMT_FLT,
        Float64 = Interop.AVSampleFormat.AV_SAMPLE_FMT_DBL,
        Unsigned8Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_U8P,
        Signed16Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_S16P,
        Singed32Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_S32P,
        Float32Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_FLTP,
        Double32Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_DBLP,
        Signed64 = Interop.AVSampleFormat.AV_SAMPLE_FMT_S64,
        Signed64Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_S64P,
    }
}
