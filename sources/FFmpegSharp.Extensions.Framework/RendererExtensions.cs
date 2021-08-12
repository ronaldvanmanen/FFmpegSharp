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
using SDL2Sharp;

namespace FFmpegSharp.Extensions.Framework
{
    public static class RendererExtensions
    {
        public static void DrawVideo(this Renderer renderer, VideoRenderer videoRenderer)
        {
            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            if (videoRenderer is null)
            {
                throw new ArgumentNullException(nameof(videoRenderer));
            }

            videoRenderer.DrawVideo(renderer);
        }

        public static void DrawVideo(this Renderer renderer, VideoRenderer videoRenderer, bool forceRefresh)
        {
            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            if (videoRenderer is null)
            {
                throw new ArgumentNullException(nameof(videoRenderer));
            }

            videoRenderer.DrawVideo(renderer, forceRefresh);
        }

        public static Texture CreateOrReuseTexture(this Renderer renderer, Texture texture, TextureAccess access, PixelFormatEnum format, int width, int height, BlendMode blendMode)
        {
            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            if (texture != null)
            {
                if (texture.IsValid &&
                    texture.Format == format &&
                    texture.Width == width &&
                    texture.Height == height)
                {
                    return texture;
                }
                else
                {
                    texture.Dispose();
                }
            }

            return renderer.CreateTexture(access, format, width, height, blendMode);
        }

        public static Texture CreateTexture(this Renderer renderer, TextureAccess access, PixelFormatEnum format, int width, int height, BlendMode blendMode)
        {
            if (renderer is null)
            {
                throw new ArgumentNullException(nameof(renderer));
            }

            var requestedTexture = renderer.CreateTexture(format, access, width, height);
            requestedTexture.BlendMode = blendMode;
            return requestedTexture;
        }
    }
}
