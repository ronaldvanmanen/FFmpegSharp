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

using System.Linq;
using System.Runtime.InteropServices;
using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.ClangSharpPInvokeGenerator;
using static System.Runtime.InteropServices.RuntimeInformation;
using static Nuke.Common.Tools.ClangSharpPInvokeGenerator.ClangSharpPInvokeGeneratorTasks;
using static Nuke.Common.Tools.ClangSharpPInvokeGenerator.ClangSharpPInvokeGeneratorConfigOption;

interface IGenerate : IBuild
{
    public Target Generate => _ => _
        .DependsOn<IRestore>(target => target.Restore)
        .Before<ICompile>(target => target.Compile)
        .OnlyWhenStatic(() => IsOSPlatform(OSPlatform.Windows))
        .Produces(ArtifactsDirectory / "log" / "*.*")
        .Executes(() =>
        {
            GenerateBindingsForAVCodec();
            GenerateBindingsForAVDevice();
            GenerateBindingsForAVFilter();
            GenerateBindingsForAVFormat();
            GenerateBindingsForAVUtil();
            GenerateBindingsForSWResample();
            GenerateBindingsForSWScale();
        });

    private void GenerateBindingsForAVCodec()
    {
        const string packageId = "FFmpeg";
        var packageFolder = packageId.ToLower();
        var packageReferenceVersion = Solution.AllProjects
            .Where(e => e.Name.Equals("FFmpegSharp.Interop"))
            .Select(e => e.GetPackageReferenceVersion(packageId))
            .Single(e => e is not null);
        var includeDirectory = GlobalPackagesFolder / packageFolder / packageReferenceVersion / "build" / "native" / "include";

        ClangSharpPInvokeGenerator(settings => settings
            .SetConfig
            (
                compatible_codegen,
                generate_aggressive_inlining,
                generate_macro_bindings,
                generate_tests_xunit,
                multi_file,
                log_exclusions,
                log_potential_typedef_remappings,
                log_visited_files
            )
            .SetHeaderFile(RootDirectory / "generation" / "header.txt")
            .SetLanguage("c++")
            .SetMethodClassName("FFmpeg")
            .SetNamespace("FFmpegSharp.Interop")
            .SetExclude("FF_API_NEXT")
            .SetFile(RootDirectory / "generation" / "libavcodec.h")
            .SetIncludeDirectory
            (
                includeDirectory / "libavcodec",
                includeDirectory
            )
            .SetLibraryPath("avcodec-58.dll")
            .SetOutput(RootDirectory / "sources" / "FFmpegSharp.Interop" / "avcodec")
            .SetTestOutput(RootDirectory / "tests" / "FFmpegSharp.Interop.UnitTests" / "avcodec")
            .SetTraverse
            (
                includeDirectory / "libavcodec" / "avcodec.h",
                includeDirectory / "libavcodec" / "avfft.h",
                includeDirectory / "libavcodec" / "bsf.h",
                includeDirectory / "libavcodec" / "codec.h",
                includeDirectory / "libavcodec" / "codec_desc.h",
                includeDirectory / "libavcodec" / "codec_id.h",
                includeDirectory / "libavcodec" / "codec_par.h",
                includeDirectory / "libavcodec" / "packet.h",
                includeDirectory / "libavcodec" / "version.h"
            )
        );
    }

