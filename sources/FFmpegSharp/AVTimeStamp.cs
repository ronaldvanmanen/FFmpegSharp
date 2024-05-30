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
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public readonly struct AVTimeStamp : IEquatable<AVTimeStamp>, IComparable<AVTimeStamp>
    {
        public static readonly AVTimeStamp Undefined = new(AV_NOPTS_VALUE);

        private readonly long _value;

        public AVTimeStamp(long value)
        {
            _value = value;
        }

        public static bool IsUndefined(AVTimeStamp timeStamp) => timeStamp._value == AV_NOPTS_VALUE;

        public override bool Equals(object? obj)
        {
            return obj is AVTimeStamp other && Equals(other);
        }

        public bool Equals(AVTimeStamp other)
        {
            return _value == other._value;
        }

        public int CompareTo(AVTimeStamp other)
        {
            return _value.CompareTo(other._value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value);
        }

        public static bool operator ==(AVTimeStamp left, AVTimeStamp right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AVTimeStamp left, AVTimeStamp right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(AVTimeStamp left, AVTimeStamp right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(AVTimeStamp left, AVTimeStamp right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(AVTimeStamp left, AVTimeStamp right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(AVTimeStamp left, AVTimeStamp right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static AVRelativeTime operator *(AVTimeStamp timeStamp, AVTimeBase timeBase)
        {
            return new AVRelativeTime(timeStamp._value * ((double)timeBase));
        }

        public static explicit operator long(AVTimeStamp value)
        {
            return value._value;
        }
    }
}
