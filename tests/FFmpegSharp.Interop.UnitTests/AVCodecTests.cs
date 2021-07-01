using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVCodec" /> struct.</summary>
    public static unsafe class AVCodecTests
    {
        /// <summary>Validates that the <see cref="AVCodec" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCodec), Marshal.SizeOf<AVCodec>());
        }

        /// <summary>Validates that the <see cref="AVCodec" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCodec).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCodec" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(240, sizeof(AVCodec));
            }
            else
            {
                Assert.Equal(124, sizeof(AVCodec));
            }
        }

        /// <summary>Provides validation of the <see cref="AVCodec.AVCodecHWConfigInternal" /> struct.</summary>
        public static unsafe class AVCodecHWConfigInternalTests
        {
            /// <summary>Validates that the <see cref="AVCodec.AVCodecHWConfigInternal" /> struct is blittable.</summary>
            [Fact]
            public static void IsBlittableTest()
            {
                Assert.Equal(sizeof(AVCodec.AVCodecHWConfigInternal), Marshal.SizeOf<AVCodec.AVCodecHWConfigInternal>());
            }

            /// <summary>Validates that the <see cref="AVCodec.AVCodecHWConfigInternal" /> struct has the right <see cref="LayoutKind" />.</summary>
            [Fact]
            public static void IsLayoutSequentialTest()
            {
                Assert.True(typeof(AVCodec.AVCodecHWConfigInternal).IsLayoutSequential);
            }

            /// <summary>Validates that the <see cref="AVCodec.AVCodecHWConfigInternal" /> struct has the correct size.</summary>
            [Fact]
            public static void SizeOfTest()
            {
                Assert.Equal(1, sizeof(AVCodec.AVCodecHWConfigInternal));
            }
        }
    }
}
