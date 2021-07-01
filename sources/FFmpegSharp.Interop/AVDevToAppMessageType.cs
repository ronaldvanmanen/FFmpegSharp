namespace FFmpegSharp.Interop
{
    [NativeTypeName("int")]
    public enum AVDevToAppMessageType : uint
    {
        AV_DEV_TO_APP_NONE = (((byte)('E')) | (((byte)('N')) << 8) | (((byte)('O')) << 16) | ((uint)('N') << 24)),
        AV_DEV_TO_APP_CREATE_WINDOW_BUFFER = (((byte)('E')) | (((byte)('R')) << 8) | (((byte)('C')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_PREPARE_WINDOW_BUFFER = (((byte)('E')) | (((byte)('R')) << 8) | (((byte)('P')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_DISPLAY_WINDOW_BUFFER = (((byte)('S')) | (((byte)('I')) << 8) | (((byte)('D')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_DESTROY_WINDOW_BUFFER = (((byte)('S')) | (((byte)('E')) << 8) | (((byte)('D')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_BUFFER_OVERFLOW = (((byte)('L')) | (((byte)('F')) << 8) | (((byte)('O')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_BUFFER_UNDERFLOW = (((byte)('L')) | (((byte)('F')) << 8) | (((byte)('U')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_BUFFER_READABLE = (((byte)(' ')) | (((byte)('D')) << 8) | (((byte)('R')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_BUFFER_WRITABLE = (((byte)(' ')) | (((byte)('R')) << 8) | (((byte)('W')) << 16) | ((uint)('B') << 24)),
        AV_DEV_TO_APP_MUTE_STATE_CHANGED = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('M')) << 16) | ((uint)('C') << 24)),
        AV_DEV_TO_APP_VOLUME_LEVEL_CHANGED = (((byte)('L')) | (((byte)('O')) << 8) | (((byte)('V')) << 16) | ((uint)('C') << 24)),
    }
}
