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
    internal sealed class CodecInfo : ICodecInfo
    {
        private readonly AVCodecParameters _codecParameters;

        public CodecInfo(AVCodecParameters codecParameters)
        {
            _codecParameters = codecParameters ?? throw new System.ArgumentNullException(nameof(codecParameters));
        }

        public long BitRate => _codecParameters.BitRate;

        public int BitsPerCodecSample => _codecParameters.BitsPerCodecSample;

        public int BitsPerRawSample => _codecParameters.BitsPerRawSample;

        public int BlockAlign => _codecParameters.BlockAlign;

        public ulong ChannelLayout => _codecParameters.ChannelLayout;

        public int Channels => _codecParameters.Channels;

        public AVChromaLocation ChromaLocation => _codecParameters.ChromaLocation;

        public AVCodecID CodecID => _codecParameters.CodecID;

        public uint CodecTag => _codecParameters.CodecTag;

        public AVMediaType CodecType => _codecParameters.CodecType;

        public AVColorPrimaries ColorPrimaries => _codecParameters.ColorPrimaries;

        public AVColorRange ColorRange => _codecParameters.ColorRange;

        public AVColorSpace ColorSpace => _codecParameters.ColorSpace;

        public AVColorTransferCharacteristic ColorTransferCharacteristic => _codecParameters.ColorTransferCharacteristic;

        public AVFieldOrder FieldOrder => _codecParameters.FieldOrder;

        public int Format => _codecParameters.Format;

        public int FrameSize => _codecParameters.FrameSize;

        public int Height => _codecParameters.Height;

        public int InitialPadding => _codecParameters.InitialPadding;

        public int Level => _codecParameters.Level;

        public int Profile => _codecParameters.Profile;

        public AVRational SampleAspectRatio => _codecParameters.SampleAspectRatio;

        public int SampleRate => _codecParameters.SampleRate;

        public int SeekPreroll => _codecParameters.SeekPreroll;

        public int TrailingPadding => _codecParameters.TrailingPadding;

        public int VideoDelay => _codecParameters.VideoDelay;

        public int Width => _codecParameters.Width;

        internal AVCodecParameters ToCodecParameters()
        {
            return _codecParameters;
        }
    }
}
