namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVOptionRange
    {
        [NativeTypeName("const char *")]
        public sbyte* str;

        public double value_min;

        public double value_max;

        public double component_min;

        public double component_max;

        public int is_range;
    }
}
