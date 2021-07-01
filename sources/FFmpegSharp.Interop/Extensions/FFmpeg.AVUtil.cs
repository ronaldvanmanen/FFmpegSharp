using static FFmpegSharp.Interop.Std;

namespace FFmpegSharp.Interop
{
    public static unsafe partial class FFmpeg
    {
        public static readonly int AVERROR_EOF = FFERRTAG((byte)'E', (byte)'O', (byte)'F', (byte)' '); ///< End of file

        public static readonly int AVERROR_OPTION_NOT_FOUND = FFERRTAG(0xF8, (byte)'O', (byte)'P', (byte)'T'); ///< Option not found

        public static int FFERRTAG(byte a, byte b, byte c, byte d) => (-(int)MKTAG(a, b, c, d));

        public static uint MKTAG(byte a, byte b, byte c, byte d) => ((uint)a) | (((uint)b) << 8) | (((uint)c) << 16) | (((uint)d) << 24);

        public static int AVERROR(int e) => e;

        public static int AVUNERROR(int e) => e;

        public static readonly AVRational AV_TIME_BASE_Q = new AVRational { num = 1, den = AV_TIME_BASE };

        public static int AV_CEIL_RSHIFT(int a, int b)
        {
            // Fast a/(1<<b) rounded toward +inf. Assume a>=0 and b>=0
            //
            // #define 	av_builtin_constant_p(x) 0
            //
            // #define AV_CEIL_RSHIFT(a,b) (!av_builtin_constant_p(b) \
            //  ? -((-(a)) >> (b))
            //  : ((a) + (1 << (b)) - 1) >> (b))
            return -((-(a)) >> (b));
        }

        public static int av_int_list_length(int* list, ulong term)
        {
            return (int)av_int_list_length_for_size(sizeof(int), list, term);
        }

        public static int av_opt_set_int_list(void* obj, sbyte* name, int* val, ulong term, int flags)
        {
            return av_int_list_length(val, term) > int.MaxValue / sizeof(int)
                ? AVERROR(EINVAL)
                : av_opt_set_bin(obj, name, (byte*)val, av_int_list_length(val, term) * sizeof(int), flags);
        }

        public static void av_log(void* avcl, int level, string message)
        {
            using (var marshaledMessage = new MarshaledString(message))
            {
                av_log(avcl, level, (sbyte*)marshaledMessage);
            }
        }

    }
}
