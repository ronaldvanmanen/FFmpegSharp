﻿// This file is part of FFmpegSharp.
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
    public interface ICodecInfo
    {
        long BitRate { get; }

        int BitsPerCodecSample { get; }

        int BitsPerRawSample { get; }

        int BlockAlign { get; }

        ulong ChannelLayout { get; }

        int Channels { get; }

        AVChromaLocation ChromaLocation { get; }

        AVCodecID CodecID { get; }

        uint CodecTag { get; }

        AVMediaType CodecType { get; }

        AVColorPrimaries ColorPrimaries { get; }

        AVColorRange ColorRange { get; }

        AVColorSpace ColorSpace { get; }

        AVColorTransferCharacteristic ColorTransferCharacteristic { get; }

        AVFieldOrder FieldOrder { get; }

        int Format { get; }

        int FrameSize { get; }

        int Height { get; }

        int InitialPadding { get; }

        int Level { get; }

        int Profile { get; }

        AVRational SampleAspectRatio { get; }

        int SampleRate { get; }

        int SeekPreroll { get; }

        int TrailingPadding { get; }

        int VideoDelay { get; }

        int Width { get; }
    }
}
