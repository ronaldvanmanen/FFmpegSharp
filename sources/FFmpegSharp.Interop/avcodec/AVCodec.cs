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
    public unsafe partial struct AVCodec
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* long_name;

        [NativeTypeName("enum AVMediaType")]
        public AVMediaType type;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID id;

        public int capabilities;

        [NativeTypeName("const AVRational *")]
        public AVRational* supported_framerates;

        [NativeTypeName("const enum AVPixelFormat *")]
        public AVPixelFormat* pix_fmts;

        [NativeTypeName("const int *")]
        public int* supported_samplerates;

        [NativeTypeName("const enum AVSampleFormat *")]
        public AVSampleFormat* sample_fmts;

        [NativeTypeName("const uint64_t *")]
        public ulong* channel_layouts;

        [NativeTypeName("uint8_t")]
        public byte max_lowres;

        [NativeTypeName("const AVClass *")]
        public AVClass* priv_class;

        [NativeTypeName("const AVProfile *")]
        public AVProfile* profiles;

        [NativeTypeName("const char *")]
        public sbyte* wrapper_name;

        public int priv_data_size;

        [NativeTypeName("struct AVCodec *")]
        public AVCodec* next;

        [NativeTypeName("int (*)(struct AVCodecContext *, const struct AVCodecContext *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, AVCodecContext*, int> update_thread_context;

        [NativeTypeName("const AVCodecDefault *")]
        public AVCodecDefault* defaults;

        [NativeTypeName("void (*)(struct AVCodec *)")]
        public delegate* unmanaged[Cdecl]<AVCodec*, void> init_static_data;

        [NativeTypeName("int (*)(struct AVCodecContext *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, int> init;

        [NativeTypeName("int (*)(struct AVCodecContext *, uint8_t *, int, const struct AVSubtitle *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, byte*, int, AVSubtitle*, int> encode_sub;

        [NativeTypeName("int (*)(struct AVCodecContext *, struct AVPacket *, const struct AVFrame *, int *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, AVPacket*, AVFrame*, int*, int> encode2;

        [NativeTypeName("int (*)(struct AVCodecContext *, void *, int *, struct AVPacket *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, void*, int*, AVPacket*, int> decode;

        [NativeTypeName("int (*)(struct AVCodecContext *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, int> close;

        [NativeTypeName("int (*)(struct AVCodecContext *, struct AVPacket *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, AVPacket*, int> receive_packet;

        [NativeTypeName("int (*)(struct AVCodecContext *, struct AVFrame *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, AVFrame*, int> receive_frame;

        [NativeTypeName("void (*)(struct AVCodecContext *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, void> flush;

        public int caps_internal;

        [NativeTypeName("const char *")]
        public sbyte* bsfs;

        [NativeTypeName("const struct AVCodecHWConfigInternal *const *")]
        public AVCodecHWConfigInternal** hw_configs;

        [NativeTypeName("const uint32_t *")]
        public uint* codec_tags;

        public partial struct AVCodecHWConfigInternal
        {
        }
    }
}
