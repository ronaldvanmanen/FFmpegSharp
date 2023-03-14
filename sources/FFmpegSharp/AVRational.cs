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
    public readonly struct AVRational : IEquatable<AVRational>, IComparable<AVRational>
    {
        private readonly Interop.AVRational _value;

        public int Numerator => _value.num;

        public int Denominator => _value.den;

        public AVRational(int numerator, int denominator)
        : this(av_make_q(numerator, denominator))
        { }

        public AVRational(Interop.AVRational value)
        {
            _value = value;
        }

        public override bool Equals(object? obj)
        {
            return obj is AVRational other && Equals(other);
        }

        public bool Equals(AVRational other)
        {
            return av_cmp_q(_value, other._value) == 0;
        }

        public int CompareTo(AVRational other)
        {
            return av_cmp_q(_value, other._value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value);
        }

        public static AVRational Inverse(AVRational value)
        {
            return new AVRational(av_inv_q(value._value));
        }

        public static AVRational Multiply(AVRational left, AVRational right)
        {
            return new AVRational(av_mul_q(left._value, right._value));
        }

        public static AVRational Divide(AVRational left, AVRational right)
        {
            return new AVRational(av_div_q(left._value, right._value));
        }

        public static AVRational Plus(AVRational left, AVRational right)
        {
            return new AVRational(av_add_q(left._value, right._value));
        }

        public static AVRational Minus(AVRational left, AVRational right)
        {
            return new AVRational(av_sub_q(left._value, right._value));
        }

        public static bool operator ==(AVRational left, AVRational right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AVRational left, AVRational right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(AVRational left, AVRational right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(AVRational left, AVRational right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(AVRational left, AVRational right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(AVRational left, AVRational right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static AVRational operator *(AVRational left, AVRational right)
        {
            return Multiply(left, right);
        }

        public static AVRational operator /(AVRational left, AVRational right)
        {
            return Divide(left, right);
        }

        public static AVRational operator +(AVRational left, AVRational right)
        {
            return Plus(left, right);
        }

        public static AVRational operator -(AVRational left, AVRational right)
        {
            return Minus(left, right);
        }

        public static implicit operator Interop.AVRational(AVRational value)
        {
            return value._value;
        }

        public static implicit operator AVRational(Interop.AVRational value)
        {
            return new AVRational(value);
        }

        public static explicit operator double(AVRational value)
        {
            return av_q2d(value._value);
        }
    }
}
