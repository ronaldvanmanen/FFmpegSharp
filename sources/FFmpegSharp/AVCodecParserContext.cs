namespace FFmpegSharp
{
    public unsafe partial struct AVCodecParserContext
    {
        public void* priv_data;

        [NativeTypeName("struct AVCodecParser *")]
        public AVCodecParser* parser;

        [NativeTypeName("int64_t")]
        public long frame_offset;

        [NativeTypeName("int64_t")]
        public long cur_offset;

        [NativeTypeName("int64_t")]
        public long next_frame_offset;

        public int pict_type;

        public int repeat_pict;

        [NativeTypeName("int64_t")]
        public long pts;

        [NativeTypeName("int64_t")]
        public long dts;

        [NativeTypeName("int64_t")]
        public long last_pts;

        [NativeTypeName("int64_t")]
        public long last_dts;

        public int fetch_timestamp;

        public int cur_frame_start_index;

        [NativeTypeName("int64_t [4]")]
        public fixed long cur_frame_offset[4];

        [NativeTypeName("int64_t [4]")]
        public fixed long cur_frame_pts[4];

        [NativeTypeName("int64_t [4]")]
        public fixed long cur_frame_dts[4];

        public int flags;

        [NativeTypeName("int64_t")]
        public long offset;

        [NativeTypeName("int64_t [4]")]
        public fixed long cur_frame_end[4];

        public int key_frame;

        [NativeTypeName("int64_t")]
        public long convergence_duration;

        public int dts_sync_point;

        public int dts_ref_dts_delta;

        public int pts_dts_delta;

        [NativeTypeName("int64_t [4]")]
        public fixed long cur_frame_pos[4];

        [NativeTypeName("int64_t")]
        public long pos;

        [NativeTypeName("int64_t")]
        public long last_pos;

        public int duration;

        [NativeTypeName("enum AVFieldOrder")]
        public AVFieldOrder field_order;

        [NativeTypeName("enum AVPictureStructure")]
        public AVPictureStructure picture_structure;

        public int output_picture_number;

        public int width;

        public int height;

        public int coded_width;

        public int coded_height;

        public int format;
    }
}
