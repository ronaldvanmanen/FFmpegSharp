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
    public unsafe partial struct AVFilterLink
    {
        public AVFilterContext* src;

        public AVFilterPad* srcpad;

        public AVFilterContext* dst;

        public AVFilterPad* dstpad;

        [NativeTypeName("enum AVMediaType")]
        public AVMediaType type;

        public int w;

        public int h;

        public AVRational sample_aspect_ratio;

        [NativeTypeName("uint64_t")]
        public ulong channel_layout;

        public int sample_rate;

        public int format;

        public AVRational time_base;

        public AVFilterFormatsConfig incfg;

        public AVFilterFormatsConfig outcfg;

        [NativeTypeName("__AnonymousEnum_avfilter_L518_C5")]
        public int init_state;

        [NativeTypeName("struct AVFilterGraph *")]
        public AVFilterGraph* graph;

        [NativeTypeName("int64_t")]
        public long current_pts;

        [NativeTypeName("int64_t")]
        public long current_pts_us;

        public int age_index;

        public AVRational frame_rate;

        public AVFrame* partial_buf;

        public int partial_buf_size;

        public int min_samples;

        public int max_samples;

        public int channels;

        [NativeTypeName("int64_t")]
        public long frame_count_in;

        [NativeTypeName("int64_t")]
        public long frame_count_out;

        public void* frame_pool;

        public int frame_wanted_out;

        public AVBufferRef* hw_frames_ctx;

        [NativeTypeName("char[61440]")]
        public fixed sbyte reserved[61440];

        public const int AVLINK_UNINIT = 0;
        public const int AVLINK_STARTINIT = 1;
        public const int AVLINK_INIT = 2;
    }
}
