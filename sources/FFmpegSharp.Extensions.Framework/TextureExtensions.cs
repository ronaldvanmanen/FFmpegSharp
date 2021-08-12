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

using SDL2Sharp;
using SDL2Sharp.Interop;

namespace FFmpegSharp.Extensions.Framework
{
    public static class TextureExtensions
    {
        public static unsafe void Clear(this Texture texture)
        {
            var pixels = stackalloc byte*[4];
            var pitch = stackalloc int[4];
            var lockResult = SDL.LockTexture(texture, null, (void**)pixels, pitch);
            if (lockResult == 0)
            {
                SDL.memset(pixels[0], 0, (nuint)(texture.Height * pitch[0]));
                SDL.memset(pixels[1], 0, (nuint)(texture.Height * pitch[1]));
                SDL.memset(pixels[2], 0, (nuint)(texture.Height * pitch[2]));
                SDL.memset(pixels[3], 0, (nuint)(texture.Height * pitch[3]));
                SDL.UnlockTexture(texture);
            }
        }
    }
}
