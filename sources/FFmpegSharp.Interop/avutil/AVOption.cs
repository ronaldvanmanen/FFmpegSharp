// Copyright (c) 2021-2023 Ronald van Manen
//
// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with FFmpegSharp; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA

using System.Runtime.InteropServices;

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVOption
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* help;

        public int offset;

        [NativeTypeName("enum AVOptionType")]
        public AVOptionType type;

        [NativeTypeName("__AnonymousRecord_opt_L267_C5")]
        public _default_val_e__Union default_val;

        public double min;

        public double max;

        public int flags;

        [NativeTypeName("const char *")]
        public sbyte* unit;

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _default_val_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("int64_t")]
            public long i64;

            [FieldOffset(0)]
            public double dbl;

            [FieldOffset(0)]
            [NativeTypeName("const char *")]
            public sbyte* str;

            [FieldOffset(0)]
            public AVRational q;
        }
    }
}
