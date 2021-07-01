using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVHWAccel" /> struct.</summary>
    public static unsafe class AVHWAccelTests
    {
        /// <summary>Validates that the <see cref="AVHWAccel" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVHWAccel), Marshal.SizeOf<AVHWAccel>());
        }

        /// <summary>Validates that the <see cref="AVHWAccel" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVHWAccel).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVHWAccel" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(112, sizeof(AVHWAccel));
            }
            else
            {
                Assert.Equal(68, sizeof(AVHWAccel));
            }
        }
    }
}
