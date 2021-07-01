using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVABufferSinkParams" /> struct.</summary>
    public static unsafe class AVABufferSinkParamsTests
    {
        /// <summary>Validates that the <see cref="AVABufferSinkParams" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVABufferSinkParams), Marshal.SizeOf<AVABufferSinkParams>());
        }

        /// <summary>Validates that the <see cref="AVABufferSinkParams" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVABufferSinkParams).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVABufferSinkParams" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(40, sizeof(AVABufferSinkParams));
            }
            else
            {
                Assert.Equal(20, sizeof(AVABufferSinkParams));
            }
        }
    }
}
