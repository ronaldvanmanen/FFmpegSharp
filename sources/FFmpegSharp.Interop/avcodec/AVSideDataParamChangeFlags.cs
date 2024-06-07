// Copyright (C) 2021-2024 Ronald van Manen
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
    public enum AVSideDataParamChangeFlags
    {
        AV_SIDE_DATA_PARAM_CHANGE_CHANNEL_COUNT = 0x0001,
        AV_SIDE_DATA_PARAM_CHANGE_CHANNEL_LAYOUT = 0x0002,
        AV_SIDE_DATA_PARAM_CHANGE_SAMPLE_RATE = 0x0004,
        AV_SIDE_DATA_PARAM_CHANGE_DIMENSIONS = 0x0008,
    }
}
