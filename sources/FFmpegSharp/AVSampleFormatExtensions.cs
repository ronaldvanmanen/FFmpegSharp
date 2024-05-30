// Copyright (c) 2021-2023 Ronald van Manen
//
// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with FFmpegSharp; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA

using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public static unsafe class AVSampleFormatExtensions
    {
        public static AVSampleFormat ToPackedFormat(this AVSampleFormat format)
        {
            return (AVSampleFormat)av_get_packed_sample_fmt((Interop.AVSampleFormat)format);
        }

        public static string? AsString(this AVSampleFormat format)
        {
            const int formatStringBufferSize = 128;
            sbyte* formatStringBuffer = stackalloc sbyte[formatStringBufferSize];
            sbyte* formatString = av_get_sample_fmt_string(formatStringBuffer, formatStringBufferSize, (Interop.AVSampleFormat)format);
            if (formatString == null)
            {
                return null;
            }
            return new string(formatString);
        }
    }
}
