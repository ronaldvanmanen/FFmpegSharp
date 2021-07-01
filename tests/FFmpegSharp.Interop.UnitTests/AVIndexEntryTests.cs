using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVIndexEntry" /> struct.</summary>
    public static unsafe class AVIndexEntryTests
    {
        /// <summary>Validates that the <see cref="AVIndexEntry" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVIndexEntry), Marshal.SizeOf<AVIndexEntry>());
        }

        /// <summary>Validates that the <see cref="AVIndexEntry" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVIndexEntry).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVIndexEntry" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(AVIndexEntry));
        }
    }
}
