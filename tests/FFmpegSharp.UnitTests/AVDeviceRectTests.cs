using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVDeviceRect" /> struct.</summary>
    public static unsafe class AVDeviceRectTests
    {
        /// <summary>Validates that the <see cref="AVDeviceRect" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVDeviceRect), Marshal.SizeOf<AVDeviceRect>());
        }

        /// <summary>Validates that the <see cref="AVDeviceRect" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVDeviceRect).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVDeviceRect" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(AVDeviceRect));
        }
    }
}
