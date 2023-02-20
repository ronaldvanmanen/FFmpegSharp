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
    public unsafe partial struct AVHWAccel
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("enum AVMediaType")]
        public AVMediaType type;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID id;

        [NativeTypeName("enum AVPixelFormat")]
        public AVPixelFormat pix_fmt;

        public int capabilities;

        [NativeTypeName("int (*)(AVCodecContext *, AVFrame *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, AVFrame*, int> alloc_frame;

        [NativeTypeName("int (*)(AVCodecContext *, const uint8_t *, uint32_t)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, byte*, uint, int> start_frame;

        [NativeTypeName("int (*)(AVCodecContext *, int, const uint8_t *, uint32_t)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, int, byte*, uint, int> decode_params;

        [NativeTypeName("int (*)(AVCodecContext *, const uint8_t *, uint32_t)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, byte*, uint, int> decode_slice;

        [NativeTypeName("int (*)(AVCodecContext *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, int> end_frame;

        public int frame_priv_data_size;

        [NativeTypeName("void (*)(struct MpegEncContext *)")]
        public delegate* unmanaged[Cdecl]<MpegEncContext*, void> decode_mb;

        [NativeTypeName("int (*)(AVCodecContext *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, int> init;

        [NativeTypeName("int (*)(AVCodecContext *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, int> uninit;

        public int priv_data_size;

        public int caps_internal;

        [NativeTypeName("int (*)(AVCodecContext *, AVBufferRef *)")]
        public delegate* unmanaged[Cdecl]<AVCodecContext*, AVBufferRef*, int> frame_params;
    }
}
