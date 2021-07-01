using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVOption" /> struct.</summary>
    public static unsafe class AVOptionTests
    {
        /// <summary>Validates that the <see cref="AVOption" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVOption), Marshal.SizeOf<AVOption>());
        }

        /// <summary>Validates that the <see cref="AVOption" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVOption).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVOption" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(64, sizeof(AVOption));
            }
            else
            {
                Assert.Equal(48, sizeof(AVOption));
            }
        }
    }
}
