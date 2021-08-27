// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with FFmpegSharp.  If not, see <https://www.gnu.org/licenses/>.

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVFilter
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* description;

        [NativeTypeName("const AVFilterPad *")]
        public AVFilterPad* inputs;

        [NativeTypeName("const AVFilterPad *")]
        public AVFilterPad* outputs;

        [NativeTypeName("const AVClass *")]
        public AVClass* priv_class;

        public int flags;

        [NativeTypeName("int (*)(AVFilterContext *)")]
        public delegate* unmanaged[Cdecl]<AVFilterContext*, int> preinit;

        [NativeTypeName("int (*)(AVFilterContext *)")]
        public delegate* unmanaged[Cdecl]<AVFilterContext*, int> init;

        [NativeTypeName("int (*)(AVFilterContext *, AVDictionary **)")]
        public delegate* unmanaged[Cdecl]<AVFilterContext*, AVDictionary**, int> init_dict;

        [NativeTypeName("void (*)(AVFilterContext *)")]
        public delegate* unmanaged[Cdecl]<AVFilterContext*, void> uninit;

        [NativeTypeName("int (*)(AVFilterContext *)")]
        public delegate* unmanaged[Cdecl]<AVFilterContext*, int> query_formats;

        public int priv_size;

        public int flags_internal;

        [NativeTypeName("struct AVFilter *")]
        public AVFilter* next;

        [NativeTypeName("int (*)(AVFilterContext *, const char *, const char *, char *, int, int)")]
        public delegate* unmanaged[Cdecl]<AVFilterContext*, sbyte*, sbyte*, sbyte*, int, int, int> process_command;

        [NativeTypeName("int (*)(AVFilterContext *, void *)")]
        public delegate* unmanaged[Cdecl]<AVFilterContext*, void*, int> init_opaque;

        [NativeTypeName("int (*)(AVFilterContext *)")]
        public delegate* unmanaged[Cdecl]<AVFilterContext*, int> activate;
    }
}
