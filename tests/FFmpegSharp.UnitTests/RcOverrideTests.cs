using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="RcOverride" /> struct.</summary>
    public static unsafe class RcOverrideTests
    {
        /// <summary>Validates that the <see cref="RcOverride" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(RcOverride), Marshal.SizeOf<RcOverride>());
        }

        /// <summary>Validates that the <see cref="RcOverride" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(RcOverride).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="RcOverride" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(RcOverride));
        }
    }
}
