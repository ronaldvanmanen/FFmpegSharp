using System.Runtime.InteropServices;

namespace FFmpegSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOpenCallback([NativeTypeName("struct AVFormatContext *")] AVFormatContext* s, [NativeTypeName("AVIOContext **")] AVIOContext** pb, [NativeTypeName("const char *")] sbyte* url, int flags, [NativeTypeName("const AVIOInterruptCB *")] AVIOInterruptCB* int_cb, [NativeTypeName("AVDictionary **")] AVDictionary** options);
}
