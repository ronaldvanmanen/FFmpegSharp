using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="FFTComplex" /> struct.</summary>
    public static unsafe class FFTComplexTests
    {
        /// <summary>Validates that the <see cref="FFTComplex" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(FFTComplex), Marshal.SizeOf<FFTComplex>());
        }

        /// <summary>Validates that the <see cref="FFTComplex" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(FFTComplex).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="FFTComplex" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(FFTComplex));
        }
    }
}
