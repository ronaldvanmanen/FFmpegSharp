using System.Runtime.InteropServices;

namespace FFmpegSharp.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int avfilter_action_func([NativeTypeName("AVFilterContext *")] AVFilterContext* ctx, [NativeTypeName("void *")] void* arg, int jobnr, int nb_jobs);
}
