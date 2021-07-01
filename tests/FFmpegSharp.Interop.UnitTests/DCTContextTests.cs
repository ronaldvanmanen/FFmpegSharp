using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="DCTContext" /> struct.</summary>
    public static unsafe class DCTContextTests
    {
        /// <summary>Validates that the <see cref="DCTContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(DCTContext), Marshal.SizeOf<DCTContext>());
        }

        /// <summary>Validates that the <see cref="DCTContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(DCTContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="DCTContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(DCTContext));
        }
    }
}
