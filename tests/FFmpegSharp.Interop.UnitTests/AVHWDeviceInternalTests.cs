using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVHWDeviceInternal" /> struct.</summary>
    public static unsafe class AVHWDeviceInternalTests
    {
        /// <summary>Validates that the <see cref="AVHWDeviceInternal" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVHWDeviceInternal), Marshal.SizeOf<AVHWDeviceInternal>());
        }

        /// <summary>Validates that the <see cref="AVHWDeviceInternal" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVHWDeviceInternal).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVHWDeviceInternal" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVHWDeviceInternal));
        }
    }
}
