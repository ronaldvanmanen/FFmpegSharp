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
    public enum AVColorTransferCharacteristic
    {
        AVCOL_TRC_RESERVED0 = 0,
        AVCOL_TRC_BT709 = 1,
        AVCOL_TRC_UNSPECIFIED = 2,
        AVCOL_TRC_RESERVED = 3,
        AVCOL_TRC_GAMMA22 = 4,
        AVCOL_TRC_GAMMA28 = 5,
        AVCOL_TRC_SMPTE170M = 6,
        AVCOL_TRC_SMPTE240M = 7,
        AVCOL_TRC_LINEAR = 8,
        AVCOL_TRC_LOG = 9,
        AVCOL_TRC_LOG_SQRT = 10,
        AVCOL_TRC_IEC61966_2_4 = 11,
        AVCOL_TRC_BT1361_ECG = 12,
        AVCOL_TRC_IEC61966_2_1 = 13,
        AVCOL_TRC_BT2020_10 = 14,
        AVCOL_TRC_BT2020_12 = 15,
        AVCOL_TRC_SMPTE2084 = 16,
        AVCOL_TRC_SMPTEST2084 = AVCOL_TRC_SMPTE2084,
        AVCOL_TRC_SMPTE428 = 17,
        AVCOL_TRC_SMPTEST428_1 = AVCOL_TRC_SMPTE428,
        AVCOL_TRC_ARIB_STD_B67 = 18,
        AVCOL_TRC_NB,
    }
}
