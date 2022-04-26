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
