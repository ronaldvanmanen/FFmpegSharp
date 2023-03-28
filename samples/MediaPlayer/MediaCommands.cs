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

using System.Windows.Input;

namespace MediaPlayer
{
    /// <summary>
    ///     Defines all media related commands.
    /// </summary>
    public static class MediaCommands
    {
        /// <summary>
        ///     Initializes the <see cref="MediaPlayer"/> class.
        /// </summary>
        static MediaCommands()
        {
            Play = new RoutedCommand(nameof(Play), typeof(MediaCommands));
            Stop = new RoutedCommand(nameof(Stop), typeof(MediaCommands));
            Pause = new RoutedCommand(nameof(Pause), typeof(MediaCommands));
            StepForward = new RoutedCommand(nameof(StepForward), typeof(MediaCommands));
            StepBackward = new RoutedCommand(nameof(StepBackward), typeof(MediaCommands));
            FastForward = new RoutedCommand(nameof(FastForward), typeof(MediaCommands));
            FastBackward = new RoutedCommand(nameof(FastBackward), typeof(MediaCommands));
        }

        /// <summary>
        ///     Gets the command that signals the <see cref="MediaPlayer"/> to start playing.
        /// </summary>
        public static RoutedCommand Play { get; }

        /// <summary>
        ///     Gets the command that signals the <see cref="MediaPlayer"/> to stop playing.
        /// </summary>
        public static RoutedCommand Stop { get; }

        /// <summary>
        ///     Gets the command that signals the <see cref="MediaPlayer"/> to pause playing.
        /// </summary>
        public static RoutedCommand Pause { get; }

        /// <summary>
        ///     Gets the command that signals the <see cref="MediaPlayer"/> to skip to the next frame.
        /// </summary>
        public static RoutedCommand StepForward { get; }

        /// <summary>
        ///     Gets the command that signals the <see cref="MediaPlayer"/> to skip to the next frame.
        /// </summary>
        public static RoutedCommand StepBackward { get; }

        /// <summary>
        ///     Gets the command that signals the <see cref="MediaPlayer"/> to skip to the next frame.
        /// </summary>
        public static RoutedCommand FastForward { get; }

        /// <summary>
        ///     Gets the command that signals the <see cref="MediaPlayer"/> to skip to the next frame.
        /// </summary>
        public static RoutedCommand FastBackward { get; }
    }
}
