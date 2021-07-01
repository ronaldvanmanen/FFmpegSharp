using System.Runtime.InteropServices;

namespace FFmpegSharp.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOpenCallback([NativeTypeName("struct AVFormatContext *")] AVFormatContext* s, AVIOContext** pb, [NativeTypeName("const char *")] sbyte* url, int flags, [NativeTypeName("const AVIOInterruptCB *")] AVIOInterruptCB* int_cb, AVDictionary** options);
}
