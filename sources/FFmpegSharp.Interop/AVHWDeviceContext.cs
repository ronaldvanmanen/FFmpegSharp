namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVHWDeviceContext
    {
        [NativeTypeName("const AVClass *")]
        public AVClass* av_class;

        public AVHWDeviceInternal* @internal;

        [NativeTypeName("enum AVHWDeviceType")]
        public AVHWDeviceType type;

        public void* hwctx;

        [NativeTypeName("void (*)(struct AVHWDeviceContext *)")]
        public delegate* unmanaged[Cdecl]<AVHWDeviceContext*, void> free;

        public void* user_opaque;
    }
}
