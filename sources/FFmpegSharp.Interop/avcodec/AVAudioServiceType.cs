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
