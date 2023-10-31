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
    internal sealed unsafe class AVStandardChannelLayoutIterator
    {
        private uint _index = 0;

        private AVStandardChannelLayout _current = null!;

        public bool MoveNext()
        {
            sbyte* name;
            ulong channelLayout;
            var retcode = av_get_standard_channel_layout(_index++, &channelLayout, &name);
            if (retcode == 0)
            {
                sbyte* description = stackalloc sbyte[256];
                var channelCount = av_get_channel_layout_nb_channels(channelLayout);
                av_get_channel_layout_string(description, 256, channelCount, channelLayout);
                _current = new AVStandardChannelLayout(
                    new string(name),
                    new string(description),
                    (AVChannelLayout)channelLayout);
            }
            return retcode == 0;
        }

        public AVStandardChannelLayout Current => _current;
    }
}
