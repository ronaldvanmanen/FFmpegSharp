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

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FFmpegSharp.Extensions.Mime;
using Microsoft.Win32;

namespace MediaPlayer
{
    public sealed class MainWindowViewModel : ObservableObject
    {
        private RelayCommand _openFileCommand = null!;

        private RelayCommand _exitCommand = null!;

        private string _mediaSource = null!;

        public ICommand OpenFileCommand => _openFileCommand ??= new RelayCommand(OpenFile);

        public ICommand ExitCommand => _exitCommand ??= new RelayCommand(Exit);

        public string MediaSource
        {
            get => _mediaSource;
            set
            {
                OnPropertyChanging(nameof(MediaSource));
                _mediaSource = value;
                OnPropertyChanged(nameof(MediaSource));
            }
        }

        private void OpenFile()
        {
            static string AsPattern(IEnumerable<string> extensions)
            {
                return string.Join(";", extensions.Select(e => "*." + e));
            }

            var mediaFilesExtensions = new SortedSet<string>(FFmpegSharp.AVInputFormat.All.SelectMany(format => format.Extensions));
            var mediaFilesPattern = AsPattern(mediaFilesExtensions);
            var videoFilesPattern = AsPattern(mediaFilesExtensions.Where(MediaTypes.IsVideoMediaType));
            var audioFilesPattern = AsPattern(mediaFilesExtensions.Where(MediaTypes.IsAudioMediaType));

            var openFileDialog = new OpenFileDialog
            {
                Filter = $"Media Files ({mediaFilesPattern})|{mediaFilesPattern}|"
                       + $"Video Files ({videoFilesPattern})|{videoFilesPattern}|"
                       + $"Audio Files ({audioFilesPattern})|{audioFilesPattern}|"
                       + "All files (*.*)|*.*",
                Multiselect = false
            };

            var result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                MediaSource = openFileDialog.FileName;
            }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
