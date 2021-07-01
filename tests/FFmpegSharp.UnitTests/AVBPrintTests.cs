using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVBPrint" /> struct.</summary>
    public static unsafe class AVBPrintTests
    {
        /// <summary>Validates that the <see cref="AVBPrint" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVBPrint), Marshal.SizeOf<AVBPrint>());
        }

        /// <summary>Validates that the <see cref="AVBPrint" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVBPrint).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVBPrint" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVBPrint));
        }
    }
}
