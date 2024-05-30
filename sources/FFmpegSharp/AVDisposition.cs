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

using System;

using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    [Flags]
    public enum AVDisposition
    {
        Default = AV_DISPOSITION_DEFAULT,
        Dub = AV_DISPOSITION_DUB,
        Original = AV_DISPOSITION_ORIGINAL,
        Comment = AV_DISPOSITION_COMMENT,
        Lyrics = AV_DISPOSITION_LYRICS,
        Karaoke = AV_DISPOSITION_KARAOKE,
        Forced = AV_DISPOSITION_FORCED,
        HearingImpaired = AV_DISPOSITION_HEARING_IMPAIRED,
        VisualImpaired = AV_DISPOSITION_VISUAL_IMPAIRED,
        CleanEffects = AV_DISPOSITION_CLEAN_EFFECTS,
        AttachedPicture = AV_DISPOSITION_ATTACHED_PIC,
        TimedThumbnails = AV_DISPOSITION_TIMED_THUMBNAILS,
        Captions = AV_DISPOSITION_CAPTIONS,
        Descriptions = AV_DISPOSITION_DESCRIPTIONS,
        Metadata = AV_DISPOSITION_METADATA,
        Dependent = AV_DISPOSITION_DEPENDENT,
        StillImage = AV_DISPOSITION_STILL_IMAGE
    }
}
