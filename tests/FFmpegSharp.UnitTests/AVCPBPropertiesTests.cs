using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVCPBProperties" /> struct.</summary>
    public static unsafe class AVCPBPropertiesTests
    {
        /// <summary>Validates that the <see cref="AVCPBProperties" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCPBProperties), Marshal.SizeOf<AVCPBProperties>());
        }

        /// <summary>Validates that the <see cref="AVCPBProperties" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCPBProperties).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCPBProperties" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(24, sizeof(AVCPBProperties));
        }
    }
}
