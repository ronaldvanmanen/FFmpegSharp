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

                AVCodec.RegisterAll();
                AVDevice.RegisterAll();
                AVFilter.RegisterAll();
                AVFormat.RegisterAll();
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