    private void GenerateBindingsForAVDevice()
    {
        const string packageId = "FFmpeg";
        var packageFolder = packageId.ToLower();
        var packageReferenceVersion = Solution.AllProjects
            .Where(e => e.Name.Equals("FFmpegSharp.Interop"))
            .Select(e => e.GetPackageReferenceVersion(packageId))
            .Single(e => e is not null);
        var includeDirectory = GlobalPackagesFolder / packageFolder / packageReferenceVersion / "build" / "native" / "include";

        ClangSharpPInvokeGenerator(settings => settings
            .SetConfig
            (
                compatible_codegen,
                generate_aggressive_inlining,
                generate_macro_bindings,
                generate_tests_xunit,
                multi_file,
                log_exclusions,
                log_potential_typedef_remappings,
                log_visited_files
            )
            .SetHeaderFile(RootDirectory / "generation" / "header.txt")
            .SetLanguage("c++")
            .SetMethodClassName("FFmpeg")
            .SetNamespace("FFmpegSharp.Interop")
            .SetExclude("FF_API_NEXT")
            .SetFile(RootDirectory / "generation" / "libavdevice.h")
            .SetIncludeDirectory
            (
                includeDirectory / "libavdevice",
                includeDirectory
            )
            .SetLibraryPath("avdevice-58.dll")
            .SetOutput(RootDirectory / "sources" / "FFmpegSharp.Interop" / "avdevice")
            .SetTestOutput(RootDirectory / "tests" / "FFmpegSharp.Interop.UnitTests" / "avdevice")
            .SetTraverse
            (
                includeDirectory / "libavdevice" / "avdevice.h",
                includeDirectory / "libavdevice" / "version.h"
            )
            .SetWithType
            (
                "AVAppToDevMessageType=uint",
                "AVDevToAppMessageType=uint"
            )
        );
    }

    private void GenerateBindingsForAVFilter()
    {
        const string packageId = "FFmpeg";
        var packageFolder = packageId.ToLower();
        var packageReferenceVersion = Solution.AllProjects
            .Where(e => e.Name.Equals("FFmpegSharp.Interop"))
            .Select(e => e.GetPackageReferenceVersion(packageId))
            .Single(e => e is not null);
        var includeDirectory = GlobalPackagesFolder / packageFolder / packageReferenceVersion / "build" / "native" / "include";

        ClangSharpPInvokeGenerator(settings => settings
            .SetConfig
            (
                compatible_codegen,
                generate_aggressive_inlining,
                generate_macro_bindings,
                generate_tests_xunit,
                multi_file,
                log_exclusions,
                log_potential_typedef_remappings,
                log_visited_files
            )
            .SetHeaderFile(RootDirectory / "generation" / "header.txt")
            .SetLanguage("c++")
            .SetMethodClassName("FFmpeg")
            .SetNamespace("FFmpegSharp.Interop")
            .SetExclude("FF_API_NEXT")
            .SetFile(RootDirectory / "generation" / "libavfilter.h")
            .SetIncludeDirectory
            (
                includeDirectory / "libavfilter",
                includeDirectory
            )
            .SetLibraryPath("avfilter-7.dll")
            .SetOutput(RootDirectory / "sources" / "FFmpegSharp.Interop" / "avfilter")
            .SetTestOutput(RootDirectory / "tests" / "FFmpegSharp.Interop.UnitTests" / "avfilter")
            .SetTraverse
            (
                includeDirectory / "libavfilter" / "avfilter.h",
                includeDirectory / "libavfilter" / "buffersink.h",
                includeDirectory / "libavfilter" / "buffersrc.h",
                includeDirectory / "libavfilter" / "version.h"
            )
        );
    }

    private void GenerateBindingsForAVFormat()
    {
        const string packageId = "FFmpeg";
        var packageFolder = packageId.ToLower();
        var packageReferenceVersion = Solution.AllProjects
            .Where(e => e.Name.Equals("FFmpegSharp.Interop"))
            .Select(e => e.GetPackageReferenceVersion(packageId))
            .Single(e => e is not null);
        var includeDirectory = GlobalPackagesFolder / packageFolder / packageReferenceVersion / "build" / "native" / "include";

        ClangSharpPInvokeGenerator(settings => settings
            .SetConfig
            (
                compatible_codegen,
                generate_aggressive_inlining,
                generate_macro_bindings,
                generate_tests_xunit,
                multi_file,
                log_exclusions,
                log_potential_typedef_remappings,
                log_visited_files
            )
            .SetHeaderFile(RootDirectory / "generation" / "header.txt")
            .SetLanguage("c++")
            .SetMethodClassName("FFmpeg")
            .SetNamespace("FFmpegSharp.Interop")
            .SetExclude
            (
                "av_hex_dump",
                "av_pkt_dump2",
                "avio_print",
                "avio_printf",
                "AVBPrint",
                "AVDeviceCapabilitiesQuery",
                "AVDeviceInfoList",
                "FF_API_NEXT"
            )
            .SetFile(RootDirectory / "generation" / "libavformat.h")
            .SetIncludeDirectory
            (
                includeDirectory / "libavformat",
                includeDirectory
            )
            .SetLibraryPath("avformat-58.dll")
            .SetOutput(RootDirectory / "sources" / "FFmpegSharp.Interop" / "avformat")
            .SetTestOutput(RootDirectory / "tests" / "FFmpegSharp.Interop.UnitTests" / "avformat")
            .SetTraverse
            (
                includeDirectory / "libavformat" / "avformat.h",
                includeDirectory / "libavformat" / "avio.h",
                includeDirectory / "libavformat" / "version.h"
            )
        );
    }

