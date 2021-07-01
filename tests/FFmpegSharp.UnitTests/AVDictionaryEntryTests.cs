using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVDictionaryEntry" /> struct.</summary>
    public static unsafe class AVDictionaryEntryTests
    {
        /// <summary>Validates that the <see cref="AVDictionaryEntry" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVDictionaryEntry), Marshal.SizeOf<AVDictionaryEntry>());
        }

        /// <summary>Validates that the <see cref="AVDictionaryEntry" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVDictionaryEntry).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVDictionaryEntry" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(16, sizeof(AVDictionaryEntry));
            }
            else
            {
                Assert.Equal(8, sizeof(AVDictionaryEntry));
            }
        }
    }
}
