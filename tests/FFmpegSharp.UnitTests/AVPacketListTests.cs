using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVPacketList" /> struct.</summary>
    public static unsafe class AVPacketListTests
    {
        /// <summary>Validates that the <see cref="AVPacketList" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVPacketList), Marshal.SizeOf<AVPacketList>());
        }

        /// <summary>Validates that the <see cref="AVPacketList" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVPacketList).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVPacketList" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(96, sizeof(AVPacketList));
            }
            else
            {
                Assert.Equal(80, sizeof(AVPacketList));
            }
        }
    }
}
