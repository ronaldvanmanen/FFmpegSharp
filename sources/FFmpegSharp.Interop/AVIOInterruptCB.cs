using System;

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVIOInterruptCB
    {
        [NativeTypeName("int (*)(void *)")]
        public IntPtr callback;

        public void* opaque;
    }
}
