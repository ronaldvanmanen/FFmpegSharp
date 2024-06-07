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

using System;
using FFmpegSharp.Interop;

namespace FFmpegSharp
{
    [Flags]
    public enum AVCodecCapabilities : uint
    {
        DrawHorizontalBand = FFmpeg.AV_CODEC_CAP_DRAW_HORIZ_BAND,
        DR1 = FFmpeg.AV_CODEC_CAP_DR1,
        Truncated = FFmpeg.AV_CODEC_CAP_TRUNCATED,
        Delay = FFmpeg.AV_CODEC_CAP_DELAY,
        SmallLastFrame = FFmpeg.AV_CODEC_CAP_SMALL_LAST_FRAME,
        Subframes = FFmpeg.AV_CODEC_CAP_SUBFRAMES,
        Experimental = FFmpeg.AV_CODEC_CAP_EXPERIMENTAL,
        ChannelConf = FFmpeg.AV_CODEC_CAP_CHANNEL_CONF,
        FrameThreads = FFmpeg.AV_CODEC_CAP_FRAME_THREADS,
        SliceThreads = FFmpeg.AV_CODEC_CAP_SLICE_THREADS,
        ParamChange = FFmpeg.AV_CODEC_CAP_PARAM_CHANGE,
        OtherThreads = FFmpeg.AV_CODEC_CAP_OTHER_THREADS,
        AutoThreads = FFmpeg.AV_CODEC_CAP_AUTO_THREADS,
        VariableFrameSize = FFmpeg.AV_CODEC_CAP_VARIABLE_FRAME_SIZE,
        AvoidProbing = FFmpeg.AV_CODEC_CAP_AVOID_PROBING,
        IntraOnly = FFmpeg.AV_CODEC_CAP_INTRA_ONLY,
        Lossless = FFmpeg.AV_CODEC_CAP_LOSSLESS,
        Hardware = FFmpeg.AV_CODEC_CAP_HARDWARE,
        Hybrid = FFmpeg.AV_CODEC_CAP_HYBRID,
        EncoderReorderedOpaque = FFmpeg.AV_CODEC_CAP_ENCODER_REORDERED_OPAQUE,
        EncoderFlush = FFmpeg.AV_CODEC_CAP_ENCODER_FLUSH,
    }
}
