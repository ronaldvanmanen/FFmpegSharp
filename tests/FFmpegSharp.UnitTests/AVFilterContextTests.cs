using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilterContext" /> struct.</summary>
    public static unsafe class AVFilterContextTests
    {
        /// <summary>Validates that the <see cref="AVFilterContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVFilterContext), Marshal.SizeOf<AVFilterContext>());
        }

        /// <summary>Validates that the <see cref="AVFilterContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVFilterContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVFilterContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(168, sizeof(AVFilterContext));
            }
            else
            {
                Assert.Equal(88, sizeof(AVFilterContext));
            }
        }

        /// <summary>Provides validation of the <see cref="AVFilterContext.AVFilterCommand" /> struct.</summary>
        public static unsafe class AVFilterCommandTests
        {
            /// <summary>Validates that the <see cref="AVFilterContext.AVFilterCommand" /> struct is blittable.</summary>
            [Fact]
            public static void IsBlittableTest()
            {
                Assert.Equal(sizeof(AVFilterContext.AVFilterCommand), Marshal.SizeOf<AVFilterContext.AVFilterCommand>());
            }

            /// <summary>Validates that the <see cref="AVFilterContext.AVFilterCommand" /> struct has the right <see cref="LayoutKind" />.</summary>
            [Fact]
            public static void IsLayoutSequentialTest()
            {
                Assert.True(typeof(AVFilterContext.AVFilterCommand).IsLayoutSequential);
            }

            /// <summary>Validates that the <see cref="AVFilterContext.AVFilterCommand" /> struct has the correct size.</summary>
            [Fact]
            public static void SizeOfTest()
            {
                Assert.Equal(1, sizeof(AVFilterContext.AVFilterCommand));
            }
        }
    }
}
