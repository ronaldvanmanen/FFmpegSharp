using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFrame" /> struct.</summary>
    public static unsafe class AVFrameTests
    {
        /// <summary>Validates that the <see cref="AVFrame" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFrame), Marshal.SizeOf<AVFrame>());
        }

        /// <summary>Validates that the <see cref="AVFrame" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFrame).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFrame" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(536, sizeof(AVFrame));
            }
            else
            {
                Assert.Equal(408, sizeof(AVFrame));
            }
        }
    }
}
