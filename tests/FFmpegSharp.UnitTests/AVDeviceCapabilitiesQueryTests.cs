using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVDeviceCapabilitiesQuery" /> struct.</summary>
    public static unsafe class AVDeviceCapabilitiesQueryTests
    {
        /// <summary>Validates that the <see cref="AVDeviceCapabilitiesQuery" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVDeviceCapabilitiesQuery), Marshal.SizeOf<AVDeviceCapabilitiesQuery>());
        }

        /// <summary>Validates that the <see cref="AVDeviceCapabilitiesQuery" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVDeviceCapabilitiesQuery).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVDeviceCapabilitiesQuery" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVDeviceCapabilitiesQuery));
        }
    }
}
