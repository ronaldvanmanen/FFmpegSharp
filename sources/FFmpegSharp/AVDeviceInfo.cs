namespace FFmpegSharp
{
    public unsafe partial struct AVDeviceInfo
    {
        [NativeTypeName("char *")]
        public sbyte* device_name;

        [NativeTypeName("char *")]
        public sbyte* device_description;
    }
}
