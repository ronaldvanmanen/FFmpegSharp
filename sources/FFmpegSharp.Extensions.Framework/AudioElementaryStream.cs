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

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class AudioElementaryStream : ElementaryStream<AVFrame>
    {
        public int ChannelCount { get; init; }

        public AVChannelLayout ChannelLayout { get; init; }

        public int SampleRate { get; init; }

        public AVSampleFormat SampleFormat { get; init; }

        public AVTimeBase TimeBase { get; init; }

        public AudioElementaryStream(int boundedCapacity)
        : base(boundedCapacity)
        { }
    }
}
