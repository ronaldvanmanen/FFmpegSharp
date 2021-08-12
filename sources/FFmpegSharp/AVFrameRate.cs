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

namespace FFmpegSharp
{
    public struct AVFrameRate : IEquatable<AVFrameRate>, IComparable<AVFrameRate>
    {
        private readonly AVRational _value;

        public AVFrameRate(AVRational value)
        {
            _value = value;
        }

        public override bool Equals(object? obj)
        {
            return obj is AVFrameRate other && Equals(other);
        }

        public bool Equals(AVFrameRate other)
        {
            return _value == other._value;
        }

        public int CompareTo(AVFrameRate other)
        {
            return _value.CompareTo(other._value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value);
        }

        public static bool operator ==(AVFrameRate left, AVFrameRate right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AVFrameRate left, AVFrameRate right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(AVFrameRate left, AVFrameRate right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(AVFrameRate left, AVFrameRate right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(AVFrameRate left, AVFrameRate right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(AVFrameRate left, AVFrameRate right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static explicit operator AVRelativeTime(AVFrameRate value)
        {
            return new AVRelativeTime((double)AVRational.Inverse((AVRational)value));
        }

        public static explicit operator AVRational(AVFrameRate value)
        {
            return value._value;
        }
    }
}
