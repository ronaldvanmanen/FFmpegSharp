using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVCodecContext" /> struct.</summary>
    public static unsafe class AVCodecContextTests
    {
        /// <summary>Validates that the <see cref="AVCodecContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCodecContext), Marshal.SizeOf<AVCodecContext>());
        }

        /// <summary>Validates that the <see cref="AVCodecContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCodecContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCodecContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(1080, sizeof(AVCodecContext));
            }
            else
            {
                Assert.Equal(920, sizeof(AVCodecContext));
            }
        }
    }
}
