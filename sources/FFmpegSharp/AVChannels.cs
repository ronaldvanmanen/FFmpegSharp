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

using System;

namespace FFmpegSharp
{
    [Flags]
    public enum AVChannels : ulong
    {
        FrontLeft = Interop.FFmpeg.AV_CH_FRONT_LEFT,
        FrontRight = Interop.FFmpeg.AV_CH_FRONT_RIGHT,
        FrontCenter = Interop.FFmpeg.AV_CH_FRONT_CENTER,
        LowFrequency = Interop.FFmpeg.AV_CH_LOW_FREQUENCY,
        BackLeft = Interop.FFmpeg.AV_CH_BACK_LEFT,
        BackRight = Interop.FFmpeg.AV_CH_BACK_RIGHT,
        FrontLeftOfCenter = Interop.FFmpeg.AV_CH_FRONT_LEFT_OF_CENTER,
        FrontRightOfCenter = Interop.FFmpeg.AV_CH_FRONT_RIGHT_OF_CENTER,
        BackCenter = Interop.FFmpeg.AV_CH_BACK_CENTER,
        SideLeft = Interop.FFmpeg.AV_CH_SIDE_LEFT,
        SideRight = Interop.FFmpeg.AV_CH_SIDE_RIGHT,
        TopCenter = Interop.FFmpeg.AV_CH_TOP_CENTER,
        TopFrontLeft = Interop.FFmpeg.AV_CH_TOP_FRONT_LEFT,
        TopFrontCenter = Interop.FFmpeg.AV_CH_TOP_FRONT_CENTER,
        TopFrontRight = Interop.FFmpeg.AV_CH_TOP_FRONT_RIGHT,
        TopBackLeft = Interop.FFmpeg.AV_CH_TOP_BACK_LEFT,
        TopBackCenter = Interop.FFmpeg.AV_CH_TOP_BACK_CENTER,
        TopBackRight = Interop.FFmpeg.AV_CH_TOP_BACK_RIGHT,
        StereoLeft = Interop.FFmpeg.AV_CH_STEREO_LEFT,
        StereoRight = Interop.FFmpeg.AV_CH_STEREO_RIGHT,
        WideLeft = Interop.FFmpeg.AV_CH_WIDE_LEFT,
        WideRight = Interop.FFmpeg.AV_CH_WIDE_RIGHT,
        SurroundDirectLeft = Interop.FFmpeg.AV_CH_SURROUND_DIRECT_LEFT,
        SurroundDirectRight = Interop.FFmpeg.AV_CH_SURROUND_DIRECT_RIGHT,
        LowFrequency2 = Interop.FFmpeg.AV_CH_LOW_FREQUENCY_2,
        TopSideLeft = Interop.FFmpeg.AV_CH_TOP_SIDE_LEFT,
        TopSideRight = Interop.FFmpeg.AV_CH_TOP_SIDE_RIGHT,
        BottomFrontCenter = Interop.FFmpeg.AV_CH_BOTTOM_FRONT_CENTER,
        BottomFrontLeft = Interop.FFmpeg.AV_CH_BOTTOM_FRONT_LEFT,
        BottomFrontRight = Interop.FFmpeg.AV_CH_BOTTOM_FRONT_RIGHT,
    }
}
