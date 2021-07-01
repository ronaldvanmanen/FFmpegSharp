using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVHWFramesConstraints" /> struct.</summary>
    public static unsafe class AVHWFramesConstraintsTests
    {
        /// <summary>Validates that the <see cref="AVHWFramesConstraints" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVHWFramesConstraints), Marshal.SizeOf<AVHWFramesConstraints>());
        }

        /// <summary>Validates that the <see cref="AVHWFramesConstraints" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVHWFramesConstraints).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVHWFramesConstraints" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(32, sizeof(AVHWFramesConstraints));
            }
            else
            {
                Assert.Equal(24, sizeof(AVHWFramesConstraints));
            }
        }
    }
}
