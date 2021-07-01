using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilterInOut" /> struct.</summary>
    public static unsafe class AVFilterInOutTests
    {
        /// <summary>Validates that the <see cref="AVFilterInOut" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFilterInOut), Marshal.SizeOf<AVFilterInOut>());
        }

        /// <summary>Validates that the <see cref="AVFilterInOut" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFilterInOut).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFilterInOut" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(32, sizeof(AVFilterInOut));
            }
            else
            {
                Assert.Equal(16, sizeof(AVFilterInOut));
            }
        }
    }
}
