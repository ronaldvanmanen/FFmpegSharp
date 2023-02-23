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

using System.Collections.Generic;

namespace FFmpegSharp
{
    public sealed class AVStandardChannelLayout
    {
        public static IEnumerable<AVStandardChannelLayout> All
        {
            get
            {
                var iterator = new AVStandardChannelLayoutIterator();
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        public string Name { get; }

        public string Description { get; }

        public AVChannelLayout Layout { get; }

        public AVStandardChannelLayout(string name, string description, AVChannelLayout layout)
        {
            Name = name;
            Description = description;
            Layout = layout;
        }
    }
}
