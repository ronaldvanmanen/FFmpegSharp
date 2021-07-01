using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVPanScan" /> struct.</summary>
    public static unsafe class AVPanScanTests
    {
        /// <summary>Validates that the <see cref="AVPanScan" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVPanScan), Marshal.SizeOf<AVPanScan>());
        }

        /// <summary>Validates that the <see cref="AVPanScan" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVPanScan).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVPanScan" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(AVPanScan));
        }
    }
}
