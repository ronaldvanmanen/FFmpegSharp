using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVChapter" /> struct.</summary>
    public static unsafe class AVChapterTests
    {
        /// <summary>Validates that the <see cref="AVChapter" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVChapter), Marshal.SizeOf<AVChapter>());
        }

        /// <summary>Validates that the <see cref="AVChapter" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVChapter).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVChapter" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(40, sizeof(AVChapter));
        }
    }
}
