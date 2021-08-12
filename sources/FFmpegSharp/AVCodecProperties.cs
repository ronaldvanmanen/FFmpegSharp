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
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    [Flags]
    public enum AVCodecProperties
    {
        IntraCompressionOnly = AV_CODEC_PROP_INTRA_ONLY,
        LossyCompression = AV_CODEC_PROP_LOSSY,
        LosslessCompression = AV_CODEC_PROP_LOSSLESS,
        FrameReordering = AV_CODEC_PROP_REORDER,
        BitmapSubtitle = AV_CODEC_PROP_BITMAP_SUB,
        TextSubtitle = AV_CODEC_PROP_TEXT_SUB
    }
}
