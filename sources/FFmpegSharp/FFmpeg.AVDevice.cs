using System;
using System.Runtime.InteropServices;

namespace FFmpegSharp
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
        [return: NativeTypeName("AVInputFormat *")]
        public static extern AVInputFormat* av_input_audio_device_next([NativeTypeName("AVInputFormat *")] AVInputFormat* d);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("AVInputFormat *")]
        public static extern AVInputFormat* av_input_video_device_next([NativeTypeName("AVInputFormat *")] AVInputFormat* d);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("AVOutputFormat *")]
        public static extern AVOutputFormat* av_output_audio_device_next([NativeTypeName("AVOutputFormat *")] AVOutputFormat* d);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("AVOutputFormat *")]
        public static extern AVOutputFormat* av_output_video_device_next([NativeTypeName("AVOutputFormat *")] AVOutputFormat* d);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avdevice_app_to_dev_control_message([NativeTypeName("struct AVFormatContext *")] AVFormatContext* s, [NativeTypeName("enum AVAppToDevMessageType")] AVAppToDevMessageType type, [NativeTypeName("void *")] void* data, [NativeTypeName("size_t")] UIntPtr data_size);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avdevice_dev_to_app_control_message([NativeTypeName("struct AVFormatContext *")] AVFormatContext* s, [NativeTypeName("enum AVDevToAppMessageType")] AVDevToAppMessageType type, [NativeTypeName("void *")] void* data, [NativeTypeName("size_t")] UIntPtr data_size);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avdevice_capabilities_create([NativeTypeName("AVDeviceCapabilitiesQuery **")] AVDeviceCapabilitiesQuery** caps, [NativeTypeName("AVFormatContext *")] AVFormatContext* s, [NativeTypeName("AVDictionary **")] AVDictionary** device_options);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avdevice_capabilities_free([NativeTypeName("AVDeviceCapabilitiesQuery **")] AVDeviceCapabilitiesQuery** caps, [NativeTypeName("AVFormatContext *")] AVFormatContext* s);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avdevice_list_devices([NativeTypeName("struct AVFormatContext *")] AVFormatContext* s, [NativeTypeName("AVDeviceInfoList **")] AVDeviceInfoList** device_list);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void avdevice_free_list_devices([NativeTypeName("AVDeviceInfoList **")] AVDeviceInfoList** device_list);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avdevice_list_input_sources([NativeTypeName("struct AVInputFormat *")] AVInputFormat* device, [NativeTypeName("const char *")] sbyte* device_name, [NativeTypeName("AVDictionary *")] AVDictionary* device_options, [NativeTypeName("AVDeviceInfoList **")] AVDeviceInfoList** device_list);

        [DllImport("avdevice-58.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int avdevice_list_output_sinks([NativeTypeName("struct AVOutputFormat *")] AVOutputFormat* device, [NativeTypeName("const char *")] sbyte* device_name, [NativeTypeName("AVDictionary *")] AVDictionary* device_options, [NativeTypeName("AVDeviceInfoList **")] AVDeviceInfoList** device_list);

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
    }
}
