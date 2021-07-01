using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVHWFramesInternal" /> struct.</summary>
    public static unsafe class AVHWFramesInternalTests
    {
        /// <summary>Validates that the <see cref="AVHWFramesInternal" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVHWFramesInternal), Marshal.SizeOf<AVHWFramesInternal>());
        }

        /// <summary>Validates that the <see cref="AVHWFramesInternal" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVHWFramesInternal).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVHWFramesInternal" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVHWFramesInternal));
        }
    }
}
