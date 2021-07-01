using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVIODirEntry" /> struct.</summary>
    public static unsafe class AVIODirEntryTests
    {
        /// <summary>Validates that the <see cref="AVIODirEntry" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVIODirEntry), Marshal.SizeOf<AVIODirEntry>());
        }

        /// <summary>Validates that the <see cref="AVIODirEntry" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVIODirEntry).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVIODirEntry" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(72, sizeof(AVIODirEntry));
        }
    }
}
