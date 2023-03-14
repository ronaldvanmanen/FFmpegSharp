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

using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public static unsafe class AVUtil
    {
        public static string BuildConfiguration => new(avutil_configuration());

        public static int GetBufferSize(int channelCount, int sampleCount, AVSampleFormat sampleFormat, bool align)
        {
            return av_samples_get_buffer_size(null, channelCount, sampleCount, (Interop.AVSampleFormat)sampleFormat, align ? 0 : 1);
        }

        public static AVChannelLayout GetDefaultChannelLayout(int channelCount)
        {
            return (AVChannelLayout)av_get_default_channel_layout(channelCount);
        }
    }
}
