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

using System;

namespace FFmpegSharp
{
    public readonly struct AVTimeBase : IEquatable<AVTimeBase>, IComparable<AVTimeBase>
    {
        public static readonly AVTimeBase Internal = new(new AVRational(1, 1000000));

        private readonly AVRational _value;

        public AVTimeBase(int numerator, int denominator)
        : this(new AVRational(numerator, denominator))
        { }

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

        public static explicit operator double(AVTimeBase value)
        {
            return (double)value._value;
        }
    }
}
