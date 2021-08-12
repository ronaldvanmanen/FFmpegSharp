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
    public enum AVDiscard
    {
        None = Interop.AVDiscard.AVDISCARD_NONE,
        Default = Interop.AVDiscard.AVDISCARD_DEFAULT,
        NonRef = Interop.AVDiscard.AVDISCARD_NONREF,
        BiDir = Interop.AVDiscard.AVDISCARD_BIDIR,
        NonIntra = Interop.AVDiscard.AVDISCARD_NONINTRA,
        NonKey = Interop.AVDiscard.AVDISCARD_NONKEY,
        All = Interop.AVDiscard.AVDISCARD_ALL,
    }
}
