using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVProfile" /> struct.</summary>
    public static unsafe class AVProfileTests
    {
        /// <summary>Validates that the <see cref="AVProfile" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVProfile), Marshal.SizeOf<AVProfile>());
        }

        /// <summary>Validates that the <see cref="AVProfile" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVProfile).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVProfile" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(16, sizeof(AVProfile));
            }
            else
            {
                Assert.Equal(8, sizeof(AVProfile));
            }
        }
    }
}
