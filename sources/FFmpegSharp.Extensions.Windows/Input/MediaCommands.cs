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

using System.Windows.Input;

namespace FFmpegSharp.Extensions.Windows.Input
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
            Play = System.Windows.Input.MediaCommands.Play;
            Stop = System.Windows.Input.MediaCommands.Stop;
            Pause = System.Windows.Input.MediaCommands.Pause;
            StepForward = new RoutedCommand(nameof(StepForward), typeof(MediaCommands));
            StepBackward = new RoutedCommand(nameof(StepBackward), typeof(MediaCommands));
            FastForward = System.Windows.Input.MediaCommands.FastForward;
            FastBackward = new RoutedCommand(nameof(FastBackward), typeof(MediaCommands));
            MuteVolume = System.Windows.Input.MediaCommands.MuteVolume;
            IncreaseVolume = System.Windows.Input.MediaCommands.IncreaseVolume;
            DecreaseVolume = System.Windows.Input.MediaCommands.DecreaseVolume;
        }

        /// <summary>
        ///     Gets the value that represents the Play command.
        /// </summary>
        public static RoutedCommand Play { get; }

        /// <summary>
        ///     Gets the value that represents the Stop command.
        /// </summary>
        public static RoutedCommand Stop { get; }

        /// <summary>
        ///     Gets the value that represents the Pause command.
        /// </summary>
        public static RoutedCommand Pause { get; }

        /// <summary>
        ///     Gets the value that represents the Step Forward command.
        /// </summary>
        public static RoutedCommand StepForward { get; }

        /// <summary>
        ///     Gets the value that represents the Step Backward command.
        /// </summary>
        public static RoutedCommand StepBackward { get; }

        /// <summary>
        ///     Gets the value that represents the Fast Forward command.
        /// </summary>
        public static RoutedCommand FastForward { get; }

        /// <summary>
        ///     Gets the value that represents the Step Backward command.
        /// </summary>
        public static RoutedCommand FastBackward { get; }

        /// <summary>
        ///     Gets the value that represents the Mute Volume command.
        /// </summary>
        public static RoutedUICommand MuteVolume { get; }

        /// <summary>
        ///     Gets the value that represents the Increase Volume command.
        /// </summary>
        public static RoutedUICommand IncreaseVolume { get; }

        /// <summary>
        ///     Gets the value that represents the Decrease Volume command.
        /// </summary>
        public static RoutedUICommand DecreaseVolume { get; }
    }
}
