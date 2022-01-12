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
using System.Text;

namespace FFmpegSharp.Interop
{
    public static unsafe class SpanExtensions
    {
        public static string AsString(this Span<byte> self) => AsString((ReadOnlySpan<byte>)self);

        public static string AsString(this ReadOnlySpan<byte> self)
        {
            if (self.IsEmpty)
            {
                return string.Empty;
            }

            fixed (byte* pSelf = self)
            {
                return Encoding.UTF8.GetString(pSelf, self.Length);
            }
        }

        public static string AsString(this ReadOnlySpan<ushort> self)
        {
            if (self.IsEmpty)
            {
                return string.Empty;
            }

            fixed (ushort* pSelf = self)
            {
                return Encoding.Unicode.GetString((byte*)pSelf, self.Length * 2);
            }
        }

        public static string AsString(this ReadOnlySpan<uint> self)
        {
            if (self.IsEmpty)
            {
                return string.Empty;
            }

            fixed (uint* pSelf = self)
            {
                return Encoding.UTF32.GetString((byte*)pSelf, self.Length * 4);
            }
        }
    }
}
