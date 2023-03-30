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
    internal sealed class PacketizedElementaryStreamInfo : IPacketizedElementaryStreamInfo
    {
        private readonly AVStream _stream;

        private CodecInfo _codecInfo;

        public PacketizedElementaryStreamInfo(AVStream stream)
        {
            _stream = stream ?? throw new System.ArgumentNullException(nameof(stream));
            _codecInfo = null!;
        }

        public ICodecInfo CodecInfo => _codecInfo ??= new CodecInfo(_stream.CodecParameters);

        public AVDiscard Discard => _stream.Discard;

        public int Index => _stream.Index;

        public AVTimeBase TimeBase => _stream.TimeBase;
    }
}
