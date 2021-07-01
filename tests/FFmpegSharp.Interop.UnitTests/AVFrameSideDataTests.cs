using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFrameSideData" /> struct.</summary>
    public static unsafe class AVFrameSideDataTests
    {
        /// <summary>Validates that the <see cref="AVFrameSideData" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFrameSideData), Marshal.SizeOf<AVFrameSideData>());
        }

        /// <summary>Validates that the <see cref="AVFrameSideData" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFrameSideData).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFrameSideData" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(40, sizeof(AVFrameSideData));
            }
            else
            {
                Assert.Equal(20, sizeof(AVFrameSideData));
            }
        }
    }
}
