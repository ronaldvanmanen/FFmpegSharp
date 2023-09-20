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
using static FFmpegSharp.Interop.AVPixelFormat;

namespace FFmpegSharp.Interop
{
    public static unsafe partial class FFmpeg
    {
        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avutil_version();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_version_info();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avutil_configuration();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avutil_license();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_get_media_type_string([NativeTypeName("enum AVMediaType")] AVMediaType media_type);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char")]
        public static extern sbyte av_get_picture_type_char([NativeTypeName("enum AVPictureType")] AVPictureType pict_type);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_strerror(int errnum, [NativeTypeName("char *")] sbyte* errbuf, [NativeTypeName("size_t")] UIntPtr errbuf_size);

        [return: NativeTypeName("char *")]
        public static sbyte* av_make_error_string([NativeTypeName("char *")] sbyte* errbuf, [NativeTypeName("size_t")] UIntPtr errbuf_size, int errnum)
        {
            _ = av_strerror(errnum, errbuf, errbuf_size);
            return errbuf;
        }

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_malloc([NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_mallocz([NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_malloc_array([NativeTypeName("size_t")] UIntPtr nmemb, [NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_mallocz_array([NativeTypeName("size_t")] UIntPtr nmemb, [NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_calloc([NativeTypeName("size_t")] UIntPtr nmemb, [NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_realloc(void* ptr, [NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_reallocp(void* ptr, [NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_realloc_f(void* ptr, [NativeTypeName("size_t")] UIntPtr nelem, [NativeTypeName("size_t")] UIntPtr elsize);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_realloc_array(void* ptr, [NativeTypeName("size_t")] UIntPtr nmemb, [NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_reallocp_array(void* ptr, [NativeTypeName("size_t")] UIntPtr nmemb, [NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_fast_realloc(void* ptr, [NativeTypeName("unsigned int *")] uint* size, [NativeTypeName("size_t")] UIntPtr min_size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_fast_malloc(void* ptr, [NativeTypeName("unsigned int *")] uint* size, [NativeTypeName("size_t")] UIntPtr min_size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_fast_mallocz(void* ptr, [NativeTypeName("unsigned int *")] uint* size, [NativeTypeName("size_t")] UIntPtr min_size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_free(void* ptr);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_freep(void* ptr);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* av_strdup([NativeTypeName("const char *")] sbyte* s);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* av_strndup([NativeTypeName("const char *")] sbyte* s, [NativeTypeName("size_t")] UIntPtr len);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_memdup([NativeTypeName("const void *")] void* p, [NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_memcpy_backptr([NativeTypeName("uint8_t *")] byte* dst, int back, int cnt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_dynarray_add(void* tab_ptr, int* nb_ptr, void* elem);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_dynarray_add_nofree(void* tab_ptr, int* nb_ptr, void* elem);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_dynarray2_add(void** tab_ptr, int* nb_ptr, [NativeTypeName("size_t")] UIntPtr elem_size, [NativeTypeName("const uint8_t *")] byte* elem_data);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_max_alloc([NativeTypeName("size_t")] UIntPtr max);

        public static AVRational av_make_q(int num, int den)
        {
            AVRational r = new AVRational
            {
                num = num,
                den = den,
            };

            return r;
        }

        public static int av_cmp_q(AVRational a, AVRational b)
        {
            long tmp = a.num * (long)(b.den) - b.num * (long)(a.den);

            if ((tmp) != 0)
            {
                return (int)((tmp ^ a.den ^ b.den) >> 63) | 1;
            }
            else if ((b.den) != 0 && (a.den) != 0)
            {
                return 0;
            }
            else if ((a.num) != 0 && (b.num) != 0)
            {
                return (a.num >> 31) - (b.num >> 31);
            }
            else
            {
                return (-2147483647 - 1);
            }
        }

        public static double av_q2d(AVRational a)
        {
            return a.num / (double)(a.den);
        }

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_reduce(int* dst_num, int* dst_den, [NativeTypeName("int64_t")] long num, [NativeTypeName("int64_t")] long den, [NativeTypeName("int64_t")] long max);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_mul_q(AVRational b, AVRational c);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_div_q(AVRational b, AVRational c);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_add_q(AVRational b, AVRational c);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_sub_q(AVRational b, AVRational c);

        public static AVRational av_inv_q(AVRational q)
        {
            AVRational r = new AVRational
            {
                num = q.den,
                den = q.num,
            };

            return r;
        }

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_d2q(double d, int max);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_nearer_q(AVRational q, AVRational q1, AVRational q2);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_find_nearest_q_idx(AVRational q, [NativeTypeName("const AVRational *")] AVRational* q_list);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint av_q2intfloat(AVRational q);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_gcd_q(AVRational a, AVRational b, int max_den, AVRational def);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_gcd([NativeTypeName("int64_t")] long a, [NativeTypeName("int64_t")] long b);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_rescale([NativeTypeName("int64_t")] long a, [NativeTypeName("int64_t")] long b, [NativeTypeName("int64_t")] long c);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_rescale_rnd([NativeTypeName("int64_t")] long a, [NativeTypeName("int64_t")] long b, [NativeTypeName("int64_t")] long c, [NativeTypeName("enum AVRounding")] AVRounding rnd);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_rescale_q([NativeTypeName("int64_t")] long a, AVRational bq, AVRational cq);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_rescale_q_rnd([NativeTypeName("int64_t")] long a, AVRational bq, AVRational cq, [NativeTypeName("enum AVRounding")] AVRounding rnd);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_compare_ts([NativeTypeName("int64_t")] long ts_a, AVRational tb_a, [NativeTypeName("int64_t")] long ts_b, AVRational tb_b);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_compare_mod([NativeTypeName("uint64_t")] ulong a, [NativeTypeName("uint64_t")] ulong b, [NativeTypeName("uint64_t")] ulong mod);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_rescale_delta(AVRational in_tb, [NativeTypeName("int64_t")] long in_ts, AVRational fs_tb, int duration, [NativeTypeName("int64_t *")] long* last, AVRational out_tb);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_add_stable(AVRational ts_tb, [NativeTypeName("int64_t")] long ts, AVRational inc_tb, [NativeTypeName("int64_t")] long inc);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_log(void* avcl, int level, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_log_once(void* avcl, int initial_level, int subsequent_level, int* state, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_vlog(void* avcl, int level, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* vl);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_log_get_level();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_log_set_level(int level);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_log_set_callback([NativeTypeName("void (*)(void *, int, const char *, va_list)")] IntPtr callback);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_log_default_callback(void* avcl, int level, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* vl);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_default_item_name(void* ctx);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVClassCategory av_default_get_category(void* ptr);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_log_format_line(void* ptr, int level, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* vl, [NativeTypeName("char *")] sbyte* line, int line_size, int* print_prefix);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_log_format_line2(void* ptr, int level, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* vl, [NativeTypeName("char *")] sbyte* line, int line_size, int* print_prefix);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_log_set_flags(int arg);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_log_get_flags();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern FILE* av_fopen_utf8([NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const char *")] sbyte* mode);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_get_time_base_q();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* av_fourcc_make_string([NativeTypeName("char *")] sbyte* buf, [NativeTypeName("uint32_t")] uint fourcc);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferRef* av_buffer_alloc(int size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferRef* av_buffer_allocz(int size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferRef* av_buffer_create([NativeTypeName("uint8_t *")] byte* data, int size, [NativeTypeName("void (*)(void *, uint8_t *)")] IntPtr free, void* opaque, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_buffer_default_free(void* opaque, [NativeTypeName("uint8_t *")] byte* data);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferRef* av_buffer_ref(AVBufferRef* buf);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_buffer_unref(AVBufferRef** buf);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffer_is_writable([NativeTypeName("const AVBufferRef *")] AVBufferRef* buf);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_buffer_get_opaque([NativeTypeName("const AVBufferRef *")] AVBufferRef* buf);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffer_get_ref_count([NativeTypeName("const AVBufferRef *")] AVBufferRef* buf);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffer_make_writable(AVBufferRef** buf);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffer_realloc(AVBufferRef** buf, int size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_buffer_replace(AVBufferRef** dst, AVBufferRef* src);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferPool* av_buffer_pool_init(int size, [NativeTypeName("AVBufferRef *(*)(int)")] IntPtr alloc);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferPool* av_buffer_pool_init2(int size, void* opaque, [NativeTypeName("AVBufferRef *(*)(void *, int)")] IntPtr alloc, [NativeTypeName("void (*)(void *)")] IntPtr pool_free);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_buffer_pool_uninit(AVBufferPool** pool);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferRef* av_buffer_pool_get(AVBufferPool* pool);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_buffer_pool_buffer_get_opaque(AVBufferRef* @ref);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong av_get_channel_layout([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_extended_channel_layout([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("uint64_t *")] ulong* channel_layout, int* nb_channels);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_get_channel_layout_string([NativeTypeName("char *")] sbyte* buf, int buf_size, int nb_channels, [NativeTypeName("uint64_t")] ulong channel_layout);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_bprint_channel_layout([NativeTypeName("struct AVBPrint *")] AVBPrint* bp, int nb_channels, [NativeTypeName("uint64_t")] ulong channel_layout);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_channel_layout_nb_channels([NativeTypeName("uint64_t")] ulong channel_layout);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_get_default_channel_layout(int nb_channels);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_channel_layout_channel_index([NativeTypeName("uint64_t")] ulong channel_layout, [NativeTypeName("uint64_t")] ulong channel);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong av_channel_layout_extract_channel([NativeTypeName("uint64_t")] ulong channel_layout, int index);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_get_channel_name([NativeTypeName("uint64_t")] ulong channel);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_get_channel_description([NativeTypeName("uint64_t")] ulong channel);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_standard_channel_layout([NativeTypeName("unsigned int")] uint index, [NativeTypeName("uint64_t *")] ulong* layout, [NativeTypeName("const char **")] sbyte** name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_cpu_flags();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_force_cpu_flags(int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_set_cpu_flags_mask(int mask);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int av_parse_cpu_flags([NativeTypeName("const char *")] sbyte* s);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_parse_cpu_caps([NativeTypeName("unsigned int *")] uint* flags, [NativeTypeName("const char *")] sbyte* s);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_cpu_count();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern UIntPtr av_cpu_max_align();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVDictionaryEntry* av_dict_get([NativeTypeName("const AVDictionary *")] AVDictionary* m, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const AVDictionaryEntry *")] AVDictionaryEntry* prev, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_dict_count([NativeTypeName("const AVDictionary *")] AVDictionary* m);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_dict_set(AVDictionary** pm, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char *")] sbyte* value, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_dict_set_int(AVDictionary** pm, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("int64_t")] long value, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_dict_parse_string(AVDictionary** pm, [NativeTypeName("const char *")] sbyte* str, [NativeTypeName("const char *")] sbyte* key_val_sep, [NativeTypeName("const char *")] sbyte* pairs_sep, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_dict_copy(AVDictionary** dst, [NativeTypeName("const AVDictionary *")] AVDictionary* src, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_dict_free(AVDictionary** m);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_dict_get_string([NativeTypeName("const AVDictionary *")] AVDictionary* m, [NativeTypeName("char **")] sbyte** buffer, [NativeTypeName("const char")] sbyte key_val_sep, [NativeTypeName("const char")] sbyte pairs_sep);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFifoBuffer* av_fifo_alloc([NativeTypeName("unsigned int")] uint size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFifoBuffer* av_fifo_alloc_array([NativeTypeName("size_t")] UIntPtr nmemb, [NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_fifo_free(AVFifoBuffer* f);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_fifo_freep(AVFifoBuffer** f);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_fifo_reset(AVFifoBuffer* f);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_fifo_size([NativeTypeName("const AVFifoBuffer *")] AVFifoBuffer* f);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_fifo_space([NativeTypeName("const AVFifoBuffer *")] AVFifoBuffer* f);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_fifo_generic_peek_at(AVFifoBuffer* f, void* dest, int offset, int buf_size, [NativeTypeName("void (*)(void *, void *, int)")] IntPtr func);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_fifo_generic_peek(AVFifoBuffer* f, void* dest, int buf_size, [NativeTypeName("void (*)(void *, void *, int)")] IntPtr func);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_fifo_generic_read(AVFifoBuffer* f, void* dest, int buf_size, [NativeTypeName("void (*)(void *, void *, int)")] IntPtr func);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_fifo_generic_write(AVFifoBuffer* f, void* src, int size, [NativeTypeName("int (*)(void *, void *, int)")] IntPtr func);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_fifo_realloc2(AVFifoBuffer* f, [NativeTypeName("unsigned int")] uint size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_fifo_grow(AVFifoBuffer* f, [NativeTypeName("unsigned int")] uint additional_space);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_fifo_drain(AVFifoBuffer* f, int size);

        [return: NativeTypeName("uint8_t *")]
        public static byte* av_fifo_peek2([NativeTypeName("const AVFifoBuffer *")] AVFifoBuffer* f, int offs)
        {
            byte* ptr = f->rptr + offs;

            if (ptr >= f->end)
            {
                ptr = f->buffer + (ptr - f->end);
            }
            else if (ptr < f->buffer)
            {
                ptr = f->end - (f->buffer - ptr);
            }

            return ptr;
        }

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_get_sample_fmt_name([NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVSampleFormat")]
        public static extern AVSampleFormat av_get_sample_fmt([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVSampleFormat")]
        public static extern AVSampleFormat av_get_alt_sample_fmt([NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt, int planar);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVSampleFormat")]
        public static extern AVSampleFormat av_get_packed_sample_fmt([NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVSampleFormat")]
        public static extern AVSampleFormat av_get_planar_sample_fmt([NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* av_get_sample_fmt_string([NativeTypeName("char *")] sbyte* buf, int buf_size, [NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_bytes_per_sample([NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_sample_fmt_is_planar([NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_samples_get_buffer_size(int* linesize, int nb_channels, int nb_samples, [NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt, int align);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_samples_fill_arrays([NativeTypeName("uint8_t **")] byte** audio_data, int* linesize, [NativeTypeName("const uint8_t *")] byte* buf, int nb_channels, int nb_samples, [NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt, int align);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_samples_alloc([NativeTypeName("uint8_t **")] byte** audio_data, int* linesize, int nb_channels, int nb_samples, [NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt, int align);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_samples_alloc_array_and_samples([NativeTypeName("uint8_t ***")] byte*** audio_data, int* linesize, int nb_channels, int nb_samples, [NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt, int align);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_samples_copy([NativeTypeName("uint8_t **")] byte** dst, [NativeTypeName("uint8_t *const *")] byte** src, int dst_offset, int src_offset, int nb_samples, int nb_channels, [NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_samples_set_silence([NativeTypeName("uint8_t **")] byte** audio_data, int offset, int nb_samples, int nb_channels, [NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        [Obsolete]
        public static extern long av_frame_get_best_effort_timestamp([NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_frame_set_best_effort_timestamp(AVFrame* frame, [NativeTypeName("int64_t")] long val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        [Obsolete]
        public static extern long av_frame_get_pkt_duration([NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_frame_set_pkt_duration(AVFrame* frame, [NativeTypeName("int64_t")] long val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        [Obsolete]
        public static extern long av_frame_get_pkt_pos([NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_frame_set_pkt_pos(AVFrame* frame, [NativeTypeName("int64_t")] long val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        [Obsolete]
        public static extern long av_frame_get_channel_layout([NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_frame_set_channel_layout(AVFrame* frame, [NativeTypeName("int64_t")] long val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int av_frame_get_channels([NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_frame_set_channels(AVFrame* frame, int val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int av_frame_get_sample_rate([NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_frame_set_sample_rate(AVFrame* frame, int val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern AVDictionary* av_frame_get_metadata([NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_frame_set_metadata(AVFrame* frame, AVDictionary* val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int av_frame_get_decode_error_flags([NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_frame_set_decode_error_flags(AVFrame* frame, int val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int av_frame_get_pkt_size([NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_frame_set_pkt_size(AVFrame* frame, int val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int8_t *")]
        [Obsolete]
        public static extern sbyte* av_frame_get_qp_table(AVFrame* f, int* stride, int* type);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int av_frame_set_qp_table(AVFrame* f, AVBufferRef* buf, int stride, int type);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVColorSpace")]
        [Obsolete]
        public static extern AVColorSpace av_frame_get_colorspace([NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_frame_set_colorspace(AVFrame* frame, [NativeTypeName("enum AVColorSpace")] AVColorSpace val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVColorRange")]
        [Obsolete]
        public static extern AVColorRange av_frame_get_color_range([NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void av_frame_set_color_range(AVFrame* frame, [NativeTypeName("enum AVColorRange")] AVColorRange val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_get_colorspace_name([NativeTypeName("enum AVColorSpace")] AVColorSpace val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFrame* av_frame_alloc();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_frame_free(AVFrame** frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_frame_ref(AVFrame* dst, [NativeTypeName("const AVFrame *")] AVFrame* src);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFrame* av_frame_clone([NativeTypeName("const AVFrame *")] AVFrame* src);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_frame_unref(AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_frame_move_ref(AVFrame* dst, AVFrame* src);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_frame_get_buffer(AVFrame* frame, int align);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_frame_is_writable(AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_frame_make_writable(AVFrame* frame);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_frame_copy(AVFrame* dst, [NativeTypeName("const AVFrame *")] AVFrame* src);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_frame_copy_props(AVFrame* dst, [NativeTypeName("const AVFrame *")] AVFrame* src);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferRef* av_frame_get_plane_buffer(AVFrame* frame, int plane);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFrameSideData* av_frame_new_side_data(AVFrame* frame, [NativeTypeName("enum AVFrameSideDataType")] AVFrameSideDataType type, int size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFrameSideData* av_frame_new_side_data_from_buf(AVFrame* frame, [NativeTypeName("enum AVFrameSideDataType")] AVFrameSideDataType type, AVBufferRef* buf);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFrameSideData* av_frame_get_side_data([NativeTypeName("const AVFrame *")] AVFrame* frame, [NativeTypeName("enum AVFrameSideDataType")] AVFrameSideDataType type);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_frame_remove_side_data(AVFrame* frame, [NativeTypeName("enum AVFrameSideDataType")] AVFrameSideDataType type);

        public const int AV_FRAME_CROP_UNALIGNED = 1 << 0;

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_frame_apply_cropping(AVFrame* frame, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_frame_side_data_name([NativeTypeName("enum AVFrameSideDataType")] AVFrameSideDataType type);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVHWDeviceType")]
        public static extern AVHWDeviceType av_hwdevice_find_type_by_name([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_hwdevice_get_type_name([NativeTypeName("enum AVHWDeviceType")] AVHWDeviceType type);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVHWDeviceType")]
        public static extern AVHWDeviceType av_hwdevice_iterate_types([NativeTypeName("enum AVHWDeviceType")] AVHWDeviceType prev);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferRef* av_hwdevice_ctx_alloc([NativeTypeName("enum AVHWDeviceType")] AVHWDeviceType type);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_hwdevice_ctx_init(AVBufferRef* @ref);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_hwdevice_ctx_create(AVBufferRef** device_ctx, [NativeTypeName("enum AVHWDeviceType")] AVHWDeviceType type, [NativeTypeName("const char *")] sbyte* device, AVDictionary* opts, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_hwdevice_ctx_create_derived(AVBufferRef** dst_ctx, [NativeTypeName("enum AVHWDeviceType")] AVHWDeviceType type, AVBufferRef* src_ctx, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_hwdevice_ctx_create_derived_opts(AVBufferRef** dst_ctx, [NativeTypeName("enum AVHWDeviceType")] AVHWDeviceType type, AVBufferRef* src_ctx, AVDictionary* options, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBufferRef* av_hwframe_ctx_alloc(AVBufferRef* device_ctx);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_hwframe_ctx_init(AVBufferRef* @ref);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_hwframe_get_buffer(AVBufferRef* hwframe_ctx, AVFrame* frame, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_hwframe_transfer_data(AVFrame* dst, [NativeTypeName("const AVFrame *")] AVFrame* src, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_hwframe_transfer_get_formats(AVBufferRef* hwframe_ctx, [NativeTypeName("enum AVHWFrameTransferDirection")] AVHWFrameTransferDirection dir, [NativeTypeName("enum AVPixelFormat **")] AVPixelFormat** formats, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_hwdevice_hwconfig_alloc(AVBufferRef* device_ctx);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVHWFramesConstraints* av_hwdevice_get_hwframe_constraints(AVBufferRef* @ref, [NativeTypeName("const void *")] void* hwconfig);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_hwframe_constraints_free(AVHWFramesConstraints** constraints);

        public const int AV_HWFRAME_MAP_READ = 1 << 0;
        public const int AV_HWFRAME_MAP_WRITE = 1 << 1;
        public const int AV_HWFRAME_MAP_OVERWRITE = 1 << 2;
        public const int AV_HWFRAME_MAP_DIRECT = 1 << 3;

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_hwframe_map(AVFrame* dst, [NativeTypeName("const AVFrame *")] AVFrame* src, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_hwframe_ctx_create_derived(AVBufferRef** derived_frame_ctx, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat format, AVBufferRef* derived_device_ctx, AVBufferRef* source_frame_ctx, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_show2(void* obj, void* av_log_obj, int req_flags, int rej_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_opt_set_defaults(void* s);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_opt_set_defaults2(void* s, int mask, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_set_options_string(void* ctx, [NativeTypeName("const char *")] sbyte* opts, [NativeTypeName("const char *")] sbyte* key_val_sep, [NativeTypeName("const char *")] sbyte* pairs_sep);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_from_string(void* ctx, [NativeTypeName("const char *")] sbyte* opts, [NativeTypeName("const char *const *")] sbyte** shorthand, [NativeTypeName("const char *")] sbyte* key_val_sep, [NativeTypeName("const char *")] sbyte* pairs_sep);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_opt_free(void* obj);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_flag_is_set(void* obj, [NativeTypeName("const char *")] sbyte* field_name, [NativeTypeName("const char *")] sbyte* flag_name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_dict(void* obj, [NativeTypeName("struct AVDictionary **")] AVDictionary** options);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_dict2(void* obj, [NativeTypeName("struct AVDictionary **")] AVDictionary** options, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_get_key_value([NativeTypeName("const char **")] sbyte** ropts, [NativeTypeName("const char *")] sbyte* key_val_sep, [NativeTypeName("const char *")] sbyte* pairs_sep, [NativeTypeName("unsigned int")] uint flags, [NativeTypeName("char **")] sbyte** rkey, [NativeTypeName("char **")] sbyte** rval);

        public const int AV_OPT_FLAG_IMPLICIT_KEY = 1;

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_eval_flags(void* obj, [NativeTypeName("const AVOption *")] AVOption* o, [NativeTypeName("const char *")] sbyte* val, int* flags_out);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_eval_int(void* obj, [NativeTypeName("const AVOption *")] AVOption* o, [NativeTypeName("const char *")] sbyte* val, int* int_out);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_eval_int64(void* obj, [NativeTypeName("const AVOption *")] AVOption* o, [NativeTypeName("const char *")] sbyte* val, [NativeTypeName("int64_t *")] long* int64_out);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_eval_float(void* obj, [NativeTypeName("const AVOption *")] AVOption* o, [NativeTypeName("const char *")] sbyte* val, float* float_out);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_eval_double(void* obj, [NativeTypeName("const AVOption *")] AVOption* o, [NativeTypeName("const char *")] sbyte* val, double* double_out);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_eval_q(void* obj, [NativeTypeName("const AVOption *")] AVOption* o, [NativeTypeName("const char *")] sbyte* val, AVRational* q_out);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVOption *")]
        public static extern AVOption* av_opt_find(void* obj, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *")] sbyte* unit, int opt_flags, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVOption *")]
        public static extern AVOption* av_opt_find2(void* obj, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *")] sbyte* unit, int opt_flags, int search_flags, void** target_obj);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVOption *")]
        public static extern AVOption* av_opt_next([NativeTypeName("const void *")] void* obj, [NativeTypeName("const AVOption *")] AVOption* prev);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_opt_child_next(void* obj, void* prev);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVClass *")]
        [Obsolete]
        public static extern AVClass* av_opt_child_class_next([NativeTypeName("const AVClass *")] AVClass* parent, [NativeTypeName("const AVClass *")] AVClass* prev);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVClass *")]
        public static extern AVClass* av_opt_child_class_iterate([NativeTypeName("const AVClass *")] AVClass* parent, void** iter);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set(void* obj, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *")] sbyte* val, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_int(void* obj, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("int64_t")] long val, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_double(void* obj, [NativeTypeName("const char *")] sbyte* name, double val, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_q(void* obj, [NativeTypeName("const char *")] sbyte* name, AVRational val, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_bin(void* obj, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const uint8_t *")] byte* val, int size, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_image_size(void* obj, [NativeTypeName("const char *")] sbyte* name, int w, int h, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_pixel_fmt(void* obj, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat fmt, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_sample_fmt(void* obj, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("enum AVSampleFormat")] AVSampleFormat fmt, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_video_rate(void* obj, [NativeTypeName("const char *")] sbyte* name, AVRational val, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_channel_layout(void* obj, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("int64_t")] long ch_layout, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_set_dict_val(void* obj, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const AVDictionary *")] AVDictionary* val, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_get(void* obj, [NativeTypeName("const char *")] sbyte* name, int search_flags, [NativeTypeName("uint8_t **")] byte** out_val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_get_int(void* obj, [NativeTypeName("const char *")] sbyte* name, int search_flags, [NativeTypeName("int64_t *")] long* out_val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_get_double(void* obj, [NativeTypeName("const char *")] sbyte* name, int search_flags, double* out_val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_get_q(void* obj, [NativeTypeName("const char *")] sbyte* name, int search_flags, AVRational* out_val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_get_image_size(void* obj, [NativeTypeName("const char *")] sbyte* name, int search_flags, int* w_out, int* h_out);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_get_pixel_fmt(void* obj, [NativeTypeName("const char *")] sbyte* name, int search_flags, [NativeTypeName("enum AVPixelFormat *")] AVPixelFormat* out_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_get_sample_fmt(void* obj, [NativeTypeName("const char *")] sbyte* name, int search_flags, [NativeTypeName("enum AVSampleFormat *")] AVSampleFormat* out_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_get_video_rate(void* obj, [NativeTypeName("const char *")] sbyte* name, int search_flags, AVRational* out_val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_get_channel_layout(void* obj, [NativeTypeName("const char *")] sbyte* name, int search_flags, [NativeTypeName("int64_t *")] long* ch_layout);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_get_dict_val(void* obj, [NativeTypeName("const char *")] sbyte* name, int search_flags, AVDictionary** out_val);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_opt_ptr([NativeTypeName("const AVClass *")] AVClass* avclass, void* obj, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_opt_freep_ranges(AVOptionRanges** ranges);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_query_ranges(AVOptionRanges** param0, void* obj, [NativeTypeName("const char *")] sbyte* key, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_copy(void* dest, [NativeTypeName("const void *")] void* src);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_query_ranges_default(AVOptionRanges** param0, void* obj, [NativeTypeName("const char *")] sbyte* key, int flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_is_set_to_default(void* obj, [NativeTypeName("const AVOption *")] AVOption* o);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_is_set_to_default_by_name(void* obj, [NativeTypeName("const char *")] sbyte* name, int search_flags);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_opt_serialize(void* obj, int opt_flags, int flags, [NativeTypeName("char **")] sbyte** buffer, [NativeTypeName("const char")] sbyte key_val_sep, [NativeTypeName("const char")] sbyte pairs_sep);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_gettime();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_gettime_relative();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_gettime_relative_is_monotonic();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_usleep([NativeTypeName("unsigned int")] uint usec);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_parse_ratio(AVRational* q, [NativeTypeName("const char *")] sbyte* str, int max, int log_offset, void* log_ctx);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_parse_video_size(int* width_ptr, int* height_ptr, [NativeTypeName("const char *")] sbyte* str);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_parse_video_rate(AVRational* rate, [NativeTypeName("const char *")] sbyte* str);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_parse_color([NativeTypeName("uint8_t *")] byte* rgba_color, [NativeTypeName("const char *")] sbyte* color_string, int slen, void* log_ctx);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_get_known_color_name(int color_idx, [NativeTypeName("const uint8_t **")] byte** rgb);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_parse_time([NativeTypeName("int64_t *")] long* timeval, [NativeTypeName("const char *")] sbyte* timestr, int duration);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_find_info_tag([NativeTypeName("char *")] sbyte* arg, int arg_size, [NativeTypeName("const char *")] sbyte* tag1, [NativeTypeName("const char *")] sbyte* info);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* av_small_strptime([NativeTypeName("const char *")] sbyte* p, [NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("struct tm *")] tm* dt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("time_t")]
        public static extern long av_timegm();

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_bits_per_pixel([NativeTypeName("const AVPixFmtDescriptor *")] AVPixFmtDescriptor* pixdesc);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_padded_bits_per_pixel([NativeTypeName("const AVPixFmtDescriptor *")] AVPixFmtDescriptor* pixdesc);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVPixFmtDescriptor *")]
        public static extern AVPixFmtDescriptor* av_pix_fmt_desc_get([NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVPixFmtDescriptor *")]
        public static extern AVPixFmtDescriptor* av_pix_fmt_desc_next([NativeTypeName("const AVPixFmtDescriptor *")] AVPixFmtDescriptor* prev);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVPixelFormat")]
        public static extern AVPixelFormat av_pix_fmt_desc_get_id([NativeTypeName("const AVPixFmtDescriptor *")] AVPixFmtDescriptor* desc);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_pix_fmt_get_chroma_sub_sample([NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt, int* h_shift, int* v_shift);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_pix_fmt_count_planes([NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_color_range_name([NativeTypeName("enum AVColorRange")] AVColorRange range);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_color_range_from_name([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_color_primaries_name([NativeTypeName("enum AVColorPrimaries")] AVColorPrimaries primaries);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_color_primaries_from_name([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_color_transfer_name([NativeTypeName("enum AVColorTransferCharacteristic")] AVColorTransferCharacteristic transfer);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_color_transfer_from_name([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_color_space_name([NativeTypeName("enum AVColorSpace")] AVColorSpace space);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_color_space_from_name([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_chroma_location_name([NativeTypeName("enum AVChromaLocation")] AVChromaLocation location);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_chroma_location_from_name([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVPixelFormat")]
        public static extern AVPixelFormat av_get_pix_fmt([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_get_pix_fmt_name([NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* av_get_pix_fmt_string([NativeTypeName("char *")] sbyte* buf, int buf_size, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_read_image_line2(void* dst, [NativeTypeName("const uint8_t *[4]")] byte** data, [NativeTypeName("const int[4]")] int* linesize, [NativeTypeName("const AVPixFmtDescriptor *")] AVPixFmtDescriptor* desc, int x, int y, int c, int w, int read_pal_component, int dst_element_size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_read_image_line([NativeTypeName("uint16_t *")] ushort* dst, [NativeTypeName("const uint8_t *[4]")] byte** data, [NativeTypeName("const int[4]")] int* linesize, [NativeTypeName("const AVPixFmtDescriptor *")] AVPixFmtDescriptor* desc, int x, int y, int c, int w, int read_pal_component);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_write_image_line2([NativeTypeName("const void *")] void* src, [NativeTypeName("uint8_t *[4]")] byte** data, [NativeTypeName("const int[4]")] int* linesize, [NativeTypeName("const AVPixFmtDescriptor *")] AVPixFmtDescriptor* desc, int x, int y, int c, int w, int src_element_size);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_write_image_line([NativeTypeName("const uint16_t *")] ushort* src, [NativeTypeName("uint8_t *[4]")] byte** data, [NativeTypeName("const int[4]")] int* linesize, [NativeTypeName("const AVPixFmtDescriptor *")] AVPixFmtDescriptor* desc, int x, int y, int c, int w);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVPixelFormat")]
        public static extern AVPixelFormat av_pix_fmt_swap_endianness([NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_pix_fmt_loss([NativeTypeName("enum AVPixelFormat")] AVPixelFormat dst_pix_fmt, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat src_pix_fmt, int has_alpha);

        [DllImport("avutil-56.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVPixelFormat")]
        public static extern AVPixelFormat av_find_best_pix_fmt_of_2([NativeTypeName("enum AVPixelFormat")] AVPixelFormat dst_pix_fmt1, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat dst_pix_fmt2, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat src_pix_fmt, int has_alpha, int* loss_ptr);

        [NativeTypeName("#define FF_LAMBDA_SHIFT 7")]
        public const int FF_LAMBDA_SHIFT = 7;

        [NativeTypeName("#define FF_LAMBDA_SCALE (1<<FF_LAMBDA_SHIFT)")]
        public const int FF_LAMBDA_SCALE = (1 << 7);

        [NativeTypeName("#define FF_QP2LAMBDA 118")]
        public const int FF_QP2LAMBDA = 118;

        [NativeTypeName("#define FF_LAMBDA_MAX (256*128-1)")]
        public const int FF_LAMBDA_MAX = (256 * 128 - 1);

        [NativeTypeName("#define FF_QUALITY_SCALE FF_LAMBDA_SCALE")]
        public const int FF_QUALITY_SCALE = (1 << 7);

        [NativeTypeName("#define AV_NOPTS_VALUE ((int64_t)UINT64_C(0x8000000000000000))")]
        public const long AV_NOPTS_VALUE = unchecked((long)(0x8000000000000000UL));

        [NativeTypeName("#define AV_TIME_BASE 1000000")]
        public const int AV_TIME_BASE = 1000000;

        [NativeTypeName("#define LIBAVUTIL_VERSION_MAJOR 56")]
        public const int LIBAVUTIL_VERSION_MAJOR = 56;

        [NativeTypeName("#define LIBAVUTIL_VERSION_MINOR 70")]
        public const int LIBAVUTIL_VERSION_MINOR = 70;

        [NativeTypeName("#define LIBAVUTIL_VERSION_MICRO 100")]
        public const int LIBAVUTIL_VERSION_MICRO = 100;

        [NativeTypeName("#define LIBAVUTIL_VERSION_INT AV_VERSION_INT(LIBAVUTIL_VERSION_MAJOR, \\\n                                               LIBAVUTIL_VERSION_MINOR, \\\n                                               LIBAVUTIL_VERSION_MICRO)")]
        public const int LIBAVUTIL_VERSION_INT = ((56) << 16 | (70) << 8 | (100));

        [NativeTypeName("#define LIBAVUTIL_BUILD LIBAVUTIL_VERSION_INT")]
        public const int LIBAVUTIL_BUILD = ((56) << 16 | (70) << 8 | (100));

        [NativeTypeName("#define LIBAVUTIL_IDENT \"Lavu\" AV_STRINGIFY(LIBAVUTIL_VERSION)")]
        public static ReadOnlySpan<byte> LIBAVUTIL_IDENT => new byte[] { 0x4C, 0x61, 0x76, 0x75, 0x35, 0x36, 0x2E, 0x37, 0x30, 0x2E, 0x31, 0x30, 0x30, 0x00 };

        [NativeTypeName("#define FF_API_VAAPI (LIBAVUTIL_VERSION_MAJOR < 57)")]
        public const bool FF_API_VAAPI = (56 < 57);

        [NativeTypeName("#define FF_API_FRAME_QP (LIBAVUTIL_VERSION_MAJOR < 57)")]
        public const bool FF_API_FRAME_QP = (56 < 57);

        [NativeTypeName("#define FF_API_PLUS1_MINUS1 (LIBAVUTIL_VERSION_MAJOR < 57)")]
        public const bool FF_API_PLUS1_MINUS1 = (56 < 57);

        [NativeTypeName("#define FF_API_ERROR_FRAME (LIBAVUTIL_VERSION_MAJOR < 57)")]
        public const bool FF_API_ERROR_FRAME = (56 < 57);

        [NativeTypeName("#define FF_API_PKT_PTS (LIBAVUTIL_VERSION_MAJOR < 57)")]
        public const bool FF_API_PKT_PTS = (56 < 57);

        [NativeTypeName("#define FF_API_CRYPTO_SIZE_T (LIBAVUTIL_VERSION_MAJOR < 57)")]
        public const bool FF_API_CRYPTO_SIZE_T = (56 < 57);

        [NativeTypeName("#define FF_API_FRAME_GET_SET (LIBAVUTIL_VERSION_MAJOR < 57)")]
        public const bool FF_API_FRAME_GET_SET = (56 < 57);

        [NativeTypeName("#define FF_API_PSEUDOPAL (LIBAVUTIL_VERSION_MAJOR < 57)")]
        public const bool FF_API_PSEUDOPAL = (56 < 57);

        [NativeTypeName("#define FF_API_CHILD_CLASS_NEXT (LIBAVUTIL_VERSION_MAJOR < 57)")]
        public const bool FF_API_CHILD_CLASS_NEXT = (56 < 57);

        [NativeTypeName("#define FF_API_BUFFER_SIZE_T (LIBAVUTIL_VERSION_MAJOR < 57)")]
        public const bool FF_API_BUFFER_SIZE_T = (56 < 57);

        [NativeTypeName("#define FF_API_D2STR (LIBAVUTIL_VERSION_MAJOR < 58)")]
        public const bool FF_API_D2STR = (56 < 58);

        [NativeTypeName("#define FF_API_DECLARE_ALIGNED (LIBAVUTIL_VERSION_MAJOR < 58)")]
        public const bool FF_API_DECLARE_ALIGNED = (56 < 58);

        [NativeTypeName("#define AV_ERROR_MAX_STRING_SIZE 64")]
        public const int AV_ERROR_MAX_STRING_SIZE = 64;

        [NativeTypeName("#define M_E 2.7182818284590452354")]
        public const double M_E = 2.7182818284590452354;

        [NativeTypeName("#define M_LN2 0.69314718055994530942")]
        public const double M_LN2 = 0.69314718055994530942;

        [NativeTypeName("#define M_LN10 2.30258509299404568402")]
        public const double M_LN10 = 2.30258509299404568402;

        [NativeTypeName("#define M_LOG2_10 3.32192809488736234787")]
        public const double M_LOG2_10 = 3.32192809488736234787;

        [NativeTypeName("#define M_PHI 1.61803398874989484820")]
        public const double M_PHI = 1.61803398874989484820;

        [NativeTypeName("#define M_PI 3.14159265358979323846")]
        public const double M_PI = 3.14159265358979323846;

        [NativeTypeName("#define M_PI_2 1.57079632679489661923")]
        public const double M_PI_2 = 1.57079632679489661923;

        [NativeTypeName("#define M_SQRT1_2 0.70710678118654752440")]
        public const double M_SQRT1_2 = 0.70710678118654752440;

        [NativeTypeName("#define M_SQRT2 1.41421356237309504880")]
        public const double M_SQRT2 = 1.41421356237309504880;

        [NativeTypeName("#define AV_LOG_QUIET -8")]
        public const int AV_LOG_QUIET = -8;

        [NativeTypeName("#define AV_LOG_PANIC 0")]
        public const int AV_LOG_PANIC = 0;

        [NativeTypeName("#define AV_LOG_FATAL 8")]
        public const int AV_LOG_FATAL = 8;

        [NativeTypeName("#define AV_LOG_ERROR 16")]
        public const int AV_LOG_ERROR = 16;

        [NativeTypeName("#define AV_LOG_WARNING 24")]
        public const int AV_LOG_WARNING = 24;

        [NativeTypeName("#define AV_LOG_INFO 32")]
        public const int AV_LOG_INFO = 32;

        [NativeTypeName("#define AV_LOG_VERBOSE 40")]
        public const int AV_LOG_VERBOSE = 40;

        [NativeTypeName("#define AV_LOG_DEBUG 48")]
        public const int AV_LOG_DEBUG = 48;

        [NativeTypeName("#define AV_LOG_TRACE 56")]
        public const int AV_LOG_TRACE = 56;

        [NativeTypeName("#define AV_LOG_MAX_OFFSET (AV_LOG_TRACE - AV_LOG_QUIET)")]
        public const int AV_LOG_MAX_OFFSET = unchecked(56 - -8);

        [NativeTypeName("#define AV_LOG_SKIP_REPEATED 1")]
        public const int AV_LOG_SKIP_REPEATED = 1;

        [NativeTypeName("#define AV_LOG_PRINT_LEVEL 2")]
        public const int AV_LOG_PRINT_LEVEL = 2;

        [NativeTypeName("#define AVPALETTE_SIZE 1024")]
        public const int AVPALETTE_SIZE = 1024;

        [NativeTypeName("#define AVPALETTE_COUNT 256")]
        public const int AVPALETTE_COUNT = 256;

        [NativeTypeName("#define AV_PIX_FMT_RGB32 AV_PIX_FMT_NE(ARGB, BGRA)")]
        public const AVPixelFormat AV_PIX_FMT_RGB32 = AV_PIX_FMT_BGRA;

        [NativeTypeName("#define AV_PIX_FMT_RGB32_1 AV_PIX_FMT_NE(RGBA, ABGR)")]
        public const AVPixelFormat AV_PIX_FMT_RGB32_1 = AV_PIX_FMT_ABGR;

        [NativeTypeName("#define AV_PIX_FMT_BGR32 AV_PIX_FMT_NE(ABGR, RGBA)")]
        public const AVPixelFormat AV_PIX_FMT_BGR32 = AV_PIX_FMT_RGBA;

        [NativeTypeName("#define AV_PIX_FMT_BGR32_1 AV_PIX_FMT_NE(BGRA, ARGB)")]
        public const AVPixelFormat AV_PIX_FMT_BGR32_1 = AV_PIX_FMT_ARGB;

        [NativeTypeName("#define AV_PIX_FMT_0RGB32 AV_PIX_FMT_NE(0RGB, BGR0)")]
        public const AVPixelFormat AV_PIX_FMT_0RGB32 = AV_PIX_FMT_BGR0;

        [NativeTypeName("#define AV_PIX_FMT_0BGR32 AV_PIX_FMT_NE(0BGR, RGB0)")]
        public const AVPixelFormat AV_PIX_FMT_0BGR32 = AV_PIX_FMT_RGB0;

        [NativeTypeName("#define AV_PIX_FMT_GRAY9 AV_PIX_FMT_NE(GRAY9BE,  GRAY9LE)")]
        public const AVPixelFormat AV_PIX_FMT_GRAY9 = AV_PIX_FMT_GRAY9LE;

        [NativeTypeName("#define AV_PIX_FMT_GRAY10 AV_PIX_FMT_NE(GRAY10BE, GRAY10LE)")]
        public const AVPixelFormat AV_PIX_FMT_GRAY10 = AV_PIX_FMT_GRAY10LE;

        [NativeTypeName("#define AV_PIX_FMT_GRAY12 AV_PIX_FMT_NE(GRAY12BE, GRAY12LE)")]
        public const AVPixelFormat AV_PIX_FMT_GRAY12 = AV_PIX_FMT_GRAY12LE;

        [NativeTypeName("#define AV_PIX_FMT_GRAY14 AV_PIX_FMT_NE(GRAY14BE, GRAY14LE)")]
        public const AVPixelFormat AV_PIX_FMT_GRAY14 = AV_PIX_FMT_GRAY14LE;

        [NativeTypeName("#define AV_PIX_FMT_GRAY16 AV_PIX_FMT_NE(GRAY16BE, GRAY16LE)")]
        public const AVPixelFormat AV_PIX_FMT_GRAY16 = AV_PIX_FMT_GRAY16LE;

        [NativeTypeName("#define AV_PIX_FMT_YA16 AV_PIX_FMT_NE(YA16BE,   YA16LE)")]
        public const AVPixelFormat AV_PIX_FMT_YA16 = AV_PIX_FMT_YA16LE;

        [NativeTypeName("#define AV_PIX_FMT_RGB48 AV_PIX_FMT_NE(RGB48BE,  RGB48LE)")]
        public const AVPixelFormat AV_PIX_FMT_RGB48 = AV_PIX_FMT_RGB48LE;

        [NativeTypeName("#define AV_PIX_FMT_RGB565 AV_PIX_FMT_NE(RGB565BE, RGB565LE)")]
        public const AVPixelFormat AV_PIX_FMT_RGB565 = AV_PIX_FMT_RGB565LE;

        [NativeTypeName("#define AV_PIX_FMT_RGB555 AV_PIX_FMT_NE(RGB555BE, RGB555LE)")]
        public const AVPixelFormat AV_PIX_FMT_RGB555 = AV_PIX_FMT_RGB555LE;

        [NativeTypeName("#define AV_PIX_FMT_RGB444 AV_PIX_FMT_NE(RGB444BE, RGB444LE)")]
        public const AVPixelFormat AV_PIX_FMT_RGB444 = AV_PIX_FMT_RGB444LE;

        [NativeTypeName("#define AV_PIX_FMT_RGBA64 AV_PIX_FMT_NE(RGBA64BE, RGBA64LE)")]
        public const AVPixelFormat AV_PIX_FMT_RGBA64 = AV_PIX_FMT_RGBA64LE;

        [NativeTypeName("#define AV_PIX_FMT_BGR48 AV_PIX_FMT_NE(BGR48BE,  BGR48LE)")]
        public const AVPixelFormat AV_PIX_FMT_BGR48 = AV_PIX_FMT_BGR48LE;

        [NativeTypeName("#define AV_PIX_FMT_BGR565 AV_PIX_FMT_NE(BGR565BE, BGR565LE)")]
        public const AVPixelFormat AV_PIX_FMT_BGR565 = AV_PIX_FMT_BGR565LE;

        [NativeTypeName("#define AV_PIX_FMT_BGR555 AV_PIX_FMT_NE(BGR555BE, BGR555LE)")]
        public const AVPixelFormat AV_PIX_FMT_BGR555 = AV_PIX_FMT_BGR555LE;

        [NativeTypeName("#define AV_PIX_FMT_BGR444 AV_PIX_FMT_NE(BGR444BE, BGR444LE)")]
        public const AVPixelFormat AV_PIX_FMT_BGR444 = AV_PIX_FMT_BGR444LE;

        [NativeTypeName("#define AV_PIX_FMT_BGRA64 AV_PIX_FMT_NE(BGRA64BE, BGRA64LE)")]
        public const AVPixelFormat AV_PIX_FMT_BGRA64 = AV_PIX_FMT_BGRA64LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV420P9 AV_PIX_FMT_NE(YUV420P9BE , YUV420P9LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV420P9 = AV_PIX_FMT_YUV420P9LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV422P9 AV_PIX_FMT_NE(YUV422P9BE , YUV422P9LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV422P9 = AV_PIX_FMT_YUV422P9LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV444P9 AV_PIX_FMT_NE(YUV444P9BE , YUV444P9LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV444P9 = AV_PIX_FMT_YUV444P9LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV420P10 AV_PIX_FMT_NE(YUV420P10BE, YUV420P10LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV420P10 = AV_PIX_FMT_YUV420P10LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV422P10 AV_PIX_FMT_NE(YUV422P10BE, YUV422P10LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV422P10 = AV_PIX_FMT_YUV422P10LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV440P10 AV_PIX_FMT_NE(YUV440P10BE, YUV440P10LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV440P10 = AV_PIX_FMT_YUV440P10LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV444P10 AV_PIX_FMT_NE(YUV444P10BE, YUV444P10LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV444P10 = AV_PIX_FMT_YUV444P10LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV420P12 AV_PIX_FMT_NE(YUV420P12BE, YUV420P12LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV420P12 = AV_PIX_FMT_YUV420P12LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV422P12 AV_PIX_FMT_NE(YUV422P12BE, YUV422P12LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV422P12 = AV_PIX_FMT_YUV422P12LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV440P12 AV_PIX_FMT_NE(YUV440P12BE, YUV440P12LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV440P12 = AV_PIX_FMT_YUV440P12LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV444P12 AV_PIX_FMT_NE(YUV444P12BE, YUV444P12LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV444P12 = AV_PIX_FMT_YUV444P12LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV420P14 AV_PIX_FMT_NE(YUV420P14BE, YUV420P14LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV420P14 = AV_PIX_FMT_YUV420P14LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV422P14 AV_PIX_FMT_NE(YUV422P14BE, YUV422P14LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV422P14 = AV_PIX_FMT_YUV422P14LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV444P14 AV_PIX_FMT_NE(YUV444P14BE, YUV444P14LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV444P14 = AV_PIX_FMT_YUV444P14LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV420P16 AV_PIX_FMT_NE(YUV420P16BE, YUV420P16LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV420P16 = AV_PIX_FMT_YUV420P16LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV422P16 AV_PIX_FMT_NE(YUV422P16BE, YUV422P16LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV422P16 = AV_PIX_FMT_YUV422P16LE;

        [NativeTypeName("#define AV_PIX_FMT_YUV444P16 AV_PIX_FMT_NE(YUV444P16BE, YUV444P16LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUV444P16 = AV_PIX_FMT_YUV444P16LE;

        [NativeTypeName("#define AV_PIX_FMT_GBRP9 AV_PIX_FMT_NE(GBRP9BE ,    GBRP9LE)")]
        public const AVPixelFormat AV_PIX_FMT_GBRP9 = AV_PIX_FMT_GBRP9LE;

        [NativeTypeName("#define AV_PIX_FMT_GBRP10 AV_PIX_FMT_NE(GBRP10BE,    GBRP10LE)")]
        public const AVPixelFormat AV_PIX_FMT_GBRP10 = AV_PIX_FMT_GBRP10LE;

        [NativeTypeName("#define AV_PIX_FMT_GBRP12 AV_PIX_FMT_NE(GBRP12BE,    GBRP12LE)")]
        public const AVPixelFormat AV_PIX_FMT_GBRP12 = AV_PIX_FMT_GBRP12LE;

        [NativeTypeName("#define AV_PIX_FMT_GBRP14 AV_PIX_FMT_NE(GBRP14BE,    GBRP14LE)")]
        public const AVPixelFormat AV_PIX_FMT_GBRP14 = AV_PIX_FMT_GBRP14LE;

        [NativeTypeName("#define AV_PIX_FMT_GBRP16 AV_PIX_FMT_NE(GBRP16BE,    GBRP16LE)")]
        public const AVPixelFormat AV_PIX_FMT_GBRP16 = AV_PIX_FMT_GBRP16LE;

        [NativeTypeName("#define AV_PIX_FMT_GBRAP10 AV_PIX_FMT_NE(GBRAP10BE,   GBRAP10LE)")]
        public const AVPixelFormat AV_PIX_FMT_GBRAP10 = AV_PIX_FMT_GBRAP10LE;

        [NativeTypeName("#define AV_PIX_FMT_GBRAP12 AV_PIX_FMT_NE(GBRAP12BE,   GBRAP12LE)")]
        public const AVPixelFormat AV_PIX_FMT_GBRAP12 = AV_PIX_FMT_GBRAP12LE;

        [NativeTypeName("#define AV_PIX_FMT_GBRAP16 AV_PIX_FMT_NE(GBRAP16BE,   GBRAP16LE)")]
        public const AVPixelFormat AV_PIX_FMT_GBRAP16 = AV_PIX_FMT_GBRAP16LE;

        [NativeTypeName("#define AV_PIX_FMT_BAYER_BGGR16 AV_PIX_FMT_NE(BAYER_BGGR16BE,    BAYER_BGGR16LE)")]
        public const AVPixelFormat AV_PIX_FMT_BAYER_BGGR16 = AV_PIX_FMT_BAYER_BGGR16LE;

        [NativeTypeName("#define AV_PIX_FMT_BAYER_RGGB16 AV_PIX_FMT_NE(BAYER_RGGB16BE,    BAYER_RGGB16LE)")]
        public const AVPixelFormat AV_PIX_FMT_BAYER_RGGB16 = AV_PIX_FMT_BAYER_RGGB16LE;

        [NativeTypeName("#define AV_PIX_FMT_BAYER_GBRG16 AV_PIX_FMT_NE(BAYER_GBRG16BE,    BAYER_GBRG16LE)")]
        public const AVPixelFormat AV_PIX_FMT_BAYER_GBRG16 = AV_PIX_FMT_BAYER_GBRG16LE;

        [NativeTypeName("#define AV_PIX_FMT_BAYER_GRBG16 AV_PIX_FMT_NE(BAYER_GRBG16BE,    BAYER_GRBG16LE)")]
        public const AVPixelFormat AV_PIX_FMT_BAYER_GRBG16 = AV_PIX_FMT_BAYER_GRBG16LE;

        [NativeTypeName("#define AV_PIX_FMT_GBRPF32 AV_PIX_FMT_NE(GBRPF32BE,  GBRPF32LE)")]
        public const AVPixelFormat AV_PIX_FMT_GBRPF32 = AV_PIX_FMT_GBRPF32LE;

        [NativeTypeName("#define AV_PIX_FMT_GBRAPF32 AV_PIX_FMT_NE(GBRAPF32BE, GBRAPF32LE)")]
        public const AVPixelFormat AV_PIX_FMT_GBRAPF32 = AV_PIX_FMT_GBRAPF32LE;

        [NativeTypeName("#define AV_PIX_FMT_GRAYF32 AV_PIX_FMT_NE(GRAYF32BE, GRAYF32LE)")]
        public const AVPixelFormat AV_PIX_FMT_GRAYF32 = AV_PIX_FMT_GRAYF32LE;

        [NativeTypeName("#define AV_PIX_FMT_YUVA420P9 AV_PIX_FMT_NE(YUVA420P9BE , YUVA420P9LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUVA420P9 = AV_PIX_FMT_YUVA420P9LE;

        [NativeTypeName("#define AV_PIX_FMT_YUVA422P9 AV_PIX_FMT_NE(YUVA422P9BE , YUVA422P9LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUVA422P9 = AV_PIX_FMT_YUVA422P9LE;

        [NativeTypeName("#define AV_PIX_FMT_YUVA444P9 AV_PIX_FMT_NE(YUVA444P9BE , YUVA444P9LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUVA444P9 = AV_PIX_FMT_YUVA444P9LE;

        [NativeTypeName("#define AV_PIX_FMT_YUVA420P10 AV_PIX_FMT_NE(YUVA420P10BE, YUVA420P10LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUVA420P10 = AV_PIX_FMT_YUVA420P10LE;

        [NativeTypeName("#define AV_PIX_FMT_YUVA422P10 AV_PIX_FMT_NE(YUVA422P10BE, YUVA422P10LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUVA422P10 = AV_PIX_FMT_YUVA422P10LE;

        [NativeTypeName("#define AV_PIX_FMT_YUVA444P10 AV_PIX_FMT_NE(YUVA444P10BE, YUVA444P10LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUVA444P10 = AV_PIX_FMT_YUVA444P10LE;

        [NativeTypeName("#define AV_PIX_FMT_YUVA422P12 AV_PIX_FMT_NE(YUVA422P12BE, YUVA422P12LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUVA422P12 = AV_PIX_FMT_YUVA422P12LE;

        [NativeTypeName("#define AV_PIX_FMT_YUVA444P12 AV_PIX_FMT_NE(YUVA444P12BE, YUVA444P12LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUVA444P12 = AV_PIX_FMT_YUVA444P12LE;

        [NativeTypeName("#define AV_PIX_FMT_YUVA420P16 AV_PIX_FMT_NE(YUVA420P16BE, YUVA420P16LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUVA420P16 = AV_PIX_FMT_YUVA420P16LE;

        [NativeTypeName("#define AV_PIX_FMT_YUVA422P16 AV_PIX_FMT_NE(YUVA422P16BE, YUVA422P16LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUVA422P16 = AV_PIX_FMT_YUVA422P16LE;

        [NativeTypeName("#define AV_PIX_FMT_YUVA444P16 AV_PIX_FMT_NE(YUVA444P16BE, YUVA444P16LE)")]
        public const AVPixelFormat AV_PIX_FMT_YUVA444P16 = AV_PIX_FMT_YUVA444P16LE;

        [NativeTypeName("#define AV_PIX_FMT_XYZ12 AV_PIX_FMT_NE(XYZ12BE, XYZ12LE)")]
        public const AVPixelFormat AV_PIX_FMT_XYZ12 = AV_PIX_FMT_XYZ12LE;

        [NativeTypeName("#define AV_PIX_FMT_NV20 AV_PIX_FMT_NE(NV20BE,  NV20LE)")]
        public const AVPixelFormat AV_PIX_FMT_NV20 = AV_PIX_FMT_NV20LE;

        [NativeTypeName("#define AV_PIX_FMT_AYUV64 AV_PIX_FMT_NE(AYUV64BE, AYUV64LE)")]
        public const AVPixelFormat AV_PIX_FMT_AYUV64 = AV_PIX_FMT_AYUV64LE;

        [NativeTypeName("#define AV_PIX_FMT_P010 AV_PIX_FMT_NE(P010BE,  P010LE)")]
        public const AVPixelFormat AV_PIX_FMT_P010 = AV_PIX_FMT_P010LE;

        [NativeTypeName("#define AV_PIX_FMT_P016 AV_PIX_FMT_NE(P016BE,  P016LE)")]
        public const AVPixelFormat AV_PIX_FMT_P016 = AV_PIX_FMT_P016LE;

        [NativeTypeName("#define AV_PIX_FMT_Y210 AV_PIX_FMT_NE(Y210BE,  Y210LE)")]
        public const AVPixelFormat AV_PIX_FMT_Y210 = AV_PIX_FMT_Y210LE;

        [NativeTypeName("#define AV_PIX_FMT_X2RGB10 AV_PIX_FMT_NE(X2RGB10BE, X2RGB10LE)")]
        public const AVPixelFormat AV_PIX_FMT_X2RGB10 = AV_PIX_FMT_X2RGB10LE;

        [NativeTypeName("#define AV_FOURCC_MAX_STRING_SIZE 32")]
        public const int AV_FOURCC_MAX_STRING_SIZE = 32;

        [NativeTypeName("#define AV_BUFFER_FLAG_READONLY (1 << 0)")]
        public const int AV_BUFFER_FLAG_READONLY = (1 << 0);

        [NativeTypeName("#define AV_CH_FRONT_LEFT 0x00000001")]
        public const int AV_CH_FRONT_LEFT = 0x00000001;

        [NativeTypeName("#define AV_CH_FRONT_RIGHT 0x00000002")]
        public const int AV_CH_FRONT_RIGHT = 0x00000002;

        [NativeTypeName("#define AV_CH_FRONT_CENTER 0x00000004")]
        public const int AV_CH_FRONT_CENTER = 0x00000004;

        [NativeTypeName("#define AV_CH_LOW_FREQUENCY 0x00000008")]
        public const int AV_CH_LOW_FREQUENCY = 0x00000008;

        [NativeTypeName("#define AV_CH_BACK_LEFT 0x00000010")]
        public const int AV_CH_BACK_LEFT = 0x00000010;

        [NativeTypeName("#define AV_CH_BACK_RIGHT 0x00000020")]
        public const int AV_CH_BACK_RIGHT = 0x00000020;

        [NativeTypeName("#define AV_CH_FRONT_LEFT_OF_CENTER 0x00000040")]
        public const int AV_CH_FRONT_LEFT_OF_CENTER = 0x00000040;

        [NativeTypeName("#define AV_CH_FRONT_RIGHT_OF_CENTER 0x00000080")]
        public const int AV_CH_FRONT_RIGHT_OF_CENTER = 0x00000080;

        [NativeTypeName("#define AV_CH_BACK_CENTER 0x00000100")]
        public const int AV_CH_BACK_CENTER = 0x00000100;

        [NativeTypeName("#define AV_CH_SIDE_LEFT 0x00000200")]
        public const int AV_CH_SIDE_LEFT = 0x00000200;

        [NativeTypeName("#define AV_CH_SIDE_RIGHT 0x00000400")]
        public const int AV_CH_SIDE_RIGHT = 0x00000400;

        [NativeTypeName("#define AV_CH_TOP_CENTER 0x00000800")]
        public const int AV_CH_TOP_CENTER = 0x00000800;

        [NativeTypeName("#define AV_CH_TOP_FRONT_LEFT 0x00001000")]
        public const int AV_CH_TOP_FRONT_LEFT = 0x00001000;

        [NativeTypeName("#define AV_CH_TOP_FRONT_CENTER 0x00002000")]
        public const int AV_CH_TOP_FRONT_CENTER = 0x00002000;

        [NativeTypeName("#define AV_CH_TOP_FRONT_RIGHT 0x00004000")]
        public const int AV_CH_TOP_FRONT_RIGHT = 0x00004000;

        [NativeTypeName("#define AV_CH_TOP_BACK_LEFT 0x00008000")]
        public const int AV_CH_TOP_BACK_LEFT = 0x00008000;

        [NativeTypeName("#define AV_CH_TOP_BACK_CENTER 0x00010000")]
        public const int AV_CH_TOP_BACK_CENTER = 0x00010000;

        [NativeTypeName("#define AV_CH_TOP_BACK_RIGHT 0x00020000")]
        public const int AV_CH_TOP_BACK_RIGHT = 0x00020000;

        [NativeTypeName("#define AV_CH_STEREO_LEFT 0x20000000")]
        public const int AV_CH_STEREO_LEFT = 0x20000000;

        [NativeTypeName("#define AV_CH_STEREO_RIGHT 0x40000000")]
        public const int AV_CH_STEREO_RIGHT = 0x40000000;

        [NativeTypeName("#define AV_CH_WIDE_LEFT 0x0000000080000000ULL")]
        public const ulong AV_CH_WIDE_LEFT = 0x0000000080000000UL;

        [NativeTypeName("#define AV_CH_WIDE_RIGHT 0x0000000100000000ULL")]
        public const ulong AV_CH_WIDE_RIGHT = 0x0000000100000000UL;

        [NativeTypeName("#define AV_CH_SURROUND_DIRECT_LEFT 0x0000000200000000ULL")]
        public const ulong AV_CH_SURROUND_DIRECT_LEFT = 0x0000000200000000UL;

        [NativeTypeName("#define AV_CH_SURROUND_DIRECT_RIGHT 0x0000000400000000ULL")]
        public const ulong AV_CH_SURROUND_DIRECT_RIGHT = 0x0000000400000000UL;

        [NativeTypeName("#define AV_CH_LOW_FREQUENCY_2 0x0000000800000000ULL")]
        public const ulong AV_CH_LOW_FREQUENCY_2 = 0x0000000800000000UL;

        [NativeTypeName("#define AV_CH_TOP_SIDE_LEFT 0x0000001000000000ULL")]
        public const ulong AV_CH_TOP_SIDE_LEFT = 0x0000001000000000UL;

        [NativeTypeName("#define AV_CH_TOP_SIDE_RIGHT 0x0000002000000000ULL")]
        public const ulong AV_CH_TOP_SIDE_RIGHT = 0x0000002000000000UL;

        [NativeTypeName("#define AV_CH_BOTTOM_FRONT_CENTER 0x0000004000000000ULL")]
        public const ulong AV_CH_BOTTOM_FRONT_CENTER = 0x0000004000000000UL;

        [NativeTypeName("#define AV_CH_BOTTOM_FRONT_LEFT 0x0000008000000000ULL")]
        public const ulong AV_CH_BOTTOM_FRONT_LEFT = 0x0000008000000000UL;

        [NativeTypeName("#define AV_CH_BOTTOM_FRONT_RIGHT 0x0000010000000000ULL")]
        public const ulong AV_CH_BOTTOM_FRONT_RIGHT = 0x0000010000000000UL;

        [NativeTypeName("#define AV_CH_LAYOUT_NATIVE 0x8000000000000000ULL")]
        public const ulong AV_CH_LAYOUT_NATIVE = 0x8000000000000000UL;

        [NativeTypeName("#define AV_CH_LAYOUT_MONO (AV_CH_FRONT_CENTER)")]
        public const int AV_CH_LAYOUT_MONO = (0x00000004);

        [NativeTypeName("#define AV_CH_LAYOUT_STEREO (AV_CH_FRONT_LEFT|AV_CH_FRONT_RIGHT)")]
        public const int AV_CH_LAYOUT_STEREO = (0x00000001 | 0x00000002);

        [NativeTypeName("#define AV_CH_LAYOUT_2POINT1 (AV_CH_LAYOUT_STEREO|AV_CH_LOW_FREQUENCY)")]
        public const int AV_CH_LAYOUT_2POINT1 = ((0x00000001 | 0x00000002) | 0x00000008);

        [NativeTypeName("#define AV_CH_LAYOUT_2_1 (AV_CH_LAYOUT_STEREO|AV_CH_BACK_CENTER)")]
        public const int AV_CH_LAYOUT_2_1 = ((0x00000001 | 0x00000002) | 0x00000100);

        [NativeTypeName("#define AV_CH_LAYOUT_SURROUND (AV_CH_LAYOUT_STEREO|AV_CH_FRONT_CENTER)")]
        public const int AV_CH_LAYOUT_SURROUND = ((0x00000001 | 0x00000002) | 0x00000004);

        [NativeTypeName("#define AV_CH_LAYOUT_3POINT1 (AV_CH_LAYOUT_SURROUND|AV_CH_LOW_FREQUENCY)")]
        public const int AV_CH_LAYOUT_3POINT1 = (((0x00000001 | 0x00000002) | 0x00000004) | 0x00000008);

        [NativeTypeName("#define AV_CH_LAYOUT_4POINT0 (AV_CH_LAYOUT_SURROUND|AV_CH_BACK_CENTER)")]
        public const int AV_CH_LAYOUT_4POINT0 = (((0x00000001 | 0x00000002) | 0x00000004) | 0x00000100);

        [NativeTypeName("#define AV_CH_LAYOUT_4POINT1 (AV_CH_LAYOUT_4POINT0|AV_CH_LOW_FREQUENCY)")]
        public const int AV_CH_LAYOUT_4POINT1 = ((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000100) | 0x00000008);

        [NativeTypeName("#define AV_CH_LAYOUT_2_2 (AV_CH_LAYOUT_STEREO|AV_CH_SIDE_LEFT|AV_CH_SIDE_RIGHT)")]
        public const int AV_CH_LAYOUT_2_2 = ((0x00000001 | 0x00000002) | 0x00000200 | 0x00000400);

        [NativeTypeName("#define AV_CH_LAYOUT_QUAD (AV_CH_LAYOUT_STEREO|AV_CH_BACK_LEFT|AV_CH_BACK_RIGHT)")]
        public const int AV_CH_LAYOUT_QUAD = ((0x00000001 | 0x00000002) | 0x00000010 | 0x00000020);

        [NativeTypeName("#define AV_CH_LAYOUT_5POINT0 (AV_CH_LAYOUT_SURROUND|AV_CH_SIDE_LEFT|AV_CH_SIDE_RIGHT)")]
        public const int AV_CH_LAYOUT_5POINT0 = (((0x00000001 | 0x00000002) | 0x00000004) | 0x00000200 | 0x00000400);

        [NativeTypeName("#define AV_CH_LAYOUT_5POINT1 (AV_CH_LAYOUT_5POINT0|AV_CH_LOW_FREQUENCY)")]
        public const int AV_CH_LAYOUT_5POINT1 = ((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000200 | 0x00000400) | 0x00000008);

        [NativeTypeName("#define AV_CH_LAYOUT_5POINT0_BACK (AV_CH_LAYOUT_SURROUND|AV_CH_BACK_LEFT|AV_CH_BACK_RIGHT)")]
        public const int AV_CH_LAYOUT_5POINT0_BACK = (((0x00000001 | 0x00000002) | 0x00000004) | 0x00000010 | 0x00000020);

        [NativeTypeName("#define AV_CH_LAYOUT_5POINT1_BACK (AV_CH_LAYOUT_5POINT0_BACK|AV_CH_LOW_FREQUENCY)")]
        public const int AV_CH_LAYOUT_5POINT1_BACK = ((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000010 | 0x00000020) | 0x00000008);

        [NativeTypeName("#define AV_CH_LAYOUT_6POINT0 (AV_CH_LAYOUT_5POINT0|AV_CH_BACK_CENTER)")]
        public const int AV_CH_LAYOUT_6POINT0 = ((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000200 | 0x00000400) | 0x00000100);

        [NativeTypeName("#define AV_CH_LAYOUT_6POINT0_FRONT (AV_CH_LAYOUT_2_2|AV_CH_FRONT_LEFT_OF_CENTER|AV_CH_FRONT_RIGHT_OF_CENTER)")]
        public const int AV_CH_LAYOUT_6POINT0_FRONT = (((0x00000001 | 0x00000002) | 0x00000200 | 0x00000400) | 0x00000040 | 0x00000080);

        [NativeTypeName("#define AV_CH_LAYOUT_HEXAGONAL (AV_CH_LAYOUT_5POINT0_BACK|AV_CH_BACK_CENTER)")]
        public const int AV_CH_LAYOUT_HEXAGONAL = ((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000010 | 0x00000020) | 0x00000100);

        [NativeTypeName("#define AV_CH_LAYOUT_6POINT1 (AV_CH_LAYOUT_5POINT1|AV_CH_BACK_CENTER)")]
        public const int AV_CH_LAYOUT_6POINT1 = (((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000200 | 0x00000400) | 0x00000008) | 0x00000100);

        [NativeTypeName("#define AV_CH_LAYOUT_6POINT1_BACK (AV_CH_LAYOUT_5POINT1_BACK|AV_CH_BACK_CENTER)")]
        public const int AV_CH_LAYOUT_6POINT1_BACK = (((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000010 | 0x00000020) | 0x00000008) | 0x00000100);

        [NativeTypeName("#define AV_CH_LAYOUT_6POINT1_FRONT (AV_CH_LAYOUT_6POINT0_FRONT|AV_CH_LOW_FREQUENCY)")]
        public const int AV_CH_LAYOUT_6POINT1_FRONT = ((((0x00000001 | 0x00000002) | 0x00000200 | 0x00000400) | 0x00000040 | 0x00000080) | 0x00000008);

        [NativeTypeName("#define AV_CH_LAYOUT_7POINT0 (AV_CH_LAYOUT_5POINT0|AV_CH_BACK_LEFT|AV_CH_BACK_RIGHT)")]
        public const int AV_CH_LAYOUT_7POINT0 = ((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000200 | 0x00000400) | 0x00000010 | 0x00000020);

        [NativeTypeName("#define AV_CH_LAYOUT_7POINT0_FRONT (AV_CH_LAYOUT_5POINT0|AV_CH_FRONT_LEFT_OF_CENTER|AV_CH_FRONT_RIGHT_OF_CENTER)")]
        public const int AV_CH_LAYOUT_7POINT0_FRONT = ((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000200 | 0x00000400) | 0x00000040 | 0x00000080);

        [NativeTypeName("#define AV_CH_LAYOUT_7POINT1 (AV_CH_LAYOUT_5POINT1|AV_CH_BACK_LEFT|AV_CH_BACK_RIGHT)")]
        public const int AV_CH_LAYOUT_7POINT1 = (((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000200 | 0x00000400) | 0x00000008) | 0x00000010 | 0x00000020);

        [NativeTypeName("#define AV_CH_LAYOUT_7POINT1_WIDE (AV_CH_LAYOUT_5POINT1|AV_CH_FRONT_LEFT_OF_CENTER|AV_CH_FRONT_RIGHT_OF_CENTER)")]
        public const int AV_CH_LAYOUT_7POINT1_WIDE = (((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000200 | 0x00000400) | 0x00000008) | 0x00000040 | 0x00000080);

        [NativeTypeName("#define AV_CH_LAYOUT_7POINT1_WIDE_BACK (AV_CH_LAYOUT_5POINT1_BACK|AV_CH_FRONT_LEFT_OF_CENTER|AV_CH_FRONT_RIGHT_OF_CENTER)")]
        public const int AV_CH_LAYOUT_7POINT1_WIDE_BACK = (((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000010 | 0x00000020) | 0x00000008) | 0x00000040 | 0x00000080);

        [NativeTypeName("#define AV_CH_LAYOUT_OCTAGONAL (AV_CH_LAYOUT_5POINT0|AV_CH_BACK_LEFT|AV_CH_BACK_CENTER|AV_CH_BACK_RIGHT)")]
        public const int AV_CH_LAYOUT_OCTAGONAL = ((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000200 | 0x00000400) | 0x00000010 | 0x00000100 | 0x00000020);

        [NativeTypeName("#define AV_CH_LAYOUT_HEXADECAGONAL (AV_CH_LAYOUT_OCTAGONAL|AV_CH_WIDE_LEFT|AV_CH_WIDE_RIGHT|AV_CH_TOP_BACK_LEFT|AV_CH_TOP_BACK_RIGHT|AV_CH_TOP_BACK_CENTER|AV_CH_TOP_FRONT_CENTER|AV_CH_TOP_FRONT_LEFT|AV_CH_TOP_FRONT_RIGHT)")]
        public const ulong AV_CH_LAYOUT_HEXADECAGONAL = (((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000200 | 0x00000400) | 0x00000010 | 0x00000100 | 0x00000020) | 0x0000000080000000UL | 0x0000000100000000UL | 0x00008000 | 0x00020000 | 0x00010000 | 0x00002000 | 0x00001000 | 0x00004000);

        [NativeTypeName("#define AV_CH_LAYOUT_STEREO_DOWNMIX (AV_CH_STEREO_LEFT|AV_CH_STEREO_RIGHT)")]
        public const int AV_CH_LAYOUT_STEREO_DOWNMIX = (0x20000000 | 0x40000000);

        [NativeTypeName("#define AV_CH_LAYOUT_22POINT2 (AV_CH_LAYOUT_5POINT1_BACK|AV_CH_FRONT_LEFT_OF_CENTER|AV_CH_FRONT_RIGHT_OF_CENTER|AV_CH_BACK_CENTER|AV_CH_LOW_FREQUENCY_2|AV_CH_SIDE_LEFT|AV_CH_SIDE_RIGHT|AV_CH_TOP_FRONT_LEFT|AV_CH_TOP_FRONT_RIGHT|AV_CH_TOP_FRONT_CENTER|AV_CH_TOP_CENTER|AV_CH_TOP_BACK_LEFT|AV_CH_TOP_BACK_RIGHT|AV_CH_TOP_SIDE_LEFT|AV_CH_TOP_SIDE_RIGHT|AV_CH_TOP_BACK_CENTER|AV_CH_BOTTOM_FRONT_CENTER|AV_CH_BOTTOM_FRONT_LEFT|AV_CH_BOTTOM_FRONT_RIGHT)")]
        public const ulong AV_CH_LAYOUT_22POINT2 = (((((0x00000001 | 0x00000002) | 0x00000004) | 0x00000010 | 0x00000020) | 0x00000008) | 0x00000040 | 0x00000080 | 0x00000100 | 0x0000000800000000UL | 0x00000200 | 0x00000400 | 0x00001000 | 0x00004000 | 0x00002000 | 0x00000800 | 0x00008000 | 0x00020000 | 0x0000001000000000UL | 0x0000002000000000UL | 0x00010000 | 0x0000004000000000UL | 0x0000008000000000UL | 0x0000010000000000UL);

        [NativeTypeName("#define AV_CPU_FLAG_FORCE 0x80000000")]
        public const uint AV_CPU_FLAG_FORCE = 0x80000000;

        [NativeTypeName("#define AV_CPU_FLAG_MMX 0x0001")]
        public const int AV_CPU_FLAG_MMX = 0x0001;

        [NativeTypeName("#define AV_CPU_FLAG_MMXEXT 0x0002")]
        public const int AV_CPU_FLAG_MMXEXT = 0x0002;

        [NativeTypeName("#define AV_CPU_FLAG_MMX2 0x0002")]
        public const int AV_CPU_FLAG_MMX2 = 0x0002;

        [NativeTypeName("#define AV_CPU_FLAG_3DNOW 0x0004")]
        public const int AV_CPU_FLAG_3DNOW = 0x0004;

        [NativeTypeName("#define AV_CPU_FLAG_SSE 0x0008")]
        public const int AV_CPU_FLAG_SSE = 0x0008;

        [NativeTypeName("#define AV_CPU_FLAG_SSE2 0x0010")]
        public const int AV_CPU_FLAG_SSE2 = 0x0010;

        [NativeTypeName("#define AV_CPU_FLAG_SSE2SLOW 0x40000000")]
        public const int AV_CPU_FLAG_SSE2SLOW = 0x40000000;

        [NativeTypeName("#define AV_CPU_FLAG_3DNOWEXT 0x0020")]
        public const int AV_CPU_FLAG_3DNOWEXT = 0x0020;

        [NativeTypeName("#define AV_CPU_FLAG_SSE3 0x0040")]
        public const int AV_CPU_FLAG_SSE3 = 0x0040;

        [NativeTypeName("#define AV_CPU_FLAG_SSE3SLOW 0x20000000")]
        public const int AV_CPU_FLAG_SSE3SLOW = 0x20000000;

        [NativeTypeName("#define AV_CPU_FLAG_SSSE3 0x0080")]
        public const int AV_CPU_FLAG_SSSE3 = 0x0080;

        [NativeTypeName("#define AV_CPU_FLAG_SSSE3SLOW 0x4000000")]
        public const int AV_CPU_FLAG_SSSE3SLOW = 0x4000000;

        [NativeTypeName("#define AV_CPU_FLAG_ATOM 0x10000000")]
        public const int AV_CPU_FLAG_ATOM = 0x10000000;

        [NativeTypeName("#define AV_CPU_FLAG_SSE4 0x0100")]
        public const int AV_CPU_FLAG_SSE4 = 0x0100;

        [NativeTypeName("#define AV_CPU_FLAG_SSE42 0x0200")]
        public const int AV_CPU_FLAG_SSE42 = 0x0200;

        [NativeTypeName("#define AV_CPU_FLAG_AESNI 0x80000")]
        public const int AV_CPU_FLAG_AESNI = 0x80000;

        [NativeTypeName("#define AV_CPU_FLAG_AVX 0x4000")]
        public const int AV_CPU_FLAG_AVX = 0x4000;

        [NativeTypeName("#define AV_CPU_FLAG_AVXSLOW 0x8000000")]
        public const int AV_CPU_FLAG_AVXSLOW = 0x8000000;

        [NativeTypeName("#define AV_CPU_FLAG_XOP 0x0400")]
        public const int AV_CPU_FLAG_XOP = 0x0400;

        [NativeTypeName("#define AV_CPU_FLAG_FMA4 0x0800")]
        public const int AV_CPU_FLAG_FMA4 = 0x0800;

        [NativeTypeName("#define AV_CPU_FLAG_CMOV 0x1000")]
        public const int AV_CPU_FLAG_CMOV = 0x1000;

        [NativeTypeName("#define AV_CPU_FLAG_AVX2 0x8000")]
        public const int AV_CPU_FLAG_AVX2 = 0x8000;

        [NativeTypeName("#define AV_CPU_FLAG_FMA3 0x10000")]
        public const int AV_CPU_FLAG_FMA3 = 0x10000;

        [NativeTypeName("#define AV_CPU_FLAG_BMI1 0x20000")]
        public const int AV_CPU_FLAG_BMI1 = 0x20000;

        [NativeTypeName("#define AV_CPU_FLAG_BMI2 0x40000")]
        public const int AV_CPU_FLAG_BMI2 = 0x40000;

        [NativeTypeName("#define AV_CPU_FLAG_AVX512 0x100000")]
        public const int AV_CPU_FLAG_AVX512 = 0x100000;

        [NativeTypeName("#define AV_CPU_FLAG_ALTIVEC 0x0001")]
        public const int AV_CPU_FLAG_ALTIVEC = 0x0001;

        [NativeTypeName("#define AV_CPU_FLAG_VSX 0x0002")]
        public const int AV_CPU_FLAG_VSX = 0x0002;

        [NativeTypeName("#define AV_CPU_FLAG_POWER8 0x0004")]
        public const int AV_CPU_FLAG_POWER8 = 0x0004;

        [NativeTypeName("#define AV_CPU_FLAG_ARMV5TE (1 << 0)")]
        public const int AV_CPU_FLAG_ARMV5TE = (1 << 0);

        [NativeTypeName("#define AV_CPU_FLAG_ARMV6 (1 << 1)")]
        public const int AV_CPU_FLAG_ARMV6 = (1 << 1);

        [NativeTypeName("#define AV_CPU_FLAG_ARMV6T2 (1 << 2)")]
        public const int AV_CPU_FLAG_ARMV6T2 = (1 << 2);

        [NativeTypeName("#define AV_CPU_FLAG_VFP (1 << 3)")]
        public const int AV_CPU_FLAG_VFP = (1 << 3);

        [NativeTypeName("#define AV_CPU_FLAG_VFPV3 (1 << 4)")]
        public const int AV_CPU_FLAG_VFPV3 = (1 << 4);

        [NativeTypeName("#define AV_CPU_FLAG_NEON (1 << 5)")]
        public const int AV_CPU_FLAG_NEON = (1 << 5);

        [NativeTypeName("#define AV_CPU_FLAG_ARMV8 (1 << 6)")]
        public const int AV_CPU_FLAG_ARMV8 = (1 << 6);

        [NativeTypeName("#define AV_CPU_FLAG_VFP_VM (1 << 7)")]
        public const int AV_CPU_FLAG_VFP_VM = (1 << 7);

        [NativeTypeName("#define AV_CPU_FLAG_SETEND (1 <<16)")]
        public const int AV_CPU_FLAG_SETEND = (1 << 16);

        [NativeTypeName("#define AV_CPU_FLAG_MMI (1 << 0)")]
        public const int AV_CPU_FLAG_MMI = (1 << 0);

        [NativeTypeName("#define AV_CPU_FLAG_MSA (1 << 1)")]
        public const int AV_CPU_FLAG_MSA = (1 << 1);

        [NativeTypeName("#define AV_DICT_MATCH_CASE 1")]
        public const int AV_DICT_MATCH_CASE = 1;

        [NativeTypeName("#define AV_DICT_IGNORE_SUFFIX 2")]
        public const int AV_DICT_IGNORE_SUFFIX = 2;

        [NativeTypeName("#define AV_DICT_DONT_STRDUP_KEY 4")]
        public const int AV_DICT_DONT_STRDUP_KEY = 4;

        [NativeTypeName("#define AV_DICT_DONT_STRDUP_VAL 8")]
        public const int AV_DICT_DONT_STRDUP_VAL = 8;

        [NativeTypeName("#define AV_DICT_DONT_OVERWRITE 16")]
        public const int AV_DICT_DONT_OVERWRITE = 16;

        [NativeTypeName("#define AV_DICT_APPEND 32")]
        public const int AV_DICT_APPEND = 32;

        [NativeTypeName("#define AV_DICT_MULTIKEY 64")]
        public const int AV_DICT_MULTIKEY = 64;

        [NativeTypeName("#define AV_NUM_DATA_POINTERS 8")]
        public const int AV_NUM_DATA_POINTERS = 8;

        [NativeTypeName("#define AV_FRAME_FLAG_CORRUPT (1 << 0)")]
        public const int AV_FRAME_FLAG_CORRUPT = (1 << 0);

        [NativeTypeName("#define AV_FRAME_FLAG_DISCARD (1 << 2)")]
        public const int AV_FRAME_FLAG_DISCARD = (1 << 2);

        [NativeTypeName("#define FF_DECODE_ERROR_INVALID_BITSTREAM 1")]
        public const int FF_DECODE_ERROR_INVALID_BITSTREAM = 1;

        [NativeTypeName("#define FF_DECODE_ERROR_MISSING_REFERENCE 2")]
        public const int FF_DECODE_ERROR_MISSING_REFERENCE = 2;

        [NativeTypeName("#define FF_DECODE_ERROR_CONCEALMENT_ACTIVE 4")]
        public const int FF_DECODE_ERROR_CONCEALMENT_ACTIVE = 4;

        [NativeTypeName("#define FF_DECODE_ERROR_DECODE_SLICES 8")]
        public const int FF_DECODE_ERROR_DECODE_SLICES = 8;

        [NativeTypeName("#define AV_OPT_FLAG_ENCODING_PARAM 1")]
        public const int AV_OPT_FLAG_ENCODING_PARAM = 1;

        [NativeTypeName("#define AV_OPT_FLAG_DECODING_PARAM 2")]
        public const int AV_OPT_FLAG_DECODING_PARAM = 2;

        [NativeTypeName("#define AV_OPT_FLAG_AUDIO_PARAM 8")]
        public const int AV_OPT_FLAG_AUDIO_PARAM = 8;

        [NativeTypeName("#define AV_OPT_FLAG_VIDEO_PARAM 16")]
        public const int AV_OPT_FLAG_VIDEO_PARAM = 16;

        [NativeTypeName("#define AV_OPT_FLAG_SUBTITLE_PARAM 32")]
        public const int AV_OPT_FLAG_SUBTITLE_PARAM = 32;

        [NativeTypeName("#define AV_OPT_FLAG_EXPORT 64")]
        public const int AV_OPT_FLAG_EXPORT = 64;

        [NativeTypeName("#define AV_OPT_FLAG_READONLY 128")]
        public const int AV_OPT_FLAG_READONLY = 128;

        [NativeTypeName("#define AV_OPT_FLAG_BSF_PARAM (1<<8)")]
        public const int AV_OPT_FLAG_BSF_PARAM = (1 << 8);

        [NativeTypeName("#define AV_OPT_FLAG_RUNTIME_PARAM (1<<15)")]
        public const int AV_OPT_FLAG_RUNTIME_PARAM = (1 << 15);

        [NativeTypeName("#define AV_OPT_FLAG_FILTERING_PARAM (1<<16)")]
        public const int AV_OPT_FLAG_FILTERING_PARAM = (1 << 16);

        [NativeTypeName("#define AV_OPT_FLAG_DEPRECATED (1<<17)")]
        public const int AV_OPT_FLAG_DEPRECATED = (1 << 17);

        [NativeTypeName("#define AV_OPT_FLAG_CHILD_CONSTS (1<<18)")]
        public const int AV_OPT_FLAG_CHILD_CONSTS = (1 << 18);

        [NativeTypeName("#define AV_OPT_SEARCH_CHILDREN (1 << 0)")]
        public const int AV_OPT_SEARCH_CHILDREN = (1 << 0);

        [NativeTypeName("#define AV_OPT_SEARCH_FAKE_OBJ (1 << 1)")]
        public const int AV_OPT_SEARCH_FAKE_OBJ = (1 << 1);

        [NativeTypeName("#define AV_OPT_ALLOW_NULL (1 << 2)")]
        public const int AV_OPT_ALLOW_NULL = (1 << 2);

        [NativeTypeName("#define AV_OPT_MULTI_COMPONENT_RANGE (1 << 12)")]
        public const int AV_OPT_MULTI_COMPONENT_RANGE = (1 << 12);

        [NativeTypeName("#define AV_OPT_SERIALIZE_SKIP_DEFAULTS 0x00000001")]
        public const int AV_OPT_SERIALIZE_SKIP_DEFAULTS = 0x00000001;

        [NativeTypeName("#define AV_OPT_SERIALIZE_OPT_FLAGS_EXACT 0x00000002")]
        public const int AV_OPT_SERIALIZE_OPT_FLAGS_EXACT = 0x00000002;

        [NativeTypeName("#define AV_PIX_FMT_FLAG_BE (1 << 0)")]
        public const int AV_PIX_FMT_FLAG_BE = (1 << 0);

        [NativeTypeName("#define AV_PIX_FMT_FLAG_PAL (1 << 1)")]
        public const int AV_PIX_FMT_FLAG_PAL = (1 << 1);

        [NativeTypeName("#define AV_PIX_FMT_FLAG_BITSTREAM (1 << 2)")]
        public const int AV_PIX_FMT_FLAG_BITSTREAM = (1 << 2);

        [NativeTypeName("#define AV_PIX_FMT_FLAG_HWACCEL (1 << 3)")]
        public const int AV_PIX_FMT_FLAG_HWACCEL = (1 << 3);

        [NativeTypeName("#define AV_PIX_FMT_FLAG_PLANAR (1 << 4)")]
        public const int AV_PIX_FMT_FLAG_PLANAR = (1 << 4);

        [NativeTypeName("#define AV_PIX_FMT_FLAG_RGB (1 << 5)")]
        public const int AV_PIX_FMT_FLAG_RGB = (1 << 5);

        [NativeTypeName("#define AV_PIX_FMT_FLAG_PSEUDOPAL (1 << 6)")]
        public const int AV_PIX_FMT_FLAG_PSEUDOPAL = (1 << 6);

        [NativeTypeName("#define AV_PIX_FMT_FLAG_ALPHA (1 << 7)")]
        public const int AV_PIX_FMT_FLAG_ALPHA = (1 << 7);

        [NativeTypeName("#define AV_PIX_FMT_FLAG_BAYER (1 << 8)")]
        public const int AV_PIX_FMT_FLAG_BAYER = (1 << 8);

        [NativeTypeName("#define AV_PIX_FMT_FLAG_FLOAT (1 << 9)")]
        public const int AV_PIX_FMT_FLAG_FLOAT = (1 << 9);

        [NativeTypeName("#define FF_LOSS_RESOLUTION 0x0001")]
        public const int FF_LOSS_RESOLUTION = 0x0001;

        [NativeTypeName("#define FF_LOSS_DEPTH 0x0002")]
        public const int FF_LOSS_DEPTH = 0x0002;

        [NativeTypeName("#define FF_LOSS_COLORSPACE 0x0004")]
        public const int FF_LOSS_COLORSPACE = 0x0004;

        [NativeTypeName("#define FF_LOSS_ALPHA 0x0008")]
        public const int FF_LOSS_ALPHA = 0x0008;

        [NativeTypeName("#define FF_LOSS_COLORQUANT 0x0010")]
        public const int FF_LOSS_COLORQUANT = 0x0010;

        [NativeTypeName("#define FF_LOSS_CHROMA 0x0020")]
        public const int FF_LOSS_CHROMA = 0x0020;
    }
}
