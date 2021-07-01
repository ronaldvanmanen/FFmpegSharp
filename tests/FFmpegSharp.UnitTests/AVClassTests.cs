using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVClass" /> struct.</summary>
    public static unsafe class AVClassTests
    {
        /// <summary>Validates that the <see cref="AVClass" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVClass), Marshal.SizeOf<AVClass>());
        }

        /// <summary>Validates that the <see cref="AVClass" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVClass).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVClass" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(88, sizeof(AVClass));
            }
            else
            {
                Assert.Equal(48, sizeof(AVClass));
            }
        }

        /// <summary>Provides validation of the <see cref="AVClass.AVOption" /> struct.</summary>
        public static unsafe class AVOptionTests
        {
            /// <summary>Validates that the <see cref="AVClass.AVOption" /> struct is blittable.</summary>
            [Fact]
            public static void IsBlittableTest()
            {
                Assert.Equal(sizeof(AVClass.AVOption), Marshal.SizeOf<AVClass.AVOption>());
            }

            /// <summary>Validates that the <see cref="AVClass.AVOption" /> struct has the right <see cref="LayoutKind" />.</summary>
            [Fact]
            public static void IsLayoutSequentialTest()
            {
                Assert.True(typeof(AVClass.AVOption).IsLayoutSequential);
            }

            /// <summary>Validates that the <see cref="AVClass.AVOption" /> struct has the correct size.</summary>
            [Fact]
            public static void SizeOfTest()
            {
                Assert.Equal(1, sizeof(AVClass.AVOption));
            }
        }
    }
}
