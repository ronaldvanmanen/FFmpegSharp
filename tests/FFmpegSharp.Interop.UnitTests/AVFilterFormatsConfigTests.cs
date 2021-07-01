using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilterFormatsConfig" /> struct.</summary>
    public static unsafe class AVFilterFormatsConfigTests
    {
        /// <summary>Validates that the <see cref="AVFilterFormatsConfig" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFilterFormatsConfig), Marshal.SizeOf<AVFilterFormatsConfig>());
        }

        /// <summary>Validates that the <see cref="AVFilterFormatsConfig" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFilterFormatsConfig).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFilterFormatsConfig" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(24, sizeof(AVFilterFormatsConfig));
            }
            else
            {
                Assert.Equal(12, sizeof(AVFilterFormatsConfig));
            }
        }
    }
}
