using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilterPad" /> struct.</summary>
    public static unsafe class AVFilterPadTests
    {
        /// <summary>Validates that the <see cref="AVFilterPad" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFilterPad), Marshal.SizeOf<AVFilterPad>());
        }

        /// <summary>Validates that the <see cref="AVFilterPad" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFilterPad).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFilterPad" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVFilterPad));
        }
    }
}
