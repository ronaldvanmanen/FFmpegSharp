using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVIODirContext" /> struct.</summary>
    public static unsafe class AVIODirContextTests
    {
        /// <summary>Validates that the <see cref="AVIODirContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVIODirContext), Marshal.SizeOf<AVIODirContext>());
        }

        /// <summary>Validates that the <see cref="AVIODirContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVIODirContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVIODirContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(8, sizeof(AVIODirContext));
            }
            else
            {
                Assert.Equal(4, sizeof(AVIODirContext));
            }
        }

        /// <summary>Provides validation of the <see cref="AVIODirContext.URLContext" /> struct.</summary>
        public static unsafe class URLContextTests
        {
            /// <summary>Validates that the <see cref="AVIODirContext.URLContext" /> struct is blittable.</summary>
            [Fact]
            public static void IsBlittableTest()
            {
                Assert.Equal(sizeof(AVIODirContext.URLContext), Marshal.SizeOf<AVIODirContext.URLContext>());
            }

            /// <summary>Validates that the <see cref="AVIODirContext.URLContext" /> struct has the right <see cref="LayoutKind" />.</summary>
            [Fact]
            public static void IsLayoutSequentialTest()
            {
                Assert.True(typeof(AVIODirContext.URLContext).IsLayoutSequential);
            }

            /// <summary>Validates that the <see cref="AVIODirContext.URLContext" /> struct has the correct size.</summary>
            [Fact]
            public static void SizeOfTest()
            {
                Assert.Equal(1, sizeof(AVIODirContext.URLContext));
            }
        }
    }
}
