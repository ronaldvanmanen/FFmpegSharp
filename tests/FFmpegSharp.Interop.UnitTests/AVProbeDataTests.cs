using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVProbeData" /> struct.</summary>
    public static unsafe class AVProbeDataTests
    {
        /// <summary>Validates that the <see cref="AVProbeData" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVProbeData), Marshal.SizeOf<AVProbeData>());
        }

        /// <summary>Validates that the <see cref="AVProbeData" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVProbeData).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVProbeData" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(32, sizeof(AVProbeData));
            }
            else
            {
                Assert.Equal(16, sizeof(AVProbeData));
            }
        }
    }
}
