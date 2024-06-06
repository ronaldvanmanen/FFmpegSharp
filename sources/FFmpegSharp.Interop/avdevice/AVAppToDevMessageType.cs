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
    public enum AVAppToDevMessageType : uint
    {
        AV_APP_TO_DEV_NONE = (unchecked(((sbyte)('E')) | (((sbyte)('N')) << 8) | (((sbyte)('O')) << 16) | ((uint)('N') << 24))),
        AV_APP_TO_DEV_WINDOW_SIZE = (unchecked(((sbyte)('M')) | (((sbyte)('O')) << 8) | (((sbyte)('E')) << 16) | ((uint)('G') << 24))),
        AV_APP_TO_DEV_WINDOW_REPAINT = (unchecked(((sbyte)('A')) | (((sbyte)('P')) << 8) | (((sbyte)('E')) << 16) | ((uint)('R') << 24))),
        AV_APP_TO_DEV_PAUSE = (unchecked(((sbyte)(' ')) | (((sbyte)('U')) << 8) | (((sbyte)('A')) << 16) | ((uint)('P') << 24))),
        AV_APP_TO_DEV_PLAY = (unchecked(((sbyte)('Y')) | (((sbyte)('A')) << 8) | (((sbyte)('L')) << 16) | ((uint)('P') << 24))),
        AV_APP_TO_DEV_TOGGLE_PAUSE = (unchecked(((sbyte)('T')) | (((sbyte)('U')) << 8) | (((sbyte)('A')) << 16) | ((uint)('P') << 24))),
        AV_APP_TO_DEV_SET_VOLUME = (unchecked(((sbyte)('L')) | (((sbyte)('O')) << 8) | (((sbyte)('V')) << 16) | ((uint)('S') << 24))),
        AV_APP_TO_DEV_MUTE = (unchecked(((sbyte)('T')) | (((sbyte)('U')) << 8) | (((sbyte)('M')) << 16) | ((uint)(' ') << 24))),
        AV_APP_TO_DEV_UNMUTE = (unchecked(((sbyte)('T')) | (((sbyte)('U')) << 8) | (((sbyte)('M')) << 16) | ((uint)('U') << 24))),
        AV_APP_TO_DEV_TOGGLE_MUTE = (unchecked(((sbyte)('T')) | (((sbyte)('U')) << 8) | (((sbyte)('M')) << 16) | ((uint)('T') << 24))),
        AV_APP_TO_DEV_GET_VOLUME = (unchecked(((sbyte)('L')) | (((sbyte)('O')) << 8) | (((sbyte)('V')) << 16) | ((uint)('G') << 24))),
        AV_APP_TO_DEV_GET_MUTE = (unchecked(((sbyte)('T')) | (((sbyte)('U')) << 8) | (((sbyte)('M')) << 16) | ((uint)('G') << 24))),
    }
}
