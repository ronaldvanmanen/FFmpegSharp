// Copyright (C) 2021-2024 Ronald van Manen
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

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVProgram
    {
        public int id;

        public int flags;

        [NativeTypeName("enum AVDiscard")]
        public AVDiscard discard;

        [NativeTypeName("unsigned int *")]
        public uint* stream_index;

        [NativeTypeName("unsigned int")]
        public uint nb_stream_indexes;

        public AVDictionary* metadata;

        public int program_num;

        public int pmt_pid;

        public int pcr_pid;

        public int pmt_version;

        [NativeTypeName("int64_t")]
        public long start_time;

        [NativeTypeName("int64_t")]
        public long end_time;

        [NativeTypeName("int64_t")]
        public long pts_wrap_reference;

        public int pts_wrap_behavior;
    }
}
