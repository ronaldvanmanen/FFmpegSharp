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

using System;

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVFormatContext
    {
        [NativeTypeName("const AVClass *")]
        public AVClass* av_class;

        [NativeTypeName("struct AVInputFormat *")]
        public AVInputFormat* iformat;

        [NativeTypeName("struct AVOutputFormat *")]
        public AVOutputFormat* oformat;

        public void* priv_data;

        public AVIOContext* pb;

        public int ctx_flags;

        [NativeTypeName("unsigned int")]
        public uint nb_streams;

        public AVStream** streams;

        [NativeTypeName("char[1024]")]
        [Obsolete]
        public fixed sbyte filename[1024];

        [NativeTypeName("char *")]
        public sbyte* url;

        [NativeTypeName("int64_t")]
        public long start_time;

        [NativeTypeName("int64_t")]
        public long duration;

        [NativeTypeName("int64_t")]
        public long bit_rate;

        [NativeTypeName("unsigned int")]
        public uint packet_size;

        public int max_delay;

        public int flags;

        [NativeTypeName("int64_t")]
        public long probesize;

        [NativeTypeName("int64_t")]
        public long max_analyze_duration;

        [NativeTypeName("const uint8_t *")]
        public byte* key;

        public int keylen;

        [NativeTypeName("unsigned int")]
        public uint nb_programs;

        public AVProgram** programs;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID video_codec_id;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID audio_codec_id;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID subtitle_codec_id;

        [NativeTypeName("unsigned int")]
        public uint max_index_size;

        [NativeTypeName("unsigned int")]
        public uint max_picture_buffer;

        [NativeTypeName("unsigned int")]
        public uint nb_chapters;

        public AVChapter** chapters;

        public AVDictionary* metadata;

        [NativeTypeName("int64_t")]
        public long start_time_realtime;

        public int fps_probe_size;

        public int error_recognition;

        public AVIOInterruptCB interrupt_callback;

        public int debug;

        [NativeTypeName("int64_t")]
        public long max_interleave_delta;

        public int strict_std_compliance;

        public int event_flags;

        public int max_ts_probe;

        public int avoid_negative_ts;

        public int ts_id;

        public int audio_preload;

        public int max_chunk_duration;

        public int max_chunk_size;

        public int use_wallclock_as_timestamps;

        public int avio_flags;

        [NativeTypeName("enum AVDurationEstimationMethod")]
        public AVDurationEstimationMethod duration_estimation_method;

        [NativeTypeName("int64_t")]
        public long skip_initial_bytes;

        [NativeTypeName("unsigned int")]
        public uint correct_ts_overflow;

        public int seek2any;

        public int flush_packets;

        public int probe_score;

        public int format_probesize;

        [NativeTypeName("char *")]
        public sbyte* codec_whitelist;

        [NativeTypeName("char *")]
        public sbyte* format_whitelist;

        public AVFormatInternal* @internal;

        public int io_repositioned;

        public AVCodec* video_codec;

        public AVCodec* audio_codec;

        public AVCodec* subtitle_codec;

        public AVCodec* data_codec;

        public int metadata_header_padding;

        public void* opaque;

        [NativeTypeName("av_format_control_message")]
        public IntPtr control_message_cb;

        [NativeTypeName("int64_t")]
        public long output_ts_offset;

        [NativeTypeName("uint8_t *")]
        public byte* dump_separator;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID data_codec_id;

        [NativeTypeName("int (*)(struct AVFormatContext *, AVIOContext **, const char *, int, const AVIOInterruptCB *, AVDictionary **)")]
        [Obsolete]
        public IntPtr open_cb;

        [NativeTypeName("char *")]
        public sbyte* protocol_whitelist;

        [NativeTypeName("int (*)(struct AVFormatContext *, AVIOContext **, const char *, int, AVDictionary **)")]
        public IntPtr io_open;

        [NativeTypeName("void (*)(struct AVFormatContext *, AVIOContext *)")]
        public IntPtr io_close;

        [NativeTypeName("char *")]
        public sbyte* protocol_blacklist;

        public int max_streams;

        public int skip_estimate_duration_from_pts;

        public int max_probe_packets;
    }
}
