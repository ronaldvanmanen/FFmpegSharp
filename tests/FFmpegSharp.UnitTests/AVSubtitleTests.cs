using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVSubtitle" /> struct.</summary>
    public static unsafe class AVSubtitleTests
    {
        /// <summary>Validates that the <see cref="AVSubtitle" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVSubtitle), Marshal.SizeOf<AVSubtitle>());
        }

        /// <summary>Validates that the <see cref="AVSubtitle" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVSubtitle).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVSubtitle" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(32, sizeof(AVSubtitle));
        }
    }
}
