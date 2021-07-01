using System;

namespace FFmpegSharp
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
        public IntPtr write_header;

        [NativeTypeName("int (*)(struct AVFormatContext *, AVPacket *)")]
        public IntPtr write_packet;

        [NativeTypeName("int (*)(struct AVFormatContext *)")]
        public IntPtr write_trailer;

        [NativeTypeName("int (*)(struct AVFormatContext *, AVPacket *, AVPacket *, int)")]
        public IntPtr interleave_packet;

        [NativeTypeName("int (*)(enum AVCodecID, int)")]
        public IntPtr query_codec;

        [NativeTypeName("void (*)(struct AVFormatContext *, int, int64_t *, int64_t *)")]
        public IntPtr get_output_timestamp;

        [NativeTypeName("int (*)(struct AVFormatContext *, int, void *, size_t)")]
        public IntPtr control_message;

        [NativeTypeName("int (*)(struct AVFormatContext *, int, AVFrame **, unsigned int)")]
        public IntPtr write_uncoded_frame;

        [NativeTypeName("int (*)(struct AVFormatContext *, struct AVDeviceInfoList *)")]
        public IntPtr get_device_list;

        [NativeTypeName("int (*)(struct AVFormatContext *, struct AVDeviceCapabilitiesQuery *)")]
        public IntPtr create_device_capabilities;

        [NativeTypeName("int (*)(struct AVFormatContext *, struct AVDeviceCapabilitiesQuery *)")]
        public IntPtr free_device_capabilities;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID data_codec;

        [NativeTypeName("int (*)(struct AVFormatContext *)")]
        public IntPtr init;

        [NativeTypeName("void (*)(struct AVFormatContext *)")]
        public IntPtr deinit;

        [NativeTypeName("int (*)(struct AVFormatContext *, const AVPacket *)")]
        public IntPtr check_bitstream;
    }
}
