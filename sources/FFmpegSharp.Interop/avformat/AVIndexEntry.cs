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

using System.Runtime.CompilerServices;

namespace FFmpegSharp.Interop
{
    public partial struct AVIndexEntry
    {
        [NativeTypeName("int64_t")]
        public long pos;

        [NativeTypeName("int64_t")]
        public long timestamp;

        public int _bitfield;

        [NativeTypeName("int : 2")]
        public int flags
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return (_bitfield << 30) >> 30;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                _bitfield = (_bitfield & ~0x3) | (value & 0x3);
            }
        }

        [NativeTypeName("int : 30")]
        public int size
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return (_bitfield << 0) >> 2;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFF << 2)) | ((value & 0x3FFFFFFF) << 2);
            }
        }

        public int min_distance;
    }
}
