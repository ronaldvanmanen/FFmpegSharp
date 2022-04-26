// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with FFmpegSharp.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVFilterContext" /> struct.</summary>
    public static unsafe partial class AVFilterContextTests
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

        /// <summary>Provides validation of the <see cref="AVFilterCommand" /> struct.</summary>
        public static unsafe partial class AVFilterCommandTests
        {
            /// <summary>Validates that the <see cref="AVFilterCommand" /> struct is blittable.</summary>
            [Fact]
            public static void IsBlittableTest()
            {
                Assert.Equal(sizeof(AVFilterCommand), Marshal.SizeOf<AVFilterCommand>());
            }

            /// <summary>Validates that the <see cref="AVFilterCommand" /> struct has the right <see cref="LayoutKind" />.</summary>
            [Fact]
            public static void IsLayoutSequentialTest()
            {
                Assert.True(typeof(AVFilterCommand).IsLayoutSequential);
            }

            /// <summary>Validates that the <see cref="AVFilterCommand" /> struct has the correct size.</summary>
            [Fact]
            public static void SizeOfTest()
            {
                Assert.Equal(1, sizeof(AVFilterCommand));
            }
        }
    }
}
