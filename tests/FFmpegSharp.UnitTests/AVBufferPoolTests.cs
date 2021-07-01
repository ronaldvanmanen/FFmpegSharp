using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVBufferPool" /> struct.</summary>
    public static unsafe class AVBufferPoolTests
    {
        /// <summary>Validates that the <see cref="AVBufferPool" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVBufferPool), Marshal.SizeOf<AVBufferPool>());
        }

        /// <summary>Validates that the <see cref="AVBufferPool" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVBufferPool).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVBufferPool" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVBufferPool));
        }
    }
}
