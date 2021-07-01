using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SwsFilter" /> struct.</summary>
    public static unsafe class SwsFilterTests
    {
        /// <summary>Validates that the <see cref="SwsFilter" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SwsFilter), Marshal.SizeOf<SwsFilter>());
        }

        /// <summary>Validates that the <see cref="SwsFilter" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SwsFilter).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SwsFilter" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(32, sizeof(SwsFilter));
            }
            else
            {
                Assert.Equal(16, sizeof(SwsFilter));
            }
        }
    }
}
