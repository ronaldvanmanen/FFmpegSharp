using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVCodecTag" /> struct.</summary>
    public static unsafe class AVCodecTagTests
    {
        /// <summary>Validates that the <see cref="AVCodecTag" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCodecTag), Marshal.SizeOf<AVCodecTag>());
        }

        /// <summary>Validates that the <see cref="AVCodecTag" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCodecTag).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCodecTag" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVCodecTag));
        }
    }
}
