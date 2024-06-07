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

using static FFmpegSharp.Interop.AVColorPrimaries;

namespace FFmpegSharp
{
    public enum AVColorPrimaries
    {
        Reserved0 = AVCOL_PRI_RESERVED0,
        BT709 = AVCOL_PRI_BT709,
        Unspecified = AVCOL_PRI_UNSPECIFIED,
        Reserved = AVCOL_PRI_RESERVED,
        BT470M = AVCOL_PRI_BT470M,
        BT470BG = AVCOL_PRI_BT470BG,
        SMPTE170M = AVCOL_PRI_SMPTE170M,
        SMPTE240M = AVCOL_PRI_SMPTE240M,
        Film = AVCOL_PRI_FILM,
        BT2020 = AVCOL_PRI_BT2020,
        SMPTE428 = AVCOL_PRI_SMPTE428,
        SMPTE428_1 = AVCOL_PRI_SMPTEST428_1,
        SMPTE431 = AVCOL_PRI_SMPTE431,
        SMPTE432 = AVCOL_PRI_SMPTE432,
        EBU3213 = AVCOL_PRI_EBU3213,
        JEDECP22 = AVCOL_PRI_JEDEC_P22
    }
}
