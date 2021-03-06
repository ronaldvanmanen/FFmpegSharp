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
    /// <summary>Provides validation of the <see cref="AVClass" /> struct.</summary>
    public static unsafe partial class AVClassTests
    {
        /// <summary>Validates that the <see cref="AVClass" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVClass), Marshal.SizeOf<AVClass>());
        }

        /// <summary>Validates that the <see cref="AVClass" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVClass).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVClass" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(88, sizeof(AVClass));
            }
            else
            {
                Assert.Equal(48, sizeof(AVClass));
            }
        }

        /// <summary>Provides validation of the <see cref="AVOption" /> struct.</summary>
        public static unsafe partial class AVOptionTests
        {
            /// <summary>Validates that the <see cref="AVOption" /> struct is blittable.</summary>
            [Fact]
            public static void IsBlittableTest()
            {
                Assert.Equal(sizeof(AVOption), Marshal.SizeOf<AVOption>());
            }

            /// <summary>Validates that the <see cref="AVOption" /> struct has the right <see cref="LayoutKind" />.</summary>
            [Fact]
            public static void IsLayoutSequentialTest()
            {
                Assert.True(typeof(AVOption).IsLayoutSequential);
            }

            /// <summary>Validates that the <see cref="AVOption" /> struct has the correct size.</summary>
            [Fact]
            public static void SizeOfTest()
            {
                Assert.Equal(64, sizeof(AVOption));
            }
        }
    }
}
