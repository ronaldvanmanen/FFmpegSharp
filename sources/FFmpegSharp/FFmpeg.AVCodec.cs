using System;
using System.Runtime.InteropServices;
using static FFmpegSharp.AVCodecID;
using static FFmpegSharp.AVPacketSideDataType;

namespace FFmpegSharp
{
    public static unsafe partial class FFmpeg
    {
        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_codec_get_pkt_timebase([NativeTypeName("const AVCodecContext *")] AVCodecContext* avctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_codec_set_pkt_timebase(AVCodecContext* avctx, AVRational val);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVCodecDescriptor *")]
        public static extern AVCodecDescriptor* av_codec_get_codec_descriptor([NativeTypeName("const AVCodecContext *")] AVCodecContext* avctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_codec_set_codec_descriptor(AVCodecContext* avctx, [NativeTypeName("const AVCodecDescriptor *")] AVCodecDescriptor* desc);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint av_codec_get_codec_properties([NativeTypeName("const AVCodecContext *")] AVCodecContext* avctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_codec_get_lowres([NativeTypeName("const AVCodecContext *")] AVCodecContext* avctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_codec_set_lowres(AVCodecContext* avctx, int val);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_codec_get_seek_preroll([NativeTypeName("const AVCodecContext *")] AVCodecContext* avctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_codec_set_seek_preroll(AVCodecContext* avctx, int val);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint16_t *")]
        public static extern ushort* av_codec_get_chroma_intra_matrix([NativeTypeName("const AVCodecContext *")] AVCodecContext* avctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_codec_set_chroma_intra_matrix(AVCodecContext* avctx, [NativeTypeName("uint16_t *")] ushort* val);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_codec_get_max_lowres([NativeTypeName("const AVCodec *")] AVCodec* codec);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodec* av_codec_next([NativeTypeName("const AVCodec *")] AVCodec* c);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avcodec_version();

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avcodec_configuration();

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avcodec_license();

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avcodec_register(AVCodec* codec);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avcodec_register_all();

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodecContext* avcodec_alloc_context3([NativeTypeName("const AVCodec *")] AVCodec* codec);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avcodec_free_context(AVCodecContext** avctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_get_context_defaults3(AVCodecContext* s, [NativeTypeName("const AVCodec *")] AVCodec* codec);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVClass *")]
        public static extern AVClass* avcodec_get_class();

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVClass *")]
        public static extern AVClass* avcodec_get_frame_class();

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVClass *")]
        public static extern AVClass* avcodec_get_subtitle_rect_class();

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_copy_context(AVCodecContext* dest, [NativeTypeName("const AVCodecContext *")] AVCodecContext* src);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_parameters_from_context(AVCodecParameters* par, [NativeTypeName("const AVCodecContext *")] AVCodecContext* codec);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_parameters_to_context(AVCodecContext* codec, [NativeTypeName("const AVCodecParameters *")] AVCodecParameters* par);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_open2(AVCodecContext* avctx, [NativeTypeName("const AVCodec *")] AVCodec* codec, AVDictionary** options);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_close(AVCodecContext* avctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avsubtitle_free(AVSubtitle* sub);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_default_get_buffer2(AVCodecContext* s, AVFrame* frame, int flags);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_default_get_encode_buffer(AVCodecContext* s, AVPacket* pkt, int flags);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avcodec_align_dimensions(AVCodecContext* s, int* width, int* height);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avcodec_align_dimensions2(AVCodecContext* s, int* width, int* height, [NativeTypeName("int [8]")] int* linesize_align);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_enum_to_chroma_pos(int* xpos, int* ypos, [NativeTypeName("enum AVChromaLocation")] AVChromaLocation pos);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVChromaLocation")]
        public static extern AVChromaLocation avcodec_chroma_pos_to_enum(int xpos, int ypos);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_decode_audio4(AVCodecContext* avctx, AVFrame* frame, int* got_frame_ptr, [NativeTypeName("const AVPacket *")] AVPacket* avpkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_decode_video2(AVCodecContext* avctx, AVFrame* picture, int* got_picture_ptr, [NativeTypeName("const AVPacket *")] AVPacket* avpkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_decode_subtitle2(AVCodecContext* avctx, AVSubtitle* sub, int* got_sub_ptr, AVPacket* avpkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_send_packet(AVCodecContext* avctx, [NativeTypeName("const AVPacket *")] AVPacket* avpkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_receive_frame(AVCodecContext* avctx, AVFrame* frame);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_send_frame(AVCodecContext* avctx, [NativeTypeName("const AVFrame *")] AVFrame* frame);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_receive_packet(AVCodecContext* avctx, AVPacket* avpkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_get_hw_frames_parameters(AVCodecContext* avctx, AVBufferRef* device_ref, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat hw_pix_fmt, AVBufferRef** out_frames_ref);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVCodecParser *")]
        public static extern AVCodecParser* av_parser_iterate(void** opaque);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodecParser* av_parser_next([NativeTypeName("const AVCodecParser *")] AVCodecParser* c);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_register_codec_parser(AVCodecParser* parser);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodecParserContext* av_parser_init(int codec_id);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_parser_parse2(AVCodecParserContext* s, AVCodecContext* avctx, [NativeTypeName("uint8_t **")] byte** poutbuf, int* poutbuf_size, [NativeTypeName("const uint8_t *")] byte* buf, int buf_size, [NativeTypeName("int64_t")] long pts, [NativeTypeName("int64_t")] long dts, [NativeTypeName("int64_t")] long pos);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_parser_change(AVCodecParserContext* s, AVCodecContext* avctx, [NativeTypeName("uint8_t **")] byte** poutbuf, int* poutbuf_size, [NativeTypeName("const uint8_t *")] byte* buf, int buf_size, int keyframe);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_parser_close(AVCodecParserContext* s);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_encode_audio2(AVCodecContext* avctx, AVPacket* avpkt, [NativeTypeName("const AVFrame *")] AVFrame* frame, int* got_packet_ptr);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_encode_video2(AVCodecContext* avctx, AVPacket* avpkt, [NativeTypeName("const AVFrame *")] AVFrame* frame, int* got_packet_ptr);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_encode_subtitle(AVCodecContext* avctx, [NativeTypeName("uint8_t *")] byte* buf, int buf_size, [NativeTypeName("const AVSubtitle *")] AVSubtitle* sub);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avpicture_alloc(AVPicture* picture, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt, int width, int height);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avpicture_free(AVPicture* picture);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avpicture_fill(AVPicture* picture, [NativeTypeName("const uint8_t *")] byte* ptr, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt, int width, int height);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avpicture_layout([NativeTypeName("const AVPicture *")] AVPicture* src, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt, int width, int height, [NativeTypeName("unsigned char *")] byte* dest, int dest_size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avpicture_get_size([NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt, int width, int height);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_picture_copy(AVPicture* dst, [NativeTypeName("const AVPicture *")] AVPicture* src, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt, int width, int height);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_picture_crop(AVPicture* dst, [NativeTypeName("const AVPicture *")] AVPicture* src, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt, int top_band, int left_band);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_picture_pad(AVPicture* dst, [NativeTypeName("const AVPicture *")] AVPicture* src, int height, int width, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt, int padtop, int padbottom, int padleft, int padright, int* color);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avcodec_get_chroma_sub_sample([NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt, int* h_shift, int* v_shift);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avcodec_pix_fmt_to_codec_tag([NativeTypeName("enum AVPixelFormat")] AVPixelFormat pix_fmt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVPixelFormat")]
        public static extern AVPixelFormat avcodec_find_best_pix_fmt_of_list([NativeTypeName("const enum AVPixelFormat *")] AVPixelFormat* pix_fmt_list, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat src_pix_fmt, int has_alpha, int* loss_ptr);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_get_pix_fmt_loss([NativeTypeName("enum AVPixelFormat")] AVPixelFormat dst_pix_fmt, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat src_pix_fmt, int has_alpha);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVPixelFormat")]
        public static extern AVPixelFormat avcodec_find_best_pix_fmt_of_2([NativeTypeName("enum AVPixelFormat")] AVPixelFormat dst_pix_fmt1, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat dst_pix_fmt2, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat src_pix_fmt, int has_alpha, int* loss_ptr);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVPixelFormat")]
        public static extern AVPixelFormat avcodec_find_best_pix_fmt2([NativeTypeName("enum AVPixelFormat")] AVPixelFormat dst_pix_fmt1, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat dst_pix_fmt2, [NativeTypeName("enum AVPixelFormat")] AVPixelFormat src_pix_fmt, int has_alpha, int* loss_ptr);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVPixelFormat")]
        public static extern AVPixelFormat avcodec_default_get_format([NativeTypeName("struct AVCodecContext *")] AVCodecContext* s, [NativeTypeName("const enum AVPixelFormat *")] AVPixelFormat* fmt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern UIntPtr av_get_codec_tag_string([NativeTypeName("char *")] sbyte* buf, [NativeTypeName("size_t")] UIntPtr buf_size, [NativeTypeName("unsigned int")] uint codec_tag);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avcodec_string([NativeTypeName("char *")] sbyte* buf, int buf_size, AVCodecContext* enc, int encode);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_get_profile_name([NativeTypeName("const AVCodec *")] AVCodec* codec, int profile);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avcodec_profile_name([NativeTypeName("enum AVCodecID")] AVCodecID codec_id, int profile);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_default_execute(AVCodecContext* c, [NativeTypeName("int (*)(AVCodecContext *, void *)")] IntPtr func, void* arg, int* ret, int count, int size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_default_execute2(AVCodecContext* c, [NativeTypeName("int (*)(AVCodecContext *, void *, int, int)")] IntPtr func, void* arg, int* ret, int count);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_fill_audio_frame(AVFrame* frame, int nb_channels, [NativeTypeName("enum AVSampleFormat")] AVSampleFormat sample_fmt, [NativeTypeName("const uint8_t *")] byte* buf, int buf_size, int align);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avcodec_flush_buffers(AVCodecContext* avctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_bits_per_sample([NativeTypeName("enum AVCodecID")] AVCodecID codec_id);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVCodecID")]
        public static extern AVCodecID av_get_pcm_codec([NativeTypeName("enum AVSampleFormat")] AVSampleFormat fmt, int be);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_exact_bits_per_sample([NativeTypeName("enum AVCodecID")] AVCodecID codec_id);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_audio_frame_duration(AVCodecContext* avctx, int frame_bytes);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_audio_frame_duration2(AVCodecParameters* par, int frame_bytes);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_register_bitstream_filter(AVBitStreamFilter* bsf);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBitStreamFilterContext* av_bitstream_filter_init([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_bitstream_filter_filter(AVBitStreamFilterContext* bsfc, AVCodecContext* avctx, [NativeTypeName("const char *")] sbyte* args, [NativeTypeName("uint8_t **")] byte** poutbuf, int* poutbuf_size, [NativeTypeName("const uint8_t *")] byte* buf, int buf_size, int keyframe);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_bitstream_filter_close(AVBitStreamFilterContext* bsf);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVBitStreamFilter *")]
        public static extern AVBitStreamFilter* av_bitstream_filter_next([NativeTypeName("const AVBitStreamFilter *")] AVBitStreamFilter* f);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVBitStreamFilter *")]
        public static extern AVBitStreamFilter* av_bsf_next(void** opaque);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_fast_padded_malloc(void* ptr, [NativeTypeName("unsigned int *")] uint* size, [NativeTypeName("size_t")] UIntPtr min_size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_fast_padded_mallocz(void* ptr, [NativeTypeName("unsigned int *")] uint* size, [NativeTypeName("size_t")] UIntPtr min_size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint av_xiphlacing([NativeTypeName("unsigned char *")] byte* s, [NativeTypeName("unsigned int")] uint v);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_register_hwaccel(AVHWAccel* hwaccel);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVHWAccel* av_hwaccel_next([NativeTypeName("const AVHWAccel *")] AVHWAccel* hwaccel);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_lockmgr_register([NativeTypeName("int (*)(void **, enum AVLockOp)")] IntPtr cb);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_is_open(AVCodecContext* s);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCPBProperties* av_cpb_properties_alloc([NativeTypeName("size_t *")] UIntPtr* size);

        [NativeTypeName("#define AV_INPUT_BUFFER_PADDING_SIZE 64")]
        public const int AV_INPUT_BUFFER_PADDING_SIZE = 64;

        [NativeTypeName("#define AV_INPUT_BUFFER_MIN_SIZE 16384")]
        public const int AV_INPUT_BUFFER_MIN_SIZE = 16384;

        [NativeTypeName("#define AV_CODEC_FLAG_UNALIGNED (1 <<  0)")]
        public const int AV_CODEC_FLAG_UNALIGNED = (1 << 0);

        [NativeTypeName("#define AV_CODEC_FLAG_QSCALE (1 <<  1)")]
        public const int AV_CODEC_FLAG_QSCALE = (1 << 1);

        [NativeTypeName("#define AV_CODEC_FLAG_4MV (1 <<  2)")]
        public const int AV_CODEC_FLAG_4MV = (1 << 2);

        [NativeTypeName("#define AV_CODEC_FLAG_OUTPUT_CORRUPT (1 <<  3)")]
        public const int AV_CODEC_FLAG_OUTPUT_CORRUPT = (1 << 3);

        [NativeTypeName("#define AV_CODEC_FLAG_QPEL (1 <<  4)")]
        public const int AV_CODEC_FLAG_QPEL = (1 << 4);

        [NativeTypeName("#define AV_CODEC_FLAG_DROPCHANGED (1 <<  5)")]
        public const int AV_CODEC_FLAG_DROPCHANGED = (1 << 5);

        [NativeTypeName("#define AV_CODEC_FLAG_PASS1 (1 <<  9)")]
        public const int AV_CODEC_FLAG_PASS1 = (1 << 9);

        [NativeTypeName("#define AV_CODEC_FLAG_PASS2 (1 << 10)")]
        public const int AV_CODEC_FLAG_PASS2 = (1 << 10);

        [NativeTypeName("#define AV_CODEC_FLAG_LOOP_FILTER (1 << 11)")]
        public const int AV_CODEC_FLAG_LOOP_FILTER = (1 << 11);

        [NativeTypeName("#define AV_CODEC_FLAG_GRAY (1 << 13)")]
        public const int AV_CODEC_FLAG_GRAY = (1 << 13);

        [NativeTypeName("#define AV_CODEC_FLAG_PSNR (1 << 15)")]
        public const int AV_CODEC_FLAG_PSNR = (1 << 15);

        [NativeTypeName("#define AV_CODEC_FLAG_TRUNCATED (1 << 16)")]
        public const int AV_CODEC_FLAG_TRUNCATED = (1 << 16);

        [NativeTypeName("#define AV_CODEC_FLAG_INTERLACED_DCT (1 << 18)")]
        public const int AV_CODEC_FLAG_INTERLACED_DCT = (1 << 18);

        [NativeTypeName("#define AV_CODEC_FLAG_LOW_DELAY (1 << 19)")]
        public const int AV_CODEC_FLAG_LOW_DELAY = (1 << 19);

        [NativeTypeName("#define AV_CODEC_FLAG_GLOBAL_HEADER (1 << 22)")]
        public const int AV_CODEC_FLAG_GLOBAL_HEADER = (1 << 22);

        [NativeTypeName("#define AV_CODEC_FLAG_BITEXACT (1 << 23)")]
        public const int AV_CODEC_FLAG_BITEXACT = (1 << 23);

        [NativeTypeName("#define AV_CODEC_FLAG_AC_PRED (1 << 24)")]
        public const int AV_CODEC_FLAG_AC_PRED = (1 << 24);

        [NativeTypeName("#define AV_CODEC_FLAG_INTERLACED_ME (1 << 29)")]
        public const int AV_CODEC_FLAG_INTERLACED_ME = (1 << 29);

        [NativeTypeName("#define AV_CODEC_FLAG_CLOSED_GOP (1U << 31)")]
        public const uint AV_CODEC_FLAG_CLOSED_GOP = (1U << 31);

        [NativeTypeName("#define AV_CODEC_FLAG2_FAST (1 <<  0)")]
        public const int AV_CODEC_FLAG2_FAST = (1 << 0);

        [NativeTypeName("#define AV_CODEC_FLAG2_NO_OUTPUT (1 <<  2)")]
        public const int AV_CODEC_FLAG2_NO_OUTPUT = (1 << 2);

        [NativeTypeName("#define AV_CODEC_FLAG2_LOCAL_HEADER (1 <<  3)")]
        public const int AV_CODEC_FLAG2_LOCAL_HEADER = (1 << 3);

        [NativeTypeName("#define AV_CODEC_FLAG2_DROP_FRAME_TIMECODE (1 << 13)")]
        public const int AV_CODEC_FLAG2_DROP_FRAME_TIMECODE = (1 << 13);

        [NativeTypeName("#define AV_CODEC_FLAG2_CHUNKS (1 << 15)")]
        public const int AV_CODEC_FLAG2_CHUNKS = (1 << 15);

        [NativeTypeName("#define AV_CODEC_FLAG2_IGNORE_CROP (1 << 16)")]
        public const int AV_CODEC_FLAG2_IGNORE_CROP = (1 << 16);

        [NativeTypeName("#define AV_CODEC_FLAG2_SHOW_ALL (1 << 22)")]
        public const int AV_CODEC_FLAG2_SHOW_ALL = (1 << 22);

        [NativeTypeName("#define AV_CODEC_FLAG2_EXPORT_MVS (1 << 28)")]
        public const int AV_CODEC_FLAG2_EXPORT_MVS = (1 << 28);

        [NativeTypeName("#define AV_CODEC_FLAG2_SKIP_MANUAL (1 << 29)")]
        public const int AV_CODEC_FLAG2_SKIP_MANUAL = (1 << 29);

        [NativeTypeName("#define AV_CODEC_FLAG2_RO_FLUSH_NOOP (1 << 30)")]
        public const int AV_CODEC_FLAG2_RO_FLUSH_NOOP = (1 << 30);

        [NativeTypeName("#define AV_CODEC_EXPORT_DATA_MVS (1 << 0)")]
        public const int AV_CODEC_EXPORT_DATA_MVS = (1 << 0);

        [NativeTypeName("#define AV_CODEC_EXPORT_DATA_PRFT (1 << 1)")]
        public const int AV_CODEC_EXPORT_DATA_PRFT = (1 << 1);

        [NativeTypeName("#define AV_CODEC_EXPORT_DATA_VIDEO_ENC_PARAMS (1 << 2)")]
        public const int AV_CODEC_EXPORT_DATA_VIDEO_ENC_PARAMS = (1 << 2);

        [NativeTypeName("#define AV_CODEC_EXPORT_DATA_FILM_GRAIN (1 << 3)")]
        public const int AV_CODEC_EXPORT_DATA_FILM_GRAIN = (1 << 3);

        [NativeTypeName("#define AV_GET_BUFFER_FLAG_REF (1 << 0)")]
        public const int AV_GET_BUFFER_FLAG_REF = (1 << 0);

        [NativeTypeName("#define AV_GET_ENCODE_BUFFER_FLAG_REF (1 << 0)")]
        public const int AV_GET_ENCODE_BUFFER_FLAG_REF = (1 << 0);

        [NativeTypeName("#define FF_COMPRESSION_DEFAULT -1")]
        public const int FF_COMPRESSION_DEFAULT = -1;

        [NativeTypeName("#define FF_PRED_LEFT 0")]
        public const int FF_PRED_LEFT = 0;

        [NativeTypeName("#define FF_PRED_PLANE 1")]
        public const int FF_PRED_PLANE = 1;

        [NativeTypeName("#define FF_PRED_MEDIAN 2")]
        public const int FF_PRED_MEDIAN = 2;

        [NativeTypeName("#define FF_CMP_SAD 0")]
        public const int FF_CMP_SAD = 0;

        [NativeTypeName("#define FF_CMP_SSE 1")]
        public const int FF_CMP_SSE = 1;

        [NativeTypeName("#define FF_CMP_SATD 2")]
        public const int FF_CMP_SATD = 2;

        [NativeTypeName("#define FF_CMP_DCT 3")]
        public const int FF_CMP_DCT = 3;

        [NativeTypeName("#define FF_CMP_PSNR 4")]
        public const int FF_CMP_PSNR = 4;

        [NativeTypeName("#define FF_CMP_BIT 5")]
        public const int FF_CMP_BIT = 5;

        [NativeTypeName("#define FF_CMP_RD 6")]
        public const int FF_CMP_RD = 6;

        [NativeTypeName("#define FF_CMP_ZERO 7")]
        public const int FF_CMP_ZERO = 7;

        [NativeTypeName("#define FF_CMP_VSAD 8")]
        public const int FF_CMP_VSAD = 8;

        [NativeTypeName("#define FF_CMP_VSSE 9")]
        public const int FF_CMP_VSSE = 9;

        [NativeTypeName("#define FF_CMP_NSSE 10")]
        public const int FF_CMP_NSSE = 10;

        [NativeTypeName("#define FF_CMP_W53 11")]
        public const int FF_CMP_W53 = 11;

        [NativeTypeName("#define FF_CMP_W97 12")]
        public const int FF_CMP_W97 = 12;

        [NativeTypeName("#define FF_CMP_DCTMAX 13")]
        public const int FF_CMP_DCTMAX = 13;

        [NativeTypeName("#define FF_CMP_DCT264 14")]
        public const int FF_CMP_DCT264 = 14;

        [NativeTypeName("#define FF_CMP_MEDIAN_SAD 15")]
        public const int FF_CMP_MEDIAN_SAD = 15;

        [NativeTypeName("#define FF_CMP_CHROMA 256")]
        public const int FF_CMP_CHROMA = 256;

        [NativeTypeName("#define SLICE_FLAG_CODED_ORDER 0x0001")]
        public const int SLICE_FLAG_CODED_ORDER = 0x0001;

        [NativeTypeName("#define SLICE_FLAG_ALLOW_FIELD 0x0002")]
        public const int SLICE_FLAG_ALLOW_FIELD = 0x0002;

        [NativeTypeName("#define SLICE_FLAG_ALLOW_PLANE 0x0004")]
        public const int SLICE_FLAG_ALLOW_PLANE = 0x0004;

        [NativeTypeName("#define FF_MB_DECISION_SIMPLE 0")]
        public const int FF_MB_DECISION_SIMPLE = 0;

        [NativeTypeName("#define FF_MB_DECISION_BITS 1")]
        public const int FF_MB_DECISION_BITS = 1;

        [NativeTypeName("#define FF_MB_DECISION_RD 2")]
        public const int FF_MB_DECISION_RD = 2;

        [NativeTypeName("#define FF_CODER_TYPE_VLC 0")]
        public const int FF_CODER_TYPE_VLC = 0;

        [NativeTypeName("#define FF_CODER_TYPE_AC 1")]
        public const int FF_CODER_TYPE_AC = 1;

        [NativeTypeName("#define FF_CODER_TYPE_RAW 2")]
        public const int FF_CODER_TYPE_RAW = 2;

        [NativeTypeName("#define FF_CODER_TYPE_RLE 3")]
        public const int FF_CODER_TYPE_RLE = 3;

        [NativeTypeName("#define FF_BUG_AUTODETECT 1")]
        public const int FF_BUG_AUTODETECT = 1;

        [NativeTypeName("#define FF_BUG_XVID_ILACE 4")]
        public const int FF_BUG_XVID_ILACE = 4;

        [NativeTypeName("#define FF_BUG_UMP4 8")]
        public const int FF_BUG_UMP4 = 8;

        [NativeTypeName("#define FF_BUG_NO_PADDING 16")]
        public const int FF_BUG_NO_PADDING = 16;

        [NativeTypeName("#define FF_BUG_AMV 32")]
        public const int FF_BUG_AMV = 32;

        [NativeTypeName("#define FF_BUG_QPEL_CHROMA 64")]
        public const int FF_BUG_QPEL_CHROMA = 64;

        [NativeTypeName("#define FF_BUG_STD_QPEL 128")]
        public const int FF_BUG_STD_QPEL = 128;

        [NativeTypeName("#define FF_BUG_QPEL_CHROMA2 256")]
        public const int FF_BUG_QPEL_CHROMA2 = 256;

        [NativeTypeName("#define FF_BUG_DIRECT_BLOCKSIZE 512")]
        public const int FF_BUG_DIRECT_BLOCKSIZE = 512;

        [NativeTypeName("#define FF_BUG_EDGE 1024")]
        public const int FF_BUG_EDGE = 1024;

        [NativeTypeName("#define FF_BUG_HPEL_CHROMA 2048")]
        public const int FF_BUG_HPEL_CHROMA = 2048;

        [NativeTypeName("#define FF_BUG_DC_CLIP 4096")]
        public const int FF_BUG_DC_CLIP = 4096;

        [NativeTypeName("#define FF_BUG_MS 8192")]
        public const int FF_BUG_MS = 8192;

        [NativeTypeName("#define FF_BUG_TRUNCATED 16384")]
        public const int FF_BUG_TRUNCATED = 16384;

        [NativeTypeName("#define FF_BUG_IEDGE 32768")]
        public const int FF_BUG_IEDGE = 32768;

        [NativeTypeName("#define FF_COMPLIANCE_VERY_STRICT 2")]
        public const int FF_COMPLIANCE_VERY_STRICT = 2;

        [NativeTypeName("#define FF_COMPLIANCE_STRICT 1")]
        public const int FF_COMPLIANCE_STRICT = 1;

        [NativeTypeName("#define FF_COMPLIANCE_NORMAL 0")]
        public const int FF_COMPLIANCE_NORMAL = 0;

        [NativeTypeName("#define FF_COMPLIANCE_UNOFFICIAL -1")]
        public const int FF_COMPLIANCE_UNOFFICIAL = -1;

        [NativeTypeName("#define FF_COMPLIANCE_EXPERIMENTAL -2")]
        public const int FF_COMPLIANCE_EXPERIMENTAL = -2;

        [NativeTypeName("#define FF_EC_GUESS_MVS 1")]
        public const int FF_EC_GUESS_MVS = 1;

        [NativeTypeName("#define FF_EC_DEBLOCK 2")]
        public const int FF_EC_DEBLOCK = 2;

        [NativeTypeName("#define FF_EC_FAVOR_INTER 256")]
        public const int FF_EC_FAVOR_INTER = 256;

        [NativeTypeName("#define FF_DEBUG_PICT_INFO 1")]
        public const int FF_DEBUG_PICT_INFO = 1;

        [NativeTypeName("#define FF_DEBUG_RC 2")]
        public const int FF_DEBUG_RC = 2;

        [NativeTypeName("#define FF_DEBUG_BITSTREAM 4")]
        public const int FF_DEBUG_BITSTREAM = 4;

        [NativeTypeName("#define FF_DEBUG_MB_TYPE 8")]
        public const int FF_DEBUG_MB_TYPE = 8;

        [NativeTypeName("#define FF_DEBUG_QP 16")]
        public const int FF_DEBUG_QP = 16;

        [NativeTypeName("#define FF_DEBUG_DCT_COEFF 0x00000040")]
        public const int FF_DEBUG_DCT_COEFF = 0x00000040;

        [NativeTypeName("#define FF_DEBUG_SKIP 0x00000080")]
        public const int FF_DEBUG_SKIP = 0x00000080;

        [NativeTypeName("#define FF_DEBUG_STARTCODE 0x00000100")]
        public const int FF_DEBUG_STARTCODE = 0x00000100;

        [NativeTypeName("#define FF_DEBUG_ER 0x00000400")]
        public const int FF_DEBUG_ER = 0x00000400;

        [NativeTypeName("#define FF_DEBUG_MMCO 0x00000800")]
        public const int FF_DEBUG_MMCO = 0x00000800;

        [NativeTypeName("#define FF_DEBUG_BUGS 0x00001000")]
        public const int FF_DEBUG_BUGS = 0x00001000;

        [NativeTypeName("#define FF_DEBUG_BUFFERS 0x00008000")]
        public const int FF_DEBUG_BUFFERS = 0x00008000;

        [NativeTypeName("#define FF_DEBUG_THREADS 0x00010000")]
        public const int FF_DEBUG_THREADS = 0x00010000;

        [NativeTypeName("#define FF_DEBUG_GREEN_MD 0x00800000")]
        public const int FF_DEBUG_GREEN_MD = 0x00800000;

        [NativeTypeName("#define FF_DEBUG_NOMC 0x01000000")]
        public const int FF_DEBUG_NOMC = 0x01000000;

        [NativeTypeName("#define AV_EF_CRCCHECK (1<<0)")]
        public const int AV_EF_CRCCHECK = (1 << 0);

        [NativeTypeName("#define AV_EF_BITSTREAM (1<<1)")]
        public const int AV_EF_BITSTREAM = (1 << 1);

        [NativeTypeName("#define AV_EF_BUFFER (1<<2)")]
        public const int AV_EF_BUFFER = (1 << 2);

        [NativeTypeName("#define AV_EF_EXPLODE (1<<3)")]
        public const int AV_EF_EXPLODE = (1 << 3);

        [NativeTypeName("#define AV_EF_IGNORE_ERR (1<<15)")]
        public const int AV_EF_IGNORE_ERR = (1 << 15);

        [NativeTypeName("#define AV_EF_CAREFUL (1<<16)")]
        public const int AV_EF_CAREFUL = (1 << 16);

        [NativeTypeName("#define AV_EF_COMPLIANT (1<<17)")]
        public const int AV_EF_COMPLIANT = (1 << 17);

        [NativeTypeName("#define AV_EF_AGGRESSIVE (1<<18)")]
        public const int AV_EF_AGGRESSIVE = (1 << 18);

        [NativeTypeName("#define FF_DCT_AUTO 0")]
        public const int FF_DCT_AUTO = 0;

        [NativeTypeName("#define FF_DCT_FASTINT 1")]
        public const int FF_DCT_FASTINT = 1;

        [NativeTypeName("#define FF_DCT_INT 2")]
        public const int FF_DCT_INT = 2;

        [NativeTypeName("#define FF_DCT_MMX 3")]
        public const int FF_DCT_MMX = 3;

        [NativeTypeName("#define FF_DCT_ALTIVEC 5")]
        public const int FF_DCT_ALTIVEC = 5;

        [NativeTypeName("#define FF_DCT_FAAN 6")]
        public const int FF_DCT_FAAN = 6;

        [NativeTypeName("#define FF_IDCT_AUTO 0")]
        public const int FF_IDCT_AUTO = 0;

        [NativeTypeName("#define FF_IDCT_INT 1")]
        public const int FF_IDCT_INT = 1;

        [NativeTypeName("#define FF_IDCT_SIMPLE 2")]
        public const int FF_IDCT_SIMPLE = 2;

        [NativeTypeName("#define FF_IDCT_SIMPLEMMX 3")]
        public const int FF_IDCT_SIMPLEMMX = 3;

        [NativeTypeName("#define FF_IDCT_ARM 7")]
        public const int FF_IDCT_ARM = 7;

        [NativeTypeName("#define FF_IDCT_ALTIVEC 8")]
        public const int FF_IDCT_ALTIVEC = 8;

        [NativeTypeName("#define FF_IDCT_SIMPLEARM 10")]
        public const int FF_IDCT_SIMPLEARM = 10;

        [NativeTypeName("#define FF_IDCT_XVID 14")]
        public const int FF_IDCT_XVID = 14;

        [NativeTypeName("#define FF_IDCT_SIMPLEARMV5TE 16")]
        public const int FF_IDCT_SIMPLEARMV5TE = 16;

        [NativeTypeName("#define FF_IDCT_SIMPLEARMV6 17")]
        public const int FF_IDCT_SIMPLEARMV6 = 17;

        [NativeTypeName("#define FF_IDCT_FAAN 20")]
        public const int FF_IDCT_FAAN = 20;

        [NativeTypeName("#define FF_IDCT_SIMPLENEON 22")]
        public const int FF_IDCT_SIMPLENEON = 22;

        [NativeTypeName("#define FF_IDCT_NONE 24")]
        public const int FF_IDCT_NONE = 24;

        [NativeTypeName("#define FF_IDCT_SIMPLEAUTO 128")]
        public const int FF_IDCT_SIMPLEAUTO = 128;

        [NativeTypeName("#define FF_THREAD_FRAME 1")]
        public const int FF_THREAD_FRAME = 1;

        [NativeTypeName("#define FF_THREAD_SLICE 2")]
        public const int FF_THREAD_SLICE = 2;

        [NativeTypeName("#define FF_PROFILE_UNKNOWN -99")]
        public const int FF_PROFILE_UNKNOWN = -99;

        [NativeTypeName("#define FF_PROFILE_RESERVED -100")]
        public const int FF_PROFILE_RESERVED = -100;

        [NativeTypeName("#define FF_PROFILE_AAC_MAIN 0")]
        public const int FF_PROFILE_AAC_MAIN = 0;

        [NativeTypeName("#define FF_PROFILE_AAC_LOW 1")]
        public const int FF_PROFILE_AAC_LOW = 1;

        [NativeTypeName("#define FF_PROFILE_AAC_SSR 2")]
        public const int FF_PROFILE_AAC_SSR = 2;

        [NativeTypeName("#define FF_PROFILE_AAC_LTP 3")]
        public const int FF_PROFILE_AAC_LTP = 3;

        [NativeTypeName("#define FF_PROFILE_AAC_HE 4")]
        public const int FF_PROFILE_AAC_HE = 4;

        [NativeTypeName("#define FF_PROFILE_AAC_HE_V2 28")]
        public const int FF_PROFILE_AAC_HE_V2 = 28;

        [NativeTypeName("#define FF_PROFILE_AAC_LD 22")]
        public const int FF_PROFILE_AAC_LD = 22;

        [NativeTypeName("#define FF_PROFILE_AAC_ELD 38")]
        public const int FF_PROFILE_AAC_ELD = 38;

        [NativeTypeName("#define FF_PROFILE_MPEG2_AAC_LOW 128")]
        public const int FF_PROFILE_MPEG2_AAC_LOW = 128;

        [NativeTypeName("#define FF_PROFILE_MPEG2_AAC_HE 131")]
        public const int FF_PROFILE_MPEG2_AAC_HE = 131;

        [NativeTypeName("#define FF_PROFILE_DNXHD 0")]
        public const int FF_PROFILE_DNXHD = 0;

        [NativeTypeName("#define FF_PROFILE_DNXHR_LB 1")]
        public const int FF_PROFILE_DNXHR_LB = 1;

        [NativeTypeName("#define FF_PROFILE_DNXHR_SQ 2")]
        public const int FF_PROFILE_DNXHR_SQ = 2;

        [NativeTypeName("#define FF_PROFILE_DNXHR_HQ 3")]
        public const int FF_PROFILE_DNXHR_HQ = 3;

        [NativeTypeName("#define FF_PROFILE_DNXHR_HQX 4")]
        public const int FF_PROFILE_DNXHR_HQX = 4;

        [NativeTypeName("#define FF_PROFILE_DNXHR_444 5")]
        public const int FF_PROFILE_DNXHR_444 = 5;

        [NativeTypeName("#define FF_PROFILE_DTS 20")]
        public const int FF_PROFILE_DTS = 20;

        [NativeTypeName("#define FF_PROFILE_DTS_ES 30")]
        public const int FF_PROFILE_DTS_ES = 30;

        [NativeTypeName("#define FF_PROFILE_DTS_96_24 40")]
        public const int FF_PROFILE_DTS_96_24 = 40;

        [NativeTypeName("#define FF_PROFILE_DTS_HD_HRA 50")]
        public const int FF_PROFILE_DTS_HD_HRA = 50;

        [NativeTypeName("#define FF_PROFILE_DTS_HD_MA 60")]
        public const int FF_PROFILE_DTS_HD_MA = 60;

        [NativeTypeName("#define FF_PROFILE_DTS_EXPRESS 70")]
        public const int FF_PROFILE_DTS_EXPRESS = 70;

        [NativeTypeName("#define FF_PROFILE_MPEG2_422 0")]
        public const int FF_PROFILE_MPEG2_422 = 0;

        [NativeTypeName("#define FF_PROFILE_MPEG2_HIGH 1")]
        public const int FF_PROFILE_MPEG2_HIGH = 1;

        [NativeTypeName("#define FF_PROFILE_MPEG2_SS 2")]
        public const int FF_PROFILE_MPEG2_SS = 2;

        [NativeTypeName("#define FF_PROFILE_MPEG2_SNR_SCALABLE 3")]
        public const int FF_PROFILE_MPEG2_SNR_SCALABLE = 3;

        [NativeTypeName("#define FF_PROFILE_MPEG2_MAIN 4")]
        public const int FF_PROFILE_MPEG2_MAIN = 4;

        [NativeTypeName("#define FF_PROFILE_MPEG2_SIMPLE 5")]
        public const int FF_PROFILE_MPEG2_SIMPLE = 5;

        [NativeTypeName("#define FF_PROFILE_H264_CONSTRAINED (1<<9)")]
        public const int FF_PROFILE_H264_CONSTRAINED = (1 << 9);

        [NativeTypeName("#define FF_PROFILE_H264_INTRA (1<<11)")]
        public const int FF_PROFILE_H264_INTRA = (1 << 11);

        [NativeTypeName("#define FF_PROFILE_H264_BASELINE 66")]
        public const int FF_PROFILE_H264_BASELINE = 66;

        [NativeTypeName("#define FF_PROFILE_H264_CONSTRAINED_BASELINE (66|FF_PROFILE_H264_CONSTRAINED)")]
        public const int FF_PROFILE_H264_CONSTRAINED_BASELINE = (66 | (1 << 9));

        [NativeTypeName("#define FF_PROFILE_H264_MAIN 77")]
        public const int FF_PROFILE_H264_MAIN = 77;

        [NativeTypeName("#define FF_PROFILE_H264_EXTENDED 88")]
        public const int FF_PROFILE_H264_EXTENDED = 88;

        [NativeTypeName("#define FF_PROFILE_H264_HIGH 100")]
        public const int FF_PROFILE_H264_HIGH = 100;

        [NativeTypeName("#define FF_PROFILE_H264_HIGH_10 110")]
        public const int FF_PROFILE_H264_HIGH_10 = 110;

        [NativeTypeName("#define FF_PROFILE_H264_HIGH_10_INTRA (110|FF_PROFILE_H264_INTRA)")]
        public const int FF_PROFILE_H264_HIGH_10_INTRA = (110 | (1 << 11));

        [NativeTypeName("#define FF_PROFILE_H264_MULTIVIEW_HIGH 118")]
        public const int FF_PROFILE_H264_MULTIVIEW_HIGH = 118;

        [NativeTypeName("#define FF_PROFILE_H264_HIGH_422 122")]
        public const int FF_PROFILE_H264_HIGH_422 = 122;

        [NativeTypeName("#define FF_PROFILE_H264_HIGH_422_INTRA (122|FF_PROFILE_H264_INTRA)")]
        public const int FF_PROFILE_H264_HIGH_422_INTRA = (122 | (1 << 11));

        [NativeTypeName("#define FF_PROFILE_H264_STEREO_HIGH 128")]
        public const int FF_PROFILE_H264_STEREO_HIGH = 128;

        [NativeTypeName("#define FF_PROFILE_H264_HIGH_444 144")]
        public const int FF_PROFILE_H264_HIGH_444 = 144;

        [NativeTypeName("#define FF_PROFILE_H264_HIGH_444_PREDICTIVE 244")]
        public const int FF_PROFILE_H264_HIGH_444_PREDICTIVE = 244;

        [NativeTypeName("#define FF_PROFILE_H264_HIGH_444_INTRA (244|FF_PROFILE_H264_INTRA)")]
        public const int FF_PROFILE_H264_HIGH_444_INTRA = (244 | (1 << 11));

        [NativeTypeName("#define FF_PROFILE_H264_CAVLC_444 44")]
        public const int FF_PROFILE_H264_CAVLC_444 = 44;

        [NativeTypeName("#define FF_PROFILE_VC1_SIMPLE 0")]
        public const int FF_PROFILE_VC1_SIMPLE = 0;

        [NativeTypeName("#define FF_PROFILE_VC1_MAIN 1")]
        public const int FF_PROFILE_VC1_MAIN = 1;

        [NativeTypeName("#define FF_PROFILE_VC1_COMPLEX 2")]
        public const int FF_PROFILE_VC1_COMPLEX = 2;

        [NativeTypeName("#define FF_PROFILE_VC1_ADVANCED 3")]
        public const int FF_PROFILE_VC1_ADVANCED = 3;

        [NativeTypeName("#define FF_PROFILE_MPEG4_SIMPLE 0")]
        public const int FF_PROFILE_MPEG4_SIMPLE = 0;

        [NativeTypeName("#define FF_PROFILE_MPEG4_SIMPLE_SCALABLE 1")]
        public const int FF_PROFILE_MPEG4_SIMPLE_SCALABLE = 1;

        [NativeTypeName("#define FF_PROFILE_MPEG4_CORE 2")]
        public const int FF_PROFILE_MPEG4_CORE = 2;

        [NativeTypeName("#define FF_PROFILE_MPEG4_MAIN 3")]
        public const int FF_PROFILE_MPEG4_MAIN = 3;

        [NativeTypeName("#define FF_PROFILE_MPEG4_N_BIT 4")]
        public const int FF_PROFILE_MPEG4_N_BIT = 4;

        [NativeTypeName("#define FF_PROFILE_MPEG4_SCALABLE_TEXTURE 5")]
        public const int FF_PROFILE_MPEG4_SCALABLE_TEXTURE = 5;

        [NativeTypeName("#define FF_PROFILE_MPEG4_SIMPLE_FACE_ANIMATION 6")]
        public const int FF_PROFILE_MPEG4_SIMPLE_FACE_ANIMATION = 6;

        [NativeTypeName("#define FF_PROFILE_MPEG4_BASIC_ANIMATED_TEXTURE 7")]
        public const int FF_PROFILE_MPEG4_BASIC_ANIMATED_TEXTURE = 7;

        [NativeTypeName("#define FF_PROFILE_MPEG4_HYBRID 8")]
        public const int FF_PROFILE_MPEG4_HYBRID = 8;

        [NativeTypeName("#define FF_PROFILE_MPEG4_ADVANCED_REAL_TIME 9")]
        public const int FF_PROFILE_MPEG4_ADVANCED_REAL_TIME = 9;

        [NativeTypeName("#define FF_PROFILE_MPEG4_CORE_SCALABLE 10")]
        public const int FF_PROFILE_MPEG4_CORE_SCALABLE = 10;

        [NativeTypeName("#define FF_PROFILE_MPEG4_ADVANCED_CODING 11")]
        public const int FF_PROFILE_MPEG4_ADVANCED_CODING = 11;

        [NativeTypeName("#define FF_PROFILE_MPEG4_ADVANCED_CORE 12")]
        public const int FF_PROFILE_MPEG4_ADVANCED_CORE = 12;

        [NativeTypeName("#define FF_PROFILE_MPEG4_ADVANCED_SCALABLE_TEXTURE 13")]
        public const int FF_PROFILE_MPEG4_ADVANCED_SCALABLE_TEXTURE = 13;

        [NativeTypeName("#define FF_PROFILE_MPEG4_SIMPLE_STUDIO 14")]
        public const int FF_PROFILE_MPEG4_SIMPLE_STUDIO = 14;

        [NativeTypeName("#define FF_PROFILE_MPEG4_ADVANCED_SIMPLE 15")]
        public const int FF_PROFILE_MPEG4_ADVANCED_SIMPLE = 15;

        [NativeTypeName("#define FF_PROFILE_JPEG2000_CSTREAM_RESTRICTION_0 1")]
        public const int FF_PROFILE_JPEG2000_CSTREAM_RESTRICTION_0 = 1;

        [NativeTypeName("#define FF_PROFILE_JPEG2000_CSTREAM_RESTRICTION_1 2")]
        public const int FF_PROFILE_JPEG2000_CSTREAM_RESTRICTION_1 = 2;

        [NativeTypeName("#define FF_PROFILE_JPEG2000_CSTREAM_NO_RESTRICTION 32768")]
        public const int FF_PROFILE_JPEG2000_CSTREAM_NO_RESTRICTION = 32768;

        [NativeTypeName("#define FF_PROFILE_JPEG2000_DCINEMA_2K 3")]
        public const int FF_PROFILE_JPEG2000_DCINEMA_2K = 3;

        [NativeTypeName("#define FF_PROFILE_JPEG2000_DCINEMA_4K 4")]
        public const int FF_PROFILE_JPEG2000_DCINEMA_4K = 4;

        [NativeTypeName("#define FF_PROFILE_VP9_0 0")]
        public const int FF_PROFILE_VP9_0 = 0;

        [NativeTypeName("#define FF_PROFILE_VP9_1 1")]
        public const int FF_PROFILE_VP9_1 = 1;

        [NativeTypeName("#define FF_PROFILE_VP9_2 2")]
        public const int FF_PROFILE_VP9_2 = 2;

        [NativeTypeName("#define FF_PROFILE_VP9_3 3")]
        public const int FF_PROFILE_VP9_3 = 3;

        [NativeTypeName("#define FF_PROFILE_HEVC_MAIN 1")]
        public const int FF_PROFILE_HEVC_MAIN = 1;

        [NativeTypeName("#define FF_PROFILE_HEVC_MAIN_10 2")]
        public const int FF_PROFILE_HEVC_MAIN_10 = 2;

        [NativeTypeName("#define FF_PROFILE_HEVC_MAIN_STILL_PICTURE 3")]
        public const int FF_PROFILE_HEVC_MAIN_STILL_PICTURE = 3;

        [NativeTypeName("#define FF_PROFILE_HEVC_REXT 4")]
        public const int FF_PROFILE_HEVC_REXT = 4;

        [NativeTypeName("#define FF_PROFILE_VVC_MAIN_10 1")]
        public const int FF_PROFILE_VVC_MAIN_10 = 1;

        [NativeTypeName("#define FF_PROFILE_VVC_MAIN_10_444 33")]
        public const int FF_PROFILE_VVC_MAIN_10_444 = 33;

        [NativeTypeName("#define FF_PROFILE_AV1_MAIN 0")]
        public const int FF_PROFILE_AV1_MAIN = 0;

        [NativeTypeName("#define FF_PROFILE_AV1_HIGH 1")]
        public const int FF_PROFILE_AV1_HIGH = 1;

        [NativeTypeName("#define FF_PROFILE_AV1_PROFESSIONAL 2")]
        public const int FF_PROFILE_AV1_PROFESSIONAL = 2;

        [NativeTypeName("#define FF_PROFILE_MJPEG_HUFFMAN_BASELINE_DCT 0xc0")]
        public const int FF_PROFILE_MJPEG_HUFFMAN_BASELINE_DCT = 0xc0;

        [NativeTypeName("#define FF_PROFILE_MJPEG_HUFFMAN_EXTENDED_SEQUENTIAL_DCT 0xc1")]
        public const int FF_PROFILE_MJPEG_HUFFMAN_EXTENDED_SEQUENTIAL_DCT = 0xc1;

        [NativeTypeName("#define FF_PROFILE_MJPEG_HUFFMAN_PROGRESSIVE_DCT 0xc2")]
        public const int FF_PROFILE_MJPEG_HUFFMAN_PROGRESSIVE_DCT = 0xc2;

        [NativeTypeName("#define FF_PROFILE_MJPEG_HUFFMAN_LOSSLESS 0xc3")]
        public const int FF_PROFILE_MJPEG_HUFFMAN_LOSSLESS = 0xc3;

        [NativeTypeName("#define FF_PROFILE_MJPEG_JPEG_LS 0xf7")]
        public const int FF_PROFILE_MJPEG_JPEG_LS = 0xf7;

        [NativeTypeName("#define FF_PROFILE_SBC_MSBC 1")]
        public const int FF_PROFILE_SBC_MSBC = 1;

        [NativeTypeName("#define FF_PROFILE_PRORES_PROXY 0")]
        public const int FF_PROFILE_PRORES_PROXY = 0;

        [NativeTypeName("#define FF_PROFILE_PRORES_LT 1")]
        public const int FF_PROFILE_PRORES_LT = 1;

        [NativeTypeName("#define FF_PROFILE_PRORES_STANDARD 2")]
        public const int FF_PROFILE_PRORES_STANDARD = 2;

        [NativeTypeName("#define FF_PROFILE_PRORES_HQ 3")]
        public const int FF_PROFILE_PRORES_HQ = 3;

        [NativeTypeName("#define FF_PROFILE_PRORES_4444 4")]
        public const int FF_PROFILE_PRORES_4444 = 4;

        [NativeTypeName("#define FF_PROFILE_PRORES_XQ 5")]
        public const int FF_PROFILE_PRORES_XQ = 5;

        [NativeTypeName("#define FF_PROFILE_ARIB_PROFILE_A 0")]
        public const int FF_PROFILE_ARIB_PROFILE_A = 0;

        [NativeTypeName("#define FF_PROFILE_ARIB_PROFILE_C 1")]
        public const int FF_PROFILE_ARIB_PROFILE_C = 1;

        [NativeTypeName("#define FF_PROFILE_KLVA_SYNC 0")]
        public const int FF_PROFILE_KLVA_SYNC = 0;

        [NativeTypeName("#define FF_PROFILE_KLVA_ASYNC 1")]
        public const int FF_PROFILE_KLVA_ASYNC = 1;

        [NativeTypeName("#define FF_LEVEL_UNKNOWN -99")]
        public const int FF_LEVEL_UNKNOWN = -99;

        [NativeTypeName("#define FF_SUB_CHARENC_MODE_DO_NOTHING -1")]
        public const int FF_SUB_CHARENC_MODE_DO_NOTHING = -1;

        [NativeTypeName("#define FF_SUB_CHARENC_MODE_AUTOMATIC 0")]
        public const int FF_SUB_CHARENC_MODE_AUTOMATIC = 0;

        [NativeTypeName("#define FF_SUB_CHARENC_MODE_PRE_DECODER 1")]
        public const int FF_SUB_CHARENC_MODE_PRE_DECODER = 1;

        [NativeTypeName("#define FF_SUB_CHARENC_MODE_IGNORE 2")]
        public const int FF_SUB_CHARENC_MODE_IGNORE = 2;

        [NativeTypeName("#define FF_DEBUG_VIS_MV_P_FOR 0x00000001")]
        public const int FF_DEBUG_VIS_MV_P_FOR = 0x00000001;

        [NativeTypeName("#define FF_DEBUG_VIS_MV_B_FOR 0x00000002")]
        public const int FF_DEBUG_VIS_MV_B_FOR = 0x00000002;

        [NativeTypeName("#define FF_DEBUG_VIS_MV_B_BACK 0x00000004")]
        public const int FF_DEBUG_VIS_MV_B_BACK = 0x00000004;

        [NativeTypeName("#define FF_CODEC_PROPERTY_LOSSLESS 0x00000001")]
        public const int FF_CODEC_PROPERTY_LOSSLESS = 0x00000001;

        [NativeTypeName("#define FF_CODEC_PROPERTY_CLOSED_CAPTIONS 0x00000002")]
        public const int FF_CODEC_PROPERTY_CLOSED_CAPTIONS = 0x00000002;

        [NativeTypeName("#define FF_SUB_TEXT_FMT_ASS 0")]
        public const int FF_SUB_TEXT_FMT_ASS = 0;

        [NativeTypeName("#define FF_SUB_TEXT_FMT_ASS_WITH_TIMINGS 1")]
        public const int FF_SUB_TEXT_FMT_ASS_WITH_TIMINGS = 1;

        [NativeTypeName("#define AV_HWACCEL_CODEC_CAP_EXPERIMENTAL 0x0200")]
        public const int AV_HWACCEL_CODEC_CAP_EXPERIMENTAL = 0x0200;

        [NativeTypeName("#define AV_HWACCEL_FLAG_IGNORE_LEVEL (1 << 0)")]
        public const int AV_HWACCEL_FLAG_IGNORE_LEVEL = (1 << 0);

        [NativeTypeName("#define AV_HWACCEL_FLAG_ALLOW_HIGH_DEPTH (1 << 1)")]
        public const int AV_HWACCEL_FLAG_ALLOW_HIGH_DEPTH = (1 << 1);

        [NativeTypeName("#define AV_HWACCEL_FLAG_ALLOW_PROFILE_MISMATCH (1 << 2)")]
        public const int AV_HWACCEL_FLAG_ALLOW_PROFILE_MISMATCH = (1 << 2);

        [NativeTypeName("#define AV_SUBTITLE_FLAG_FORCED 0x00000001")]
        public const int AV_SUBTITLE_FLAG_FORCED = 0x00000001;

        [NativeTypeName("#define AV_PARSER_PTS_NB 4")]
        public const int AV_PARSER_PTS_NB = 4;

        [NativeTypeName("#define PARSER_FLAG_COMPLETE_FRAMES 0x0001")]
        public const int PARSER_FLAG_COMPLETE_FRAMES = 0x0001;

        [NativeTypeName("#define PARSER_FLAG_ONCE 0x0002")]
        public const int PARSER_FLAG_ONCE = 0x0002;

        [NativeTypeName("#define PARSER_FLAG_FETCHED_OFFSET 0x0004")]
        public const int PARSER_FLAG_FETCHED_OFFSET = 0x0004;

        [NativeTypeName("#define PARSER_FLAG_USE_CODEC_TS 0x1000")]
        public const int PARSER_FLAG_USE_CODEC_TS = 0x1000;

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern FFTContext* av_fft_init(int nbits, int inverse);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_fft_permute(FFTContext* s, FFTComplex* z);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_fft_calc(FFTContext* s, FFTComplex* z);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_fft_end(FFTContext* s);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern FFTContext* av_mdct_init(int nbits, int inverse, double scale);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_imdct_calc(FFTContext* s, [NativeTypeName("FFTSample *")] float* output, [NativeTypeName("const FFTSample *")] float* input);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_imdct_half(FFTContext* s, [NativeTypeName("FFTSample *")] float* output, [NativeTypeName("const FFTSample *")] float* input);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_mdct_calc(FFTContext* s, [NativeTypeName("FFTSample *")] float* output, [NativeTypeName("const FFTSample *")] float* input);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_mdct_end(FFTContext* s);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern RDFTContext* av_rdft_init(int nbits, [NativeTypeName("enum RDFTransformType")] RDFTransformType trans);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_rdft_calc(RDFTContext* s, [NativeTypeName("FFTSample *")] float* data);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_rdft_end(RDFTContext* s);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern DCTContext* av_dct_init(int nbits, [NativeTypeName("enum DCTTransformType")] DCTTransformType type);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_dct_calc(DCTContext* s, [NativeTypeName("FFTSample *")] float* data);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_dct_end(DCTContext* s);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVBitStreamFilter *")]
        public static extern AVBitStreamFilter* av_bsf_get_by_name([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVBitStreamFilter *")]
        public static extern AVBitStreamFilter* av_bsf_iterate(void** opaque);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_bsf_alloc([NativeTypeName("const AVBitStreamFilter *")] AVBitStreamFilter* filter, AVBSFContext** ctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_bsf_init(AVBSFContext* ctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_bsf_send_packet(AVBSFContext* ctx, AVPacket* pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_bsf_receive_packet(AVBSFContext* ctx, AVPacket* pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_bsf_flush(AVBSFContext* ctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_bsf_free(AVBSFContext** ctx);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVClass *")]
        public static extern AVClass* av_bsf_get_class();

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVBSFList* av_bsf_list_alloc();

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_bsf_list_free(AVBSFList** lst);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_bsf_list_append(AVBSFList* lst, AVBSFContext* bsf);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_bsf_list_append2(AVBSFList* lst, [NativeTypeName("const char *")] sbyte* bsf_name, AVDictionary** options);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_bsf_list_finalize(AVBSFList** lst, AVBSFContext** bsf);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_bsf_list_parse_str([NativeTypeName("const char *")] sbyte* str, AVBSFContext** bsf);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_bsf_get_null_filter(AVBSFContext** bsf);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVCodec *")]
        public static extern AVCodec* av_codec_iterate(void** opaque);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodec* avcodec_find_decoder([NativeTypeName("enum AVCodecID")] AVCodecID id);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodec* avcodec_find_decoder_by_name([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodec* avcodec_find_encoder([NativeTypeName("enum AVCodecID")] AVCodecID id);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodec* avcodec_find_encoder_by_name([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_codec_is_encoder([NativeTypeName("const AVCodec *")] AVCodec* codec);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_codec_is_decoder([NativeTypeName("const AVCodec *")] AVCodec* codec);

        public const int AV_CODEC_HW_CONFIG_METHOD_HW_DEVICE_CTX = 0x01;
        public const int AV_CODEC_HW_CONFIG_METHOD_HW_FRAMES_CTX = 0x02;
        public const int AV_CODEC_HW_CONFIG_METHOD_INTERNAL = 0x04;
        public const int AV_CODEC_HW_CONFIG_METHOD_AD_HOC = 0x08;

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVCodecHWConfig *")]
        public static extern AVCodecHWConfig* avcodec_get_hw_config([NativeTypeName("const AVCodec *")] AVCodec* codec, int index);

        [NativeTypeName("#define AV_CODEC_CAP_DRAW_HORIZ_BAND (1 <<  0)")]
        public const int AV_CODEC_CAP_DRAW_HORIZ_BAND = (1 << 0);

        [NativeTypeName("#define AV_CODEC_CAP_DR1 (1 <<  1)")]
        public const int AV_CODEC_CAP_DR1 = (1 << 1);

        [NativeTypeName("#define AV_CODEC_CAP_TRUNCATED (1 <<  3)")]
        public const int AV_CODEC_CAP_TRUNCATED = (1 << 3);

        [NativeTypeName("#define AV_CODEC_CAP_DELAY (1 <<  5)")]
        public const int AV_CODEC_CAP_DELAY = (1 << 5);

        [NativeTypeName("#define AV_CODEC_CAP_SMALL_LAST_FRAME (1 <<  6)")]
        public const int AV_CODEC_CAP_SMALL_LAST_FRAME = (1 << 6);

        [NativeTypeName("#define AV_CODEC_CAP_SUBFRAMES (1 <<  8)")]
        public const int AV_CODEC_CAP_SUBFRAMES = (1 << 8);

        [NativeTypeName("#define AV_CODEC_CAP_EXPERIMENTAL (1 <<  9)")]
        public const int AV_CODEC_CAP_EXPERIMENTAL = (1 << 9);

        [NativeTypeName("#define AV_CODEC_CAP_CHANNEL_CONF (1 << 10)")]
        public const int AV_CODEC_CAP_CHANNEL_CONF = (1 << 10);

        [NativeTypeName("#define AV_CODEC_CAP_FRAME_THREADS (1 << 12)")]
        public const int AV_CODEC_CAP_FRAME_THREADS = (1 << 12);

        [NativeTypeName("#define AV_CODEC_CAP_SLICE_THREADS (1 << 13)")]
        public const int AV_CODEC_CAP_SLICE_THREADS = (1 << 13);

        [NativeTypeName("#define AV_CODEC_CAP_PARAM_CHANGE (1 << 14)")]
        public const int AV_CODEC_CAP_PARAM_CHANGE = (1 << 14);

        [NativeTypeName("#define AV_CODEC_CAP_OTHER_THREADS (1 << 15)")]
        public const int AV_CODEC_CAP_OTHER_THREADS = (1 << 15);

        [NativeTypeName("#define AV_CODEC_CAP_AUTO_THREADS AV_CODEC_CAP_OTHER_THREADS")]
        public const int AV_CODEC_CAP_AUTO_THREADS = (1 << 15);

        [NativeTypeName("#define AV_CODEC_CAP_VARIABLE_FRAME_SIZE (1 << 16)")]
        public const int AV_CODEC_CAP_VARIABLE_FRAME_SIZE = (1 << 16);

        [NativeTypeName("#define AV_CODEC_CAP_AVOID_PROBING (1 << 17)")]
        public const int AV_CODEC_CAP_AVOID_PROBING = (1 << 17);

        [NativeTypeName("#define AV_CODEC_CAP_INTRA_ONLY 0x40000000")]
        public const int AV_CODEC_CAP_INTRA_ONLY = 0x40000000;

        [NativeTypeName("#define AV_CODEC_CAP_LOSSLESS 0x80000000")]
        public const uint AV_CODEC_CAP_LOSSLESS = 0x80000000;

        [NativeTypeName("#define AV_CODEC_CAP_HARDWARE (1 << 18)")]
        public const int AV_CODEC_CAP_HARDWARE = (1 << 18);

        [NativeTypeName("#define AV_CODEC_CAP_HYBRID (1 << 19)")]
        public const int AV_CODEC_CAP_HYBRID = (1 << 19);

        [NativeTypeName("#define AV_CODEC_CAP_ENCODER_REORDERED_OPAQUE (1 << 20)")]
        public const int AV_CODEC_CAP_ENCODER_REORDERED_OPAQUE = (1 << 20);

        [NativeTypeName("#define AV_CODEC_CAP_ENCODER_FLUSH (1 << 21)")]
        public const int AV_CODEC_CAP_ENCODER_FLUSH = (1 << 21);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVCodecDescriptor *")]
        public static extern AVCodecDescriptor* avcodec_descriptor_get([NativeTypeName("enum AVCodecID")] AVCodecID id);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVCodecDescriptor *")]
        public static extern AVCodecDescriptor* avcodec_descriptor_next([NativeTypeName("const AVCodecDescriptor *")] AVCodecDescriptor* prev);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVCodecDescriptor *")]
        public static extern AVCodecDescriptor* avcodec_descriptor_get_by_name([NativeTypeName("const char *")] sbyte* name);

        [NativeTypeName("#define AV_CODEC_PROP_INTRA_ONLY (1 << 0)")]
        public const int AV_CODEC_PROP_INTRA_ONLY = (1 << 0);

        [NativeTypeName("#define AV_CODEC_PROP_LOSSY (1 << 1)")]
        public const int AV_CODEC_PROP_LOSSY = (1 << 1);

        [NativeTypeName("#define AV_CODEC_PROP_LOSSLESS (1 << 2)")]
        public const int AV_CODEC_PROP_LOSSLESS = (1 << 2);

        [NativeTypeName("#define AV_CODEC_PROP_REORDER (1 << 3)")]
        public const int AV_CODEC_PROP_REORDER = (1 << 3);

        [NativeTypeName("#define AV_CODEC_PROP_BITMAP_SUB (1 << 16)")]
        public const int AV_CODEC_PROP_BITMAP_SUB = (1 << 16);

        [NativeTypeName("#define AV_CODEC_PROP_TEXT_SUB (1 << 17)")]
        public const int AV_CODEC_PROP_TEXT_SUB = (1 << 17);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVMediaType")]
        public static extern AVMediaType avcodec_get_type([NativeTypeName("enum AVCodecID")] AVCodecID codec_id);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avcodec_get_name([NativeTypeName("enum AVCodecID")] AVCodecID id);

        [NativeTypeName("#define AV_CODEC_ID_IFF_BYTERUN1 AV_CODEC_ID_IFF_ILBM")]
        public const AVCodecID AV_CODEC_ID_IFF_BYTERUN1 = AV_CODEC_ID_IFF_ILBM;

        [NativeTypeName("#define AV_CODEC_ID_H265 AV_CODEC_ID_HEVC")]
        public const AVCodecID AV_CODEC_ID_H265 = AV_CODEC_ID_HEVC;

        [NativeTypeName("#define AV_CODEC_ID_H266 AV_CODEC_ID_VVC")]
        public const AVCodecID AV_CODEC_ID_H266 = AV_CODEC_ID_VVC;

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodecParameters* avcodec_parameters_alloc();

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avcodec_parameters_free(AVCodecParameters** par);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avcodec_parameters_copy(AVCodecParameters* dst, [NativeTypeName("const AVCodecParameters *")] AVCodecParameters* src);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVPacket* av_packet_alloc();

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVPacket* av_packet_clone([NativeTypeName("const AVPacket *")] AVPacket* src);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_packet_free(AVPacket** pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_init_packet(AVPacket* pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_new_packet(AVPacket* pkt, int size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_shrink_packet(AVPacket* pkt, int size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_grow_packet(AVPacket* pkt, int grow_by);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_packet_from_data(AVPacket* pkt, [NativeTypeName("uint8_t *")] byte* data, int size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_dup_packet(AVPacket* pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_copy_packet(AVPacket* dst, [NativeTypeName("const AVPacket *")] AVPacket* src);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_copy_packet_side_data(AVPacket* dst, [NativeTypeName("const AVPacket *")] AVPacket* src);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_free_packet(AVPacket* pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint8_t *")]
        public static extern byte* av_packet_new_side_data(AVPacket* pkt, [NativeTypeName("enum AVPacketSideDataType")] AVPacketSideDataType type, int size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_packet_add_side_data(AVPacket* pkt, [NativeTypeName("enum AVPacketSideDataType")] AVPacketSideDataType type, [NativeTypeName("uint8_t *")] byte* data, [NativeTypeName("size_t")] UIntPtr size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_packet_shrink_side_data(AVPacket* pkt, [NativeTypeName("enum AVPacketSideDataType")] AVPacketSideDataType type, int size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint8_t *")]
        public static extern byte* av_packet_get_side_data([NativeTypeName("const AVPacket *")] AVPacket* pkt, [NativeTypeName("enum AVPacketSideDataType")] AVPacketSideDataType type, int* size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_packet_merge_side_data(AVPacket* pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_packet_split_side_data(AVPacket* pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* av_packet_side_data_name([NativeTypeName("enum AVPacketSideDataType")] AVPacketSideDataType type);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint8_t *")]
        public static extern byte* av_packet_pack_dictionary(AVDictionary* dict, int* size);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_packet_unpack_dictionary([NativeTypeName("const uint8_t *")] byte* data, int size, AVDictionary** dict);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_packet_free_side_data(AVPacket* pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_packet_ref(AVPacket* dst, [NativeTypeName("const AVPacket *")] AVPacket* src);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_packet_unref(AVPacket* pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_packet_move_ref(AVPacket* dst, AVPacket* src);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_packet_copy_props(AVPacket* dst, [NativeTypeName("const AVPacket *")] AVPacket* src);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_packet_make_refcounted(AVPacket* pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_packet_make_writable(AVPacket* pkt);

        [DllImport("avcodec-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_packet_rescale_ts(AVPacket* pkt, AVRational tb_src, AVRational tb_dst);

        [NativeTypeName("#define AV_PKT_DATA_QUALITY_FACTOR AV_PKT_DATA_QUALITY_STATS")]
        public const AVPacketSideDataType AV_PKT_DATA_QUALITY_FACTOR = AV_PKT_DATA_QUALITY_STATS;

        [NativeTypeName("#define AV_PKT_FLAG_KEY 0x0001")]
        public const int AV_PKT_FLAG_KEY = 0x0001;

        [NativeTypeName("#define AV_PKT_FLAG_CORRUPT 0x0002")]
        public const int AV_PKT_FLAG_CORRUPT = 0x0002;

        [NativeTypeName("#define AV_PKT_FLAG_DISCARD 0x0004")]
        public const int AV_PKT_FLAG_DISCARD = 0x0004;

        [NativeTypeName("#define AV_PKT_FLAG_TRUSTED 0x0008")]
        public const int AV_PKT_FLAG_TRUSTED = 0x0008;

        [NativeTypeName("#define AV_PKT_FLAG_DISPOSABLE 0x0010")]
        public const int AV_PKT_FLAG_DISPOSABLE = 0x0010;

        [NativeTypeName("#define LIBAVCODEC_VERSION_MAJOR 58")]
        public const int LIBAVCODEC_VERSION_MAJOR = 58;

        [NativeTypeName("#define LIBAVCODEC_VERSION_MINOR 134")]
        public const int LIBAVCODEC_VERSION_MINOR = 134;

        [NativeTypeName("#define LIBAVCODEC_VERSION_MICRO 100")]
        public const int LIBAVCODEC_VERSION_MICRO = 100;

        [NativeTypeName("#define LIBAVCODEC_VERSION_INT AV_VERSION_INT(LIBAVCODEC_VERSION_MAJOR, \\\n                                               LIBAVCODEC_VERSION_MINOR, \\\n                                               LIBAVCODEC_VERSION_MICRO)")]
        public const int LIBAVCODEC_VERSION_INT = ((58) << 16 | (134) << 8 | (100));

        [NativeTypeName("#define LIBAVCODEC_BUILD LIBAVCODEC_VERSION_INT")]
        public const int LIBAVCODEC_BUILD = ((58) << 16 | (134) << 8 | (100));

        [NativeTypeName("#define LIBAVCODEC_IDENT \"Lavc\" AV_STRINGIFY(LIBAVCODEC_VERSION)")]
        public static ReadOnlySpan<byte> LIBAVCODEC_IDENT => new byte[] { 0x4C, 0x61, 0x76, 0x63, 0x35, 0x38, 0x2E, 0x31, 0x33, 0x34, 0x2E, 0x31, 0x30, 0x30, 0x00 };
    }
}
