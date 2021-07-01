using System;

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVInputFormat
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* long_name;

        public int flags;

        [NativeTypeName("const char *")]
        public sbyte* extensions;

        [NativeTypeName("const struct AVCodecTag *const *")]
        public AVCodecTag** codec_tag;

        [NativeTypeName("const AVClass *")]
        public AVClass* priv_class;

        [NativeTypeName("const char *")]
        public sbyte* mime_type;

        [NativeTypeName("struct AVInputFormat *")]
        public AVInputFormat* next;

        public int raw_codec_id;

        public int priv_data_size;

        [NativeTypeName("int (*)(const AVProbeData *)")]
        public IntPtr read_probe;

        [NativeTypeName("int (*)(struct AVFormatContext *)")]
        public IntPtr read_header;

        [NativeTypeName("int (*)(struct AVFormatContext *, AVPacket *)")]
        public IntPtr read_packet;

        [NativeTypeName("int (*)(struct AVFormatContext *)")]
        public IntPtr read_close;

        [NativeTypeName("int (*)(struct AVFormatContext *, int, int64_t, int)")]
        public IntPtr read_seek;

        [NativeTypeName("int64_t (*)(struct AVFormatContext *, int, int64_t *, int64_t)")]
        public IntPtr read_timestamp;

        [NativeTypeName("int (*)(struct AVFormatContext *)")]
        public IntPtr read_play;

        [NativeTypeName("int (*)(struct AVFormatContext *)")]
        public IntPtr read_pause;

        [NativeTypeName("int (*)(struct AVFormatContext *, int, int64_t, int64_t, int64_t, int)")]
        public IntPtr read_seek2;

        [NativeTypeName("int (*)(struct AVFormatContext *, struct AVDeviceInfoList *)")]
        public IntPtr get_device_list;

        [NativeTypeName("int (*)(struct AVFormatContext *, struct AVDeviceCapabilitiesQuery *)")]
        public IntPtr create_device_capabilities;

        [NativeTypeName("int (*)(struct AVFormatContext *, struct AVDeviceCapabilitiesQuery *)")]
        public IntPtr free_device_capabilities;
    }
}
