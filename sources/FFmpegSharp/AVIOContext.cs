using System;

namespace FFmpegSharp
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

        [NativeTypeName("void *")]
        public void* opaque;

        [NativeTypeName("int (*)(void *, uint8_t *, int)")]
        public IntPtr read_packet;

        [NativeTypeName("int (*)(void *, uint8_t *, int)")]
        public IntPtr write_packet;

        [NativeTypeName("int64_t (*)(void *, int64_t, int)")]
        public IntPtr seek;

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
        public IntPtr update_checksum;

        public int error;

        [NativeTypeName("int (*)(void *, int)")]
        public IntPtr read_pause;

        [NativeTypeName("int64_t (*)(void *, int, int64_t, int)")]
        public IntPtr read_seek;

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
        public IntPtr write_data_type;

        public int ignore_boundary_point;

        [NativeTypeName("enum AVIODataMarkerType")]
        public AVIODataMarkerType current_type;

        [NativeTypeName("int64_t")]
        public long last_time;

        [NativeTypeName("int (*)(void *)")]
        public IntPtr short_seek_get;

        [NativeTypeName("int64_t")]
        public long written;

        [NativeTypeName("unsigned char *")]
        public byte* buf_ptr_max;

        public int min_packet_size;
    }
}
