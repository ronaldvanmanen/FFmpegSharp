// Copyright (c) 2021-2023 Ronald van Manen
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

namespace FFmpegSharp.Interop
{
    public enum AVIODirEntryType
    {
        AVIO_ENTRY_UNKNOWN,
        AVIO_ENTRY_BLOCK_DEVICE,
        AVIO_ENTRY_CHARACTER_DEVICE,
        AVIO_ENTRY_DIRECTORY,
        AVIO_ENTRY_NAMED_PIPE,
        AVIO_ENTRY_SYMBOLIC_LINK,
        AVIO_ENTRY_SOCKET,
        AVIO_ENTRY_FILE,
        AVIO_ENTRY_SERVER,
        AVIO_ENTRY_SHARE,
        AVIO_ENTRY_WORKGROUP,
    }
}
