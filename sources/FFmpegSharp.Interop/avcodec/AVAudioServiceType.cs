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
    public enum AVAudioServiceType
    {
        AV_AUDIO_SERVICE_TYPE_MAIN = 0,
        AV_AUDIO_SERVICE_TYPE_EFFECTS = 1,
        AV_AUDIO_SERVICE_TYPE_VISUALLY_IMPAIRED = 2,
        AV_AUDIO_SERVICE_TYPE_HEARING_IMPAIRED = 3,
        AV_AUDIO_SERVICE_TYPE_DIALOGUE = 4,
        AV_AUDIO_SERVICE_TYPE_COMMENTARY = 5,
        AV_AUDIO_SERVICE_TYPE_EMERGENCY = 6,
        AV_AUDIO_SERVICE_TYPE_VOICE_OVER = 7,
        AV_AUDIO_SERVICE_TYPE_KARAOKE = 8,
        AV_AUDIO_SERVICE_TYPE_NB,
    }
}
