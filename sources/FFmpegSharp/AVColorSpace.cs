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

namespace FFmpegSharp
{
    public enum AVColorSpace
    {
        Rgb = Interop.AVColorSpace.AVCOL_SPC_RGB,
        Bt709 = Interop.AVColorSpace.AVCOL_SPC_BT709,
        Unspecified = Interop.AVColorSpace.AVCOL_SPC_UNSPECIFIED,
        Reserved = Interop.AVColorSpace.AVCOL_SPC_RESERVED,
        Fcc = Interop.AVColorSpace.AVCOL_SPC_FCC,
        Bt470Bg = Interop.AVColorSpace.AVCOL_SPC_BT470BG,
        Smpte170M = Interop.AVColorSpace.AVCOL_SPC_SMPTE170M,
        Smpte240M = Interop.AVColorSpace.AVCOL_SPC_SMPTE240M,
        Ycgco = Interop.AVColorSpace.AVCOL_SPC_YCGCO,
        Ycocg = Interop.AVColorSpace.AVCOL_SPC_YCOCG,
        Bt2020Ncl = Interop.AVColorSpace.AVCOL_SPC_BT2020_NCL,
        Bt2020Cl = Interop.AVColorSpace.AVCOL_SPC_BT2020_CL,
        Smpte2085 = Interop.AVColorSpace.AVCOL_SPC_SMPTE2085,
        ChromaDerivedNcl = Interop.AVColorSpace.AVCOL_SPC_CHROMA_DERIVED_NCL,
        ChromaDerivedCl = Interop.AVColorSpace.AVCOL_SPC_CHROMA_DERIVED_CL,
        Ictcp = Interop.AVColorSpace.AVCOL_SPC_ICTCP,
    }
}
