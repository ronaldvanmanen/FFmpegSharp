using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVCodecParameters" /> struct.</summary>
    public static unsafe class AVCodecParametersTests
    {
        /// <summary>Validates that the <see cref="AVCodecParameters" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCodecParameters), Marshal.SizeOf<AVCodecParameters>());
        }

        /// <summary>Validates that the <see cref="AVCodecParameters" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCodecParameters).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCodecParameters" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(144, sizeof(AVCodecParameters));
            }
            else
            {
                Assert.Equal(136, sizeof(AVCodecParameters));
            }
        }
    }
}
