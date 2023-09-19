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
using System.Collections.Generic;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVCodec
    {
        public static IEnumerable<AVCodec> All
        {
            get
            {
                var iterator = new AVCodecIterator();
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        private readonly Interop.AVCodec* _handle;

        public AVCodecID Id => (AVCodecID)_handle->id;

        public AVCodecCapabilities Capabilities => (AVCodecCapabilities)_handle->capabilities;

        public string Name => new(_handle->name);

        public string LongName => new(_handle->long_name);

        public bool IsDecoder => av_codec_is_decoder(_handle) != 0;

        public bool IsEncoder => av_codec_is_encoder(_handle) != 0;

        public AVCodec(Interop.AVCodec* handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
        }

        public static AVCodec? FindDecoder(AVCodecID id)
        {
            var codec = avcodec_find_decoder((Interop.AVCodecID)id);
            if (codec == null)
            {
                return null;
            }
            return new AVCodec(codec);
        }

        public static AVCodec? FindEncoder(AVCodecID id)
        {
            var codec = avcodec_find_encoder((Interop.AVCodecID)id);
            if (codec == null)
            {
                return null;
            }
            return new AVCodec(codec);
        }

        public static implicit operator Interop.AVCodec*(AVCodec value)
        {
            return value._handle;
        }
    }
}
