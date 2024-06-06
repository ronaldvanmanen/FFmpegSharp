// Copyright (c) 2021-2023 Ronald van Manen
//
// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with FFmpegSharp; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA

namespace FFmpegSharp.Interop
{
    [NativeTypeName("int")]
    public enum AVDevToAppMessageType : uint
    {
        AV_DEV_TO_APP_NONE = (unchecked(((sbyte)('E')) | (((sbyte)('N')) << 8) | (((sbyte)('O')) << 16) | ((uint)('N') << 24))),
        AV_DEV_TO_APP_CREATE_WINDOW_BUFFER = (unchecked(((sbyte)('E')) | (((sbyte)('R')) << 8) | (((sbyte)('C')) << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_PREPARE_WINDOW_BUFFER = (unchecked(((sbyte)('E')) | (((sbyte)('R')) << 8) | (((sbyte)('P')) << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_DISPLAY_WINDOW_BUFFER = (unchecked(((sbyte)('S')) | (((sbyte)('I')) << 8) | (((sbyte)('D')) << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_DESTROY_WINDOW_BUFFER = (unchecked(((sbyte)('S')) | (((sbyte)('E')) << 8) | (((sbyte)('D')) << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_BUFFER_OVERFLOW = (unchecked(((sbyte)('L')) | (((sbyte)('F')) << 8) | (((sbyte)('O')) << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_BUFFER_UNDERFLOW = (unchecked(((sbyte)('L')) | (((sbyte)('F')) << 8) | (((sbyte)('U')) << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_BUFFER_READABLE = (unchecked(((sbyte)(' ')) | (((sbyte)('D')) << 8) | (((sbyte)('R')) << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_BUFFER_WRITABLE = (unchecked(((sbyte)(' ')) | (((sbyte)('R')) << 8) | (((sbyte)('W')) << 16) | ((uint)('B') << 24))),
        AV_DEV_TO_APP_MUTE_STATE_CHANGED = (unchecked(((sbyte)('T')) | (((sbyte)('U')) << 8) | (((sbyte)('M')) << 16) | ((uint)('C') << 24))),
        AV_DEV_TO_APP_VOLUME_LEVEL_CHANGED = (unchecked(((sbyte)('L')) | (((sbyte)('O')) << 8) | (((sbyte)('V')) << 16) | ((uint)('C') << 24))),
    }
}
