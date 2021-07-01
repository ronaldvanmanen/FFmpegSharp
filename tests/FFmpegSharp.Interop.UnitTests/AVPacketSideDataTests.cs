using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVPacketSideData" /> struct.</summary>
    public static unsafe class AVPacketSideDataTests
    {
        /// <summary>Validates that the <see cref="AVPacketSideData" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVPacketSideData), Marshal.SizeOf<AVPacketSideData>());
        }

        /// <summary>Validates that the <see cref="AVPacketSideData" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVPacketSideData).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVPacketSideData" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(16, sizeof(AVPacketSideData));
            }
            else
            {
                Assert.Equal(12, sizeof(AVPacketSideData));
            }
        }
    }
}
