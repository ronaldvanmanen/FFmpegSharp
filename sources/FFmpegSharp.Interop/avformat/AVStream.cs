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
    public unsafe partial struct AVStream
    {
        public int index;

        public int id;

        [Obsolete]
        public AVCodecContext* codec;

        public void* priv_data;

        public AVRational time_base;

        [NativeTypeName("int64_t")]
        public long start_time;

        [NativeTypeName("int64_t")]
        public long duration;

        [NativeTypeName("int64_t")]
        public long nb_frames;

        public int disposition;

        [NativeTypeName("enum AVDiscard")]
        public AVDiscard discard;

        public AVRational sample_aspect_ratio;

        public AVDictionary* metadata;

        public AVRational avg_frame_rate;

        public AVPacket attached_pic;

        public AVPacketSideData* side_data;

        public int nb_side_data;

        public int event_flags;

        public AVRational r_frame_rate;

        [NativeTypeName("char *")]
        [Obsolete]
        public sbyte* recommended_encoder_configuration;

        public AVCodecParameters* codecpar;

        public void* unused;

        public int pts_wrap_bits;

        [NativeTypeName("int64_t")]
        public long first_dts;

        [NativeTypeName("int64_t")]
        public long cur_dts;

        [NativeTypeName("int64_t")]
        public long last_IP_pts;

        public int last_IP_duration;

        public int probe_packets;

        public int codec_info_nb_frames;

        [NativeTypeName("enum AVStreamParseType")]
        public AVStreamParseType need_parsing;

        [NativeTypeName("struct AVCodecParserContext *")]
        public AVCodecParserContext* parser;

        public void* unused7;

        public AVProbeData unused6;

        [NativeTypeName("int64_t[17]")]
        public fixed long unused5[17];

        public AVIndexEntry* index_entries;

        public int nb_index_entries;

        [NativeTypeName("unsigned int")]
        public uint index_entries_allocated_size;

        public int stream_identifier;

        public int unused8;

        public int unused9;

        public int unused10;

        public AVStreamInternal* @internal;
    }
}
