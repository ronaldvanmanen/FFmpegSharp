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

using System;
using System.Runtime.InteropServices;

namespace FFmpegSharp.Interop
{
    public static unsafe partial class FFmpeg
    {
        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint swscale_version();

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* swscale_configuration();

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* swscale_license();

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const int *")]
        public static extern int* sws_getCoefficients(int colorspace);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int sws_isSupportedInput([NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int sws_isSupportedOutput([NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int sws_isSupportedEndiannessConversion([NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct SwsContext *")]
        public static extern SwsContext* sws_alloc_context();

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int sws_init_context([NativeTypeName("struct SwsContext *")] SwsContext* sws_context, SwsFilter* srcFilter, SwsFilter* dstFilter);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sws_freeContext([NativeTypeName("struct SwsContext *")] SwsContext* swsContext);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct SwsContext *")]
        public static extern SwsContext* sws_getContext(int srcW, int srcH, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat srcFormat, int dstW, int dstH, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat dstFormat, int flags, SwsFilter* srcFilter, SwsFilter* dstFilter, [NativeTypeName("const double *")] double* param9);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int sws_scale([NativeTypeName("struct SwsContext *")] SwsContext* c, [NativeTypeName("const uint8_t *const[]")] byte** srcSlice, [NativeTypeName("const int[]")] int* srcStride, int srcSliceY, int srcSliceH, [NativeTypeName("uint8_t *const[]")] byte** dst, [NativeTypeName("const int[]")] int* dstStride);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int sws_setColorspaceDetails([NativeTypeName("struct SwsContext *")] SwsContext* c, [NativeTypeName("const int[4]")] int* inv_table, int srcRange, [NativeTypeName("const int[4]")] int* table, int dstRange, int brightness, int contrast, int saturation);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int sws_getColorspaceDetails([NativeTypeName("struct SwsContext *")] SwsContext* c, int** inv_table, int* srcRange, int** table, int* dstRange, int* brightness, int* contrast, int* saturation);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SwsVector* sws_allocVec(int length);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SwsVector* sws_getGaussianVec(double variance, double quality);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sws_scaleVec(SwsVector* a, double scalar);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sws_normalizeVec(SwsVector* a, double height);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern SwsVector* sws_getConstVec(double c, int length);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern SwsVector* sws_getIdentityVec();

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void sws_convVec(SwsVector* a, SwsVector* b);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void sws_addVec(SwsVector* a, SwsVector* b);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void sws_subVec(SwsVector* a, SwsVector* b);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void sws_shiftVec(SwsVector* a, int shift);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern SwsVector* sws_cloneVec(SwsVector* a);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void sws_printVec2(SwsVector* a, AVClass* log_ctx, int log_level);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sws_freeVec(SwsVector* a);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SwsFilter* sws_getDefaultFilter(float lumaGBlur, float chromaGBlur, float lumaSharpen, float chromaSharpen, float chromaHShift, float chromaVShift, int verbose);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sws_freeFilter(SwsFilter* filter);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct SwsContext *")]
        public static extern SwsContext* sws_getCachedContext([NativeTypeName("struct SwsContext *")] SwsContext* context, int srcW, int srcH, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat srcFormat, int dstW, int dstH, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat dstFormat, int flags, SwsFilter* srcFilter, SwsFilter* dstFilter, [NativeTypeName("const double *")] double* param10);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sws_convertPalette8ToPacked32([NativeTypeName("const uint8_t *")] byte* src, [NativeTypeName("uint8_t *")] byte* dst, int num_pixels, [NativeTypeName("const uint8_t *")] byte* palette);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sws_convertPalette8ToPacked24([NativeTypeName("const uint8_t *")] byte* src, [NativeTypeName("uint8_t *")] byte* dst, int num_pixels, [NativeTypeName("const uint8_t *")] byte* palette);

        [DllImport("swscale-5.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVClass *")]
        public static extern AVClass* sws_get_class();

        [NativeTypeName("#define LIBSWSCALE_VERSION_MAJOR 5")]
        public const int LIBSWSCALE_VERSION_MAJOR = 5;

        [NativeTypeName("#define LIBSWSCALE_VERSION_MINOR 9")]
        public const int LIBSWSCALE_VERSION_MINOR = 9;

        [NativeTypeName("#define LIBSWSCALE_VERSION_MICRO 100")]
        public const int LIBSWSCALE_VERSION_MICRO = 100;

        [NativeTypeName("#define LIBSWSCALE_VERSION_INT AV_VERSION_INT(LIBSWSCALE_VERSION_MAJOR, \\\n                                               LIBSWSCALE_VERSION_MINOR, \\\n                                               LIBSWSCALE_VERSION_MICRO)")]
        public const int LIBSWSCALE_VERSION_INT = ((5) << 16 | (9) << 8 | (100));

        [NativeTypeName("#define LIBSWSCALE_BUILD LIBSWSCALE_VERSION_INT")]
        public const int LIBSWSCALE_BUILD = ((5) << 16 | (9) << 8 | (100));

        [NativeTypeName("#define LIBSWSCALE_IDENT \"SwS\" AV_STRINGIFY(LIBSWSCALE_VERSION)")]
        public static ReadOnlySpan<byte> LIBSWSCALE_IDENT => new byte[] { 0x53, 0x77, 0x53, 0x35, 0x2E, 0x39, 0x2E, 0x31, 0x30, 0x30, 0x00 };

        [NativeTypeName("#define FF_API_SWS_VECTOR (LIBSWSCALE_VERSION_MAJOR < 6)")]
        public const bool FF_API_SWS_VECTOR = (5 < 6);

        [NativeTypeName("#define SWS_FAST_BILINEAR 1")]
        public const int SWS_FAST_BILINEAR = 1;

        [NativeTypeName("#define SWS_BILINEAR 2")]
        public const int SWS_BILINEAR = 2;

        [NativeTypeName("#define SWS_BICUBIC 4")]
        public const int SWS_BICUBIC = 4;

        [NativeTypeName("#define SWS_X 8")]
        public const int SWS_X = 8;

        [NativeTypeName("#define SWS_POINT 0x10")]
        public const int SWS_POINT = 0x10;

        [NativeTypeName("#define SWS_AREA 0x20")]
        public const int SWS_AREA = 0x20;

        [NativeTypeName("#define SWS_BICUBLIN 0x40")]
        public const int SWS_BICUBLIN = 0x40;

        [NativeTypeName("#define SWS_GAUSS 0x80")]
        public const int SWS_GAUSS = 0x80;

        [NativeTypeName("#define SWS_SINC 0x100")]
        public const int SWS_SINC = 0x100;

        [NativeTypeName("#define SWS_LANCZOS 0x200")]
        public const int SWS_LANCZOS = 0x200;

        [NativeTypeName("#define SWS_SPLINE 0x400")]
        public const int SWS_SPLINE = 0x400;

        [NativeTypeName("#define SWS_SRC_V_CHR_DROP_MASK 0x30000")]
        public const int SWS_SRC_V_CHR_DROP_MASK = 0x30000;

        [NativeTypeName("#define SWS_SRC_V_CHR_DROP_SHIFT 16")]
        public const int SWS_SRC_V_CHR_DROP_SHIFT = 16;

        [NativeTypeName("#define SWS_PARAM_DEFAULT 123456")]
        public const int SWS_PARAM_DEFAULT = 123456;

        [NativeTypeName("#define SWS_PRINT_INFO 0x1000")]
        public const int SWS_PRINT_INFO = 0x1000;

        [NativeTypeName("#define SWS_FULL_CHR_H_INT 0x2000")]
        public const int SWS_FULL_CHR_H_INT = 0x2000;

        [NativeTypeName("#define SWS_FULL_CHR_H_INP 0x4000")]
        public const int SWS_FULL_CHR_H_INP = 0x4000;

        [NativeTypeName("#define SWS_DIRECT_BGR 0x8000")]
        public const int SWS_DIRECT_BGR = 0x8000;

        [NativeTypeName("#define SWS_ACCURATE_RND 0x40000")]
        public const int SWS_ACCURATE_RND = 0x40000;

        [NativeTypeName("#define SWS_BITEXACT 0x80000")]
        public const int SWS_BITEXACT = 0x80000;

        [NativeTypeName("#define SWS_ERROR_DIFFUSION 0x800000")]
        public const int SWS_ERROR_DIFFUSION = 0x800000;

        [NativeTypeName("#define SWS_MAX_REDUCE_CUTOFF 0.002")]
        public const double SWS_MAX_REDUCE_CUTOFF = 0.002;

        [NativeTypeName("#define SWS_CS_ITU709 1")]
        public const int SWS_CS_ITU709 = 1;

        [NativeTypeName("#define SWS_CS_FCC 4")]
        public const int SWS_CS_FCC = 4;

        [NativeTypeName("#define SWS_CS_ITU601 5")]
        public const int SWS_CS_ITU601 = 5;

        [NativeTypeName("#define SWS_CS_ITU624 5")]
        public const int SWS_CS_ITU624 = 5;

        [NativeTypeName("#define SWS_CS_SMPTE170M 5")]
        public const int SWS_CS_SMPTE170M = 5;

        [NativeTypeName("#define SWS_CS_SMPTE240M 7")]
        public const int SWS_CS_SMPTE240M = 7;

        [NativeTypeName("#define SWS_CS_DEFAULT 5")]
        public const int SWS_CS_DEFAULT = 5;

        [NativeTypeName("#define SWS_CS_BT2020 9")]
        public const int SWS_CS_BT2020 = 9;
    }
}
