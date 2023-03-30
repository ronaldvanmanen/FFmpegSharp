﻿// This file is part of FFmpegSharp.
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

using static FFmpegSharp.Interop.AVColorTransferCharacteristic;

namespace FFmpegSharp
{
    public enum AVColorTransferCharacteristic
    {
        RESERVED0 = AVCOL_TRC_RESERVED0,
        BT709 = AVCOL_TRC_BT709,
        UNSPECIFIED = AVCOL_TRC_UNSPECIFIED,
        RESERVED = AVCOL_TRC_RESERVED,
        GAMMA22 = AVCOL_TRC_GAMMA22,
        GAMMA28 = AVCOL_TRC_GAMMA28,
        SMPTE170M = AVCOL_TRC_SMPTE170M,
        SMPTE240M = AVCOL_TRC_SMPTE240M,
        LINEAR = AVCOL_TRC_LINEAR,
        LOG = AVCOL_TRC_LOG,
        LOG_SQRT = AVCOL_TRC_LOG_SQRT,
        IEC61966_2_4 = AVCOL_TRC_IEC61966_2_4,
        BT1361_ECG = AVCOL_TRC_BT1361_ECG,
        IEC61966_2_1 = AVCOL_TRC_IEC61966_2_1,
        BT2020_10 = AVCOL_TRC_BT2020_10,
        BT2020_12 = AVCOL_TRC_BT2020_12,
        SMPTE2084 = AVCOL_TRC_SMPTE2084,
#pragma warning disable CA1069 // Enums values should not be duplicated
        SMPTEST2084 = AVCOL_TRC_SMPTEST2084,
#pragma warning restore CA1069 // Enums values should not be duplicated
        SMPTE428 = AVCOL_TRC_SMPTE428,
#pragma warning disable CA1069 // Enums values should not be duplicated
        SMPTEST428_1 = AVCOL_TRC_SMPTEST428_1,
#pragma warning restore CA1069 // Enums values should not be duplicated
        ARIB_STD_B67 = AVCOL_TRC_ARIB_STD_B67
    }
}
