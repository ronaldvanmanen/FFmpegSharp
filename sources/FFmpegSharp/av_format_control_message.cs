using System;
using System.Runtime.InteropServices;

namespace FFmpegSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int av_format_control_message([NativeTypeName("struct AVFormatContext *")] AVFormatContext* s, int type, [NativeTypeName("void *")] void* data, [NativeTypeName("size_t")] UIntPtr data_size);
}
