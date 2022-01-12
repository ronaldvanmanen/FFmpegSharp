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

namespace FFmpegSharp.Interop
{
    public unsafe struct MarshaledString : IDisposable
    {
        public MarshaledString(string input)
        {
            int length;
            IntPtr value;

            if (input is null)
            {
                length = 0;
                value = IntPtr.Zero;
            }
            else
            {
                var valueBytes = (input.Length != 0) ? Encoding.UTF8.GetBytes(input) : Array.Empty<byte>();
                length = valueBytes.Length;
                value = Marshal.AllocHGlobal(length + 1);
                Marshal.Copy(valueBytes, 0, value, length);
                Marshal.WriteByte(value, length, 0);
            }

            Length = length;
            Value = (sbyte*)value;
        }

        public ReadOnlySpan<byte> AsSpan() => new ReadOnlySpan<byte>(Value, Length);

        public int Length { get; private set; }

        public sbyte* Value { get; private set; }

        public void Dispose()
        {
            if (Value != null)
            {
                Marshal.FreeHGlobal((IntPtr)Value);
                Value = null;
                Length = 0;
            }
        }

        public static implicit operator sbyte*(in MarshaledString value) => value.Value;

        public override string ToString()
        {
            var span = new ReadOnlySpan<byte>(Value, Length);
            return span.AsString();
        }
    }
}
