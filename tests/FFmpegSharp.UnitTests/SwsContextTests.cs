using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SwsContext" /> struct.</summary>
    public static unsafe class SwsContextTests
    {
        /// <summary>Validates that the <see cref="SwsContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SwsContext), Marshal.SizeOf<SwsContext>());
        }

        /// <summary>Validates that the <see cref="SwsContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SwsContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SwsContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(SwsContext));
        }
    }
}
