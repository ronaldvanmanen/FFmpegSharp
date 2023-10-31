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

using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public enum AVChannelLayout : ulong
    {
        Mono = AV_CH_LAYOUT_MONO,
        Stereo = AV_CH_LAYOUT_STEREO,
        TwoPointOne = AV_CH_LAYOUT_2POINT1,
        TwoOne = AV_CH_LAYOUT_2_1,
        Surround = AV_CH_LAYOUT_SURROUND,
        ThreePointOne = AV_CH_LAYOUT_3POINT1,
        FourPointZero = AV_CH_LAYOUT_4POINT0,
        FourPointOne = AV_CH_LAYOUT_4POINT1,
        TwoTwo = AV_CH_LAYOUT_2_2,
        Quad = AV_CH_LAYOUT_QUAD,
        FivePointZero = AV_CH_LAYOUT_5POINT0,
        FivePointOne = AV_CH_LAYOUT_5POINT1,
        FivePointZeroBack = AV_CH_LAYOUT_5POINT0_BACK,
        FivePointOneBack = AV_CH_LAYOUT_5POINT1_BACK,
        SixPointZero = AV_CH_LAYOUT_6POINT0,
        SixPointZeroFront = AV_CH_LAYOUT_6POINT0_FRONT,
        Hexagonal = AV_CH_LAYOUT_HEXAGONAL,
        SixPointOne = AV_CH_LAYOUT_6POINT1,
        SixPointOneBack = AV_CH_LAYOUT_6POINT1_BACK,
        SixPointOneFront = AV_CH_LAYOUT_6POINT1_FRONT,
        SevenPointZero = AV_CH_LAYOUT_7POINT0,
        SevenPointZeroFront = AV_CH_LAYOUT_7POINT0_FRONT,
        SevenPointOne = AV_CH_LAYOUT_7POINT1,
        SevenPointOneWide = AV_CH_LAYOUT_7POINT1_WIDE,
        SevenPointOneWideBack = AV_CH_LAYOUT_7POINT1_WIDE_BACK,
        Octagonal = AV_CH_LAYOUT_OCTAGONAL,
        Hexadecagonal = AV_CH_LAYOUT_HEXADECAGONAL,
        StereoDownmix = AV_CH_LAYOUT_STEREO_DOWNMIX,
        TwentytwoPointTwo = AV_CH_LAYOUT_22POINT2,
    }
}
