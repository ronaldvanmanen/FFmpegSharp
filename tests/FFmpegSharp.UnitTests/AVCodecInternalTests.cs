using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVCodecInternal" /> struct.</summary>
    public static unsafe class AVCodecInternalTests
    {
        /// <summary>Validates that the <see cref="AVCodecInternal" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCodecInternal), Marshal.SizeOf<AVCodecInternal>());
        }

        /// <summary>Validates that the <see cref="AVCodecInternal" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCodecInternal).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCodecInternal" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVCodecInternal));
        }
    }
}
