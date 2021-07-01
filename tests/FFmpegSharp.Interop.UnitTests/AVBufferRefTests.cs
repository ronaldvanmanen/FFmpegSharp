using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVBufferRef" /> struct.</summary>
    public static unsafe class AVBufferRefTests
    {
        /// <summary>Validates that the <see cref="AVBufferRef" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVBufferRef), Marshal.SizeOf<AVBufferRef>());
        }

        /// <summary>Validates that the <see cref="AVBufferRef" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVBufferRef).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVBufferRef" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(24, sizeof(AVBufferRef));
            }
            else
            {
                Assert.Equal(12, sizeof(AVBufferRef));
            }
        }
    }
}
