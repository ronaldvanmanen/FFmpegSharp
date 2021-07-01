using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVBufferSinkParams" /> struct.</summary>
    public static unsafe class AVBufferSinkParamsTests
    {
        /// <summary>Validates that the <see cref="AVBufferSinkParams" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVBufferSinkParams), Marshal.SizeOf<AVBufferSinkParams>());
        }

        /// <summary>Validates that the <see cref="AVBufferSinkParams" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVBufferSinkParams).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVBufferSinkParams" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(8, sizeof(AVBufferSinkParams));
            }
            else
            {
                Assert.Equal(4, sizeof(AVBufferSinkParams));
            }
        }
    }
}
