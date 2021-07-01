namespace FFmpegSharp.Interop
{
    public partial struct AVOptionRanges
    {
    }

    public unsafe partial struct AVOptionRanges
    {
        public AVOptionRange** range;

        public int nb_ranges;

        public int nb_components;
    }
}
