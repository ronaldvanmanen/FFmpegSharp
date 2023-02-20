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
    public enum AVSideDataParamChangeFlags
    {
        AV_SIDE_DATA_PARAM_CHANGE_CHANNEL_COUNT = 0x0001,
        AV_SIDE_DATA_PARAM_CHANGE_CHANNEL_LAYOUT = 0x0002,
        AV_SIDE_DATA_PARAM_CHANGE_SAMPLE_RATE = 0x0004,
        AV_SIDE_DATA_PARAM_CHANGE_DIMENSIONS = 0x0008,
    }
}
