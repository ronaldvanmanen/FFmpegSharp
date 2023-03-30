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
    public readonly struct AVRelativeTime : IEquatable<AVRelativeTime>, IComparable<AVRelativeTime>
    {
        public static readonly AVRelativeTime Undefined = new(double.NaN);

        public static readonly AVRelativeTime Zero = new(0d);

        public static AVRelativeTime Current => FromMicroSeconds(av_gettime_relative());

        public static bool IsMonotonic => 0 != av_gettime_relative_is_monotonic();

        public static bool IsUndefined(AVRelativeTime timeStamp) => double.IsNaN(timeStamp._seconds);

        public static AVRelativeTime FromMilliSeconds(double milliSeconds)
        {
            return new AVRelativeTime(milliSeconds / 1000d);
        }

        public static AVRelativeTime FromMicroSeconds(double microSeconds)
        {
            return new AVRelativeTime(microSeconds / 1000000d);
        }

        private readonly double _seconds;

        public AVRelativeTime(double seconds)
        {
            _seconds = seconds;
        }

        public override bool Equals(object? obj)
        {
            return obj is AVRelativeTime other && Equals(other);
        }

        public bool Equals(AVRelativeTime other)
        {
            return _seconds == other._seconds;
        }

        public int CompareTo(AVRelativeTime other)
        {
            return _seconds.CompareTo(other._seconds);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_seconds);
        }

        public static bool operator ==(AVRelativeTime left, AVRelativeTime right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AVRelativeTime left, AVRelativeTime right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(AVRelativeTime left, AVRelativeTime right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(AVRelativeTime left, AVRelativeTime right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(AVRelativeTime left, AVRelativeTime right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(AVRelativeTime left, AVRelativeTime right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static AVRelativeTime operator *(AVRelativeTime time, double scalar)
        {
            return new AVRelativeTime(time._seconds * scalar);
        }

        public static AVRelativeTime operator +(AVRelativeTime left, AVRelativeTime right)
        {
            return Plus(left, right);
        }

        public static AVRelativeTime operator -(AVRelativeTime left, AVRelativeTime right)
        {
            return Minus(left, right);
        }

        public static AVRelativeTime Abs(AVRelativeTime value)
        {
            return new AVRelativeTime(Math.Abs(value._seconds));
        }

        public static AVRelativeTime Plus(AVRelativeTime left, AVRelativeTime right)
        {
            return new AVRelativeTime(left._seconds + right._seconds);
        }

        public static AVRelativeTime Minus(AVRelativeTime left, AVRelativeTime right)
        {
            return new AVRelativeTime(left._seconds - right._seconds);
        }

        public static explicit operator double(AVRelativeTime value)
        {
            return value._seconds;
        }
    }
}
