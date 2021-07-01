using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFormatInternal" /> struct.</summary>
    public static unsafe class AVFormatInternalTests
    {
        /// <summary>Validates that the <see cref="AVFormatInternal" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFormatInternal), Marshal.SizeOf<AVFormatInternal>());
        }

        /// <summary>Validates that the <see cref="AVFormatInternal" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFormatInternal).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFormatInternal" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVFormatInternal));
        }
    }
}
