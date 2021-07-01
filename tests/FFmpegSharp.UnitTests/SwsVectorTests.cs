using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="SwsVector" /> struct.</summary>
    public static unsafe class SwsVectorTests
    {
        /// <summary>Validates that the <see cref="SwsVector" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(SwsVector), Marshal.SizeOf<SwsVector>());
        }

        /// <summary>Validates that the <see cref="SwsVector" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(SwsVector).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="SwsVector" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(16, sizeof(SwsVector));
            }
            else
            {
                Assert.Equal(8, sizeof(SwsVector));
            }
        }
    }
}
