using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVDictionary" /> struct.</summary>
    public static unsafe class AVDictionaryTests
    {
        /// <summary>Validates that the <see cref="AVDictionary" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVDictionary), Marshal.SizeOf<AVDictionary>());
        }

        /// <summary>Validates that the <see cref="AVDictionary" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVDictionary).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVDictionary" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(AVDictionary));
        }
    }
}
