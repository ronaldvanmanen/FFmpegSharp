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

using System;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    [Flags]
    public enum SwsFlags
    {
        None = 0,
        FastBilinear = SWS_FAST_BILINEAR,
        Bilinear = SWS_BILINEAR,
        Bicubic = SWS_BICUBIC,
        X = SWS_X,
        Point = SWS_POINT,
        Area = SWS_AREA,
        Bicubiclin = SWS_BICUBLIN,
        Gauss = SWS_GAUSS,
        Sinc = SWS_SINC,
        Lanczos = SWS_LANCZOS,
        Spline = SWS_SPLINE,
    }
}
