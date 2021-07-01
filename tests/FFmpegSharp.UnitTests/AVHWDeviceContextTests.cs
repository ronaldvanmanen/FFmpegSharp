using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVHWDeviceContext" /> struct.</summary>
    public static unsafe class AVHWDeviceContextTests
    {
        /// <summary>Validates that the <see cref="AVHWDeviceContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVHWDeviceContext), Marshal.SizeOf<AVHWDeviceContext>());
        }

        /// <summary>Validates that the <see cref="AVHWDeviceContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVHWDeviceContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVHWDeviceContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(48, sizeof(AVHWDeviceContext));
            }
            else
            {
                Assert.Equal(24, sizeof(AVHWDeviceContext));
            }
        }
    }
}
