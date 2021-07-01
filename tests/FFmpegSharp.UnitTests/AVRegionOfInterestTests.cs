using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVRegionOfInterest" /> struct.</summary>
    public static unsafe class AVRegionOfInterestTests
    {
        /// <summary>Validates that the <see cref="AVRegionOfInterest" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVRegionOfInterest), Marshal.SizeOf<AVRegionOfInterest>());
        }

        /// <summary>Validates that the <see cref="AVRegionOfInterest" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVRegionOfInterest).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVRegionOfInterest" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(28, sizeof(AVRegionOfInterest));
        }
    }
}
