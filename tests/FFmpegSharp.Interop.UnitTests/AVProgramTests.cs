using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVProgram" /> struct.</summary>
    public static unsafe class AVProgramTests
    {
        /// <summary>Validates that the <see cref="AVProgram" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVProgram), Marshal.SizeOf<AVProgram>());
        }

        /// <summary>Validates that the <see cref="AVProgram" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVProgram).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVProgram" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(88, sizeof(AVProgram));
            }
            else
            {
                Assert.Equal(72, sizeof(AVProgram));
            }
        }
    }
}
