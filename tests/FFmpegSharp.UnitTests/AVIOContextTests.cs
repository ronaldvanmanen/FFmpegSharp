using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVIOContext" /> struct.</summary>
    public static unsafe class AVIOContextTests
    {
        /// <summary>Validates that the <see cref="AVIOContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVIOContext), Marshal.SizeOf<AVIOContext>());
        }

        /// <summary>Validates that the <see cref="AVIOContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVIOContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVIOContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(256, sizeof(AVIOContext));
            }
            else
            {
                Assert.Equal(184, sizeof(AVIOContext));
            }
        }
    }
}
