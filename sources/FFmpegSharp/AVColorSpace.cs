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

using static FFmpegSharp.Interop.AVColorSpace;

namespace FFmpegSharp
{
    public enum AVColorSpace
    {
        RGB = AVCOL_SPC_RGB,
        BT709 = AVCOL_SPC_BT709,
        Unspecified = AVCOL_SPC_UNSPECIFIED,
        Reserved = AVCOL_SPC_RESERVED,
        FCC = AVCOL_SPC_FCC,
        BT470BG = AVCOL_SPC_BT470BG,
        SMPTE170M = AVCOL_SPC_SMPTE170M,
        SMPTE240M = AVCOL_SPC_SMPTE240M,
        YCGCO = AVCOL_SPC_YCGCO,
        YCOCG = AVCOL_SPC_YCOCG,
        BT2020NCL = AVCOL_SPC_BT2020_NCL,
        BT2020CL = AVCOL_SPC_BT2020_CL,
        SMPTE2085 = AVCOL_SPC_SMPTE2085,
        ChromaDerivedNCL = AVCOL_SPC_CHROMA_DERIVED_NCL,
        ChromaDerivedCL = AVCOL_SPC_CHROMA_DERIVED_CL,
        ICTCP = AVCOL_SPC_ICTCP,
    }
}
