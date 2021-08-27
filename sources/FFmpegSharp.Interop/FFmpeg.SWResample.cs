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
using System.Runtime.InteropServices;

namespace FFmpegSharp.Interop
{
    public static unsafe partial class FFmpeg
    {
        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVClass *")]
        public static extern AVClass* swr_get_class();

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct SwrContext *")]
        public static extern SwrContext* swr_alloc();

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_init([NativeTypeName("struct SwrContext *")] SwrContext* s);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_is_initialized([NativeTypeName("struct SwrContext *")] SwrContext* s);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct SwrContext *")]
        public static extern SwrContext* swr_alloc_set_opts([NativeTypeName("struct SwrContext *")] SwrContext* s, [NativeTypeName("int64_t")] long out_ch_layout, [NativeTypeName("enum AVSampleFormat")] AVSampleFormat out_sample_fmt, int out_sample_rate, [NativeTypeName("int64_t")] long in_ch_layout, [NativeTypeName("enum AVSampleFormat")] AVSampleFormat in_sample_fmt, int in_sample_rate, int log_offset, void* log_ctx);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void swr_free([NativeTypeName("struct SwrContext **")] SwrContext** s);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void swr_close([NativeTypeName("struct SwrContext *")] SwrContext* s);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_convert([NativeTypeName("struct SwrContext *")] SwrContext* s, [NativeTypeName("uint8_t **")] byte** @out, int out_count, [NativeTypeName("const uint8_t **")] byte** @in, int in_count);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long swr_next_pts([NativeTypeName("struct SwrContext *")] SwrContext* s, [NativeTypeName("int64_t")] long pts);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_set_compensation([NativeTypeName("struct SwrContext *")] SwrContext* s, int sample_delta, int compensation_distance);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_set_channel_mapping([NativeTypeName("struct SwrContext *")] SwrContext* s, [NativeTypeName("const int *")] int* channel_map);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_build_matrix([NativeTypeName("uint64_t")] ulong in_layout, [NativeTypeName("uint64_t")] ulong out_layout, double center_mix_level, double surround_mix_level, double lfe_mix_level, double rematrix_maxval, double rematrix_volume, double* matrix, int stride, [NativeTypeName("enum AVMatrixEncoding")] AVMatrixEncoding matrix_encoding, void* log_ctx);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_set_matrix([NativeTypeName("struct SwrContext *")] SwrContext* s, [NativeTypeName("const double *")] double* matrix, int stride);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_drop_output([NativeTypeName("struct SwrContext *")] SwrContext* s, int count);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_inject_silence([NativeTypeName("struct SwrContext *")] SwrContext* s, int count);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long swr_get_delay([NativeTypeName("struct SwrContext *")] SwrContext* s, [NativeTypeName("int64_t")] long @base);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_get_out_samples([NativeTypeName("struct SwrContext *")] SwrContext* s, int in_samples);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint swresample_version();

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* swresample_configuration();

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* swresample_license();

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_convert_frame(SwrContext* swr, AVFrame* output, [NativeTypeName("const AVFrame *")] AVFrame* input);

        [DllImport("swresample-3.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int swr_config_frame(SwrContext* swr, [NativeTypeName("const AVFrame *")] AVFrame* @out, [NativeTypeName("const AVFrame *")] AVFrame* @in);

        [NativeTypeName("#define SWR_FLAG_RESAMPLE 1")]
        public const int SWR_FLAG_RESAMPLE = 1;

        [NativeTypeName("#define LIBSWRESAMPLE_VERSION_MAJOR 3")]
        public const int LIBSWRESAMPLE_VERSION_MAJOR = 3;

        [NativeTypeName("#define LIBSWRESAMPLE_VERSION_MINOR 9")]
        public const int LIBSWRESAMPLE_VERSION_MINOR = 9;

        [NativeTypeName("#define LIBSWRESAMPLE_VERSION_MICRO 100")]
        public const int LIBSWRESAMPLE_VERSION_MICRO = 100;

        [NativeTypeName("#define LIBSWRESAMPLE_VERSION_INT AV_VERSION_INT(LIBSWRESAMPLE_VERSION_MAJOR, \\\n                                                  LIBSWRESAMPLE_VERSION_MINOR, \\\n                                                  LIBSWRESAMPLE_VERSION_MICRO)")]
        public const int LIBSWRESAMPLE_VERSION_INT = ((3) << 16 | (9) << 8 | (100));

        [NativeTypeName("#define LIBSWRESAMPLE_BUILD LIBSWRESAMPLE_VERSION_INT")]
        public const int LIBSWRESAMPLE_BUILD = ((3) << 16 | (9) << 8 | (100));

        [NativeTypeName("#define LIBSWRESAMPLE_IDENT \"SwR\" AV_STRINGIFY(LIBSWRESAMPLE_VERSION)")]
        public static ReadOnlySpan<byte> LIBSWRESAMPLE_IDENT => new byte[] { 0x53, 0x77, 0x52, 0x33, 0x2E, 0x39, 0x2E, 0x31, 0x30, 0x30, 0x00 };
    }
}
