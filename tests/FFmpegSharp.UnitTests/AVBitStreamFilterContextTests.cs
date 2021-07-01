using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVBitStreamFilterContext" /> struct.</summary>
    public static unsafe class AVBitStreamFilterContextTests
    {
        /// <summary>Validates that the <see cref="AVBitStreamFilterContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVBitStreamFilterContext), Marshal.SizeOf<AVBitStreamFilterContext>());
        }

        /// <summary>Validates that the <see cref="AVBitStreamFilterContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVBitStreamFilterContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVBitStreamFilterContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(40, sizeof(AVBitStreamFilterContext));
            }
            else
            {
                Assert.Equal(20, sizeof(AVBitStreamFilterContext));
            }
        }
    }
}
