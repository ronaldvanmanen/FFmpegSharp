using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVOutputFormat" /> struct.</summary>
    public static unsafe class AVOutputFormatTests
    {
        /// <summary>Validates that the <see cref="AVOutputFormat" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVOutputFormat), Marshal.SizeOf<AVOutputFormat>());
        }

        /// <summary>Validates that the <see cref="AVOutputFormat" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVOutputFormat).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVOutputFormat" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(200, sizeof(AVOutputFormat));
            }
            else
            {
                Assert.Equal(108, sizeof(AVOutputFormat));
            }
        }
    }
}
