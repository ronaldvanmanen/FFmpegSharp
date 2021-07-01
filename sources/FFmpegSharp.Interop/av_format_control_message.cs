using System;
using System.Runtime.InteropServices;

namespace FFmpegSharp.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int av_format_control_message([NativeTypeName("struct AVFormatContext *")] AVFormatContext* s, int type, void* data, [NativeTypeName("size_t")] UIntPtr data_size);
}
