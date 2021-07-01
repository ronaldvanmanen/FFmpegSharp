using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVBitStreamFilter" /> struct.</summary>
    public static unsafe class AVBitStreamFilterTests
    {
        /// <summary>Validates that the <see cref="AVBitStreamFilter" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVBitStreamFilter), Marshal.SizeOf<AVBitStreamFilter>());
        }

        /// <summary>Validates that the <see cref="AVBitStreamFilter" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVBitStreamFilter).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVBitStreamFilter" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(64, sizeof(AVBitStreamFilter));
            }
            else
            {
                Assert.Equal(32, sizeof(AVBitStreamFilter));
            }
        }
    }
}
