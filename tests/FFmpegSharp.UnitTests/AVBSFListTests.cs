using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVBSFList" /> struct.</summary>
    public static unsafe class AVBSFListTests
    {
        /// <summary>Validates that the <see cref="AVBSFList" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVBSFList), Marshal.SizeOf<AVBSFList>());
        }

        /// <summary>Validates that the <see cref="AVBSFList" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVBSFList).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVBSFList" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVBSFList));
        }
    }
}
