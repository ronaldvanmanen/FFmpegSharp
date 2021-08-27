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
    [NativeTypeName("int")]
    public enum AVAppToDevMessageType : uint
    {
        AV_APP_TO_DEV_NONE = (((byte)('E')) | (((byte)('N')) << 8) | (((byte)('O')) << 16) | ((uint)('N') << 24)),
        AV_APP_TO_DEV_WINDOW_SIZE = (((byte)('M')) | (((byte)('O')) << 8) | (((byte)('E')) << 16) | ((uint)('G') << 24)),
        AV_APP_TO_DEV_WINDOW_REPAINT = (((byte)('A')) | (((byte)('P')) << 8) | (((byte)('E')) << 16) | ((uint)('R') << 24)),
        AV_APP_TO_DEV_PAUSE = (((byte)(' ')) | (((byte)('U')) << 8) | (((byte)('A')) << 16) | ((uint)('P') << 24)),
        AV_APP_TO_DEV_PLAY = (((byte)('Y')) | (((byte)('A')) << 8) | (((byte)('L')) << 16) | ((uint)('P') << 24)),
        AV_APP_TO_DEV_TOGGLE_PAUSE = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('A')) << 16) | ((uint)('P') << 24)),
        AV_APP_TO_DEV_SET_VOLUME = (((byte)('L')) | (((byte)('O')) << 8) | (((byte)('V')) << 16) | ((uint)('S') << 24)),
        AV_APP_TO_DEV_MUTE = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('M')) << 16) | ((uint)(' ') << 24)),
        AV_APP_TO_DEV_UNMUTE = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('M')) << 16) | ((uint)('U') << 24)),
        AV_APP_TO_DEV_TOGGLE_MUTE = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('M')) << 16) | ((uint)('T') << 24)),
        AV_APP_TO_DEV_GET_VOLUME = (((byte)('L')) | (((byte)('O')) << 8) | (((byte)('V')) << 16) | ((uint)('G') << 24)),
        AV_APP_TO_DEV_GET_MUTE = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('M')) << 16) | ((uint)('G') << 24)),
    }
}
