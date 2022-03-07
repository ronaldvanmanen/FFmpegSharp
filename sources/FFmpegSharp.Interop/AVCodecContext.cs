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
    public unsafe partial struct AVCodecContext
    {
        [NativeTypeName("const AVClass *")]
        public AVClass* av_class;

        public int log_level_offset;

        [NativeTypeName("enum AVMediaType")]
        public AVMediaType codec_type;

        [NativeTypeName("const struct AVCodec *")]
        public AVCodec* codec;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID codec_id;

        [NativeTypeName("unsigned int")]
        public uint codec_tag;

        public void* priv_data;

        [NativeTypeName("struct AVCodecInternal *")]
        public AVCodecInternal* @internal;

        public void* opaque;

        [NativeTypeName("int64_t")]
        public long bit_rate;

        public int bit_rate_tolerance;

        public int global_quality;

        public int compression_level;

        public int flags;

        public int flags2;

        [NativeTypeName("uint8_t *")]
        public byte* extradata;

        public int extradata_size;

        public AVRational time_base;

        public int ticks_per_frame;

        public int delay;

        public int width;

        public int height;

        public int coded_width;

        public int coded_height;

        public int gop_size;

        [NativeTypeName("enum AVPixelFormat")]
        public AVPixelFormat pix_fmt;

        [NativeTypeName("void (*)(struct AVCodecContext *, const AVFrame *, int *, int, int, int)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, AVFrame*, int, int, int, int, void> draw_horiz_band;

        [NativeTypeName("enum AVPixelFormat (*)(struct AVCodecContext *, const enum AVPixelFormat *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, AVPixelFormat*, AVPixelFormat> get_format;

        public int max_b_frames;

        public float b_quant_factor;

        public int b_frame_strategy;

        public float b_quant_offset;

        public int has_b_frames;

        public int mpeg_quant;

        public float i_quant_factor;

        public float i_quant_offset;

        public float lumi_masking;

        public float temporal_cplx_masking;

        public float spatial_cplx_masking;

        public float p_masking;

        public float dark_masking;

        public int slice_count;

        public int prediction_method;

        public int* slice_offset;

        public AVRational sample_aspect_ratio;

        public int me_cmp;

        public int me_sub_cmp;

        public int mb_cmp;

        public int ildct_cmp;

        public int dia_size;

        public int last_predictor_count;

        public int pre_me;

        public int me_pre_cmp;

        public int pre_dia_size;

        public int me_subpel_quality;

        public int me_range;

        public int slice_flags;

        public int mb_decision;

        [NativeTypeName("uint16_t *")]
        public ushort* intra_matrix;

        [NativeTypeName("uint16_t *")]
        public ushort* inter_matrix;

        public int scenechange_threshold;

        public int noise_reduction;

        public int intra_dc_precision;

        public int skip_top;

        public int skip_bottom;

        public int mb_lmin;

        public int mb_lmax;

        public int me_penalty_compensation;

        public int bidir_refine;

        public int brd_scale;

        public int keyint_min;

        public int refs;

        public int chromaoffset;

        public int mv0_threshold;

        public int b_sensitivity;

        [NativeTypeName("enum AVColorPrimaries")]
        public AVColorPrimaries color_primaries;

        [NativeTypeName("enum AVColorTransferCharacteristic")]
        public AVColorTransferCharacteristic color_trc;

        [NativeTypeName("enum AVColorSpace")]
        public AVColorSpace colorspace;

        [NativeTypeName("enum AVColorRange")]
        public AVColorRange color_range;

        [NativeTypeName("enum AVChromaLocation")]
        public AVChromaLocation chroma_sample_location;

        public int slices;

        [NativeTypeName("enum AVFieldOrder")]
        public AVFieldOrder field_order;

        public int sample_rate;

        public int channels;

        [NativeTypeName("enum AVSampleFormat")]
        public AVSampleFormat sample_fmt;

        public int frame_size;

        public int frame_number;

        public int block_align;

        public int cutoff;

        [NativeTypeName("uint64_t")]
        public ulong channel_layout;

        [NativeTypeName("uint64_t")]
        public ulong request_channel_layout;

        [NativeTypeName("enum AVAudioServiceType")]
        public AVAudioServiceType audio_service_type;

        [NativeTypeName("enum AVSampleFormat")]
        public AVSampleFormat request_sample_fmt;

        [NativeTypeName("int (*)(struct AVCodecContext *, AVFrame *, int)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, AVFrame*, int, int> get_buffer2;

        public int refcounted_frames;

        public float qcompress;

        public float qblur;

        public int qmin;

        public int qmax;

        public int max_qdiff;

        public int rc_buffer_size;

        public int rc_override_count;

        public RcOverride* rc_override;

        [NativeTypeName("int64_t")]
        public long rc_max_rate;

        [NativeTypeName("int64_t")]
        public long rc_min_rate;

        public float rc_max_available_vbv_use;

        public float rc_min_vbv_overflow_use;

        public int rc_initial_buffer_occupancy;

        public int coder_type;

        public int context_model;

        public int frame_skip_threshold;

        public int frame_skip_factor;

        public int frame_skip_exp;

        public int frame_skip_cmp;

        public int trellis;

        public int min_prediction_order;

        public int max_prediction_order;

        [NativeTypeName("int64_t")]
        public long timecode_frame_start;

        [NativeTypeName("void (*)(struct AVCodecContext *, void *, int, int)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, void*, int, int, void> rtp_callback;

        public int rtp_payload_size;

        public int mv_bits;

        public int header_bits;

        public int i_tex_bits;

        public int p_tex_bits;

        public int i_count;

        public int p_count;

        public int skip_count;

        public int misc_bits;

        public int frame_bits;

        [NativeTypeName("char *")]
        public sbyte* stats_out;

        [NativeTypeName("char *")]
        public sbyte* stats_in;

        public int workaround_bugs;

        public int strict_std_compliance;

        public int error_concealment;

        public int debug;

        public int err_recognition;

        [NativeTypeName("int64_t")]
        public long reordered_opaque;

        [NativeTypeName("const struct AVHWAccel *")]
        public AVHWAccel* hwaccel;

        public void* hwaccel_context;

        [NativeTypeName("uint64_t [8]")]
        public fixed ulong error[8];

        public int dct_algo;

        public int idct_algo;

        public int bits_per_coded_sample;

        public int bits_per_raw_sample;

        public int lowres;

        public AVFrame* coded_frame;

        public int thread_count;

        public int thread_type;

        public int active_thread_type;

        public int thread_safe_callbacks;

        [NativeTypeName("int (*)(struct AVCodecContext *, int (*)(struct AVCodecContext *, void *), void *, int *, int, int)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, delegate* unmanaged[Cdecl]<AVCodecContext*, void*, int>, void*, int*, int, int, int> execute;

        [NativeTypeName("int (*)(struct AVCodecContext *, int (*)(struct AVCodecContext *, void *, int, int), void *, int *, int)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, delegate* unmanaged[Cdecl]<AVCodecContext*, void*, int, int, int>, void*, int*, int, int> execute2;

        public int nsse_weight;

        public int profile;

        public int level;

        [NativeTypeName("enum AVDiscard")]
        public AVDiscard skip_loop_filter;

        [NativeTypeName("enum AVDiscard")]
        public AVDiscard skip_idct;

        [NativeTypeName("enum AVDiscard")]
        public AVDiscard skip_frame;

        [NativeTypeName("uint8_t *")]
        public byte* subtitle_header;

        public int subtitle_header_size;

        [NativeTypeName("uint64_t")]
        public ulong vbv_delay;

        public int side_data_only_packets;

        public int initial_padding;

        public AVRational framerate;

        [NativeTypeName("enum AVPixelFormat")]
        public AVPixelFormat sw_pix_fmt;

        public AVRational pkt_timebase;

        [NativeTypeName("const AVCodecDescriptor *")]
        public AVCodecDescriptor* codec_descriptor;

        [NativeTypeName("int64_t")]
        public long pts_correction_num_faulty_pts;

        [NativeTypeName("int64_t")]
        public long pts_correction_num_faulty_dts;

        [NativeTypeName("int64_t")]
        public long pts_correction_last_pts;

        [NativeTypeName("int64_t")]
        public long pts_correction_last_dts;

        [NativeTypeName("char *")]
        public sbyte* sub_charenc;

        public int sub_charenc_mode;

        public int skip_alpha;

        public int seek_preroll;

        public int debug_mv;

        [NativeTypeName("uint16_t *")]
        public ushort* chroma_intra_matrix;

        [NativeTypeName("uint8_t *")]
        public byte* dump_separator;

        [NativeTypeName("char *")]
        public sbyte* codec_whitelist;

        [NativeTypeName("unsigned int")]
        public uint properties;

        public AVPacketSideData* coded_side_data;

        public int nb_coded_side_data;

        public AVBufferRef* hw_frames_ctx;

        public int sub_text_format;

        public int trailing_padding;

        [NativeTypeName("int64_t")]
        public long max_pixels;

        public AVBufferRef* hw_device_ctx;

        public int hwaccel_flags;

        public int apply_cropping;

        public int extra_hw_frames;

        public int discard_damaged_percentage;

        [NativeTypeName("int64_t")]
        public long max_samples;

        public int export_side_data;

        [NativeTypeName("int (*)(struct AVCodecContext *, AVPacket *, int)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, AVPacket*, int, int> get_encode_buffer;
    }
}
