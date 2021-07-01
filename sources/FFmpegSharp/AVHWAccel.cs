using System;

namespace FFmpegSharp
{
    public unsafe partial struct AVHWAccel
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("enum AVMediaType")]
        public AVMediaType type;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID id;

        [NativeTypeName("enum AVPixelFormat")]
        public AVPixelFormat pix_fmt;

        public int capabilities;

        [NativeTypeName("int (*)(AVCodecContext *, AVFrame *)")]
        public IntPtr alloc_frame;

        [NativeTypeName("int (*)(AVCodecContext *, const uint8_t *, uint32_t)")]
        public IntPtr start_frame;

        [NativeTypeName("int (*)(AVCodecContext *, int, const uint8_t *, uint32_t)")]
        public IntPtr decode_params;

        [NativeTypeName("int (*)(AVCodecContext *, const uint8_t *, uint32_t)")]
        public IntPtr decode_slice;

        [NativeTypeName("int (*)(AVCodecContext *)")]
        public IntPtr end_frame;

        public int frame_priv_data_size;

        [NativeTypeName("void (*)(struct MpegEncContext *)")]
        public IntPtr decode_mb;

        [NativeTypeName("int (*)(AVCodecContext *)")]
        public IntPtr init;

        [NativeTypeName("int (*)(AVCodecContext *)")]
        public IntPtr uninit;

        public int priv_data_size;

        public int caps_internal;

        [NativeTypeName("int (*)(AVCodecContext *, AVBufferRef *)")]
        public IntPtr frame_params;
    }
}
