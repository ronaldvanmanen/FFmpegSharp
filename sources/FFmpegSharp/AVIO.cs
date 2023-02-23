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

using System.Collections.Generic;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public static unsafe class AVIO
    {
        private enum ProtocolType { Input = 0, Output = 1 };

        private sealed class UnsafeProtocolNameEmumerator
        {
            private readonly void* _opaque = null;

            private sbyte* _current = null;

            private readonly ProtocolType _protocolType = 0;

            public UnsafeProtocolNameEmumerator(ProtocolType protocolType)
            {
                _protocolType = protocolType;
            }

            public bool MoveNext()
            {
                fixed (void** opaque = &_opaque)
                {
                    return (_current = avio_enum_protocols(opaque, (int)_protocolType)) != null;
                }
            }

            public string Current => new string(_current);
        }

        public static IEnumerable<string> InputProtocolNames
        {
            get
            {
                var enumerator = new UnsafeProtocolNameEmumerator(ProtocolType.Input);
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }

        public static IEnumerable<string> OutputProtocolNames
        {
            get
            {
                var enumerator = new UnsafeProtocolNameEmumerator(ProtocolType.Output);
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }
    }
}
