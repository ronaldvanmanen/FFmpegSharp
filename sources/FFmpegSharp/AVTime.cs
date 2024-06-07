// Copyright (C) 2021-2024 Ronald van Manen
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

using System;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public readonly struct AVTime : IEquatable<AVTime>, IComparable<AVTime>
    {
        public static AVTime Current => new(av_gettime());

        private readonly long _microseconds;

        public AVTime(long microseconds)
        {
            _microseconds = microseconds;
        }

        public override bool Equals(object? obj)
        {
            return obj is AVTime other && Equals(other);
        }

        public bool Equals(AVTime other)
        {
            return _microseconds == other._microseconds;
        }

        public int CompareTo(AVTime other)
        {
            return _microseconds.CompareTo(other._microseconds);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_microseconds);
        }

        public static bool operator ==(AVTime left, AVTime right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AVTime left, AVTime right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(AVTime left, AVTime right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(AVTime left, AVTime right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(AVTime left, AVTime right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(AVTime left, AVTime right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
