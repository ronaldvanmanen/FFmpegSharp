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
    public unsafe partial struct AVIOContext
    {
        [NativeTypeName("const AVClass *")]
        public AVClass* av_class;

        [NativeTypeName("unsigned char *")]
        public byte* buffer;

        public int buffer_size;

        [NativeTypeName("unsigned char *")]
        public byte* buf_ptr;

        [NativeTypeName("unsigned char *")]
        public byte* buf_end;

        public void* opaque;

        [NativeTypeName("int (*)(void *, uint8_t *, int)")]
        public delegate* unmanaged[Cdecl]<void*, byte*, int, int> read_packet;

        [NativeTypeName("int (*)(void *, uint8_t *, int)")]
        public delegate* unmanaged[Cdecl]<void*, byte*, int, int> write_packet;

        [NativeTypeName("int64_t (*)(void *, int64_t, int)")]
        public delegate* unmanaged[Cdecl]<void*, long, int, long> seek;

        [NativeTypeName("int64_t")]
        public long pos;

        public int eof_reached;

        public int write_flag;

        public int max_packet_size;

        [NativeTypeName("unsigned long")]
        public uint checksum;

        [NativeTypeName("unsigned char *")]
        public byte* checksum_ptr;

        [NativeTypeName("unsigned long (*)(unsigned long, const uint8_t *, unsigned int)")]
        public delegate* unmanaged[Cdecl]<uint, byte*, uint, uint> update_checksum;

        public int error;

        [NativeTypeName("int (*)(void *, int)")]
        public delegate* unmanaged[Cdecl]<void*, int, int> read_pause;

        [NativeTypeName("int64_t (*)(void *, int, int64_t, int)")]
        public delegate* unmanaged[Cdecl]<void*, int, long, int, long> read_seek;

        public int seekable;

        [NativeTypeName("int64_t")]
        public long maxsize;

        public int direct;

        [NativeTypeName("int64_t")]
        public long bytes_read;

        public int seek_count;

        public int writeout_count;

        public int orig_buffer_size;

        public int short_seek_threshold;

        [NativeTypeName("const char *")]
        public sbyte* protocol_whitelist;

        [NativeTypeName("const char *")]
        public sbyte* protocol_blacklist;

        [NativeTypeName("int (*)(void *, uint8_t *, int, enum AVIODataMarkerType, int64_t)")]
        public delegate* unmanaged[Cdecl]<void*, byte*, int, AVIODataMarkerType, long, int> write_data_type;

        public int ignore_boundary_point;

        [NativeTypeName("enum AVIODataMarkerType")]
        public AVIODataMarkerType current_type;

        [NativeTypeName("int64_t")]
        public long last_time;

        [NativeTypeName("int (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, int> short_seek_get;

        [NativeTypeName("int64_t")]
        public long written;

        [NativeTypeName("unsigned char *")]
        public byte* buf_ptr_max;

        public int min_packet_size;
    }
}
