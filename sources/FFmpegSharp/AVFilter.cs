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

using System;
using System.Collections.Generic;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe partial class AVFilter
    {
        public static IEnumerable<AVFilter> All
        {
            get
            {
                var iterator = new AVFilterIterator();
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        private readonly Interop.AVFilter* _handle;

        public string Name => new(_handle->name);

        public string Description => new(_handle->description);

        public AVFilterFlags Flags => (AVFilterFlags)_handle->flags;

        public AVFilterPadCollection Inputs => new(_handle->inputs);

        public AVFilterPadCollection Outputs => new(_handle->outputs);

        public bool CanProcessCommand => _handle->process_command != null;

        public AVFilter(Interop.AVFilter* handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            _handle = handle;
        }
    }
}
