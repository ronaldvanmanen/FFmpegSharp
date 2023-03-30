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

using static FFmpegSharp.Interop.AVFieldOrder;

namespace FFmpegSharp
{
    public enum AVFieldOrder
    {
        Unknown = AV_FIELD_UNKNOWN,
        Progressive = AV_FIELD_PROGRESSIVE,
        TopCodedFirstTopDisplayedFirst = AV_FIELD_TT,
        BottomCodedFirstBottomDisplayedFirst = AV_FIELD_BB,
        TopCodedFirstBottomDisplayedFirst = AV_FIELD_TB,
        BottomCodedFirstTopDisplayedFirst = AV_FIELD_BT,
    }
}
