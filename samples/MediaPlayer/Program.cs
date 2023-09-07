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
using FFmpegSharp;
using SDL2Sharp.Interop;

namespace MediaPlayer
{
    public static class Program
    {
        [STAThread]
        public static int Main()
        {
            try
            {
                SDL.Init(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_AUDIO | SDL.SDL_INIT_TIMER | SDL.SDL_INIT_EVENTS);
                AVDevice.RegisterAll();
                AVFormat.NetworkInit();

                var application = new App();
                var exitCode = application.Run();
                return exitCode;
            }
            finally
            {
                AVFormat.NetworkDeinit();

                SDL.Quit();
            }
        }
    }
}
