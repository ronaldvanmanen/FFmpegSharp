using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilterFormats" /> struct.</summary>
    public static unsafe class AVFilterFormatsTests
    {
        /// <summary>Validates that the <see cref="AVFilterFormats" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFilterFormats), Marshal.SizeOf<AVFilterFormats>());
        }

        /// <summary>Validates that the <see cref="AVFilterFormats" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFilterFormats).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFilterFormats" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVFilterFormats));
        }
    }
}
