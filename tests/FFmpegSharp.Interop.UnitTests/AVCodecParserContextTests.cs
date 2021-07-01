using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVCodecParserContext" /> struct.</summary>
    public static unsafe class AVCodecParserContextTests
    {
        /// <summary>Validates that the <see cref="AVCodecParserContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCodecParserContext), Marshal.SizeOf<AVCodecParserContext>());
        }

        /// <summary>Validates that the <see cref="AVCodecParserContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCodecParserContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCodecParserContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(352, sizeof(AVCodecParserContext));
            }
            else
            {
                Assert.Equal(344, sizeof(AVCodecParserContext));
            }
        }
    }
}
