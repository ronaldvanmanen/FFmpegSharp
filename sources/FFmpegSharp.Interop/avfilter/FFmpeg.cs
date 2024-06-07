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
using System.Runtime.InteropServices;

namespace FFmpegSharp.Interop
{
    public static unsafe partial class FFmpeg
    {
        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avfilter_version();

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avfilter_configuration();

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avfilter_license();

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_pad_count([NativeTypeName("const AVFilterPad *")] AVFilterPad* pads);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avfilter_pad_get_name([NativeTypeName("const AVFilterPad *")] AVFilterPad* pads, int pad_idx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVMediaType")]
        public static extern AVMediaType avfilter_pad_get_type([NativeTypeName("const AVFilterPad *")] AVFilterPad* pads, int pad_idx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_link(AVFilterContext* src, [NativeTypeName("unsigned int")] uint srcpad, AVFilterContext* dst, [NativeTypeName("unsigned int")] uint dstpad);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avfilter_link_free(AVFilterLink** link);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int avfilter_link_get_channels(AVFilterLink* link);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void avfilter_link_set_closed(AVFilterLink* link, int closed);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_config_links(AVFilterContext* filter);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_process_command(AVFilterContext* filter, [NativeTypeName("const char *")] sbyte* cmd, [NativeTypeName("const char *")] sbyte* arg, [NativeTypeName("char *")] sbyte* res, int res_len, int flags);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVFilter *")]
        public static extern AVFilter* av_filter_iterate(void** opaque);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void avfilter_register_all();

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int avfilter_register(AVFilter* filter);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVFilter *")]
        [Obsolete]
        public static extern AVFilter* avfilter_next([NativeTypeName("const AVFilter *")] AVFilter* prev);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVFilter *")]
        public static extern AVFilter* avfilter_get_by_name([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_init_str(AVFilterContext* ctx, [NativeTypeName("const char *")] sbyte* args);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_init_dict(AVFilterContext* ctx, AVDictionary** options);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avfilter_free(AVFilterContext* filter);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_insert_filter(AVFilterLink* link, AVFilterContext* filt, [NativeTypeName("unsigned int")] uint filt_srcpad_idx, [NativeTypeName("unsigned int")] uint filt_dstpad_idx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVClass *")]
        public static extern AVClass* avfilter_get_class();

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFilterGraph* avfilter_graph_alloc();

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFilterContext* avfilter_graph_alloc_filter(AVFilterGraph* graph, [NativeTypeName("const AVFilter *")] AVFilter* filter, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFilterContext* avfilter_graph_get_filter(AVFilterGraph* graph, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_graph_create_filter(AVFilterContext** filt_ctx, [NativeTypeName("const AVFilter *")] AVFilter* filt, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *")] sbyte* args, void* opaque, AVFilterGraph* graph_ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avfilter_graph_set_auto_convert(AVFilterGraph* graph, [NativeTypeName("unsigned int")] uint flags);

        public const int AVFILTER_AUTO_CONVERT_ALL = 0;
        public const int AVFILTER_AUTO_CONVERT_NONE = -1;

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_graph_config(AVFilterGraph* graphctx, void* log_ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avfilter_graph_free(AVFilterGraph** graph);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFilterInOut* avfilter_inout_alloc();

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avfilter_inout_free(AVFilterInOut** inout);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_graph_parse(AVFilterGraph* graph, [NativeTypeName("const char *")] sbyte* filters, AVFilterInOut* inputs, AVFilterInOut* outputs, void* log_ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_graph_parse_ptr(AVFilterGraph* graph, [NativeTypeName("const char *")] sbyte* filters, AVFilterInOut** inputs, AVFilterInOut** outputs, void* log_ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_graph_parse2(AVFilterGraph* graph, [NativeTypeName("const char *")] sbyte* filters, AVFilterInOut** inputs, AVFilterInOut** outputs);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_graph_send_command(AVFilterGraph* graph, [NativeTypeName("const char *")] sbyte* target, [NativeTypeName("const char *")] sbyte* cmd, [NativeTypeName("const char *")] sbyte* arg, [NativeTypeName("char *")] sbyte* res, int res_len, int flags);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_graph_queue_command(AVFilterGraph* graph, [NativeTypeName("const char *")] sbyte* target, [NativeTypeName("const char *")] sbyte* cmd, [NativeTypeName("const char *")] sbyte* arg, int flags, double ts);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* avfilter_graph_dump(AVFilterGraph* graph, [NativeTypeName("const char *")] sbyte* options);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avfilter_graph_request_oldest(AVFilterGraph* graph);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersink_get_frame_flags(AVFilterContext* ctx, AVFrame* frame, int flags);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern AVBufferSinkParams* av_buffersink_params_alloc();

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern AVABufferSinkParams* av_abuffersink_params_alloc();

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_buffersink_set_frame_size(AVFilterContext* ctx, [NativeTypeName("unsigned int")] uint frame_size);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVMediaType")]
        public static extern AVMediaType av_buffersink_get_type([NativeTypeName("const AVFilterContext *")] AVFilterContext* ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_buffersink_get_time_base([NativeTypeName("const AVFilterContext *")] AVFilterContext* ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersink_get_format([NativeTypeName("const AVFilterContext *")] AVFilterContext* ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_buffersink_get_frame_rate([NativeTypeName("const AVFilterContext *")] AVFilterContext* ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersink_get_w([NativeTypeName("const AVFilterContext *")] AVFilterContext* ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersink_get_h([NativeTypeName("const AVFilterContext *")] AVFilterContext* ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_buffersink_get_sample_aspect_ratio([NativeTypeName("const AVFilterContext *")] AVFilterContext* ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersink_get_channels([NativeTypeName("const AVFilterContext *")] AVFilterContext* ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong av_buffersink_get_channel_layout([NativeTypeName("const AVFilterContext *")] AVFilterContext* ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersink_get_sample_rate([NativeTypeName("const AVFilterContext *")] AVFilterContext* ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferRef* av_buffersink_get_hw_frames_ctx([NativeTypeName("const AVFilterContext *")] AVFilterContext* ctx);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersink_get_frame(AVFilterContext* ctx, AVFrame* frame);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersink_get_samples(AVFilterContext* ctx, AVFrame* frame, int nb_samples);

        public const int AV_BUFFERSRC_FLAG_NO_CHECK_FORMAT = 1;
        public const int AV_BUFFERSRC_FLAG_PUSH = 4;
        public const int AV_BUFFERSRC_FLAG_KEEP_REF = 8;

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint av_buffersrc_get_nb_failed_requests(AVFilterContext* buffer_src);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferSrcParameters* av_buffersrc_parameters_alloc();

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersrc_parameters_set(AVFilterContext* ctx, AVBufferSrcParameters* param1);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersrc_write_frame(AVFilterContext* ctx, [NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersrc_add_frame(AVFilterContext* ctx, AVFrame* frame);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersrc_add_frame_flags(AVFilterContext* buffer_src, AVFrame* frame, int flags);

        [DllImport("avfilter-7.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffersrc_close(AVFilterContext* ctx, [NativeTypeName("int64_t")] long pts, [NativeTypeName("unsigned int")] uint flags);

        [NativeTypeName("#define LIBAVFILTER_VERSION_MAJOR 7")]
        public const int LIBAVFILTER_VERSION_MAJOR = 7;

        [NativeTypeName("#define LIBAVFILTER_VERSION_MINOR 110")]
        public const int LIBAVFILTER_VERSION_MINOR = 110;

        [NativeTypeName("#define LIBAVFILTER_VERSION_MICRO 100")]
        public const int LIBAVFILTER_VERSION_MICRO = 100;

        [NativeTypeName("#define LIBAVFILTER_VERSION_INT AV_VERSION_INT(LIBAVFILTER_VERSION_MAJOR, \\\n                                               LIBAVFILTER_VERSION_MINOR, \\\n                                               LIBAVFILTER_VERSION_MICRO)")]
        public const int LIBAVFILTER_VERSION_INT = ((7) << 16 | (110) << 8 | (100));

        [NativeTypeName("#define LIBAVFILTER_BUILD LIBAVFILTER_VERSION_INT")]
        public const int LIBAVFILTER_BUILD = ((7) << 16 | (110) << 8 | (100));

        [NativeTypeName("#define LIBAVFILTER_IDENT \"Lavfi\" AV_STRINGIFY(LIBAVFILTER_VERSION)")]
        public static ReadOnlySpan<byte> LIBAVFILTER_IDENT => new byte[] { 0x4C, 0x61, 0x76, 0x66, 0x69, 0x37, 0x2E, 0x31, 0x31, 0x30, 0x2E, 0x31, 0x30, 0x30, 0x00 };

        [NativeTypeName("#define FF_API_OLD_FILTER_OPTS_ERROR (LIBAVFILTER_VERSION_MAJOR < 8)")]
        public const bool FF_API_OLD_FILTER_OPTS_ERROR = (7 < 8);

        [NativeTypeName("#define FF_API_LAVR_OPTS (LIBAVFILTER_VERSION_MAJOR < 8)")]
        public const bool FF_API_LAVR_OPTS = (7 < 8);

        [NativeTypeName("#define FF_API_FILTER_GET_SET (LIBAVFILTER_VERSION_MAJOR < 8)")]
        public const bool FF_API_FILTER_GET_SET = (7 < 8);

        [NativeTypeName("#define FF_API_SWS_PARAM_OPTION (LIBAVFILTER_VERSION_MAJOR < 8)")]
        public const bool FF_API_SWS_PARAM_OPTION = (7 < 8);

        [NativeTypeName("#define FF_API_FILTER_LINK_SET_CLOSED (LIBAVFILTER_VERSION_MAJOR < 8)")]
        public const bool FF_API_FILTER_LINK_SET_CLOSED = (7 < 8);

        [NativeTypeName("#define FF_API_BUFFERSINK_ALLOC (LIBAVFILTER_VERSION_MAJOR < 9)")]
        public const bool FF_API_BUFFERSINK_ALLOC = (7 < 9);

        [NativeTypeName("#define AVFILTER_FLAG_DYNAMIC_INPUTS (1 << 0)")]
        public const int AVFILTER_FLAG_DYNAMIC_INPUTS = (1 << 0);

        [NativeTypeName("#define AVFILTER_FLAG_DYNAMIC_OUTPUTS (1 << 1)")]
        public const int AVFILTER_FLAG_DYNAMIC_OUTPUTS = (1 << 1);

        [NativeTypeName("#define AVFILTER_FLAG_SLICE_THREADS (1 << 2)")]
        public const int AVFILTER_FLAG_SLICE_THREADS = (1 << 2);

        [NativeTypeName("#define AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC (1 << 16)")]
        public const int AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC = (1 << 16);

        [NativeTypeName("#define AVFILTER_FLAG_SUPPORT_TIMELINE_INTERNAL (1 << 17)")]
        public const int AVFILTER_FLAG_SUPPORT_TIMELINE_INTERNAL = (1 << 17);

        [NativeTypeName("#define AVFILTER_FLAG_SUPPORT_TIMELINE (AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC | AVFILTER_FLAG_SUPPORT_TIMELINE_INTERNAL)")]
        public const int AVFILTER_FLAG_SUPPORT_TIMELINE = ((1 << 16) | (1 << 17));

        [NativeTypeName("#define AVFILTER_THREAD_SLICE (1 << 0)")]
        public const int AVFILTER_THREAD_SLICE = (1 << 0);

        [NativeTypeName("#define AVFILTER_CMD_FLAG_ONE 1")]
        public const int AVFILTER_CMD_FLAG_ONE = 1;

        [NativeTypeName("#define AVFILTER_CMD_FLAG_FAST 2")]
        public const int AVFILTER_CMD_FLAG_FAST = 2;

        [NativeTypeName("#define AV_BUFFERSINK_FLAG_PEEK 1")]
        public const int AV_BUFFERSINK_FLAG_PEEK = 1;

        [NativeTypeName("#define AV_BUFFERSINK_FLAG_NO_REQUEST 2")]
        public const int AV_BUFFERSINK_FLAG_NO_REQUEST = 2;
    }
}
