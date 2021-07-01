using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVCodecParser" /> struct.</summary>
    public static unsafe class AVCodecParserTests
    {
        /// <summary>Validates that the <see cref="AVCodecParser" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCodecParser), Marshal.SizeOf<AVCodecParser>());
        }

        /// <summary>Validates that the <see cref="AVCodecParser" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCodecParser).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCodecParser" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(64, sizeof(AVCodecParser));
            }
            else
            {
                Assert.Equal(44, sizeof(AVCodecParser));
            }
        }
    }
}
