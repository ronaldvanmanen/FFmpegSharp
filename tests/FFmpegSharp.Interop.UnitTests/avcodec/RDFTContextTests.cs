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

using System.Runtime.InteropServices;
using Xunit;

namespace FFmpegSharp.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="RDFTContext" /> struct.</summary>
    public static unsafe partial class RDFTContextTests
    {
        /// <summary>Validates that the <see cref="RDFTContext" /> struct is blittable.</summary>
        [Fact]
        public static void IsBlittableTest()
        {
            Assert.Equal(sizeof(RDFTContext), Marshal.SizeOf<RDFTContext>());
        }

        /// <summary>Validates that the <see cref="RDFTContext" /> struct has the right <see cref="LayoutKind" />.</summary>
        [Fact]
        public static void IsLayoutSequentialTest()
        {
            Assert.True(typeof(RDFTContext).IsLayoutSequential);
        }

        /// <summary>Validates that the <see cref="RDFTContext" /> struct has the correct size.</summary>
        [Fact]
        public static void SizeOfTest()
        {
            Assert.Equal(1, sizeof(RDFTContext));
        }
    }
}
