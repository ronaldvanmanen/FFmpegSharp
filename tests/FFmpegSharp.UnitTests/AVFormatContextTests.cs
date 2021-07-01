using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFormatContext" /> struct.</summary>
    public static unsafe class AVFormatContextTests
    {
        /// <summary>Validates that the <see cref="AVFormatContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFormatContext), Marshal.SizeOf<AVFormatContext>());
        }

        /// <summary>Validates that the <see cref="AVFormatContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFormatContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFormatContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(1504, sizeof(AVFormatContext));
            }
            else
            {
                Assert.Equal(1376, sizeof(AVFormatContext));
            }
        }
    }
}
