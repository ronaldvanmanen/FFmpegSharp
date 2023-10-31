﻿// Copyright (c) 2021-2023 Ronald van Manen
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

namespace FFmpegSharp
{
    public enum AVCodecID
    {
        NONE = Interop.AVCodecID.AV_CODEC_ID_NONE,
        MPEG1VIDEO = Interop.AVCodecID.AV_CODEC_ID_MPEG1VIDEO,
        MPEG2VIDEO = Interop.AVCodecID.AV_CODEC_ID_MPEG2VIDEO,
        H261 = Interop.AVCodecID.AV_CODEC_ID_H261,
        H263 = Interop.AVCodecID.AV_CODEC_ID_H263,
        RV10 = Interop.AVCodecID.AV_CODEC_ID_RV10,
        RV20 = Interop.AVCodecID.AV_CODEC_ID_RV20,
        MJPEG = Interop.AVCodecID.AV_CODEC_ID_MJPEG,
        MJPEGB = Interop.AVCodecID.AV_CODEC_ID_MJPEGB,
        LJPEG = Interop.AVCodecID.AV_CODEC_ID_LJPEG,
        SP5X = Interop.AVCodecID.AV_CODEC_ID_SP5X,
        JPEGLS = Interop.AVCodecID.AV_CODEC_ID_JPEGLS,
        MPEG4 = Interop.AVCodecID.AV_CODEC_ID_MPEG4,
        RAWVIDEO = Interop.AVCodecID.AV_CODEC_ID_RAWVIDEO,
        MSMPEG4V1 = Interop.AVCodecID.AV_CODEC_ID_MSMPEG4V1,
        MSMPEG4V2 = Interop.AVCodecID.AV_CODEC_ID_MSMPEG4V2,
        MSMPEG4V3 = Interop.AVCodecID.AV_CODEC_ID_MSMPEG4V3,
        WMV1 = Interop.AVCodecID.AV_CODEC_ID_WMV1,
        WMV2 = Interop.AVCodecID.AV_CODEC_ID_WMV2,
        H263P = Interop.AVCodecID.AV_CODEC_ID_H263P,
        H263I = Interop.AVCodecID.AV_CODEC_ID_H263I,
        FLV1 = Interop.AVCodecID.AV_CODEC_ID_FLV1,
        SVQ1 = Interop.AVCodecID.AV_CODEC_ID_SVQ1,
        SVQ3 = Interop.AVCodecID.AV_CODEC_ID_SVQ3,
        DVVIDEO = Interop.AVCodecID.AV_CODEC_ID_DVVIDEO,
        HUFFYUV = Interop.AVCodecID.AV_CODEC_ID_HUFFYUV,
        CYUV = Interop.AVCodecID.AV_CODEC_ID_CYUV,
        H264 = Interop.AVCodecID.AV_CODEC_ID_H264,
        INDEO3 = Interop.AVCodecID.AV_CODEC_ID_INDEO3,
        VP3 = Interop.AVCodecID.AV_CODEC_ID_VP3,
        THEORA = Interop.AVCodecID.AV_CODEC_ID_THEORA,
        ASV1 = Interop.AVCodecID.AV_CODEC_ID_ASV1,
        ASV2 = Interop.AVCodecID.AV_CODEC_ID_ASV2,
        FFV1 = Interop.AVCodecID.AV_CODEC_ID_FFV1,
        FOURXM = Interop.AVCodecID.AV_CODEC_ID_4XM,
        VCR1 = Interop.AVCodecID.AV_CODEC_ID_VCR1,
        CLJR = Interop.AVCodecID.AV_CODEC_ID_CLJR,
        MDEC = Interop.AVCodecID.AV_CODEC_ID_MDEC,
        ROQ = Interop.AVCodecID.AV_CODEC_ID_ROQ,
        INTERPLAY_VIDEO = Interop.AVCodecID.AV_CODEC_ID_INTERPLAY_VIDEO,
        XAN_WC3 = Interop.AVCodecID.AV_CODEC_ID_XAN_WC3,
        XAN_WC4 = Interop.AVCodecID.AV_CODEC_ID_XAN_WC4,
        RPZA = Interop.AVCodecID.AV_CODEC_ID_RPZA,
        CINEPAK = Interop.AVCodecID.AV_CODEC_ID_CINEPAK,
        WS_VQA = Interop.AVCodecID.AV_CODEC_ID_WS_VQA,
        MSRLE = Interop.AVCodecID.AV_CODEC_ID_MSRLE,
        MSVIDEO1 = Interop.AVCodecID.AV_CODEC_ID_MSVIDEO1,
        IDCIN = Interop.AVCodecID.AV_CODEC_ID_IDCIN,
        EIGHTBPS = Interop.AVCodecID.AV_CODEC_ID_8BPS,
        SMC = Interop.AVCodecID.AV_CODEC_ID_SMC,
        FLIC = Interop.AVCodecID.AV_CODEC_ID_FLIC,
        TRUEMOTION1 = Interop.AVCodecID.AV_CODEC_ID_TRUEMOTION1,
        VMDVIDEO = Interop.AVCodecID.AV_CODEC_ID_VMDVIDEO,
        MSZH = Interop.AVCodecID.AV_CODEC_ID_MSZH,
        ZLIB = Interop.AVCodecID.AV_CODEC_ID_ZLIB,
        QTRLE = Interop.AVCodecID.AV_CODEC_ID_QTRLE,
        TSCC = Interop.AVCodecID.AV_CODEC_ID_TSCC,
        ULTI = Interop.AVCodecID.AV_CODEC_ID_ULTI,
        QDRAW = Interop.AVCodecID.AV_CODEC_ID_QDRAW,
        VIXL = Interop.AVCodecID.AV_CODEC_ID_VIXL,
        QPEG = Interop.AVCodecID.AV_CODEC_ID_QPEG,
        PNG = Interop.AVCodecID.AV_CODEC_ID_PNG,
        PPM = Interop.AVCodecID.AV_CODEC_ID_PPM,
        PBM = Interop.AVCodecID.AV_CODEC_ID_PBM,
        PGM = Interop.AVCodecID.AV_CODEC_ID_PGM,
        PGMYUV = Interop.AVCodecID.AV_CODEC_ID_PGMYUV,
        PAM = Interop.AVCodecID.AV_CODEC_ID_PAM,
        FFVHUFF = Interop.AVCodecID.AV_CODEC_ID_FFVHUFF,
        RV30 = Interop.AVCodecID.AV_CODEC_ID_RV30,
        RV40 = Interop.AVCodecID.AV_CODEC_ID_RV40,
        VC1 = Interop.AVCodecID.AV_CODEC_ID_VC1,
        WMV3 = Interop.AVCodecID.AV_CODEC_ID_WMV3,
        LOCO = Interop.AVCodecID.AV_CODEC_ID_LOCO,
        WNV1 = Interop.AVCodecID.AV_CODEC_ID_WNV1,
        AASC = Interop.AVCodecID.AV_CODEC_ID_AASC,
        INDEO2 = Interop.AVCodecID.AV_CODEC_ID_INDEO2,
        FRAPS = Interop.AVCodecID.AV_CODEC_ID_FRAPS,
        TRUEMOTION2 = Interop.AVCodecID.AV_CODEC_ID_TRUEMOTION2,
        BMP = Interop.AVCodecID.AV_CODEC_ID_BMP,
        CSCD = Interop.AVCodecID.AV_CODEC_ID_CSCD,
        MMVIDEO = Interop.AVCodecID.AV_CODEC_ID_MMVIDEO,
        ZMBV = Interop.AVCodecID.AV_CODEC_ID_ZMBV,
        AVS = Interop.AVCodecID.AV_CODEC_ID_AVS,
        SMACKVIDEO = Interop.AVCodecID.AV_CODEC_ID_SMACKVIDEO,
        NUV = Interop.AVCodecID.AV_CODEC_ID_NUV,
        KMVC = Interop.AVCodecID.AV_CODEC_ID_KMVC,
        FLASHSV = Interop.AVCodecID.AV_CODEC_ID_FLASHSV,
        CAVS = Interop.AVCodecID.AV_CODEC_ID_CAVS,
        JPEG2000 = Interop.AVCodecID.AV_CODEC_ID_JPEG2000,
        VMNC = Interop.AVCodecID.AV_CODEC_ID_VMNC,
        VP5 = Interop.AVCodecID.AV_CODEC_ID_VP5,
        VP6 = Interop.AVCodecID.AV_CODEC_ID_VP6,
        VP6F = Interop.AVCodecID.AV_CODEC_ID_VP6F,
        TARGA = Interop.AVCodecID.AV_CODEC_ID_TARGA,
        DSICINVIDEO = Interop.AVCodecID.AV_CODEC_ID_DSICINVIDEO,
        TIERTEXSEQVIDEO = Interop.AVCodecID.AV_CODEC_ID_TIERTEXSEQVIDEO,
        TIFF = Interop.AVCodecID.AV_CODEC_ID_TIFF,
        GIF = Interop.AVCodecID.AV_CODEC_ID_GIF,
        DXA = Interop.AVCodecID.AV_CODEC_ID_DXA,
        DNXHD = Interop.AVCodecID.AV_CODEC_ID_DNXHD,
        THP = Interop.AVCodecID.AV_CODEC_ID_THP,
        SGI = Interop.AVCodecID.AV_CODEC_ID_SGI,
        C93 = Interop.AVCodecID.AV_CODEC_ID_C93,
        BETHSOFTVID = Interop.AVCodecID.AV_CODEC_ID_BETHSOFTVID,
        PTX = Interop.AVCodecID.AV_CODEC_ID_PTX,
        TXD = Interop.AVCodecID.AV_CODEC_ID_TXD,
        VP6A = Interop.AVCodecID.AV_CODEC_ID_VP6A,
        AMV = Interop.AVCodecID.AV_CODEC_ID_AMV,
        VB = Interop.AVCodecID.AV_CODEC_ID_VB,
        PCX = Interop.AVCodecID.AV_CODEC_ID_PCX,
        SUNRAST = Interop.AVCodecID.AV_CODEC_ID_SUNRAST,
        INDEO4 = Interop.AVCodecID.AV_CODEC_ID_INDEO4,
        INDEO5 = Interop.AVCodecID.AV_CODEC_ID_INDEO5,
        MIMIC = Interop.AVCodecID.AV_CODEC_ID_MIMIC,
        RL2 = Interop.AVCodecID.AV_CODEC_ID_RL2,
        ESCAPE124 = Interop.AVCodecID.AV_CODEC_ID_ESCAPE124,
        DIRAC = Interop.AVCodecID.AV_CODEC_ID_DIRAC,
        BFI = Interop.AVCodecID.AV_CODEC_ID_BFI,
        CMV = Interop.AVCodecID.AV_CODEC_ID_CMV,
        MOTIONPIXELS = Interop.AVCodecID.AV_CODEC_ID_MOTIONPIXELS,
        TGV = Interop.AVCodecID.AV_CODEC_ID_TGV,
        TGQ = Interop.AVCodecID.AV_CODEC_ID_TGQ,
        TQI = Interop.AVCodecID.AV_CODEC_ID_TQI,
        AURA = Interop.AVCodecID.AV_CODEC_ID_AURA,
        AURA2 = Interop.AVCodecID.AV_CODEC_ID_AURA2,
        V210X = Interop.AVCodecID.AV_CODEC_ID_V210X,
        TMV = Interop.AVCodecID.AV_CODEC_ID_TMV,
        V210 = Interop.AVCodecID.AV_CODEC_ID_V210,
        DPX = Interop.AVCodecID.AV_CODEC_ID_DPX,
        MAD = Interop.AVCodecID.AV_CODEC_ID_MAD,
        FRWU = Interop.AVCodecID.AV_CODEC_ID_FRWU,
        FLASHSV2 = Interop.AVCodecID.AV_CODEC_ID_FLASHSV2,
        CDGRAPHICS = Interop.AVCodecID.AV_CODEC_ID_CDGRAPHICS,
        R210 = Interop.AVCodecID.AV_CODEC_ID_R210,
        ANM = Interop.AVCodecID.AV_CODEC_ID_ANM,
        BINKVIDEO = Interop.AVCodecID.AV_CODEC_ID_BINKVIDEO,
        IFF_ILBM = Interop.AVCodecID.AV_CODEC_ID_IFF_ILBM,
        KGV1 = Interop.AVCodecID.AV_CODEC_ID_KGV1,
        YOP = Interop.AVCodecID.AV_CODEC_ID_YOP,
        VP8 = Interop.AVCodecID.AV_CODEC_ID_VP8,
        PICTOR = Interop.AVCodecID.AV_CODEC_ID_PICTOR,
        ANSI = Interop.AVCodecID.AV_CODEC_ID_ANSI,
        A64_MULTI = Interop.AVCodecID.AV_CODEC_ID_A64_MULTI,
        A64_MULTI5 = Interop.AVCodecID.AV_CODEC_ID_A64_MULTI5,
        R10K = Interop.AVCodecID.AV_CODEC_ID_R10K,
        MXPEG = Interop.AVCodecID.AV_CODEC_ID_MXPEG,
        LAGARITH = Interop.AVCodecID.AV_CODEC_ID_LAGARITH,
        PRORES = Interop.AVCodecID.AV_CODEC_ID_PRORES,
        JV = Interop.AVCodecID.AV_CODEC_ID_JV,
        DFA = Interop.AVCodecID.AV_CODEC_ID_DFA,
        WMV3IMAGE = Interop.AVCodecID.AV_CODEC_ID_WMV3IMAGE,
        VC1IMAGE = Interop.AVCodecID.AV_CODEC_ID_VC1IMAGE,
        UTVIDEO = Interop.AVCodecID.AV_CODEC_ID_UTVIDEO,
        BMV_VIDEO = Interop.AVCodecID.AV_CODEC_ID_BMV_VIDEO,
        VBLE = Interop.AVCodecID.AV_CODEC_ID_VBLE,
        DXTORY = Interop.AVCodecID.AV_CODEC_ID_DXTORY,
        V410 = Interop.AVCodecID.AV_CODEC_ID_V410,
        XWD = Interop.AVCodecID.AV_CODEC_ID_XWD,
        CDXL = Interop.AVCodecID.AV_CODEC_ID_CDXL,
        XBM = Interop.AVCodecID.AV_CODEC_ID_XBM,
        ZEROCODEC = Interop.AVCodecID.AV_CODEC_ID_ZEROCODEC,
        MSS1 = Interop.AVCodecID.AV_CODEC_ID_MSS1,
        MSA1 = Interop.AVCodecID.AV_CODEC_ID_MSA1,
        TSCC2 = Interop.AVCodecID.AV_CODEC_ID_TSCC2,
        MTS2 = Interop.AVCodecID.AV_CODEC_ID_MTS2,
        CLLC = Interop.AVCodecID.AV_CODEC_ID_CLLC,
        MSS2 = Interop.AVCodecID.AV_CODEC_ID_MSS2,
        VP9 = Interop.AVCodecID.AV_CODEC_ID_VP9,
        AIC = Interop.AVCodecID.AV_CODEC_ID_AIC,
        ESCAPE130 = Interop.AVCodecID.AV_CODEC_ID_ESCAPE130,
        G2M = Interop.AVCodecID.AV_CODEC_ID_G2M,
        WEBP = Interop.AVCodecID.AV_CODEC_ID_WEBP,
        HNM4_VIDEO = Interop.AVCodecID.AV_CODEC_ID_HNM4_VIDEO,
        HEVC = Interop.AVCodecID.AV_CODEC_ID_HEVC,
        FIC = Interop.AVCodecID.AV_CODEC_ID_FIC,
        ALIAS_PIX = Interop.AVCodecID.AV_CODEC_ID_ALIAS_PIX,
        BRENDER_PIX = Interop.AVCodecID.AV_CODEC_ID_BRENDER_PIX,
        PAF_VIDEO = Interop.AVCodecID.AV_CODEC_ID_PAF_VIDEO,
        EXR = Interop.AVCodecID.AV_CODEC_ID_EXR,
        VP7 = Interop.AVCodecID.AV_CODEC_ID_VP7,
        SANM = Interop.AVCodecID.AV_CODEC_ID_SANM,
        SGIRLE = Interop.AVCodecID.AV_CODEC_ID_SGIRLE,
        MVC1 = Interop.AVCodecID.AV_CODEC_ID_MVC1,
        MVC2 = Interop.AVCodecID.AV_CODEC_ID_MVC2,
        HQX = Interop.AVCodecID.AV_CODEC_ID_HQX,
        TDSC = Interop.AVCodecID.AV_CODEC_ID_TDSC,
        HQ_HQA = Interop.AVCodecID.AV_CODEC_ID_HQ_HQA,
        HAP = Interop.AVCodecID.AV_CODEC_ID_HAP,
        DDS = Interop.AVCodecID.AV_CODEC_ID_DDS,
        DXV = Interop.AVCodecID.AV_CODEC_ID_DXV,
        SCREENPRESSO = Interop.AVCodecID.AV_CODEC_ID_SCREENPRESSO,
        RSCC = Interop.AVCodecID.AV_CODEC_ID_RSCC,
        AVS2 = Interop.AVCodecID.AV_CODEC_ID_AVS2,
        PGX = Interop.AVCodecID.AV_CODEC_ID_PGX,
        AVS3 = Interop.AVCodecID.AV_CODEC_ID_AVS3,
        MSP2 = Interop.AVCodecID.AV_CODEC_ID_MSP2,
        VVC = Interop.AVCodecID.AV_CODEC_ID_VVC,
        Y41P = Interop.AVCodecID.AV_CODEC_ID_Y41P,
        AVRP = Interop.AVCodecID.AV_CODEC_ID_AVRP,
        Zero12V = Interop.AVCodecID.AV_CODEC_ID_012V,
        AVUI = Interop.AVCodecID.AV_CODEC_ID_AVUI,
        AYUV = Interop.AVCodecID.AV_CODEC_ID_AYUV,
        TARGA_Y216 = Interop.AVCodecID.AV_CODEC_ID_TARGA_Y216,
        V308 = Interop.AVCodecID.AV_CODEC_ID_V308,
        V408 = Interop.AVCodecID.AV_CODEC_ID_V408,
        YUV4 = Interop.AVCodecID.AV_CODEC_ID_YUV4,
        AVRN = Interop.AVCodecID.AV_CODEC_ID_AVRN,
        CPIA = Interop.AVCodecID.AV_CODEC_ID_CPIA,
        XFACE = Interop.AVCodecID.AV_CODEC_ID_XFACE,
        SNOW = Interop.AVCodecID.AV_CODEC_ID_SNOW,
        SMVJPEG = Interop.AVCodecID.AV_CODEC_ID_SMVJPEG,
        APNG = Interop.AVCodecID.AV_CODEC_ID_APNG,
        DAALA = Interop.AVCodecID.AV_CODEC_ID_DAALA,
        CFHD = Interop.AVCodecID.AV_CODEC_ID_CFHD,
        TRUEMOTION2RT = Interop.AVCodecID.AV_CODEC_ID_TRUEMOTION2RT,
        M101 = Interop.AVCodecID.AV_CODEC_ID_M101,
        MAGICYUV = Interop.AVCodecID.AV_CODEC_ID_MAGICYUV,
        SHEERVIDEO = Interop.AVCodecID.AV_CODEC_ID_SHEERVIDEO,
        YLC = Interop.AVCodecID.AV_CODEC_ID_YLC,
        PSD = Interop.AVCodecID.AV_CODEC_ID_PSD,
        PIXLET = Interop.AVCodecID.AV_CODEC_ID_PIXLET,
        SPEEDHQ = Interop.AVCodecID.AV_CODEC_ID_SPEEDHQ,
        FMVC = Interop.AVCodecID.AV_CODEC_ID_FMVC,
        SCPR = Interop.AVCodecID.AV_CODEC_ID_SCPR,
        CLEARVIDEO = Interop.AVCodecID.AV_CODEC_ID_CLEARVIDEO,
        XPM = Interop.AVCodecID.AV_CODEC_ID_XPM,
        AV1 = Interop.AVCodecID.AV_CODEC_ID_AV1,
        BITPACKED = Interop.AVCodecID.AV_CODEC_ID_BITPACKED,
        MSCC = Interop.AVCodecID.AV_CODEC_ID_MSCC,
        SRGC = Interop.AVCodecID.AV_CODEC_ID_SRGC,
        SVG = Interop.AVCodecID.AV_CODEC_ID_SVG,
        GDV = Interop.AVCodecID.AV_CODEC_ID_GDV,
        FITS = Interop.AVCodecID.AV_CODEC_ID_FITS,
        IMM4 = Interop.AVCodecID.AV_CODEC_ID_IMM4,
        PROSUMER = Interop.AVCodecID.AV_CODEC_ID_PROSUMER,
        MWSC = Interop.AVCodecID.AV_CODEC_ID_MWSC,
        WCMV = Interop.AVCodecID.AV_CODEC_ID_WCMV,
        RASC = Interop.AVCodecID.AV_CODEC_ID_RASC,
        HYMT = Interop.AVCodecID.AV_CODEC_ID_HYMT,
        ARBC = Interop.AVCodecID.AV_CODEC_ID_ARBC,
        AGM = Interop.AVCodecID.AV_CODEC_ID_AGM,
        LSCR = Interop.AVCodecID.AV_CODEC_ID_LSCR,
        VP4 = Interop.AVCodecID.AV_CODEC_ID_VP4,
        IMM5 = Interop.AVCodecID.AV_CODEC_ID_IMM5,
        MVDV = Interop.AVCodecID.AV_CODEC_ID_MVDV,
        MVHA = Interop.AVCodecID.AV_CODEC_ID_MVHA,
        CDTOONS = Interop.AVCodecID.AV_CODEC_ID_CDTOONS,
        MV30 = Interop.AVCodecID.AV_CODEC_ID_MV30,
        NOTCHLC = Interop.AVCodecID.AV_CODEC_ID_NOTCHLC,
        PFM = Interop.AVCodecID.AV_CODEC_ID_PFM,
        MOBICLIP = Interop.AVCodecID.AV_CODEC_ID_MOBICLIP,
        PHOTOCD = Interop.AVCodecID.AV_CODEC_ID_PHOTOCD,
        IPU = Interop.AVCodecID.AV_CODEC_ID_IPU,
        ARGO = Interop.AVCodecID.AV_CODEC_ID_ARGO,
        CRI = Interop.AVCodecID.AV_CODEC_ID_CRI,
        SIMBIOSIS_IMX = Interop.AVCodecID.AV_CODEC_ID_SIMBIOSIS_IMX,
        SGA_VIDEO = Interop.AVCodecID.AV_CODEC_ID_SGA_VIDEO,
        FIRST_AUDIO = Interop.AVCodecID.AV_CODEC_ID_FIRST_AUDIO,
        PCM_S16LE = Interop.AVCodecID.AV_CODEC_ID_PCM_S16LE,
        PCM_S16BE = Interop.AVCodecID.AV_CODEC_ID_PCM_S16BE,
        PCM_U16LE = Interop.AVCodecID.AV_CODEC_ID_PCM_U16LE,
        PCM_U16BE = Interop.AVCodecID.AV_CODEC_ID_PCM_U16BE,
        PCM_S8 = Interop.AVCodecID.AV_CODEC_ID_PCM_S8,
        PCM_U8 = Interop.AVCodecID.AV_CODEC_ID_PCM_U8,
        PCM_MULAW = Interop.AVCodecID.AV_CODEC_ID_PCM_MULAW,
        PCM_ALAW = Interop.AVCodecID.AV_CODEC_ID_PCM_ALAW,
        PCM_S32LE = Interop.AVCodecID.AV_CODEC_ID_PCM_S32LE,
        PCM_S32BE = Interop.AVCodecID.AV_CODEC_ID_PCM_S32BE,
        PCM_U32LE = Interop.AVCodecID.AV_CODEC_ID_PCM_U32LE,
        PCM_U32BE = Interop.AVCodecID.AV_CODEC_ID_PCM_U32BE,
        PCM_S24LE = Interop.AVCodecID.AV_CODEC_ID_PCM_S24LE,
        PCM_S24BE = Interop.AVCodecID.AV_CODEC_ID_PCM_S24BE,
        PCM_U24LE = Interop.AVCodecID.AV_CODEC_ID_PCM_U24LE,
        PCM_U24BE = Interop.AVCodecID.AV_CODEC_ID_PCM_U24BE,
        PCM_S24DAUD = Interop.AVCodecID.AV_CODEC_ID_PCM_S24DAUD,
        PCM_ZORK = Interop.AVCodecID.AV_CODEC_ID_PCM_ZORK,
        PCM_S16LE_PLANAR = Interop.AVCodecID.AV_CODEC_ID_PCM_S16LE_PLANAR,
        PCM_DVD = Interop.AVCodecID.AV_CODEC_ID_PCM_DVD,
        PCM_F32BE = Interop.AVCodecID.AV_CODEC_ID_PCM_F32BE,
        PCM_F32LE = Interop.AVCodecID.AV_CODEC_ID_PCM_F32LE,
        PCM_F64BE = Interop.AVCodecID.AV_CODEC_ID_PCM_F64BE,
        PCM_F64LE = Interop.AVCodecID.AV_CODEC_ID_PCM_F64LE,
        PCM_BLURAY = Interop.AVCodecID.AV_CODEC_ID_PCM_BLURAY,
        PCM_LXF = Interop.AVCodecID.AV_CODEC_ID_PCM_LXF,
        S302M = Interop.AVCodecID.AV_CODEC_ID_S302M,
        PCM_S8_PLANAR = Interop.AVCodecID.AV_CODEC_ID_PCM_S8_PLANAR,
        PCM_S24LE_PLANAR = Interop.AVCodecID.AV_CODEC_ID_PCM_S24LE_PLANAR,
        PCM_S32LE_PLANAR = Interop.AVCodecID.AV_CODEC_ID_PCM_S32LE_PLANAR,
        PCM_S16BE_PLANAR = Interop.AVCodecID.AV_CODEC_ID_PCM_S16BE_PLANAR,
        PCM_S64LE = Interop.AVCodecID.AV_CODEC_ID_PCM_S64LE,
        PCM_S64BE = Interop.AVCodecID.AV_CODEC_ID_PCM_S64BE,
        PCM_F16LE = Interop.AVCodecID.AV_CODEC_ID_PCM_F16LE,
        PCM_F24LE = Interop.AVCodecID.AV_CODEC_ID_PCM_F24LE,
        PCM_VIDC = Interop.AVCodecID.AV_CODEC_ID_PCM_VIDC,
        PCM_SGA = Interop.AVCodecID.AV_CODEC_ID_PCM_SGA,
        ADPCM_IMA_QT = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_QT,
        ADPCM_IMA_WAV = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_WAV,
        ADPCM_IMA_DK3 = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_DK3,
        ADPCM_IMA_DK4 = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_DK4,
        ADPCM_IMA_WS = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_WS,
        ADPCM_IMA_SMJPEG = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_SMJPEG,
        ADPCM_MS = Interop.AVCodecID.AV_CODEC_ID_ADPCM_MS,
        ADPCM_4XM = Interop.AVCodecID.AV_CODEC_ID_ADPCM_4XM,
        ADPCM_XA = Interop.AVCodecID.AV_CODEC_ID_ADPCM_XA,
        ADPCM_ADX = Interop.AVCodecID.AV_CODEC_ID_ADPCM_ADX,
        ADPCM_EA = Interop.AVCodecID.AV_CODEC_ID_ADPCM_EA,
        ADPCM_G726 = Interop.AVCodecID.AV_CODEC_ID_ADPCM_G726,
        ADPCM_CT = Interop.AVCodecID.AV_CODEC_ID_ADPCM_CT,
        ADPCM_SWF = Interop.AVCodecID.AV_CODEC_ID_ADPCM_SWF,
        ADPCM_YAMAHA = Interop.AVCodecID.AV_CODEC_ID_ADPCM_YAMAHA,
        ADPCM_SBPRO_4 = Interop.AVCodecID.AV_CODEC_ID_ADPCM_SBPRO_4,
        ADPCM_SBPRO_3 = Interop.AVCodecID.AV_CODEC_ID_ADPCM_SBPRO_3,
        ADPCM_SBPRO_2 = Interop.AVCodecID.AV_CODEC_ID_ADPCM_SBPRO_2,
        ADPCM_THP = Interop.AVCodecID.AV_CODEC_ID_ADPCM_THP,
        ADPCM_IMA_AMV = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_AMV,
        ADPCM_EA_R1 = Interop.AVCodecID.AV_CODEC_ID_ADPCM_EA_R1,
        ADPCM_EA_R3 = Interop.AVCodecID.AV_CODEC_ID_ADPCM_EA_R3,
        ADPCM_EA_R2 = Interop.AVCodecID.AV_CODEC_ID_ADPCM_EA_R2,
        ADPCM_IMA_EA_SEAD = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_EA_SEAD,
        ADPCM_IMA_EA_EACS = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_EA_EACS,
        ADPCM_EA_XAS = Interop.AVCodecID.AV_CODEC_ID_ADPCM_EA_XAS,
        ADPCM_EA_MAXIS_XA = Interop.AVCodecID.AV_CODEC_ID_ADPCM_EA_MAXIS_XA,
        ADPCM_IMA_ISS = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_ISS,
        ADPCM_G722 = Interop.AVCodecID.AV_CODEC_ID_ADPCM_G722,
        ADPCM_IMA_APC = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_APC,
        ADPCM_VIMA = Interop.AVCodecID.AV_CODEC_ID_ADPCM_VIMA,
        ADPCM_AFC = Interop.AVCodecID.AV_CODEC_ID_ADPCM_AFC,
        ADPCM_IMA_OKI = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_OKI,
        ADPCM_DTK = Interop.AVCodecID.AV_CODEC_ID_ADPCM_DTK,
        ADPCM_IMA_RAD = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_RAD,
        ADPCM_G726LE = Interop.AVCodecID.AV_CODEC_ID_ADPCM_G726LE,
        ADPCM_THP_LE = Interop.AVCodecID.AV_CODEC_ID_ADPCM_THP_LE,
        ADPCM_PSX = Interop.AVCodecID.AV_CODEC_ID_ADPCM_PSX,
        ADPCM_AICA = Interop.AVCodecID.AV_CODEC_ID_ADPCM_AICA,
        ADPCM_IMA_DAT4 = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_DAT4,
        ADPCM_MTAF = Interop.AVCodecID.AV_CODEC_ID_ADPCM_MTAF,
        ADPCM_AGM = Interop.AVCodecID.AV_CODEC_ID_ADPCM_AGM,
        ADPCM_ARGO = Interop.AVCodecID.AV_CODEC_ID_ADPCM_ARGO,
        ADPCM_IMA_SSI = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_SSI,
        ADPCM_ZORK = Interop.AVCodecID.AV_CODEC_ID_ADPCM_ZORK,
        ADPCM_IMA_APM = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_APM,
        ADPCM_IMA_ALP = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_ALP,
        ADPCM_IMA_MTF = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_MTF,
        ADPCM_IMA_CUNNING = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_CUNNING,
        ADPCM_IMA_MOFLEX = Interop.AVCodecID.AV_CODEC_ID_ADPCM_IMA_MOFLEX,
        AMR_NB = Interop.AVCodecID.AV_CODEC_ID_AMR_NB,
        AMR_WB = Interop.AVCodecID.AV_CODEC_ID_AMR_WB,
        RA_144 = Interop.AVCodecID.AV_CODEC_ID_RA_144,
        RA_288 = Interop.AVCodecID.AV_CODEC_ID_RA_288,
        ROQ_DPCM = Interop.AVCodecID.AV_CODEC_ID_ROQ_DPCM,
        INTERPLAY_DPCM = Interop.AVCodecID.AV_CODEC_ID_INTERPLAY_DPCM,
        XAN_DPCM = Interop.AVCodecID.AV_CODEC_ID_XAN_DPCM,
        SOL_DPCM = Interop.AVCodecID.AV_CODEC_ID_SOL_DPCM,
        SDX2_DPCM = Interop.AVCodecID.AV_CODEC_ID_SDX2_DPCM,
        GREMLIN_DPCM = Interop.AVCodecID.AV_CODEC_ID_GREMLIN_DPCM,
        DERF_DPCM = Interop.AVCodecID.AV_CODEC_ID_DERF_DPCM,
        MP2 = Interop.AVCodecID.AV_CODEC_ID_MP2,
        MP3 = Interop.AVCodecID.AV_CODEC_ID_MP3,
        AAC = Interop.AVCodecID.AV_CODEC_ID_AAC,
        AC3 = Interop.AVCodecID.AV_CODEC_ID_AC3,
        DTS = Interop.AVCodecID.AV_CODEC_ID_DTS,
        VORBIS = Interop.AVCodecID.AV_CODEC_ID_VORBIS,
        DVAUDIO = Interop.AVCodecID.AV_CODEC_ID_DVAUDIO,
        WMAV1 = Interop.AVCodecID.AV_CODEC_ID_WMAV1,
        WMAV2 = Interop.AVCodecID.AV_CODEC_ID_WMAV2,
        MACE3 = Interop.AVCodecID.AV_CODEC_ID_MACE3,
        MACE6 = Interop.AVCodecID.AV_CODEC_ID_MACE6,
        VMDAUDIO = Interop.AVCodecID.AV_CODEC_ID_VMDAUDIO,
        FLAC = Interop.AVCodecID.AV_CODEC_ID_FLAC,
        MP3ADU = Interop.AVCodecID.AV_CODEC_ID_MP3ADU,
        MP3ON4 = Interop.AVCodecID.AV_CODEC_ID_MP3ON4,
        SHORTEN = Interop.AVCodecID.AV_CODEC_ID_SHORTEN,
        ALAC = Interop.AVCodecID.AV_CODEC_ID_ALAC,
        WESTWOOD_SND1 = Interop.AVCodecID.AV_CODEC_ID_WESTWOOD_SND1,
        GSM = Interop.AVCodecID.AV_CODEC_ID_GSM,
        QDM2 = Interop.AVCodecID.AV_CODEC_ID_QDM2,
        COOK = Interop.AVCodecID.AV_CODEC_ID_COOK,
        TRUESPEECH = Interop.AVCodecID.AV_CODEC_ID_TRUESPEECH,
        TTA = Interop.AVCodecID.AV_CODEC_ID_TTA,
        SMACKAUDIO = Interop.AVCodecID.AV_CODEC_ID_SMACKAUDIO,
        QCELP = Interop.AVCodecID.AV_CODEC_ID_QCELP,
        WAVPACK = Interop.AVCodecID.AV_CODEC_ID_WAVPACK,
        DSICINAUDIO = Interop.AVCodecID.AV_CODEC_ID_DSICINAUDIO,
        IMC = Interop.AVCodecID.AV_CODEC_ID_IMC,
        MUSEPACK7 = Interop.AVCodecID.AV_CODEC_ID_MUSEPACK7,
        MLP = Interop.AVCodecID.AV_CODEC_ID_MLP,
        GSM_MS = Interop.AVCodecID.AV_CODEC_ID_GSM_MS,
        ATRAC3 = Interop.AVCodecID.AV_CODEC_ID_ATRAC3,
        APE = Interop.AVCodecID.AV_CODEC_ID_APE,
        NELLYMOSER = Interop.AVCodecID.AV_CODEC_ID_NELLYMOSER,
        MUSEPACK8 = Interop.AVCodecID.AV_CODEC_ID_MUSEPACK8,
        SPEEX = Interop.AVCodecID.AV_CODEC_ID_SPEEX,
        WMAVOICE = Interop.AVCodecID.AV_CODEC_ID_WMAVOICE,
        WMAPRO = Interop.AVCodecID.AV_CODEC_ID_WMAPRO,
        WMALOSSLESS = Interop.AVCodecID.AV_CODEC_ID_WMALOSSLESS,
        ATRAC3P = Interop.AVCodecID.AV_CODEC_ID_ATRAC3P,
        EAC3 = Interop.AVCodecID.AV_CODEC_ID_EAC3,
        SIPR = Interop.AVCodecID.AV_CODEC_ID_SIPR,
        MP1 = Interop.AVCodecID.AV_CODEC_ID_MP1,
        TWINVQ = Interop.AVCodecID.AV_CODEC_ID_TWINVQ,
        TRUEHD = Interop.AVCodecID.AV_CODEC_ID_TRUEHD,
        MP4ALS = Interop.AVCodecID.AV_CODEC_ID_MP4ALS,
        ATRAC1 = Interop.AVCodecID.AV_CODEC_ID_ATRAC1,
        BINKAUDIO_RDFT = Interop.AVCodecID.AV_CODEC_ID_BINKAUDIO_RDFT,
        BINKAUDIO_DCT = Interop.AVCodecID.AV_CODEC_ID_BINKAUDIO_DCT,
        AAC_LATM = Interop.AVCodecID.AV_CODEC_ID_AAC_LATM,
        QDMC = Interop.AVCodecID.AV_CODEC_ID_QDMC,
        CELT = Interop.AVCodecID.AV_CODEC_ID_CELT,
        G723_1 = Interop.AVCodecID.AV_CODEC_ID_G723_1,
        G729 = Interop.AVCodecID.AV_CODEC_ID_G729,
        EIGHTSVX_EXP = Interop.AVCodecID.AV_CODEC_ID_8SVX_EXP,
        EIGHTSVX_FIB = Interop.AVCodecID.AV_CODEC_ID_8SVX_FIB,
        BMV_AUDIO = Interop.AVCodecID.AV_CODEC_ID_BMV_AUDIO,
        RALF = Interop.AVCodecID.AV_CODEC_ID_RALF,
        IAC = Interop.AVCodecID.AV_CODEC_ID_IAC,
        ILBC = Interop.AVCodecID.AV_CODEC_ID_ILBC,
        OPUS = Interop.AVCodecID.AV_CODEC_ID_OPUS,
        COMFORT_NOISE = Interop.AVCodecID.AV_CODEC_ID_COMFORT_NOISE,
        TAK = Interop.AVCodecID.AV_CODEC_ID_TAK,
        METASOUND = Interop.AVCodecID.AV_CODEC_ID_METASOUND,
        PAF_AUDIO = Interop.AVCodecID.AV_CODEC_ID_PAF_AUDIO,
        ON2AVC = Interop.AVCodecID.AV_CODEC_ID_ON2AVC,
        DSS_SP = Interop.AVCodecID.AV_CODEC_ID_DSS_SP,
        CODEC2 = Interop.AVCodecID.AV_CODEC_ID_CODEC2,
        FFWAVESYNTH = Interop.AVCodecID.AV_CODEC_ID_FFWAVESYNTH,
        SONIC = Interop.AVCodecID.AV_CODEC_ID_SONIC,
        SONIC_LS = Interop.AVCodecID.AV_CODEC_ID_SONIC_LS,
        EVRC = Interop.AVCodecID.AV_CODEC_ID_EVRC,
        SMV = Interop.AVCodecID.AV_CODEC_ID_SMV,
        DSD_LSBF = Interop.AVCodecID.AV_CODEC_ID_DSD_LSBF,
        DSD_MSBF = Interop.AVCodecID.AV_CODEC_ID_DSD_MSBF,
        DSD_LSBF_PLANAR = Interop.AVCodecID.AV_CODEC_ID_DSD_LSBF_PLANAR,
        DSD_MSBF_PLANAR = Interop.AVCodecID.AV_CODEC_ID_DSD_MSBF_PLANAR,
        FOURGV = Interop.AVCodecID.AV_CODEC_ID_4GV,
        INTERPLAY_ACM = Interop.AVCodecID.AV_CODEC_ID_INTERPLAY_ACM,
        XMA1 = Interop.AVCodecID.AV_CODEC_ID_XMA1,
        XMA2 = Interop.AVCodecID.AV_CODEC_ID_XMA2,
        DST = Interop.AVCodecID.AV_CODEC_ID_DST,
        ATRAC3AL = Interop.AVCodecID.AV_CODEC_ID_ATRAC3AL,
        ATRAC3PAL = Interop.AVCodecID.AV_CODEC_ID_ATRAC3PAL,
        DOLBY_E = Interop.AVCodecID.AV_CODEC_ID_DOLBY_E,
        APTX = Interop.AVCodecID.AV_CODEC_ID_APTX,
        APTX_HD = Interop.AVCodecID.AV_CODEC_ID_APTX_HD,
        SBC = Interop.AVCodecID.AV_CODEC_ID_SBC,
        ATRAC9 = Interop.AVCodecID.AV_CODEC_ID_ATRAC9,
        HCOM = Interop.AVCodecID.AV_CODEC_ID_HCOM,
        ACELP_KELVIN = Interop.AVCodecID.AV_CODEC_ID_ACELP_KELVIN,
        MPEGH_3D_AUDIO = Interop.AVCodecID.AV_CODEC_ID_MPEGH_3D_AUDIO,
        SIREN = Interop.AVCodecID.AV_CODEC_ID_SIREN,
        HCA = Interop.AVCodecID.AV_CODEC_ID_HCA,
        FASTAUDIO = Interop.AVCodecID.AV_CODEC_ID_FASTAUDIO,
        FIRST_SUBTITLE = Interop.AVCodecID.AV_CODEC_ID_FIRST_SUBTITLE,
        DVD_SUBTITLE = Interop.AVCodecID.AV_CODEC_ID_DVD_SUBTITLE,
        DVB_SUBTITLE = Interop.AVCodecID.AV_CODEC_ID_DVB_SUBTITLE,
        TEXT = Interop.AVCodecID.AV_CODEC_ID_TEXT,
        XSUB = Interop.AVCodecID.AV_CODEC_ID_XSUB,
        SSA = Interop.AVCodecID.AV_CODEC_ID_SSA,
        MOV_TEXT = Interop.AVCodecID.AV_CODEC_ID_MOV_TEXT,
        HDMV_PGS_SUBTITLE = Interop.AVCodecID.AV_CODEC_ID_HDMV_PGS_SUBTITLE,
        DVB_TELETEXT = Interop.AVCodecID.AV_CODEC_ID_DVB_TELETEXT,
        SRT = Interop.AVCodecID.AV_CODEC_ID_SRT,
        MICRODVD = Interop.AVCodecID.AV_CODEC_ID_MICRODVD,
        EIA_608 = Interop.AVCodecID.AV_CODEC_ID_EIA_608,
        JACOSUB = Interop.AVCodecID.AV_CODEC_ID_JACOSUB,
        SAMI = Interop.AVCodecID.AV_CODEC_ID_SAMI,
        REALTEXT = Interop.AVCodecID.AV_CODEC_ID_REALTEXT,
        STL = Interop.AVCodecID.AV_CODEC_ID_STL,
        SUBVIEWER1 = Interop.AVCodecID.AV_CODEC_ID_SUBVIEWER1,
        SUBVIEWER = Interop.AVCodecID.AV_CODEC_ID_SUBVIEWER,
        SUBRIP = Interop.AVCodecID.AV_CODEC_ID_SUBRIP,
        WEBVTT = Interop.AVCodecID.AV_CODEC_ID_WEBVTT,
        MPL2 = Interop.AVCodecID.AV_CODEC_ID_MPL2,
        VPLAYER = Interop.AVCodecID.AV_CODEC_ID_VPLAYER,
        PJS = Interop.AVCodecID.AV_CODEC_ID_PJS,
        ASS = Interop.AVCodecID.AV_CODEC_ID_ASS,
        HDMV_TEXT_SUBTITLE = Interop.AVCodecID.AV_CODEC_ID_HDMV_TEXT_SUBTITLE,
        TTML = Interop.AVCodecID.AV_CODEC_ID_TTML,
        ARIB_CAPTION = Interop.AVCodecID.AV_CODEC_ID_ARIB_CAPTION,
        FIRST_UNKNOWN = Interop.AVCodecID.AV_CODEC_ID_FIRST_UNKNOWN,
        TTF = Interop.AVCodecID.AV_CODEC_ID_TTF,
        SCTE_35 = Interop.AVCodecID.AV_CODEC_ID_SCTE_35,
        EPG = Interop.AVCodecID.AV_CODEC_ID_EPG,
        BINTEXT = Interop.AVCodecID.AV_CODEC_ID_BINTEXT,
        XBIN = Interop.AVCodecID.AV_CODEC_ID_XBIN,
        IDF = Interop.AVCodecID.AV_CODEC_ID_IDF,
        OTF = Interop.AVCodecID.AV_CODEC_ID_OTF,
        SMPTE_KLV = Interop.AVCodecID.AV_CODEC_ID_SMPTE_KLV,
        DVD_NAV = Interop.AVCodecID.AV_CODEC_ID_DVD_NAV,
        TIMED_ID3 = Interop.AVCodecID.AV_CODEC_ID_TIMED_ID3,
        BIN_DATA = Interop.AVCodecID.AV_CODEC_ID_BIN_DATA,
        PROBE = Interop.AVCodecID.AV_CODEC_ID_PROBE,
        MPEG2TS = Interop.AVCodecID.AV_CODEC_ID_MPEG2TS,
        MPEG4SYSTEMS = Interop.AVCodecID.AV_CODEC_ID_MPEG4SYSTEMS,
        FFMETADATA = Interop.AVCodecID.AV_CODEC_ID_FFMETADATA,
        WRAPPED_AVFRAME = Interop.AVCodecID.AV_CODEC_ID_WRAPPED_AVFRAME
    }
}
