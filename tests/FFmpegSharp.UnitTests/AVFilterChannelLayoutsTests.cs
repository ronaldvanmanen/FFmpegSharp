using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilterChannelLayouts" /> struct.</summary>
    public static unsafe class AVFilterChannelLayoutsTests
    {
        /// <summary>Validates that the <see cref="AVFilterChannelLayouts" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFilterChannelLayouts), Marshal.SizeOf<AVFilterChannelLayouts>());
        }

        /// <summary>Validates that the <see cref="AVFilterChannelLayouts" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFilterChannelLayouts).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFilterChannelLayouts" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVFilterChannelLayouts));
        }
    }
}
