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
    public enum AVOptionType
    {
        AV_OPT_TYPE_FLAGS,
        AV_OPT_TYPE_INT,
        AV_OPT_TYPE_INT64,
        AV_OPT_TYPE_DOUBLE,
        AV_OPT_TYPE_FLOAT,
        AV_OPT_TYPE_STRING,
        AV_OPT_TYPE_RATIONAL,
        AV_OPT_TYPE_BINARY,
        AV_OPT_TYPE_DICT,
        AV_OPT_TYPE_UINT64,
        AV_OPT_TYPE_CONST,
        AV_OPT_TYPE_IMAGE_SIZE,
        AV_OPT_TYPE_PIXEL_FMT,
        AV_OPT_TYPE_SAMPLE_FMT,
        AV_OPT_TYPE_VIDEO_RATE,
        AV_OPT_TYPE_DURATION,
        AV_OPT_TYPE_COLOR,
        AV_OPT_TYPE_CHANNEL_LAYOUT,
        AV_OPT_TYPE_BOOL,
    }
}
