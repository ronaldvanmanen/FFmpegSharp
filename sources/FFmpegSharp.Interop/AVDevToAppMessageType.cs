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
    public enum AVDevToAppMessageType : uint
    {
        AV_DEV_TO_APP_NONE = (((byte)('E')) | (((byte)('N')) << 8) | (((byte)('O')) << 16) | ((uint)('N') << 24)),
        AV_DEV_TO_APP_CREATE_WINDOW_BUFFER = (((byte)('E')) | (((byte)('R')) << 8) | (((byte)('C')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_PREPARE_WINDOW_BUFFER = (((byte)('E')) | (((byte)('R')) << 8) | (((byte)('P')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_DISPLAY_WINDOW_BUFFER = (((byte)('S')) | (((byte)('I')) << 8) | (((byte)('D')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_DESTROY_WINDOW_BUFFER = (((byte)('S')) | (((byte)('E')) << 8) | (((byte)('D')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_BUFFER_OVERFLOW = (((byte)('L')) | (((byte)('F')) << 8) | (((byte)('O')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_BUFFER_UNDERFLOW = (((byte)('L')) | (((byte)('F')) << 8) | (((byte)('U')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_BUFFER_READABLE = (((byte)(' ')) | (((byte)('D')) << 8) | (((byte)('R')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_BUFFER_WRITABLE = (((byte)(' ')) | (((byte)('R')) << 8) | (((byte)('W')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_MUTE_STATE_CHANGED = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('M')) << 16) | ((uint)('C') << 24)),
        AV_DEV_TO_APP_VOLUME_LEVEL_CHANGED = (((byte)('L')) | (((byte)('O')) << 8) | (((byte)('V')) << 16) | ((uint)('C') << 24)),
    }
}
