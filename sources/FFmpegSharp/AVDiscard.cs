namespace FFmpegSharp
{
    public enum AVDiscard
    {
        AVDISCARD_NONE = -16,
        AVDISCARD_DEFAULT = 0,
        AVDISCARD_NONREF = 8,
        AVDISCARD_BIDIR = 16,
        AVDISCARD_NONINTRA = 24,
        AVDISCARD_NONKEY = 32,
        AVDISCARD_ALL = 48,
    }
}
