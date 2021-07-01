using System;
using System.Runtime.InteropServices;

namespace FFmpegSharp
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int avfilter_execute_func([NativeTypeName("AVFilterContext *")] AVFilterContext* ctx, [NativeTypeName("avfilter_action_func *")] IntPtr* func, [NativeTypeName("void *")] void* arg, [NativeTypeName("int *")] int* ret, int nb_jobs);
}
