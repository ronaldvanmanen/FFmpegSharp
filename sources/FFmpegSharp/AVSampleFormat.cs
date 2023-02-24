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

namespace FFmpegSharp
{
    public enum AVSampleFormat
    {
        None = Interop.AVSampleFormat.AV_SAMPLE_FMT_NONE,
        Unsigned8 = Interop.AVSampleFormat.AV_SAMPLE_FMT_U8,
        Signed16 = Interop.AVSampleFormat.AV_SAMPLE_FMT_S16,
        Signed32 = Interop.AVSampleFormat.AV_SAMPLE_FMT_S32,
        Float32 = Interop.AVSampleFormat.AV_SAMPLE_FMT_FLT,
        Float64 = Interop.AVSampleFormat.AV_SAMPLE_FMT_DBL,
        Unsigned8Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_U8P,
        Signed16Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_S16P,
        Singed32Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_S32P,
        Float32Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_FLTP,
        Double32Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_DBLP,
        Signed64 = Interop.AVSampleFormat.AV_SAMPLE_FMT_S64,
        Signed64Planar = Interop.AVSampleFormat.AV_SAMPLE_FMT_S64P,
    }
}
