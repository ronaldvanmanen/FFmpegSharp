using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVDeviceInfo" /> struct.</summary>
    public static unsafe class AVDeviceInfoTests
    {
        /// <summary>Validates that the <see cref="AVDeviceInfo" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVDeviceInfo), Marshal.SizeOf<AVDeviceInfo>());
        }

        /// <summary>Validates that the <see cref="AVDeviceInfo" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVDeviceInfo).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVDeviceInfo" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(16, sizeof(AVDeviceInfo));
            }
            else
            {
                Assert.Equal(8, sizeof(AVDeviceInfo));
            }
        }
    }
}
