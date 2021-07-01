using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVPixFmtDescriptor" /> struct.</summary>
    public static unsafe class AVPixFmtDescriptorTests
    {
        /// <summary>Validates that the <see cref="AVPixFmtDescriptor" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVPixFmtDescriptor), Marshal.SizeOf<AVPixFmtDescriptor>());
        }

        /// <summary>Validates that the <see cref="AVPixFmtDescriptor" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVPixFmtDescriptor).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVPixFmtDescriptor" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(160, sizeof(AVPixFmtDescriptor));
            }
            else
            {
                Assert.Equal(152, sizeof(AVPixFmtDescriptor));
            }
        }
    }
}
