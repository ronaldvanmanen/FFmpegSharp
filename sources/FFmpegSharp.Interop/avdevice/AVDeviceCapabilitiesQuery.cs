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
    public unsafe partial struct AVDeviceCapabilitiesQuery
    {
        [NativeTypeName("const AVClass *")]
        public AVClass* av_class;

        public AVFormatContext* device_context;

        [NativeTypeName("enum AVCodecID")]
        public AVCodecID codec;

        [NativeTypeName("enum AVSampleFormat")]
        public AVSampleFormat sample_format;

        [NativeTypeName("enum AVPixelFormat")]
        public AVPixelFormat pixel_format;

        public int sample_rate;

        public int channels;

        [NativeTypeName("int64_t")]
        public long channel_layout;

        public int window_width;

        public int window_height;

        public int frame_width;

        public int frame_height;

        public AVRational fps;
    }
}
