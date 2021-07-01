namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVHWFramesContext
    {
        [NativeTypeName("const AVClass *")]
        public AVClass* av_class;

        public AVHWFramesInternal* @internal;

        public AVBufferRef* device_ref;

        public AVHWDeviceContext* device_ctx;

        public void* hwctx;

        [NativeTypeName("void (*)(struct AVHWFramesContext *)")]
        public delegate* unmanaged[Cdecl]<AVHWFramesContext*, void> free;

        public void* user_opaque;

        public AVBufferPool* pool;

        public int initial_pool_size;

        [NativeTypeName("enum AVPixelFormat")]
        public AVPixelFormat format;

        [NativeTypeName("enum AVPixelFormat")]
        public AVPixelFormat sw_format;

        public int width;

        public int height;
    }
}
