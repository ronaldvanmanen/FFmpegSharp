using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVCodecHWConfig" /> struct.</summary>
    public static unsafe class AVCodecHWConfigTests
    {
        /// <summary>Validates that the <see cref="AVCodecHWConfig" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCodecHWConfig), Marshal.SizeOf<AVCodecHWConfig>());
        }

        /// <summary>Validates that the <see cref="AVCodecHWConfig" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCodecHWConfig).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCodecHWConfig" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(12, sizeof(AVCodecHWConfig));
        }
    }
}