    private void GenerateBindingsForAVUtil()
    {
        const string packageId = "FFmpeg";
        var packageFolder = packageId.ToLower();
        var packageReferenceVersion = Solution.AllProjects
            .Where(e => e.Name.Equals("FFmpegSharp.Interop"))
            .Select(e => e.GetPackageReferenceVersion(packageId))
            .Single(e => e is not null);
        var includeDirectory = GlobalPackagesFolder / packageFolder / packageReferenceVersion / "build" / "native" / "include";

        ClangSharpPInvokeGenerator(settings => settings
            .SetConfig
            (
                compatible_codegen,
                generate_aggressive_inlining,
                generate_macro_bindings,
                generate_tests_xunit,
                multi_file,
                log_exclusions,
                log_potential_typedef_remappings,
                log_visited_files
            )
            .SetHeaderFile(RootDirectory / "generation" / "header.txt")
            .SetLanguage("c++")
            .SetMethodClassName("FFmpeg")
            .SetNamespace("FFmpegSharp.Interop")
            .SetExclude
            (
                "__builtin_add_overflow",
                "__builtin_sub_overflow",
                "av_alloc_size",
                "av_ceil_log2",
                "av_ceil_log2_c",
                "av_clip",
                "av_clip_c",
                "av_clip_int16",
                "av_clip_int16_c",
                "av_clip_int8",
                "av_clip_int8_c",
                "av_clip_intp2",
                "av_clip_intp2_c",
                "av_clip_uint16",
                "av_clip_uint16_c",
                "av_clip_uint8",
                "av_clip_uint8_c",
                "av_clip_uintp2",
                "av_clip_uintp2_c",
                "av_clip64",
                "av_clip64_c",
                "av_clipd",
                "av_clipd_c",
                "av_clipf",
                "av_clipf_c",
                "av_clipl_int32",
                "av_clipl_int32_c",
                "av_err2str",
                "av_fopen_utf8",
                "av_fourcc2str",
                "av_int_list_length",
                "av_int_list_length_for_size",
                "av_log",
                "av_log_once",
                "av_log2",
                "av_log2_16bit",
                "av_make_q",
                "av_mod_uintp2",
                "av_mod_uintp2_c",
                "av_opt_set_int_list",
                "av_parity",
                "av_parity_c",
                "av_parse_ratio_quiet",
                "av_popcount",
                "av_popcount_c",
                "av_popcount64",
                "av_popcount64_c",
                "av_printf_format",
                "av_q2d",
                "av_sat_add32",
                "av_sat_add32_c",
                "av_sat_add64",
                "av_sat_add64_c",
                "av_sat_dadd32",
                "av_sat_dadd32_c",
                "av_sat_dsub32",
                "av_sat_dsub32_c",
                "av_sat_sub32",
                "av_sat_sub32_c",
                "av_sat_sub64",
                "av_sat_sub64_c",
                "av_size_mult",
                "av_small_strptime",
                "av_timegm",
                "av_uninit",
                "av_x_if_null",
                "tm",
                "AV_CEIL_RSHIFT",
                "AV_GCC_VERSION_AT_LEAST",
                "AV_GCC_VERSION_AT_MOST",
                "AV_HAS_BUILTIN",
                "AV_IS_INPUT_DEVICE",
                "AV_IS_OUTPUT_DEVICE",
                "AV_LOG_C",
                "AV_NE",
                "AV_NOWARN_DEPRECATED",
                "AV_PIX_FMT_NE",
                "AV_TIME_BASE_Q",
                "AV_VERSION_INT",
                "AV_VERSION_DOT",
                "AV_VERSION",
                "AV_VERSION_MAJOR",
                "AV_VERSION_MINOR",
                "AV_VERSION_MICRO",
                "AVERROR",
                "AVERROR_BSF_NOT_FOUND",
                "AVERROR_BUFFER_TOO_SMALL",
                "AVERROR_BUG",
                "AVERROR_BUG2",
                "AVERROR_DECODER_NOT_FOUND",
                "AVERROR_DEMUXER_NOT_FOUND",
                "AVERROR_ENCODER_NOT_FOUND",
                "AVERROR_EOF",
                "AVERROR_EXIT",
                "AVERROR_EXPERIMENTAL",
                "AVERROR_EXTERNAL",
                "AVERROR_FILTER_NOT_FOUND",
                "AVERROR_HTTP_BAD_REQUEST",
                "AVERROR_HTTP_FORBIDDEN",
                "AVERROR_HTTP_NOT_FOUND",
                "AVERROR_HTTP_OTHER_4XX",
                "AVERROR_HTTP_SERVER_ERROR",
                "AVERROR_HTTP_UNAUTHORIZED",
                "AVERROR_INPUT_CHANGED",
                "AVERROR_INVALIDDATA",
                "AVERROR_MUXER_NOT_FOUND",
                "AVERROR_OPTION_NOT_FOUND",
                "AVERROR_OUTPUT_CHANGED",
                "AVERROR_PATCHWELCOME",
                "AVERROR_PROTOCOL_NOT_FOUND",
                "AVERROR_STREAM_NOT_FOUND",
                "AVERROR_UNKNOWN",
                "AVUNERROR",
                "DECLARE_ALIGNED",
                "DECLARE_ASM_ALIGNED",
                "DECLARE_ASM_CONST",
                "FF_API_NEXT",
                "FF_ARRAY_ELEMS",
                "FFABS",
                "FFABSU",
                "FFABS64U",
                "FFDIFFSIGN",
                "FFERRTAG",
                "FFMAX",
                "FFMAX3",
                "FFMIN",
                "FFMIN3",
                "FFNABS",
                "FFSIGN",
                "FFSWAP",
                "FFUDIV",
                "FFUMOD",
                "GET_UTF8",
                "GET_UTF16",
                "MKBETAG",
                "MKTAG",
                "PUT_UTF8",
                "PUT_UTF16",
                "ROUNDED_DIV",
                "RSHIFT"
            )
            .SetFile(RootDirectory / "generation" / "libavutil.h")
            .SetIncludeDirectory
            (
                includeDirectory / "libavutil",
                includeDirectory
            )
            .SetLibraryPath("avutil-56.dll")
            .SetOutput(RootDirectory / "sources" / "FFmpegSharp.Interop" / "avutil")
            .SetRemap("_default_val_e__Union=AVOptionDefaultValue")
            .SetTestOutput(RootDirectory / "tests" / "FFmpegSharp.Interop.UnitTests" / "avutil")
            .SetTraverse
            (
                includeDirectory / "libavutil" / "avutil.h",
                includeDirectory / "libavutil" / "buffer.h",
                includeDirectory / "libavutil" / "channel_layout.h",
                includeDirectory / "libavutil" / "common.h",
                includeDirectory / "libavutil" / "cpu.h",
                includeDirectory / "libavutil" / "dict.h",
                includeDirectory / "libavutil" / "error.h",
                includeDirectory / "libavutil" / "fifo.h",
                includeDirectory / "libavutil" / "frame.h",
                includeDirectory / "libavutil" / "hwcontext.h",
                includeDirectory / "libavutil" / "log.h",
                includeDirectory / "libavutil" / "mathematics.h",
                includeDirectory / "libavutil" / "mem.h",
                includeDirectory / "libavutil" / "opt.h",
                includeDirectory / "libavutil" / "parseutils.h",
                includeDirectory / "libavutil" / "pixdesc.h",
                includeDirectory / "libavutil" / "pixfmt.h",
                includeDirectory / "libavutil" / "rational.h",
                includeDirectory / "libavutil" / "samplefmt.h",
                includeDirectory / "libavutil" / "time.h",
                includeDirectory / "libavutil" / "version.h"
            )
        );
    }

