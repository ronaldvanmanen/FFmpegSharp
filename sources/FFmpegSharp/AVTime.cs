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
