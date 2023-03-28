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
using System.Runtime.Serialization;

namespace FFplaySharp
{
    [Serializable]
    internal sealed class PlaybackException : Exception
    {
        public PlaybackException() { }

        public PlaybackException(string message)
        : base(message)
        { }

        public PlaybackException(string message, Exception inner)
        : base(message, inner)
        { }

        private PlaybackException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        { }
    }
}