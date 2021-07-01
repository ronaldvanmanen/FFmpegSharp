namespace FFmpegSharp
{
    [NativeTypeName("int")]
    public enum AVAppToDevMessageType : uint
    {
        AV_APP_TO_DEV_NONE = (((byte)('E')) | (((byte)('N')) << 8) | (((byte)('O')) << 16) | ((uint)('N') << 24)),
        AV_APP_TO_DEV_WINDOW_SIZE = (((byte)('M')) | (((byte)('O')) << 8) | (((byte)('E')) << 16) | ((uint)('G') << 24)),
        AV_APP_TO_DEV_WINDOW_REPAINT = (((byte)('A')) | (((byte)('P')) << 8) | (((byte)('E')) << 16) | ((uint)('R') << 24)),
        AV_APP_TO_DEV_PAUSE = (((byte)(' ')) | (((byte)('U')) << 8) | (((byte)('A')) << 16) | ((uint)('P') << 24)),
        AV_APP_TO_DEV_PLAY = (((byte)('Y')) | (((byte)('A')) << 8) | (((byte)('L')) << 16) | ((uint)('P') << 24)),
        AV_APP_TO_DEV_TOGGLE_PAUSE = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('A')) << 16) | ((uint)('P') << 24)),
        AV_APP_TO_DEV_SET_VOLUME = (((byte)('L')) | (((byte)('O')) << 8) | (((byte)('V')) << 16) | ((uint)('S') << 24)),
        AV_APP_TO_DEV_MUTE = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('M')) << 16) | ((uint)(' ') << 24)),
        AV_APP_TO_DEV_UNMUTE = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('M')) << 16) | ((uint)('U') << 24)),
        AV_APP_TO_DEV_TOGGLE_MUTE = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('M')) << 16) | ((uint)('T') << 24)),
        AV_APP_TO_DEV_GET_VOLUME = (((byte)('L')) | (((byte)('O')) << 8) | (((byte)('V')) << 16) | ((uint)('G') << 24)),
        AV_APP_TO_DEV_GET_MUTE = (((byte)('T')) | (((byte)('U')) << 8) | (((byte)('M')) << 16) | ((uint)('G') << 24)),
    }
}
