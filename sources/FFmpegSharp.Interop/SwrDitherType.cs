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
    public enum SwrDitherType
    {
        SWR_DITHER_NONE = 0,
        SWR_DITHER_RECTANGULAR,
        SWR_DITHER_TRIANGULAR,
        SWR_DITHER_TRIANGULAR_HIGHPASS,
        SWR_DITHER_NS = 64,
        SWR_DITHER_NS_LIPSHITZ,
        SWR_DITHER_NS_F_WEIGHTED,
        SWR_DITHER_NS_MODIFIED_E_WEIGHTED,
        SWR_DITHER_NS_IMPROVED_E_WEIGHTED,
        SWR_DITHER_NS_SHIBATA,
        SWR_DITHER_NS_LOW_SHIBATA,
        SWR_DITHER_NS_HIGH_SHIBATA,
        SWR_DITHER_NB,
    }
}
