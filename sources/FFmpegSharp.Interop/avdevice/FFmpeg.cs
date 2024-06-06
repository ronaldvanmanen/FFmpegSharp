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
using System.Runtime.InteropServices;

namespace FFmpegSharp.Interop
{
    public static unsafe partial class FFmpeg
    {
        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint avdevice_version();

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avdevice_configuration();

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* avdevice_license();

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avdevice_register_all();

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVInputFormat* av_input_audio_device_next(AVInputFormat* d);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVInputFormat* av_input_video_device_next(AVInputFormat* d);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVOutputFormat* av_output_audio_device_next(AVOutputFormat* d);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AVOutputFormat* av_output_video_device_next(AVOutputFormat* d);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avdevice_app_to_dev_control_message([NativeTypeName("struct AVFormatContext *")] AVFormatContext* s, [NativeTypeName("enum AVAppToDevMessageType")] AVAppToDevMessageType type, void* data, [NativeTypeName("size_t")] UIntPtr data_size);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avdevice_dev_to_app_control_message([NativeTypeName("struct AVFormatContext *")] AVFormatContext* s, [NativeTypeName("enum AVDevToAppMessageType")] AVDevToAppMessageType type, void* data, [NativeTypeName("size_t")] UIntPtr data_size);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int avdevice_capabilities_create(AVDeviceCapabilitiesQuery** caps, AVFormatContext* s, AVDictionary** device_options);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void avdevice_capabilities_free(AVDeviceCapabilitiesQuery** caps, AVFormatContext* s);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avdevice_list_devices([NativeTypeName("struct AVFormatContext *")] AVFormatContext* s, AVDeviceInfoList** device_list);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avdevice_free_list_devices(AVDeviceInfoList** device_list);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avdevice_list_input_sources([NativeTypeName("struct AVInputFormat *")] AVInputFormat* device, [NativeTypeName("const char *")] sbyte* device_name, AVDictionary* device_options, AVDeviceInfoList** device_list);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avdevice_list_output_sinks([NativeTypeName("struct AVOutputFormat *")] AVOutputFormat* device, [NativeTypeName("const char *")] sbyte* device_name, AVDictionary* device_options, AVDeviceInfoList** device_list);

        [NativeTypeName("#define LIBAVDEVICE_VERSION_MAJOR 58")]
        public const int LIBAVDEVICE_VERSION_MAJOR = 58;

        [NativeTypeName("#define LIBAVDEVICE_VERSION_MINOR 13")]
        public const int LIBAVDEVICE_VERSION_MINOR = 13;

        [NativeTypeName("#define LIBAVDEVICE_VERSION_MICRO 100")]
        public const int LIBAVDEVICE_VERSION_MICRO = 100;

        [NativeTypeName("#define LIBAVDEVICE_VERSION_INT AV_VERSION_INT(LIBAVDEVICE_VERSION_MAJOR, \\\n                                               LIBAVDEVICE_VERSION_MINOR, \\\n                                               LIBAVDEVICE_VERSION_MICRO)")]
        public const int LIBAVDEVICE_VERSION_INT = ((58) << 16 | (13) << 8 | (100));

        [NativeTypeName("#define LIBAVDEVICE_BUILD LIBAVDEVICE_VERSION_INT")]
        public const int LIBAVDEVICE_BUILD = ((58) << 16 | (13) << 8 | (100));

        [NativeTypeName("#define LIBAVDEVICE_IDENT \"Lavd\" AV_STRINGIFY(LIBAVDEVICE_VERSION)")]
        public static ReadOnlySpan<byte> LIBAVDEVICE_IDENT => new byte[] { 0x4C, 0x61, 0x76, 0x64, 0x35, 0x38, 0x2E, 0x31, 0x33, 0x2E, 0x31, 0x30, 0x30, 0x00 };

        [NativeTypeName("#define FF_API_DEVICE_CAPABILITIES (LIBAVDEVICE_VERSION_MAJOR < 60)")]
        public const bool FF_API_DEVICE_CAPABILITIES = (58 < 60);
    }
}
