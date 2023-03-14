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

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class PacketizedElementaryStream : ElementaryStream<AVPacket>
    {
        private readonly AVStream _stream;

        public AVCodecID CodecID => _stream.CodecParameters.CodecID;

        public AVCodecParameters CodecParameters => _stream.CodecParameters;

        public AVTimeBase TimeBase => _stream.TimeBase;

        public AVDiscard Discard
        {
            get => _stream.Discard;
            set => _stream.Discard = value;
        }

        public PacketizedElementaryStream(AVStream stream, int boundedCapacity)
        : base(boundedCapacity)
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
        }
    }
}
