using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilterGraphInternal" /> struct.</summary>
    public static unsafe class AVFilterGraphInternalTests
    {
        /// <summary>Validates that the <see cref="AVFilterGraphInternal" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFilterGraphInternal), Marshal.SizeOf<AVFilterGraphInternal>());
        }

        /// <summary>Validates that the <see cref="AVFilterGraphInternal" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFilterGraphInternal).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFilterGraphInternal" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVFilterGraphInternal));
        }
    }
}
