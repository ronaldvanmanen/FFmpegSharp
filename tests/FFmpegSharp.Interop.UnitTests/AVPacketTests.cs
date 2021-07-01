using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVPacket" /> struct.</summary>
    public static unsafe class AVPacketTests
    {
        /// <summary>Validates that the <see cref="AVPacket" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVPacket), Marshal.SizeOf<AVPacket>());
        }

        /// <summary>Validates that the <see cref="AVPacket" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVPacket).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVPacket" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(88, sizeof(AVPacket));
            }
            else
            {
                Assert.Equal(72, sizeof(AVPacket));
            }
        }
    }
}
