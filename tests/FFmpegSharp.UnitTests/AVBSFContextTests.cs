using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVBSFContext" /> struct.</summary>
    public static unsafe class AVBSFContextTests
    {
        /// <summary>Validates that the <see cref="AVBSFContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVBSFContext), Marshal.SizeOf<AVBSFContext>());
        }

        /// <summary>Validates that the <see cref="AVBSFContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVBSFContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVBSFContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(64, sizeof(AVBSFContext));
            }
            else
            {
                Assert.Equal(40, sizeof(AVBSFContext));
            }
        }
    }
}
