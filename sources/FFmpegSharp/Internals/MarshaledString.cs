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
using System.Runtime.InteropServices;
using System.Text;

namespace FFmpegSharp.Internals
{
    internal unsafe struct MarshaledString : IDisposable
    {
        public int Length { get; private set; }

        public sbyte* Value { get; private set; }

        public MarshaledString(string input)
        {
            if (input is null)
            {
                Length = 0;
                Value = (sbyte*)IntPtr.Zero;
            }
            else
            {
                var bytes = (input.Length != 0) ? Encoding.UTF8.GetBytes(input) : Array.Empty<byte>();
                var length = bytes.Length;
                var value = Marshal.AllocHGlobal(length + 1);
                Marshal.Copy(bytes, 0, value, length);
                Marshal.WriteByte(value, length, 0);
                Length = length;
                Value = (sbyte*)value;
            }
        }

        public void Dispose()
        {
            if (Value != null)
            {
                Marshal.FreeHGlobal((IntPtr)Value);
                Value = null;
                Length = 0;
            }
        }

        public ReadOnlySpan<byte> AsSpan() => new(Value, Length);

        public override string ToString()
        {
            var span = new ReadOnlySpan<byte>(Value, Length);
            return span.AsString();
        }

        public static implicit operator sbyte*(in MarshaledString value) => value.Value;
    }
}
