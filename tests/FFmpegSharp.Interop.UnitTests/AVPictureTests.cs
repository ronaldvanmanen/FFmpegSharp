using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVPicture" /> struct.</summary>
    public static unsafe class AVPictureTests
    {
        /// <summary>Validates that the <see cref="AVPicture" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVPicture), Marshal.SizeOf<AVPicture>());
        }

        /// <summary>Validates that the <see cref="AVPicture" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVPicture).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVPicture" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(96, sizeof(AVPicture));
            }
            else
            {
                Assert.Equal(64, sizeof(AVPicture));
            }
        }
    }
}
