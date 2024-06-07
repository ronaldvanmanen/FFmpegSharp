﻿// Copyright (C) 2021-2024 Ronald van Manen
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

using System.Windows;
using System.Windows.Controls;

namespace Player
{
    [TemplatePart(Name = PART_VideoHwndHost, Type = typeof(VideoHwndHost))]
    internal sealed class MediaControl : Control
    {
        private const string PART_VideoHwndHost = "PART_VideoHwndHost";

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.RegisterAttached(
                nameof(Source),
                typeof(string),
                typeof(MediaControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, SourceChanged));

        private MediaPlayer _mediaPlayer = null!;

        private VideoHwndHost _videoHwndHost = null!;

        public string Source
        {
            get => (string)GetValue(SourceProperty);

            set => SetValue(SourceProperty, value);
        }

        static MediaControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MediaControl), new FrameworkPropertyMetadata(typeof(MediaControl)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _videoHwndHost = (VideoHwndHost)GetTemplateChild(PART_VideoHwndHost);
        }

        private void SourceChanged()
        {
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.Dispose();
            }

            _mediaPlayer = new MediaPlayer(Source, _videoHwndHost.Handle);
        }

        private static void SourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (dependencyObject is MediaControl mediaControl)
            {
                mediaControl.SourceChanged();
            }
        }
    }
}