using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilterGraph" /> struct.</summary>
    public static unsafe class AVFilterGraphTests
    {
        /// <summary>Validates that the <see cref="AVFilterGraph" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFilterGraph), Marshal.SizeOf<AVFilterGraph>());
        }

        /// <summary>Validates that the <see cref="AVFilterGraph" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFilterGraph).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFilterGraph" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(96, sizeof(AVFilterGraph));
            }
            else
            {
                Assert.Equal(56, sizeof(AVFilterGraph));
            }
        }
    }
}
