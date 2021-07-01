using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="FFTContext" /> struct.</summary>
    public static unsafe class FFTContextTests
    {
        /// <summary>Validates that the <see cref="FFTContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(FFTContext), Marshal.SizeOf<FFTContext>());
        }

        /// <summary>Validates that the <see cref="FFTContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(FFTContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="FFTContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(FFTContext));
        }
    }
}
