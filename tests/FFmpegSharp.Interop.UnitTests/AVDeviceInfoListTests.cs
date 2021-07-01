using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVDeviceInfoList" /> struct.</summary>
    public static unsafe class AVDeviceInfoListTests
    {
        /// <summary>Validates that the <see cref="AVDeviceInfoList" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVDeviceInfoList), Marshal.SizeOf<AVDeviceInfoList>());
        }

        /// <summary>Validates that the <see cref="AVDeviceInfoList" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVDeviceInfoList).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVDeviceInfoList" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVDeviceInfoList));
        }
    }
}
