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
using System.Collections.Generic;
using System.Linq;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public static class AVChannelLayoutExtensions
    {
        public static IEnumerable<AVChannels> GetChannels(this AVChannelLayout layout)
        {
            return Enum.GetValues<AVChannels>().Where(e => ((AVChannels)layout).HasFlag(e));
        }

        public static unsafe int GetChannelCount(this AVChannelLayout layout)
        {
            return av_get_channel_layout_nb_channels((ulong)layout);
        }
    }
}
