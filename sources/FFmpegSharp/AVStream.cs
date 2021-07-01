namespace FFmpegSharp
{
    public unsafe partial struct AVStream
    {
        public int index;

        public int id;

        [NativeTypeName("AVCodecContext *")]
        public AVCodecContext* codec;

        [NativeTypeName("void *")]
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

        [NativeTypeName("AVDictionary *")]
        public AVDictionary* metadata;

        public AVRational avg_frame_rate;

        public AVPacket attached_pic;

        [NativeTypeName("AVPacketSideData *")]
        public AVPacketSideData* side_data;

        public int nb_side_data;

        public int event_flags;

        public AVRational r_frame_rate;

        [NativeTypeName("char *")]
        public sbyte* recommended_encoder_configuration;

        [NativeTypeName("AVCodecParameters *")]
        public AVCodecParameters* codecpar;

        [NativeTypeName("void *")]
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

        [NativeTypeName("void *")]
        public void* unused7;

        public AVProbeData unused6;

        [NativeTypeName("int64_t [17]")]
        public fixed long unused5[17];

        [NativeTypeName("AVIndexEntry *")]
        public AVIndexEntry* index_entries;

        public int nb_index_entries;

        [NativeTypeName("unsigned int")]
        public uint index_entries_allocated_size;

        public int stream_identifier;

        public int unused8;

        public int unused9;

        public int unused10;

        [NativeTypeName("AVStreamInternal *")]
        public AVStreamInternal* @internal;
    }
}
