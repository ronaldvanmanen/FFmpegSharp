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
        AV_DEV_TO_APP_NONE = (unchecked(('E') | (('N') << 8) | (('O') << 16) | ((uint)('N') << 24))),
        AV_DEV_TO_APP_CREATE_WINDOW_BUFFER = (unchecked(('E') | (('R') << 8) | (('C') << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_PREPARE_WINDOW_BUFFER = (unchecked(('E') | (('R') << 8) | (('P') << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_DISPLAY_WINDOW_BUFFER = (unchecked(('S') | (('I') << 8) | (('D') << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_DESTROY_WINDOW_BUFFER = (unchecked(('S') | (('E') << 8) | (('D') << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_BUFFER_OVERFLOW = (unchecked(('L') | (('F') << 8) | (('O') << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_BUFFER_UNDERFLOW = (unchecked(('L') | (('F') << 8) | (('U') << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_BUFFER_READABLE = (unchecked((' ') | (('D') << 8) | (('R') << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_BUFFER_WRITABLE = (unchecked((' ') | (('R') << 8) | (('W') << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_MUTE_STATE_CHANGED = (unchecked(('T') | (('U') << 8) | (('M') << 16) | ((uint)('C') << 24))),
        AV_DEV_TO_APP_VOLUME_LEVEL_CHANGED = (unchecked(('L') | (('O') << 8) | (('V') << 16) | ((uint)('C') << 24))),
    }
}
