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

using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public readonly struct AVTimeStamp
    {
        public static readonly AVTimeStamp Undefined = new(AV_NOPTS_VALUE);

        private readonly long _value;

        public AVTimeStamp(long value)
        {
            _value = value;
        }

        public static bool IsUndefined(AVTimeStamp timeStamp) => timeStamp._value == AV_NOPTS_VALUE;

        public static AVRelativeTime operator *(AVTimeStamp timeStamp, AVTimeBase timeBase)
        {
            return new AVRelativeTime(timeStamp._value * ((double)(AVRational)timeBase));
        }

        public static explicit operator long(AVTimeStamp value)
        {
            return value._value;
        }
    }
}
