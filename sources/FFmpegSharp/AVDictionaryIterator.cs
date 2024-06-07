// Copyright (C) 2021-2024 Ronald van Manen
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

using System.Collections.Generic;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    internal sealed unsafe class AVDictionaryIterator
    {
        private readonly Interop.AVDictionary* _dictionary;

        private Interop.AVDictionaryEntry* _current;

        public KeyValuePair<string, string> Current =>
            new(
                new string(_current->key),
                new string(_current->value));

        public AVDictionaryIterator(Interop.AVDictionary* dictionary)
        {
            _dictionary = dictionary;
            _current = null;
        }

        public bool MoveNext()
        {
            var key = stackalloc sbyte[1] { 0 };
            _current = av_dict_get(_dictionary, key, _current, AV_DICT_IGNORE_SUFFIX);
            return _current != null;
        }

        public void Reset()
        {
            _current = null;
        }
    }
}
