using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="RDFTContext" /> struct.</summary>
    public static unsafe class RDFTContextTests
    {
        /// <summary>Validates that the <see cref="RDFTContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(RDFTContext), Marshal.SizeOf<RDFTContext>());
        }

        /// <summary>Validates that the <see cref="RDFTContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(RDFTContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="RDFTContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(RDFTContext));
        }
    }
}
