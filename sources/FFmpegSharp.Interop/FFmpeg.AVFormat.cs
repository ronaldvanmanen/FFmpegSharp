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

using System;
using System.Runtime.InteropServices;

namespace FFmpegSharp.Interop
{
    public static unsafe partial class FFmpeg
    {
        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_packet(AVIOContext* s, AVPacket* pkt, int size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_append_packet(AVIOContext* s, AVPacket* pkt, int size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_stream_get_r_frame_rate([NativeTypeName("const AVStream *")] AVStream* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_stream_set_r_frame_rate(AVStream* s, AVRational r);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* av_stream_get_recommended_encoder_configuration([NativeTypeName("const AVStream *")] AVStream* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_stream_set_recommended_encoder_configuration(AVStream* s, [NativeTypeName("char *")] sbyte* configuration);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct AVCodecParserContext *")]
        public static extern AVCodecParserContext* av_stream_get_parser([NativeTypeName("const AVStream *")] AVStream* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long av_stream_get_end_pts([NativeTypeName("const AVStream *")] AVStream* st);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_format_get_probe_score([NativeTypeName("const AVFormatContext *")] AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodec* av_format_get_video_codec([NativeTypeName("const AVFormatContext *")] AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_format_set_video_codec(AVFormatContext* s, AVCodec* c);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodec* av_format_get_audio_codec([NativeTypeName("const AVFormatContext *")] AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_format_set_audio_codec(AVFormatContext* s, AVCodec* c);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodec* av_format_get_subtitle_codec([NativeTypeName("const AVFormatContext *")] AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_format_set_subtitle_codec(AVFormatContext* s, AVCodec* c);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVCodec* av_format_get_data_codec([NativeTypeName("const AVFormatContext *")] AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_format_set_data_codec(AVFormatContext* s, AVCodec* c);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_format_get_metadata_header_padding([NativeTypeName("const AVFormatContext *")] AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_format_set_metadata_header_padding(AVFormatContext* s, int c);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* av_format_get_opaque([NativeTypeName("const AVFormatContext *")] AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_format_set_opaque(AVFormatContext* s, void* opaque);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("av_format_control_message")]
        public static extern delegate* unmanaged[Cdecl]<AVFormatContext*, int, void*, nuint, int> av_format_get_control_message_cb([NativeTypeName("const AVFormatContext *")] AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_format_set_control_message_cb(AVFormatContext* s, [NativeTypeName("av_format_control_message")] delegate* unmanaged[Cdecl]<AVFormatContext*, int, void*, nuint, int> callback);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("AVOpenCallback")]
        public static extern delegate* unmanaged[Cdecl]<AVFormatContext*, AVIOContext**, sbyte*, int, AVIOInterruptCB*, AVDictionary**, int> av_format_get_open_cb([NativeTypeName("const AVFormatContext *")] AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_format_set_open_cb(AVFormatContext* s, [NativeTypeName("AVOpenCallback")] delegate* unmanaged[Cdecl]<AVFormatContext*, AVIOContext**, sbyte*, int, AVIOInterruptCB*, AVDictionary**, int> callback);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_format_inject_global_side_data(AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVDurationEstimationMethod")]
        public static extern AVDurationEstimationMethod av_fmt_ctx_get_duration_estimation_method([NativeTypeName("const AVFormatContext *")] AVFormatContext* ctx);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avformat_version();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avformat_configuration();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avformat_license();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_register_all();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_register_input_format(AVInputFormat* format);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_register_output_format(AVOutputFormat* format);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_network_init();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_network_deinit();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVInputFormat* av_iformat_next([NativeTypeName("const AVInputFormat *")] AVInputFormat* f);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVOutputFormat* av_oformat_next([NativeTypeName("const AVOutputFormat *")] AVOutputFormat* f);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVOutputFormat *")]
        public static extern AVOutputFormat* av_muxer_iterate(void** opaque);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVInputFormat *")]
        public static extern AVInputFormat* av_demuxer_iterate(void** opaque);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVFormatContext* avformat_alloc_context();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avformat_free_context(AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVClass *")]
        public static extern AVClass* avformat_get_class();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVStream* avformat_new_stream(AVFormatContext* s, [NativeTypeName("const AVCodec *")] AVCodec* c);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_stream_add_side_data(AVStream* st, [NativeTypeName("enum AVPacketSideDataType")] AVPacketSideDataType type, [NativeTypeName("uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint8_t *")]
        public static extern byte* av_stream_new_side_data(AVStream* stream, [NativeTypeName("enum AVPacketSideDataType")] AVPacketSideDataType type, int size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint8_t *")]
        public static extern byte* av_stream_get_side_data([NativeTypeName("const AVStream *")] AVStream* stream, [NativeTypeName("enum AVPacketSideDataType")] AVPacketSideDataType type, int* size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVProgram* av_new_program(AVFormatContext* s, int id);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_alloc_output_context2(AVFormatContext** ctx, AVOutputFormat* oformat, [NativeTypeName("const char *")] sbyte* format_name, [NativeTypeName("const char *")] sbyte* filename);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVInputFormat* av_find_input_format([NativeTypeName("const char *")] sbyte* short_name);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVInputFormat* av_probe_input_format(AVProbeData* pd, int is_opened);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVInputFormat* av_probe_input_format2(AVProbeData* pd, int is_opened, int* score_max);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVInputFormat* av_probe_input_format3(AVProbeData* pd, int is_opened, int* score_ret);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_probe_input_buffer2(AVIOContext* pb, AVInputFormat** fmt, [NativeTypeName("const char *")] sbyte* url, void* logctx, [NativeTypeName("unsigned int")] uint offset, [NativeTypeName("unsigned int")] uint max_probe_size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_probe_input_buffer(AVIOContext* pb, AVInputFormat** fmt, [NativeTypeName("const char *")] sbyte* url, void* logctx, [NativeTypeName("unsigned int")] uint offset, [NativeTypeName("unsigned int")] uint max_probe_size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_open_input(AVFormatContext** ps, [NativeTypeName("const char *")] sbyte* url, AVInputFormat* fmt, AVDictionary** options);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_demuxer_open(AVFormatContext* ic);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_find_stream_info(AVFormatContext* ic, AVDictionary** options);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVProgram* av_find_program_from_stream(AVFormatContext* ic, AVProgram* last, int s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_program_add_stream_index(AVFormatContext* ac, int progid, [NativeTypeName("unsigned int")] uint idx);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_find_best_stream(AVFormatContext* ic, [NativeTypeName("enum AVMediaType")] AVMediaType type, int wanted_stream_nb, int related_stream, AVCodec** decoder_ret, int flags);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_read_frame(AVFormatContext* s, AVPacket* pkt);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_seek_frame(AVFormatContext* s, int stream_index, [NativeTypeName("int64_t")] long timestamp, int flags);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_seek_file(AVFormatContext* s, int stream_index, [NativeTypeName("int64_t")] long min_ts, [NativeTypeName("int64_t")] long ts, [NativeTypeName("int64_t")] long max_ts, int flags);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_flush(AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_read_play(AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_read_pause(AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avformat_close_input(AVFormatContext** s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_write_header(AVFormatContext* s, AVDictionary** options);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_init_output(AVFormatContext* s, AVDictionary** options);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_write_frame(AVFormatContext* s, AVPacket* pkt);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_interleaved_write_frame(AVFormatContext* s, AVPacket* pkt);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_write_uncoded_frame(AVFormatContext* s, int stream_index, AVFrame* frame);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_interleaved_write_uncoded_frame(AVFormatContext* s, int stream_index, AVFrame* frame);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_write_uncoded_frame_query(AVFormatContext* s, int stream_index);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_write_trailer(AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVOutputFormat* av_guess_format([NativeTypeName("const char *")] sbyte* short_name, [NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("const char *")] sbyte* mime_type);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVCodecID")]
        public static extern AVCodecID av_guess_codec(AVOutputFormat* fmt, [NativeTypeName("const char *")] sbyte* short_name, [NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("const char *")] sbyte* mime_type, [NativeTypeName("enum AVMediaType")] AVMediaType type);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_output_timestamp([NativeTypeName("struct AVFormatContext *")] AVFormatContext* s, int stream, [NativeTypeName("int64_t *")] long* dts, [NativeTypeName("int64_t *")] long* wall);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_hex_dump_log(void* avcl, int level, [NativeTypeName("const uint8_t *")] byte* buf, int size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_pkt_dump_log2(void* avcl, int level, [NativeTypeName("const AVPacket *")] AVPacket* pkt, int dump_payload, [NativeTypeName("const AVStream *")] AVStream* st);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("enum AVCodecID")]
        public static extern AVCodecID av_codec_get_id([NativeTypeName("const struct AVCodecTag *const *")] AVCodecTag** tags, [NativeTypeName("unsigned int")] uint tag);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint av_codec_get_tag([NativeTypeName("const struct AVCodecTag *const *")] AVCodecTag** tags, [NativeTypeName("enum AVCodecID")] AVCodecID id);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_codec_get_tag2([NativeTypeName("const struct AVCodecTag *const *")] AVCodecTag** tags, [NativeTypeName("enum AVCodecID")] AVCodecID id, [NativeTypeName("unsigned int *")] uint* tag);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_find_default_stream_index(AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_index_search_timestamp(AVStream* st, [NativeTypeName("int64_t")] long timestamp, int flags);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_add_index_entry(AVStream* st, [NativeTypeName("int64_t")] long pos, [NativeTypeName("int64_t")] long timestamp, int size, int distance, int flags);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_url_split([NativeTypeName("char *")] sbyte* proto, int proto_size, [NativeTypeName("char *")] sbyte* authorization, int authorization_size, [NativeTypeName("char *")] sbyte* hostname, int hostname_size, int* port_ptr, [NativeTypeName("char *")] sbyte* path, int path_size, [NativeTypeName("const char *")] sbyte* url);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void av_dump_format(AVFormatContext* ic, int index, [NativeTypeName("const char *")] sbyte* url, int is_output);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_frame_filename2([NativeTypeName("char *")] sbyte* buf, int buf_size, [NativeTypeName("const char *")] sbyte* path, int number, int flags);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_get_frame_filename([NativeTypeName("char *")] sbyte* buf, int buf_size, [NativeTypeName("const char *")] sbyte* path, int number);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_filename_number_test([NativeTypeName("const char *")] sbyte* filename);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_sdp_create([NativeTypeName("AVFormatContext *[]")] AVFormatContext** ac, int n_files, [NativeTypeName("char *")] sbyte* buf, int size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_match_ext([NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("const char *")] sbyte* extensions);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_query_codec([NativeTypeName("const AVOutputFormat *")] AVOutputFormat* ofmt, [NativeTypeName("enum AVCodecID")] AVCodecID codec_id, int std_compliance);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const struct AVCodecTag *")]
        public static extern AVCodecTag* avformat_get_riff_video_tags();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const struct AVCodecTag *")]
        public static extern AVCodecTag* avformat_get_riff_audio_tags();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const struct AVCodecTag *")]
        public static extern AVCodecTag* avformat_get_mov_video_tags();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const struct AVCodecTag *")]
        public static extern AVCodecTag* avformat_get_mov_audio_tags();

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_guess_sample_aspect_ratio(AVFormatContext* format, AVStream* stream, AVFrame* frame);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_guess_frame_rate(AVFormatContext* ctx, AVStream* stream, AVFrame* frame);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_match_stream_specifier(AVFormatContext* s, AVStream* st, [NativeTypeName("const char *")] sbyte* spec);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_queue_attached_pictures(AVFormatContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int av_apply_bitstream_filters(AVCodecContext* codec, AVPacket* pkt, AVBitStreamFilterContext* bsfc);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avformat_transfer_internal_stream_timing_info([NativeTypeName("const AVOutputFormat *")] AVOutputFormat* ofmt, AVStream* ost, [NativeTypeName("const AVStream *")] AVStream* ist, [NativeTypeName("enum AVTimebaseSource")] AVTimebaseSource copy_tb);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVRational av_stream_get_codec_timebase([NativeTypeName("const AVStream *")] AVStream* st);

        [NativeTypeName("#define AVPROBE_SCORE_RETRY (AVPROBE_SCORE_MAX/4)")]
        public const int AVPROBE_SCORE_RETRY = (100 / 4);

        [NativeTypeName("#define AVPROBE_SCORE_STREAM_RETRY (AVPROBE_SCORE_MAX/4-1)")]
        public const int AVPROBE_SCORE_STREAM_RETRY = (100 / 4 - 1);

        [NativeTypeName("#define AVPROBE_SCORE_EXTENSION 50")]
        public const int AVPROBE_SCORE_EXTENSION = 50;

        [NativeTypeName("#define AVPROBE_SCORE_MIME 75")]
        public const int AVPROBE_SCORE_MIME = 75;

        [NativeTypeName("#define AVPROBE_SCORE_MAX 100")]
        public const int AVPROBE_SCORE_MAX = 100;

        [NativeTypeName("#define AVPROBE_PADDING_SIZE 32")]
        public const int AVPROBE_PADDING_SIZE = 32;

        [NativeTypeName("#define AVFMT_NOFILE 0x0001")]
        public const int AVFMT_NOFILE = 0x0001;

        [NativeTypeName("#define AVFMT_NEEDNUMBER 0x0002")]
        public const int AVFMT_NEEDNUMBER = 0x0002;

        [NativeTypeName("#define AVFMT_SHOW_IDS 0x0008")]
        public const int AVFMT_SHOW_IDS = 0x0008;

        [NativeTypeName("#define AVFMT_GLOBALHEADER 0x0040")]
        public const int AVFMT_GLOBALHEADER = 0x0040;

        [NativeTypeName("#define AVFMT_NOTIMESTAMPS 0x0080")]
        public const int AVFMT_NOTIMESTAMPS = 0x0080;

        [NativeTypeName("#define AVFMT_GENERIC_INDEX 0x0100")]
        public const int AVFMT_GENERIC_INDEX = 0x0100;

        [NativeTypeName("#define AVFMT_TS_DISCONT 0x0200")]
        public const int AVFMT_TS_DISCONT = 0x0200;

        [NativeTypeName("#define AVFMT_VARIABLE_FPS 0x0400")]
        public const int AVFMT_VARIABLE_FPS = 0x0400;

        [NativeTypeName("#define AVFMT_NODIMENSIONS 0x0800")]
        public const int AVFMT_NODIMENSIONS = 0x0800;

        [NativeTypeName("#define AVFMT_NOSTREAMS 0x1000")]
        public const int AVFMT_NOSTREAMS = 0x1000;

        [NativeTypeName("#define AVFMT_NOBINSEARCH 0x2000")]
        public const int AVFMT_NOBINSEARCH = 0x2000;

        [NativeTypeName("#define AVFMT_NOGENSEARCH 0x4000")]
        public const int AVFMT_NOGENSEARCH = 0x4000;

        [NativeTypeName("#define AVFMT_NO_BYTE_SEEK 0x8000")]
        public const int AVFMT_NO_BYTE_SEEK = 0x8000;

        [NativeTypeName("#define AVFMT_ALLOW_FLUSH 0x10000")]
        public const int AVFMT_ALLOW_FLUSH = 0x10000;

        [NativeTypeName("#define AVFMT_TS_NONSTRICT 0x20000")]
        public const int AVFMT_TS_NONSTRICT = 0x20000;

        [NativeTypeName("#define AVFMT_TS_NEGATIVE 0x40000")]
        public const int AVFMT_TS_NEGATIVE = 0x40000;

        [NativeTypeName("#define AVFMT_SEEK_TO_PTS 0x4000000")]
        public const int AVFMT_SEEK_TO_PTS = 0x4000000;

        [NativeTypeName("#define AVINDEX_KEYFRAME 0x0001")]
        public const int AVINDEX_KEYFRAME = 0x0001;

        [NativeTypeName("#define AVINDEX_DISCARD_FRAME 0x0002")]
        public const int AVINDEX_DISCARD_FRAME = 0x0002;

        [NativeTypeName("#define AV_DISPOSITION_DEFAULT 0x0001")]
        public const int AV_DISPOSITION_DEFAULT = 0x0001;

        [NativeTypeName("#define AV_DISPOSITION_DUB 0x0002")]
        public const int AV_DISPOSITION_DUB = 0x0002;

        [NativeTypeName("#define AV_DISPOSITION_ORIGINAL 0x0004")]
        public const int AV_DISPOSITION_ORIGINAL = 0x0004;

        [NativeTypeName("#define AV_DISPOSITION_COMMENT 0x0008")]
        public const int AV_DISPOSITION_COMMENT = 0x0008;

        [NativeTypeName("#define AV_DISPOSITION_LYRICS 0x0010")]
        public const int AV_DISPOSITION_LYRICS = 0x0010;

        [NativeTypeName("#define AV_DISPOSITION_KARAOKE 0x0020")]
        public const int AV_DISPOSITION_KARAOKE = 0x0020;

        [NativeTypeName("#define AV_DISPOSITION_FORCED 0x0040")]
        public const int AV_DISPOSITION_FORCED = 0x0040;

        [NativeTypeName("#define AV_DISPOSITION_HEARING_IMPAIRED 0x0080")]
        public const int AV_DISPOSITION_HEARING_IMPAIRED = 0x0080;

        [NativeTypeName("#define AV_DISPOSITION_VISUAL_IMPAIRED 0x0100")]
        public const int AV_DISPOSITION_VISUAL_IMPAIRED = 0x0100;

        [NativeTypeName("#define AV_DISPOSITION_CLEAN_EFFECTS 0x0200")]
        public const int AV_DISPOSITION_CLEAN_EFFECTS = 0x0200;

        [NativeTypeName("#define AV_DISPOSITION_ATTACHED_PIC 0x0400")]
        public const int AV_DISPOSITION_ATTACHED_PIC = 0x0400;

        [NativeTypeName("#define AV_DISPOSITION_TIMED_THUMBNAILS 0x0800")]
        public const int AV_DISPOSITION_TIMED_THUMBNAILS = 0x0800;

        [NativeTypeName("#define AV_DISPOSITION_CAPTIONS 0x10000")]
        public const int AV_DISPOSITION_CAPTIONS = 0x10000;

        [NativeTypeName("#define AV_DISPOSITION_DESCRIPTIONS 0x20000")]
        public const int AV_DISPOSITION_DESCRIPTIONS = 0x20000;

        [NativeTypeName("#define AV_DISPOSITION_METADATA 0x40000")]
        public const int AV_DISPOSITION_METADATA = 0x40000;

        [NativeTypeName("#define AV_DISPOSITION_DEPENDENT 0x80000")]
        public const int AV_DISPOSITION_DEPENDENT = 0x80000;

        [NativeTypeName("#define AV_DISPOSITION_STILL_IMAGE 0x100000")]
        public const int AV_DISPOSITION_STILL_IMAGE = 0x100000;

        [NativeTypeName("#define AV_PTS_WRAP_IGNORE 0")]
        public const int AV_PTS_WRAP_IGNORE = 0;

        [NativeTypeName("#define AV_PTS_WRAP_ADD_OFFSET 1")]
        public const int AV_PTS_WRAP_ADD_OFFSET = 1;

        [NativeTypeName("#define AV_PTS_WRAP_SUB_OFFSET -1")]
        public const int AV_PTS_WRAP_SUB_OFFSET = -1;

        [NativeTypeName("#define AVSTREAM_EVENT_FLAG_METADATA_UPDATED 0x0001")]
        public const int AVSTREAM_EVENT_FLAG_METADATA_UPDATED = 0x0001;

        [NativeTypeName("#define AVSTREAM_EVENT_FLAG_NEW_PACKETS (1 << 1)")]
        public const int AVSTREAM_EVENT_FLAG_NEW_PACKETS = (1 << 1);

        [NativeTypeName("#define AV_PROGRAM_RUNNING 1")]
        public const int AV_PROGRAM_RUNNING = 1;

        [NativeTypeName("#define AVFMTCTX_NOHEADER 0x0001")]
        public const int AVFMTCTX_NOHEADER = 0x0001;

        [NativeTypeName("#define AVFMTCTX_UNSEEKABLE 0x0002")]
        public const int AVFMTCTX_UNSEEKABLE = 0x0002;

        [NativeTypeName("#define AVFMT_FLAG_GENPTS 0x0001")]
        public const int AVFMT_FLAG_GENPTS = 0x0001;

        [NativeTypeName("#define AVFMT_FLAG_IGNIDX 0x0002")]
        public const int AVFMT_FLAG_IGNIDX = 0x0002;

        [NativeTypeName("#define AVFMT_FLAG_NONBLOCK 0x0004")]
        public const int AVFMT_FLAG_NONBLOCK = 0x0004;

        [NativeTypeName("#define AVFMT_FLAG_IGNDTS 0x0008")]
        public const int AVFMT_FLAG_IGNDTS = 0x0008;

        [NativeTypeName("#define AVFMT_FLAG_NOFILLIN 0x0010")]
        public const int AVFMT_FLAG_NOFILLIN = 0x0010;

        [NativeTypeName("#define AVFMT_FLAG_NOPARSE 0x0020")]
        public const int AVFMT_FLAG_NOPARSE = 0x0020;

        [NativeTypeName("#define AVFMT_FLAG_NOBUFFER 0x0040")]
        public const int AVFMT_FLAG_NOBUFFER = 0x0040;

        [NativeTypeName("#define AVFMT_FLAG_CUSTOM_IO 0x0080")]
        public const int AVFMT_FLAG_CUSTOM_IO = 0x0080;

        [NativeTypeName("#define AVFMT_FLAG_DISCARD_CORRUPT 0x0100")]
        public const int AVFMT_FLAG_DISCARD_CORRUPT = 0x0100;

        [NativeTypeName("#define AVFMT_FLAG_FLUSH_PACKETS 0x0200")]
        public const int AVFMT_FLAG_FLUSH_PACKETS = 0x0200;

        [NativeTypeName("#define AVFMT_FLAG_BITEXACT 0x0400")]
        public const int AVFMT_FLAG_BITEXACT = 0x0400;

        [NativeTypeName("#define AVFMT_FLAG_MP4A_LATM 0x8000")]
        public const int AVFMT_FLAG_MP4A_LATM = 0x8000;

        [NativeTypeName("#define AVFMT_FLAG_SORT_DTS 0x10000")]
        public const int AVFMT_FLAG_SORT_DTS = 0x10000;

        [NativeTypeName("#define AVFMT_FLAG_PRIV_OPT 0x20000")]
        public const int AVFMT_FLAG_PRIV_OPT = 0x20000;

        [NativeTypeName("#define AVFMT_FLAG_KEEP_SIDE_DATA 0x40000")]
        public const int AVFMT_FLAG_KEEP_SIDE_DATA = 0x40000;

        [NativeTypeName("#define AVFMT_FLAG_FAST_SEEK 0x80000")]
        public const int AVFMT_FLAG_FAST_SEEK = 0x80000;

        [NativeTypeName("#define AVFMT_FLAG_SHORTEST 0x100000")]
        public const int AVFMT_FLAG_SHORTEST = 0x100000;

        [NativeTypeName("#define AVFMT_FLAG_AUTO_BSF 0x200000")]
        public const int AVFMT_FLAG_AUTO_BSF = 0x200000;

        [NativeTypeName("#define FF_FDEBUG_TS 0x0001")]
        public const int FF_FDEBUG_TS = 0x0001;

        [NativeTypeName("#define AVFMT_EVENT_FLAG_METADATA_UPDATED 0x0001")]
        public const int AVFMT_EVENT_FLAG_METADATA_UPDATED = 0x0001;

        [NativeTypeName("#define AVFMT_AVOID_NEG_TS_AUTO -1")]
        public const int AVFMT_AVOID_NEG_TS_AUTO = -1;

        [NativeTypeName("#define AVFMT_AVOID_NEG_TS_MAKE_NON_NEGATIVE 1")]
        public const int AVFMT_AVOID_NEG_TS_MAKE_NON_NEGATIVE = 1;

        [NativeTypeName("#define AVFMT_AVOID_NEG_TS_MAKE_ZERO 2")]
        public const int AVFMT_AVOID_NEG_TS_MAKE_ZERO = 2;

        [NativeTypeName("#define AVSEEK_FLAG_BACKWARD 1")]
        public const int AVSEEK_FLAG_BACKWARD = 1;

        [NativeTypeName("#define AVSEEK_FLAG_BYTE 2")]
        public const int AVSEEK_FLAG_BYTE = 2;

        [NativeTypeName("#define AVSEEK_FLAG_ANY 4")]
        public const int AVSEEK_FLAG_ANY = 4;

        [NativeTypeName("#define AVSEEK_FLAG_FRAME 8")]
        public const int AVSEEK_FLAG_FRAME = 8;

        [NativeTypeName("#define AVSTREAM_INIT_IN_WRITE_HEADER 0")]
        public const int AVSTREAM_INIT_IN_WRITE_HEADER = 0;

        [NativeTypeName("#define AVSTREAM_INIT_IN_INIT_OUTPUT 1")]
        public const int AVSTREAM_INIT_IN_INIT_OUTPUT = 1;

        [NativeTypeName("#define AV_FRAME_FILENAME_FLAGS_MULTIPLE 1")]
        public const int AV_FRAME_FILENAME_FLAGS_MULTIPLE = 1;

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avio_find_protocol_name([NativeTypeName("const char *")] sbyte* url);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_check([NativeTypeName("const char *")] sbyte* url, int flags);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avpriv_io_move([NativeTypeName("const char *")] sbyte* url_src, [NativeTypeName("const char *")] sbyte* url_dst);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avpriv_io_delete([NativeTypeName("const char *")] sbyte* url);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_open_dir(AVIODirContext** s, [NativeTypeName("const char *")] sbyte* url, AVDictionary** options);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_read_dir(AVIODirContext* s, AVIODirEntry** next);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_close_dir(AVIODirContext** s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_free_directory_entry(AVIODirEntry** entry);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVIOContext* avio_alloc_context([NativeTypeName("unsigned char *")] byte* buffer, int buffer_size, int write_flag, void* opaque, [NativeTypeName("int (*)(void *, uint8_t *, int)")] delegate* unmanaged[Cdecl]<void*, byte*, int, int> read_packet, [NativeTypeName("int (*)(void *, uint8_t *, int)")] delegate* unmanaged[Cdecl]<void*, byte*, int, int> write_packet, [NativeTypeName("int64_t (*)(void *, int64_t, int)")] delegate* unmanaged[Cdecl]<void*, long, int, long> seek);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_context_free(AVIOContext** s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_w8(AVIOContext* s, int b);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_write(AVIOContext* s, [NativeTypeName("const unsigned char *")] byte* buf, int size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_wl64(AVIOContext* s, [NativeTypeName("uint64_t")] ulong val);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_wb64(AVIOContext* s, [NativeTypeName("uint64_t")] ulong val);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_wl32(AVIOContext* s, [NativeTypeName("unsigned int")] uint val);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_wb32(AVIOContext* s, [NativeTypeName("unsigned int")] uint val);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_wl24(AVIOContext* s, [NativeTypeName("unsigned int")] uint val);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_wb24(AVIOContext* s, [NativeTypeName("unsigned int")] uint val);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_wl16(AVIOContext* s, [NativeTypeName("unsigned int")] uint val);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_wb16(AVIOContext* s, [NativeTypeName("unsigned int")] uint val);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_put_str(AVIOContext* s, [NativeTypeName("const char *")] sbyte* str);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_put_str16le(AVIOContext* s, [NativeTypeName("const char *")] sbyte* str);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_put_str16be(AVIOContext* s, [NativeTypeName("const char *")] sbyte* str);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_write_marker(AVIOContext* s, [NativeTypeName("int64_t")] long time, [NativeTypeName("enum AVIODataMarkerType")] AVIODataMarkerType type);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long avio_seek(AVIOContext* s, [NativeTypeName("int64_t")] long offset, int whence);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long avio_skip(AVIOContext* s, [NativeTypeName("int64_t")] long offset);

        [return: NativeTypeName("int64_t")]
        public static long avio_tell(AVIOContext* s)
        {
            return avio_seek(s, 0, 1);
        }

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long avio_size(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_feof(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_printf(AVIOContext* s, [NativeTypeName("const char *")] sbyte* fmt);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_print_string_array(AVIOContext* s, [NativeTypeName("const char *[]")] sbyte** strings);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avio_flush(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_read(AVIOContext* s, [NativeTypeName("unsigned char *")] byte* buf, int size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_read_partial(AVIOContext* s, [NativeTypeName("unsigned char *")] byte* buf, int size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_r8(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avio_rl16(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avio_rl24(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avio_rl32(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong avio_rl64(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avio_rb16(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avio_rb24(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avio_rb32(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong avio_rb64(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_get_str(AVIOContext* pb, int maxlen, [NativeTypeName("char *")] sbyte* buf, int buflen);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_get_str16le(AVIOContext* pb, int maxlen, [NativeTypeName("char *")] sbyte* buf, int buflen);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_get_str16be(AVIOContext* pb, int maxlen, [NativeTypeName("char *")] sbyte* buf, int buflen);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_open(AVIOContext** s, [NativeTypeName("const char *")] sbyte* url, int flags);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_open2(AVIOContext** s, [NativeTypeName("const char *")] sbyte* url, int flags, [NativeTypeName("const AVIOInterruptCB *")] AVIOInterruptCB* int_cb, AVDictionary** options);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_close(AVIOContext* s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_closep(AVIOContext** s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_open_dyn_buf(AVIOContext** s);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_get_dyn_buf(AVIOContext* s, [NativeTypeName("uint8_t **")] byte** pbuffer);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_close_dyn_buf(AVIOContext* s, [NativeTypeName("uint8_t **")] byte** pbuffer);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avio_enum_protocols(void** opaque, int output);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const AVClass *")]
        public static extern AVClass* avio_protocol_get_class([NativeTypeName("const char *")] sbyte* name);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_pause(AVIOContext* h, int pause);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long avio_seek_time(AVIOContext* h, int stream_index, [NativeTypeName("int64_t")] long timestamp, int flags);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_read_to_bprint(AVIOContext* h, [NativeTypeName("struct AVBPrint *")] AVBPrint* pb, [NativeTypeName("size_t")] nuint max_size);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_accept(AVIOContext* s, AVIOContext** c);

        [DllImport("avformat-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avio_handshake(AVIOContext* c);

        [NativeTypeName("#define AVIO_SEEKABLE_NORMAL (1 << 0)")]
        public const int AVIO_SEEKABLE_NORMAL = (1 << 0);

        [NativeTypeName("#define AVIO_SEEKABLE_TIME (1 << 1)")]
        public const int AVIO_SEEKABLE_TIME = (1 << 1);

        [NativeTypeName("#define AVSEEK_SIZE 0x10000")]
        public const int AVSEEK_SIZE = 0x10000;

        [NativeTypeName("#define AVSEEK_FORCE 0x20000")]
        public const int AVSEEK_FORCE = 0x20000;

        [NativeTypeName("#define AVIO_FLAG_READ 1")]
        public const int AVIO_FLAG_READ = 1;

        [NativeTypeName("#define AVIO_FLAG_WRITE 2")]
        public const int AVIO_FLAG_WRITE = 2;

        [NativeTypeName("#define AVIO_FLAG_READ_WRITE (AVIO_FLAG_READ|AVIO_FLAG_WRITE)")]
        public const int AVIO_FLAG_READ_WRITE = (1 | 2);

        [NativeTypeName("#define AVIO_FLAG_NONBLOCK 8")]
        public const int AVIO_FLAG_NONBLOCK = 8;

        [NativeTypeName("#define AVIO_FLAG_DIRECT 0x8000")]
        public const int AVIO_FLAG_DIRECT = 0x8000;

        [NativeTypeName("#define LIBAVFORMAT_VERSION_MAJOR 58")]
        public const int LIBAVFORMAT_VERSION_MAJOR = 58;

        [NativeTypeName("#define LIBAVFORMAT_VERSION_MINOR 76")]
        public const int LIBAVFORMAT_VERSION_MINOR = 76;

        [NativeTypeName("#define LIBAVFORMAT_VERSION_MICRO 100")]
        public const int LIBAVFORMAT_VERSION_MICRO = 100;

        [NativeTypeName("#define LIBAVFORMAT_VERSION_INT AV_VERSION_INT(LIBAVFORMAT_VERSION_MAJOR, \\\n                                               LIBAVFORMAT_VERSION_MINOR, \\\n                                               LIBAVFORMAT_VERSION_MICRO)")]
        public const int LIBAVFORMAT_VERSION_INT = ((58) << 16 | (76) << 8 | (100));

        [NativeTypeName("#define LIBAVFORMAT_BUILD LIBAVFORMAT_VERSION_INT")]
        public const int LIBAVFORMAT_BUILD = ((58) << 16 | (76) << 8 | (100));

        [NativeTypeName("#define LIBAVFORMAT_IDENT \"Lavf\" AV_STRINGIFY(LIBAVFORMAT_VERSION)")]
        public static ReadOnlySpan<byte> LIBAVFORMAT_IDENT => new byte[] { 0x4C, 0x61, 0x76, 0x66, 0x35, 0x38, 0x2E, 0x37, 0x36, 0x2E, 0x31, 0x30, 0x30, 0x00 };
    }
}
