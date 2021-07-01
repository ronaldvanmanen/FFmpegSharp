using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFifoBuffer" /> struct.</summary>
    public static unsafe class AVFifoBufferTests
    {
        /// <summary>Validates that the <see cref="AVFifoBuffer" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFifoBuffer), Marshal.SizeOf<AVFifoBuffer>());
        }

        /// <summary>Validates that the <see cref="AVFifoBuffer" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFifoBuffer).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFifoBuffer" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(40, sizeof(AVFifoBuffer));
            }
            else
            {
                Assert.Equal(24, sizeof(AVFifoBuffer));
            }
        }
    }
}
