using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVInputFormat" /> struct.</summary>
    public static unsafe class AVInputFormatTests
    {
        /// <summary>Validates that the <see cref="AVInputFormat" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVInputFormat), Marshal.SizeOf<AVInputFormat>());
        }

        /// <summary>Validates that the <see cref="AVInputFormat" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVInputFormat).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVInputFormat" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(168, sizeof(AVInputFormat));
            }
            else
            {
                Assert.Equal(88, sizeof(AVInputFormat));
            }
        }
    }
}
