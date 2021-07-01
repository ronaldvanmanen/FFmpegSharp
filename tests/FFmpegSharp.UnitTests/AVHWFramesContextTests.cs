using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVHWFramesContext" /> struct.</summary>
    public static unsafe class AVHWFramesContextTests
    {
        /// <summary>Validates that the <see cref="AVHWFramesContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVHWFramesContext), Marshal.SizeOf<AVHWFramesContext>());
        }

        /// <summary>Validates that the <see cref="AVHWFramesContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVHWFramesContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVHWFramesContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(88, sizeof(AVHWFramesContext));
            }
            else
            {
                Assert.Equal(52, sizeof(AVHWFramesContext));
            }
        }
    }
}
