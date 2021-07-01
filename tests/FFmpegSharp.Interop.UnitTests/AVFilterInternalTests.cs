using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilterInternal" /> struct.</summary>
    public static unsafe class AVFilterInternalTests
    {
        /// <summary>Validates that the <see cref="AVFilterInternal" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFilterInternal), Marshal.SizeOf<AVFilterInternal>());
        }

        /// <summary>Validates that the <see cref="AVFilterInternal" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFilterInternal).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFilterInternal" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVFilterInternal));
        }
    }
}
