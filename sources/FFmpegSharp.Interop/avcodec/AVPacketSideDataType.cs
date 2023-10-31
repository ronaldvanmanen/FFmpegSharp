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
    public enum AVPacketSideDataType
    {
        AV_PKT_DATA_PALETTE,
        AV_PKT_DATA_NEW_EXTRADATA,
        AV_PKT_DATA_PARAM_CHANGE,
        AV_PKT_DATA_H263_MB_INFO,
        AV_PKT_DATA_REPLAYGAIN,
        AV_PKT_DATA_DISPLAYMATRIX,
        AV_PKT_DATA_STEREO3D,
        AV_PKT_DATA_AUDIO_SERVICE_TYPE,
        AV_PKT_DATA_QUALITY_STATS,
        AV_PKT_DATA_FALLBACK_TRACK,
        AV_PKT_DATA_CPB_PROPERTIES,
        AV_PKT_DATA_SKIP_SAMPLES,
        AV_PKT_DATA_JP_DUALMONO,
        AV_PKT_DATA_STRINGS_METADATA,
        AV_PKT_DATA_SUBTITLE_POSITION,
        AV_PKT_DATA_MATROSKA_BLOCKADDITIONAL,
        AV_PKT_DATA_WEBVTT_IDENTIFIER,
        AV_PKT_DATA_WEBVTT_SETTINGS,
        AV_PKT_DATA_METADATA_UPDATE,
        AV_PKT_DATA_MPEGTS_STREAM_ID,
        AV_PKT_DATA_MASTERING_DISPLAY_METADATA,
        AV_PKT_DATA_SPHERICAL,
        AV_PKT_DATA_CONTENT_LIGHT_LEVEL,
        AV_PKT_DATA_A53_CC,
        AV_PKT_DATA_ENCRYPTION_INIT_INFO,
        AV_PKT_DATA_ENCRYPTION_INFO,
        AV_PKT_DATA_AFD,
        AV_PKT_DATA_PRFT,
        AV_PKT_DATA_ICC_PROFILE,
        AV_PKT_DATA_DOVI_CONF,
        AV_PKT_DATA_S12M_TIMECODE,
        AV_PKT_DATA_NB,
    }
}
