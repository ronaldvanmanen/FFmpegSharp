using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilterLink" /> struct.</summary>
    public static unsafe class AVFilterLinkTests
    {
        /// <summary>Validates that the <see cref="AVFilterLink" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFilterLink), Marshal.SizeOf<AVFilterLink>());
        }

        /// <summary>Validates that the <see cref="AVFilterLink" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFilterLink).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFilterLink" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(61680, sizeof(AVFilterLink));
            }
            else
            {
                Assert.Equal(61616, sizeof(AVFilterLink));
            }
        }
    }
}
