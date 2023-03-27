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
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;

namespace MediaPlayer
{
    public sealed class MainWindowViewModel : ObservableObject
    {
        private RelayCommand _openFileCommand = null!;

        private RelayCommand _exitCommand = null!;

        private Uri _mediaSource = null!;

        public ICommand OpenFileCommand => _openFileCommand ??= new RelayCommand(OpenFile);

        public ICommand ExitCommand => _exitCommand ??= new RelayCommand(Exit);

        public Uri MediaSource
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
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Media Files (*.asf;*.mkv;*.mov;*.mp4;*.wma;*.wmv;*.flac;*.mp3;*.wav)|*.asf;*.mkv;*.mov;*.mp4;*.wma;*.wmv*.flac;*.mp3;*.wav|"
                       + "Video Files (*.asf;*.mkv;*.mov;*.mp4;*.wma;*.wmv)|*.asf;*.mkv;*.mov;*.mp4;*.wma;*.wmv|"
                       + "Audio Files (*.flac;*.mp3;*.wav)|*.flac;*.mp3;*.wav|"
                       + "All files (*.*)|*.*",
                Multiselect = false
            };

            var result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                MediaSource = new Uri(openFileDialog.FileName);
            }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
