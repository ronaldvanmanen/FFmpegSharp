namespace FFmpegSharp
{
    public unsafe partial struct AVOptionRanges
    {
        public AVOptionRange** range;

        public int nb_ranges;

        public int nb_components;
    }
}
