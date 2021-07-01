using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVStreamInternal" /> struct.</summary>
    public static unsafe class AVStreamInternalTests
    {
        /// <summary>Validates that the <see cref="AVStreamInternal" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVStreamInternal), Marshal.SizeOf<AVStreamInternal>());
        }

        /// <summary>Validates that the <see cref="AVStreamInternal" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVStreamInternal).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVStreamInternal" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVStreamInternal));
        }
    }
}
