using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilter" /> struct.</summary>
    public static unsafe class AVFilterTests
    {
        /// <summary>Validates that the <see cref="AVFilter" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFilter), Marshal.SizeOf<AVFilter>());
        }

        /// <summary>Validates that the <see cref="AVFilter" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFilter).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFilter" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(128, sizeof(AVFilter));
            }
            else
            {
                Assert.Equal(68, sizeof(AVFilter));
            }
        }
    }
}
