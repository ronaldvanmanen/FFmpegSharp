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
using System.Collections;
using System.Collections.Generic;

namespace FFmpegSharp
{
    internal sealed class AVDictionaryEnumerator : IEnumerator<KeyValuePair<string, string>>
    {
        private readonly AVDictionaryUnsafeEnumerator _enumerator;

        public KeyValuePair<string, string> Current => _enumerator.Current;

        object IEnumerator.Current => _enumerator.Current;

        public AVDictionaryEnumerator(AVDictionaryUnsafeEnumerator enumerator)
        {
            if (enumerator == null)
            {
                throw new ArgumentNullException(nameof(enumerator));
            }
            _enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }

        public void Reset()
        {
            _enumerator.Reset();
        }
    }
}
