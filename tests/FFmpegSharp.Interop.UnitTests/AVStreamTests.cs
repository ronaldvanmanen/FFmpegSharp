using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVStream" /> struct.</summary>
    public static unsafe class AVStreamTests
    {
        /// <summary>Validates that the <see cref="AVStream" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVStream), Marshal.SizeOf<AVStream>());
        }

        /// <summary>Validates that the <see cref="AVStream" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVStream).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVStream" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(496, sizeof(AVStream));
            }
            else
            {
                Assert.Equal(424, sizeof(AVStream));
            }
        }
    }
}
