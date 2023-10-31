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
        AV_APP_TO_DEV_NONE = (unchecked(('E') | (('N') << 8) | (('O') << 16) | ((uint)('N') << 24))),
        AV_APP_TO_DEV_WINDOW_SIZE = (unchecked(('M') | (('O') << 8) | (('E') << 16) | ((uint)('G') << 24))),
        AV_APP_TO_DEV_WINDOW_REPAINT = (unchecked(('A') | (('P') << 8) | (('E') << 16) | ((uint)('R') << 24))),
        AV_APP_TO_DEV_PAUSE = (unchecked((' ') | (('U') << 8) | (('A') << 16) | ((uint)('P') << 24))),
        AV_APP_TO_DEV_PLAY = (unchecked(('Y') | (('A') << 8) | (('L') << 16) | ((uint)('P') << 24))),
        AV_APP_TO_DEV_TOGGLE_PAUSE = (unchecked(('T') | (('U') << 8) | (('A') << 16) | ((uint)('P') << 24))),
        AV_APP_TO_DEV_SET_VOLUME = (unchecked(('L') | (('O') << 8) | (('V') << 16) | ((uint)('S') << 24))),
        AV_APP_TO_DEV_MUTE = (unchecked(('T') | (('U') << 8) | (('M') << 16) | ((uint)(' ') << 24))),
        AV_APP_TO_DEV_UNMUTE = (unchecked(('T') | (('U') << 8) | (('M') << 16) | ((uint)('U') << 24))),
        AV_APP_TO_DEV_TOGGLE_MUTE = (unchecked(('T') | (('U') << 8) | (('M') << 16) | ((uint)('T') << 24))),
        AV_APP_TO_DEV_GET_VOLUME = (unchecked(('L') | (('O') << 8) | (('V') << 16) | ((uint)('G') << 24))),
        AV_APP_TO_DEV_GET_MUTE = (unchecked(('T') | (('U') << 8) | (('M') << 16) | ((uint)('G') << 24))),
    }
}
