using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVRational" /> struct.</summary>
    public static unsafe class AVRationalTests
    {
        /// <summary>Validates that the <see cref="AVRational" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVRational), Marshal.SizeOf<AVRational>());
        }

        /// <summary>Validates that the <see cref="AVRational" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVRational).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVRational" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(8, sizeof(AVRational));
        }
    }
}
