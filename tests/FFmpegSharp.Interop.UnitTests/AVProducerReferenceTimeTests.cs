using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVProducerReferenceTime" /> struct.</summary>
    public static unsafe class AVProducerReferenceTimeTests
    {
        /// <summary>Validates that the <see cref="AVProducerReferenceTime" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVProducerReferenceTime), Marshal.SizeOf<AVProducerReferenceTime>());
        }

        /// <summary>Validates that the <see cref="AVProducerReferenceTime" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVProducerReferenceTime).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVProducerReferenceTime" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(16, sizeof(AVProducerReferenceTime));
        }
    }
}
