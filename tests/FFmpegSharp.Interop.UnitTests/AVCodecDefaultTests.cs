using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVCodecDefault" /> struct.</summary>
    public static unsafe class AVCodecDefaultTests
    {
        /// <summary>Validates that the <see cref="AVCodecDefault" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCodecDefault), Marshal.SizeOf<AVCodecDefault>());
        }

        /// <summary>Validates that the <see cref="AVCodecDefault" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCodecDefault).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCodecDefault" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVCodecDefault));
        }
    }
}
