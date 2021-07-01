using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVIOInterruptCB" /> struct.</summary>
    public static unsafe class AVIOInterruptCBTests
    {
        /// <summary>Validates that the <see cref="AVIOInterruptCB" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVIOInterruptCB), Marshal.SizeOf<AVIOInterruptCB>());
        }

        /// <summary>Validates that the <see cref="AVIOInterruptCB" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVIOInterruptCB).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVIOInterruptCB" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(16, sizeof(AVIOInterruptCB));
            }
            else
            {
                Assert.Equal(8, sizeof(AVIOInterruptCB));
            }
        }
    }
}
