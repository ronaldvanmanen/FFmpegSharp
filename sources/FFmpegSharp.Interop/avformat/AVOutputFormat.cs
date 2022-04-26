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
    public unsafe partial struct AVOutputFormat
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* long_name;

        [NativeTypeName("const char *")]
        public sbyte* mime_type;

        [NativeTypeName("const char *")]
        public sbyte* extensions;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID audio_codec;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID video_codec;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID subtitle_codec;

        public int flags;

        [NativeTypeName("const struct AVCodecTag *const *")]
        public AVCodecTag** codec_tag;

        [NativeTypeName("const AVClass *")]
        public AVClass* priv_class;

        [NativeTypeName("struct AVOutputFormat *")]
        public AVOutputFormat* next;

        public int priv_data_size;

        [NativeTypeName("int (*)(struct AVFormatContext *)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, int> write_header;

        [NativeTypeName("int (*)(struct AVFormatContext *, AVPacket *)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, AVPacket*, int> write_packet;

        [NativeTypeName("int (*)(struct AVFormatContext *)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, int> write_trailer;

        [NativeTypeName("int (*)(struct AVFormatContext *, AVPacket *, AVPacket *, int)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, AVPacket*, AVPacket*, int, int> interleave_packet;

        [NativeTypeName("int (*)(enum AVCodecID, int)")]
        public delegate* unmanaged[Cdecl]<AVCodecID, int, int> query_codec;

        [NativeTypeName("void (*)(struct AVFormatContext *, int, int64_t *, int64_t *)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, int, long*, long*, void> get_output_timestamp;

        [NativeTypeName("int (*)(struct AVFormatContext *, int, void *, size_t)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, int, void*, nuint, int> control_message;

        [NativeTypeName("int (*)(struct AVFormatContext *, int, AVFrame **, unsigned int)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, int, AVFrame**, uint, int> write_uncoded_frame;

        [NativeTypeName("int (*)(struct AVFormatContext *, struct AVDeviceInfoList *)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, AVDeviceInfoList*, int> get_device_list;

        [NativeTypeName("int (*)(struct AVFormatContext *, struct AVDeviceCapabilitiesQuery *)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, AVDeviceCapabilitiesQuery*, int> create_device_capabilities;

        [NativeTypeName("int (*)(struct AVFormatContext *, struct AVDeviceCapabilitiesQuery *)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, AVDeviceCapabilitiesQuery*, int> free_device_capabilities;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID data_codec;

        [NativeTypeName("int (*)(struct AVFormatContext *)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, int> init;

        [NativeTypeName("void (*)(struct AVFormatContext *)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, void> deinit;

        [NativeTypeName("int (*)(struct AVFormatContext *, const AVPacket *)")]
        public delegate* unmanaged[Cdecl]<AVFormatContext*, AVPacket*, int> check_bitstream;
    }
}
