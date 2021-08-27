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

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVBitStreamFilter
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const enum AVCodecID *")]
        public AVCodecID* codec_ids;

        [NativeTypeName("const AVClass *")]
        public AVClass* priv_class;

        public int priv_data_size;

        [NativeTypeName("int (*)(AVBSFContext *)")]
        public IntPtr init;

        [NativeTypeName("int (*)(AVBSFContext *, AVPacket *)")]
        public IntPtr filter;

        [NativeTypeName("void (*)(AVBSFContext *)")]
        public IntPtr close;

        [NativeTypeName("void (*)(AVBSFContext *)")]
        public IntPtr flush;
    }
}
