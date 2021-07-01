using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVComponentDescriptor" /> struct.</summary>
    public static unsafe class AVComponentDescriptorTests
    {
        /// <summary>Validates that the <see cref="AVComponentDescriptor" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVComponentDescriptor), Marshal.SizeOf<AVComponentDescriptor>());
        }

        /// <summary>Validates that the <see cref="AVComponentDescriptor" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVComponentDescriptor).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVComponentDescriptor" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(32, sizeof(AVComponentDescriptor));
        }
    }
}
