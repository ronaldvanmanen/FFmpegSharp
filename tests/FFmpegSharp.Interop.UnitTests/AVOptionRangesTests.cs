using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVOptionRanges" /> struct.</summary>
    public static unsafe class AVOptionRangesTests
    {
        /// <summary>Validates that the <see cref="AVOptionRanges" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVOptionRanges), Marshal.SizeOf<AVOptionRanges>());
        }

        /// <summary>Validates that the <see cref="AVOptionRanges" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVOptionRanges).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVOptionRanges" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(16, sizeof(AVOptionRanges));
            }
            else
            {
                Assert.Equal(12, sizeof(AVOptionRanges));
            }
        }
    }
}
