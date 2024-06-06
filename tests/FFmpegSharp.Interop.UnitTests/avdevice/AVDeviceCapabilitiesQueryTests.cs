// Copyright (c) 2021-2023 Ronald van Manen
//
// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with FFmpegSharp; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA

using System;
using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="AVDeviceCapabilitiesQuery" /> struct.</summary>
    public static unsafe partial class AVDeviceCapabilitiesQueryTests
    {
        /// <summary>Validates that the <see cref="AVDeviceCapabilitiesQuery" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(AVDeviceCapabilitiesQuery), Marshal.SizeOf<AVDeviceCapabilitiesQuery>());
        }

        /// <summary>Validates that the <see cref="AVDeviceCapabilitiesQuery" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(AVDeviceCapabilitiesQuery).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="AVDeviceCapabilitiesQuery" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal(72, sizeof(AVDeviceCapabilitiesQuery));
            }
            else
            {
                Assert.Equal(64, sizeof(AVDeviceCapabilitiesQuery));
            }
        }
    }
}
