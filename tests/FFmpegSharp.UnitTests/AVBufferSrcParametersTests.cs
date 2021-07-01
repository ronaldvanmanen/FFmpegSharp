using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVBufferSrcParameters" /> struct.</summary>
    public static unsafe class AVBufferSrcParametersTests
    {
        /// <summary>Validates that the <see cref="AVBufferSrcParameters" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVBufferSrcParameters), Marshal.SizeOf<AVBufferSrcParameters>());
        }

        /// <summary>Validates that the <see cref="AVBufferSrcParameters" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVBufferSrcParameters).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVBufferSrcParameters" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(64, sizeof(AVBufferSrcParameters));
            }
            else
            {
                Assert.Equal(56, sizeof(AVBufferSrcParameters));
            }
        }
    }
}
