using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="MpegEncContext" /> struct.</summary>
    public static unsafe class MpegEncContextTests
    {
        /// <summary>Validates that the <see cref="MpegEncContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(MpegEncContext), Marshal.SizeOf<MpegEncContext>());
        }

        /// <summary>Validates that the <see cref="MpegEncContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(MpegEncContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="MpegEncContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(MpegEncContext));
        }
    }
}
