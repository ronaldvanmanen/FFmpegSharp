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

namespace FFmpegSharp.Interop
{
    public enum AVColorSpace
    {
        AVCOL_SPC_RGB = 0,
        AVCOL_SPC_BT709 = 1,
        AVCOL_SPC_UNSPECIFIED = 2,
        AVCOL_SPC_RESERVED = 3,
        AVCOL_SPC_FCC = 4,
        AVCOL_SPC_BT470BG = 5,
        AVCOL_SPC_SMPTE170M = 6,
        AVCOL_SPC_SMPTE240M = 7,
        AVCOL_SPC_YCGCO = 8,
        AVCOL_SPC_YCOCG = AVCOL_SPC_YCGCO,
        AVCOL_SPC_BT2020_NCL = 9,
        AVCOL_SPC_BT2020_CL = 10,
        AVCOL_SPC_SMPTE2085 = 11,
        AVCOL_SPC_CHROMA_DERIVED_NCL = 12,
        AVCOL_SPC_CHROMA_DERIVED_CL = 13,
        AVCOL_SPC_ICTCP = 14,
        AVCOL_SPC_NB,
    }
}
