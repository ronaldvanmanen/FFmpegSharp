using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="SwrContext" /> struct.</summary>
    public static unsafe class SwrContextTests
    {
        /// <summary>Validates that the <see cref="SwrContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SwrContext), Marshal.SizeOf<SwrContext>());
        }

        /// <summary>Validates that the <see cref="SwrContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SwrContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SwrContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(SwrContext));
        }
    }
}
