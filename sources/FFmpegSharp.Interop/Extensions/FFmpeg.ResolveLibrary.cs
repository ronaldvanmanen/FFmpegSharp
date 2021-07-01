using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace FFmpegSharp.Interop
{
    public static unsafe partial class FFmpeg
    {
        public static event DllImportResolver ResolveLibrary;

        public static string LibraryDirectory { get; set; }

        static FFmpeg()
        {
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), OnDllImport);
        }

        private static IntPtr OnDllImport(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (TryResolveLibrary(libraryName, assembly, searchPath, out var nativeLibrary))
            {
                return nativeLibrary;
            }

            if (libraryName.Equals("avcodec-58.dll") ||
                libraryName.Equals("avdevice-58.dll") ||
                libraryName.Equals("avfilter-7.dll") ||
                libraryName.Equals("avformat-58.dll") ||
                libraryName.Equals("avutil-56.dll") ||
                libraryName.Equals("postproc-55.dll") ||
                libraryName.Equals("swresample-3.dll") ||
                libraryName.Equals("swscale-5.dll"))
            {
                if (TryResolveNativeLibrary(libraryName, assembly, searchPath, out nativeLibrary))
                {
                    return nativeLibrary;
                }
            }

            return IntPtr.Zero;
        }

        private static bool TryResolveNativeLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath, out IntPtr nativeLibrary)
        {
            if (NativeLibrary.TryLoad(libraryName, assembly, searchPath, out nativeLibrary))
            {
                return true;
            }

            if (string.IsNullOrEmpty(LibraryDirectory))
            {
                return false;
            }

            var libraryPath = Path.Combine(LibraryDirectory, libraryName);
            var result = NativeLibrary.TryLoad(libraryPath, out nativeLibrary);
            return result;
        }

        private static bool TryResolveLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath, out IntPtr nativeLibrary)
        {
            var resolveLibrary = ResolveLibrary;

            if (resolveLibrary != null)
            {
                var resolvers = resolveLibrary.GetInvocationList();

                foreach (DllImportResolver resolver in resolvers)
                {
                    nativeLibrary = resolver(libraryName, assembly, searchPath);

                    if (nativeLibrary != IntPtr.Zero)
                    {
                        return true;
                    }
                }
            }

            nativeLibrary = IntPtr.Zero;

            return false;
        }
    }
}
