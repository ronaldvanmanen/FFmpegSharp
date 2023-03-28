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
    public readonly struct AVTimeBase : IEquatable<AVTimeBase>, IComparable<AVTimeBase>
    {
        public static readonly AVTimeBase Internal = new(new AVRational(1, 1000000));

        private readonly AVRational _value;

        public AVTimeBase(AVRational value)
        {
            _value = value;
        }

        public override bool Equals(object? obj)
        {
            return obj is AVTimeBase other && Equals(other);
        }

        public bool Equals(AVTimeBase other)
        {
            return _value == other._value;
        }

        public int CompareTo(AVTimeBase other)
        {
            return _value.CompareTo(other._value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value);
        }

        public static bool operator ==(AVTimeBase left, AVTimeBase right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AVTimeBase left, AVTimeBase right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(AVTimeBase left, AVTimeBase right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(AVTimeBase left, AVTimeBase right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(AVTimeBase left, AVTimeBase right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(AVTimeBase left, AVTimeBase right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static explicit operator AVRational(AVTimeBase value)
        {
            return value._value;
        }
    }
}
