using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVBuffer" /> struct.</summary>
    public static unsafe class AVBufferTests
    {
        /// <summary>Validates that the <see cref="AVBuffer" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVBuffer), Marshal.SizeOf<AVBuffer>());
        }

        /// <summary>Validates that the <see cref="AVBuffer" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVBuffer).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVBuffer" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVBuffer));
        }
    }
}