    private void GenerateBindingsForSWResample()
    {
        const string packageId = "FFmpeg";
        var packageFolder = packageId.ToLower();
        var packageReferenceVersion = Solution.AllProjects
            .Where(e => e.Name.Equals("FFmpegSharp.Interop"))
            .Select(e => e.GetPackageReferenceVersion(packageId))
            .Single(e => e is not null);
        var includeDirectory = GlobalPackagesFolder / packageFolder / packageReferenceVersion / "build" / "native" / "include";

        ClangSharpPInvokeGenerator(settings => settings
            .SetConfig
            (
                compatible_codegen,
                generate_aggressive_inlining,
                generate_macro_bindings,
                generate_tests_xunit,
                multi_file,
                log_exclusions,
                log_potential_typedef_remappings,
                log_visited_files
            )
            .SetHeaderFile(RootDirectory / "generation" / "header.txt")
            .SetLanguage("c++")
            .SetMethodClassName("FFmpeg")
            .SetNamespace("FFmpegSharp.Interop")
            .SetExclude("FF_API_NEXT")
            .SetFile(RootDirectory / "generation" / "libswresample.h")
            .SetIncludeDirectory
            (
                includeDirectory / "libswresample",
                includeDirectory
            )
            .SetLibraryPath("swresample-3.dll")
            .SetOutput(RootDirectory / "sources" / "FFmpegSharp.Interop" / "swresample")
            .SetTestOutput(RootDirectory / "tests" / "FFmpegSharp.Interop.UnitTests" / "swresample")
            .SetTraverse
            (
                includeDirectory / "libswresample" / "swresample.h",
                includeDirectory / "libswresample" / "version.h"
            )
        );
    }

