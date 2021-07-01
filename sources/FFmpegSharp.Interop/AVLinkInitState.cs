namespace FFmpegSharp.Interop
{
    public enum AVLinkInitState
    {
        AVLINK_UNINIT = 0,      ///< not started
        AVLINK_STARTINIT,       ///< started, but incomplete
        AVLINK_INIT             ///< complete
    }
}