using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVOptionRange" /> struct.</summary>
    public static unsafe class AVOptionRangeTests
    {
        /// <summary>Validates that the <see cref="AVOptionRange" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVOptionRange), Marshal.SizeOf<AVOptionRange>());
        }

        /// <summary>Validates that the <see cref="AVOptionRange" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVOptionRange).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVOptionRange" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(48, sizeof(AVOptionRange));
        }
    }
}
