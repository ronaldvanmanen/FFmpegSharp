using System;

namespace FFmpegSharp
{
    public unsafe partial struct AVIOInterruptCB
    {
        [NativeTypeName("int (*)(void *)")]
        public IntPtr callback;

        [NativeTypeName("void *")]
        public void* opaque;
    }
}
