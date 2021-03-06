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
    /// <summary>Provides validation of the <see cref="AVCodecDescriptor" /> struct.</summary>
    public static unsafe partial class AVCodecDescriptorTests
    {
        /// <summary>Validates that the <see cref="AVCodecDescriptor" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVCodecDescriptor), Marshal.SizeOf<AVCodecDescriptor>());
        }

        /// <summary>Validates that the <see cref="AVCodecDescriptor" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVCodecDescriptor).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVCodecDescriptor" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(48, sizeof(AVCodecDescriptor));
            }
            else
            {
                Assert.Equal(28, sizeof(AVCodecDescriptor));
            }
        }

        /// <summary>Provides validation of the <see cref="AVProfile" /> struct.</summary>
        public static unsafe partial class AVProfileTests
        {
            /// <summary>Validates that the <see cref="AVProfile" /> struct is blittable.</summary>
            [Fact]
            public static void IsBlittableTest()
            {
                Assert.Equal(sizeof(AVProfile), Marshal.SizeOf<AVProfile>());
            }

            /// <summary>Validates that the <see cref="AVProfile" /> struct has the right <see cref="LayoutKind" />.</summary>
            [Fact]
            public static void IsLayoutSequentialTest()
            {
                Assert.True(typeof(AVProfile).IsLayoutSequential);
            }

            /// <summary>Validates that the <see cref="AVProfile" /> struct has the correct size.</summary>
            [Fact]
            public static void SizeOfTest()
            {
                Assert.Equal(16, sizeof(AVProfile));
            }
        }
    }
}
