using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVBSFInternal" /> struct.</summary>
    public static unsafe class AVBSFInternalTests
    {
        /// <summary>Validates that the <see cref="AVBSFInternal" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVBSFInternal), Marshal.SizeOf<AVBSFInternal>());
        }

        /// <summary>Validates that the <see cref="AVBSFInternal" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVBSFInternal).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVBSFInternal" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVBSFInternal));
        }
    }
}
