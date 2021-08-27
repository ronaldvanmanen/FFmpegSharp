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
    public unsafe partial struct AVClass
    {
        [NativeTypeName("const char *")]
        public sbyte* class_name;

        [NativeTypeName("const char *(*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, sbyte*> item_name;

        [NativeTypeName("const struct AVOption *")]
        public AVOption* option;

        public int version;

        public int log_level_offset_offset;

        public int parent_log_context_offset;

        [NativeTypeName("void *(*)(void *, void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*> child_next;

        [NativeTypeName("const struct AVClass *(*)(const struct AVClass *)")]
        public delegate* unmanaged[Cdecl]<AVClass*, AVClass*> child_class_next;

        public AVClassCategory category;

        [NativeTypeName("AVClassCategory (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, AVClassCategory> get_category;

        [NativeTypeName("int (*)(struct AVOptionRanges **, void *, const char *, int)")]
        public delegate* unmanaged[Cdecl]<AVOptionRanges**, void*, sbyte*, int, int> query_ranges;

        [NativeTypeName("const struct AVClass *(*)(void **)")]
        public delegate* unmanaged[Cdecl]<void**, AVClass*> child_class_iterate;

        public partial struct AVOption
        {
        }
    }
}
