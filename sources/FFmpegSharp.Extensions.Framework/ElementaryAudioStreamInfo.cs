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

namespace FFmpegSharp
{
    internal sealed class ElementaryAudioStreamInfo : IElementaryAudioStreamInfo
    {
        private readonly AVCodecContext _codecContext;

        public ElementaryAudioStreamInfo(AVCodecContext codecContext)
        {
            _codecContext = codecContext ?? throw new ArgumentNullException(nameof(codecContext));
        }

        public long BitRate => _codecContext.BitRate;

        public int BitRateTolerance => _codecContext.BitRateTolerance;

        public int ChannelCount => _codecContext.ChannelCount;

        public AVChannelLayout ChannelLayout => _codecContext.ChannelLayout;

        public AVCodec Codec => _codecContext.Codec;

        public AVCodecID CodecID => _codecContext.CodecID;

        public AVMediaType CodecType => _codecContext.CodecType;

        public int CompressionLevel => _codecContext.CompressionLevel;

        public int GlobalQuality => _codecContext.GlobalQuality;

        public AVTimeBase PacketTimeBase => _codecContext.PacketTimeBase;

        public AVSampleFormat SampleFormat => _codecContext.SampleFormat;

        public int SampleRate => _codecContext.SampleRate;

        public AVTimeBase TimeBase => _codecContext.TimeBase;
    }
}
