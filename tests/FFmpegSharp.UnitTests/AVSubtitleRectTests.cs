using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVSubtitleRect" /> struct.</summary>
    public static unsafe class AVSubtitleRectTests
    {
        /// <summary>Validates that the <see cref="AVSubtitleRect" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVSubtitleRect), Marshal.SizeOf<AVSubtitleRect>());
        }

        /// <summary>Validates that the <see cref="AVSubtitleRect" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVSubtitleRect).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVSubtitleRect" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(200, sizeof(AVSubtitleRect));
            }
            else
            {
                Assert.Equal(132, sizeof(AVSubtitleRect));
            }
        }
    }
}
