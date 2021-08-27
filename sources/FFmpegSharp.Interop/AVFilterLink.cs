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
    public unsafe partial struct AVFilterLink
    {
        [NativeTypeName("AVFilterContext *")]
        public AVFilterContext* src;

        [NativeTypeName("AVFilterPad *")]
        public AVFilterPad* srcpad;

        [NativeTypeName("AVFilterContext *")]
        public AVFilterContext* dst;

        [NativeTypeName("AVFilterPad *")]
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

        [NativeTypeName("enum (anonymous enum at packages/ffmpeg.runtime.win-x64/include/libavfilter/avfilter.h:518:5)")]
        public AVLinkInitState init_state;

        [NativeTypeName("struct AVFilterGraph *")]
        public AVFilterGraph* graph;

        [NativeTypeName("int64_t")]
        public long current_pts;

        [NativeTypeName("int64_t")]
        public long current_pts_us;

        public int age_index;

        public AVRational frame_rate;

        [NativeTypeName("AVFrame *")]
        public AVFrame* partial_buf;

        public int partial_buf_size;

        public int min_samples;

        public int max_samples;

        public int channels;

        [NativeTypeName("int64_t")]
        public long frame_count_in;

        [NativeTypeName("int64_t")]
        public long frame_count_out;

        [NativeTypeName("void *")]
        public void* frame_pool;

        public int frame_wanted_out;

        [NativeTypeName("AVBufferRef *")]
        public AVBufferRef* hw_frames_ctx;

        [NativeTypeName("char [61440]")]
        public fixed sbyte reserved[61440];

        public const int AVLINK_UNINIT = 0;
        public const int AVLINK_STARTINIT = 1;
        public const int AVLINK_INIT = 2;
    }
}