    private void GenerateBindingsForSWScale()
    {
        const string packageId = "FFmpeg";
        var packageFolder = packageId.ToLower();
        var packageReferenceVersion = Solution.AllProjects
            .Where(e => e.Name.Equals("FFmpegSharp.Interop"))
            .Select(e => e.GetPackageReferenceVersion(packageId))
            .Single(e => e is not null);
        var includeDirectory = GlobalPackagesFolder / packageFolder / packageReferenceVersion / "build" / "native" / "include";

        ClangSharpPInvokeGenerator(settings => settings
            .SetConfig
            (
                compatible_codegen,
                generate_aggressive_inlining,
                generate_macro_bindings,
                generate_tests_xunit,
                multi_file,
                log_exclusions,
                log_potential_typedef_remappings,
                log_visited_files
            )
            .SetHeaderFile(RootDirectory / "generation" / "header.txt")
            .SetLanguage("c++")
            .SetMethodClassName("FFmpeg")
            .SetNamespace("FFmpegSharp.Interop")
            .SetExclude("FF_API_NEXT")
            .SetFile(RootDirectory / "generation" / "libswscale.h")
            .SetIncludeDirectory
            (
                includeDirectory / "libswscale",
                includeDirectory
            )
            .SetLibraryPath("swscale-3.dll")
            .SetOutput(RootDirectory / "sources" / "FFmpegSharp.Interop" / "swscale")
            .SetTestOutput(RootDirectory / "tests" / "FFmpegSharp.Interop.UnitTests" / "swscale")
            .SetTraverse
            (
                includeDirectory / "libswscale" / "swscale.h",
                includeDirectory / "libswscale" / "version.h"
            )
        );
    }
}
