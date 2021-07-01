using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVCodecDescriptor" /> struct.</summary>
    public static unsafe class AVCodecDescriptorTests
    {
        /// <summary>Validates that the <see cref="AVCodecDescriptor" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCodecDescriptor), Marshal.SizeOf<AVCodecDescriptor>());
        }

        /// <summary>Validates that the <see cref="AVCodecDescriptor" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCodecDescriptor).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCodecDescriptor" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(48, sizeof(AVCodecDescriptor));
            }
            else
            {
                Assert.Equal(28, sizeof(AVCodecDescriptor));
            }
        }

        /// <summary>Provides validation of the <see cref="AVCodecDescriptor.AVProfile" /> struct.</summary>
        public static unsafe class AVProfileTests
        {
            /// <summary>Validates that the <see cref="AVCodecDescriptor.AVProfile" /> struct is blittable.</summary>
            [Fact]
            public static void IsBlittableTest()
            {
                Assert.Equal(sizeof(AVCodecDescriptor.AVProfile), Marshal.SizeOf<AVCodecDescriptor.AVProfile>());
            }

            /// <summary>Validates that the <see cref="AVCodecDescriptor.AVProfile" /> struct has the right <see cref="LayoutKind" />.</summary>
            [Fact]
            public static void IsLayoutSequentialTest()
            {
                Assert.True(typeof(AVCodecDescriptor.AVProfile).IsLayoutSequential);
            }

            /// <summary>Validates that the <see cref="AVCodecDescriptor.AVProfile" /> struct has the correct size.</summary>
            [Fact]
            public static void SizeOfTest()
            {
                Assert.Equal(1, sizeof(AVCodecDescriptor.AVProfile));
            }
        }
    }
}
