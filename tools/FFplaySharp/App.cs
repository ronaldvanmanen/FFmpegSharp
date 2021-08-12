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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using FFmpegSharp;
using FFmpegSharp.Extensions.Framework;
using Microsoft.Extensions.Logging;
using SDL2Sharp;

namespace FFplaySharp
{
    internal sealed class App : Application
    {
        private static readonly TimeSpan HideCursorDelay = TimeSpan.FromSeconds(1);

        private readonly CommandLineOptions _options;

        private readonly ILogger _logger;

        private readonly AVDictionary _swsOptions;

        private readonly AVDictionary _swrOptions;

        private readonly AVDictionary _formatOptions;

        private readonly AVDictionary _codecOptions;

        private readonly AVDictionary _resampleOptions;

        private readonly PresentationClock _presentationClock;

        private readonly ExternalClock _externalClock;

        private MediaDemultiplexer _demultiplexer;

        private AudioDecoder _audioDecoder;

        private VideoDecoder _videoDecoder;

        private SubtitleDecoder _subtitleDecoder;

        private AudioRenderer _audioRenderer;

        private VideoRenderer _videoRenderer;

        private int _subtitleOutputIndex = 0;

        private Window _window;

        private Thread _renderingThread;

        private volatile bool _rendererInvalidated;

        private volatile bool _rendering;

        private DateTime _cursorLastActive = DateTime.UtcNow;

        public App(CommandLineOptions options, ILogger logger, CancellationToken cancellationToken)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _swsOptions = new AVDictionary() { { "flags", "bicubic" } };
            _swrOptions = new AVDictionary();
            _formatOptions = new AVDictionary();
            _codecOptions = new AVDictionary();
            _resampleOptions = new AVDictionary();

            _presentationClock = new PresentationClock();
            _externalClock = new ExternalClock();
            _demultiplexer = null!;
            _audioDecoder = null!;
            _videoDecoder = null!;
            _subtitleDecoder = null!;
            _audioRenderer = null!;
            _videoRenderer = null!;

            _window = null!;
            _renderingThread = null!;
            _rendererInvalidated = false;
            _rendering = false;

            cancellationToken.Register(Quit);
        }

        protected override void OnInitializing()
        {
            Subsystems = Subsystems.Video | Subsystems.Audio | Subsystems.Events | Subsystems.Timer;

            if (_options.NoDisplay)
            {
                _options.DisableVideo = true;
            }

            if (_options.DisableAudio)
            {
                Subsystems &= ~Subsystems.Audio;
            }
            else
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    // Try to work around an occasional ALSA buffer underflow issue
                    // when the period size is NPOT due to ALSA resampling by
                    // forcing the buffer size.
                    const string SDL_AUDIO_ALSA_SET_BUFFER_SIZE = "SDL_AUDIO_ALSA_SET_BUFFER_SIZE";
                    if (null == Environment.GetEnvironmentVariable(SDL_AUDIO_ALSA_SET_BUFFER_SIZE))
                    {
                        Environment.SetEnvironmentVariable(SDL_AUDIO_ALSA_SET_BUFFER_SIZE, "1");
                    }
                }
            }

            if (_options.NoDisplay)
            {
                Subsystems &= ~Subsystems.Video;
            }
        }

        protected override void OnInitialized()
        {
            if (!_options.DisableVideo)
            {
                _videoRenderer = new VideoRenderer(_presentationClock, _externalClock);
            }

            if (!_options.NoDisplay)
            {
                var windowFlags = WindowFlags.Hidden;

                if (_options.AlwaysOnTop)
                {
                    windowFlags |= WindowFlags.AlwaysOnTop;
                }

                if (_options.NoBorder)
                {
                    windowFlags |= WindowFlags.Borderless;
                }
                else
                {
                    windowFlags |= WindowFlags.Resizable;
                }

                Hints.SetValue(Hints.RenderScaleQuality, "linear");

                _window = new Window(_options.WindowTitle, _options.Width, _options.Height, windowFlags);
                _window.KeyDown += HandleWindowKeyDownEvent;
                _window.MouseMotion += HandleWindowMouseMotionEvent;
                _window.SizeChanged += HandleWindowSizeChangedEvent;
                _window.Show();
                _renderingThread = new Thread(Render);
                _renderingThread.Name = "Renderer Thread";
                _rendererInvalidated = true;
                _rendering = true;
                _renderingThread.Start();
            }

            _demultiplexer = new MediaDemultiplexer(_options.Input);
            _demultiplexer.PropertyChanged += HandleDemultiplexerPropertyChangedEvent;
            _demultiplexer.DisableAudio = _options.DisableAudio;
            _demultiplexer.DisableSubtitling = _options.DisableSubtitling;
            _demultiplexer.DisableVideo = _options.DisableVideo;
            _demultiplexer.FindStreamInfo = _options.FindStreamInfo;
            _demultiplexer.GeneratePts = _options.GeneratePts;
            _demultiplexer.Start();
        }

        protected override void OnQuiting()
        {
            _rendererInvalidated = false;
            _rendering = false;
            _renderingThread?.Join();
            _demultiplexer?.Stop();
            _videoDecoder?.Stop();
            _audioDecoder?.Stop();
            _audioRenderer?.Stop();
            _window?.Dispose();
        }

        protected override void OnIdle()
        {
            if (Cursor.Shown)
            {
                var cursorInactivity = DateTime.UtcNow - _cursorLastActive;
                if (cursorInactivity >= HideCursorDelay)
                {
                    Cursor.Hide();
                }
            }
        }

        private void HandleWindowKeyDownEvent(object? sender, KeyEventArgs eventArgs)
        {
            switch (eventArgs.KeyCode)
            {
                case KeyCode.F11:
                    ToggleFullScreen();
                    break;

                case KeyCode.Return:
                    if (eventArgs.Alt)
                    {
                        ToggleFullScreen();
                    }
                    break;

                case KeyCode.M:
                    ToggleMute();
                    break;

                case KeyCode.T:
                    CycleSubtitles();
                    break;

                case KeyCode.Plus:
                case KeyCode.KeypadPlus:
                case KeyCode.VolumeUp:
                    IncreaseVolume();
                    break;

                case KeyCode.Minus:
                case KeyCode.KeypadMinus:
                case KeyCode.VolumeDown:
                    DecreaseVolume();
                    break;
            }
        }

        private void HandleWindowMouseMotionEvent(object? sender, MouseMotionEventArgs eventArgs)
        {
            if (Cursor.Hidden)
            {
                Cursor.Show();
            }

            _cursorLastActive = DateTime.UtcNow;
        }

        private void HandleWindowSizeChangedEvent(object? sender, WindowSizeChangedEventArgs eventArgs)
        {
            _rendererInvalidated = true;
        }

        private void HandleDemultiplexerPropertyChangedEvent(object? sender, PropertyChangedEventArgs eventArgs)
        {
            switch (eventArgs.PropertyName)
            {
                case nameof(MediaDemultiplexer.BestAudioOutput):
                {
                    if (_options.DisableAudio)
                    {
                        break;
                    }

                    var audioOutput = _demultiplexer.BestAudioOutput;
                    if (audioOutput == null)
                    {
                        break;
                    }

                    var options = new AudioDecoderOptions { Fast = _options.Fast };
                    _audioDecoder = new AudioDecoder(audioOutput, options);
                    _audioDecoder.Start();

                    _audioRenderer = new AudioRenderer(
                        _presentationClock,
                        _externalClock,
                        _audioDecoder.AudioOutput,
                        _audioDecoder.SampleRate,
                        _audioDecoder.SampleFormat,
                        _audioDecoder.ChannelLayout);
                    _audioRenderer.Volume = AudioRenderer.MaxVolume;
                    _presentationClock.TimeSource = _audioRenderer;
                    _audioRenderer.Start();
                    break;
                }

                case nameof(MediaDemultiplexer.BestVideoOutput):
                {
                    if (_options.DisableVideo)
                    {
                        break;
                    }

                    var videoOutput = _demultiplexer.BestVideoOutput;
                    if (videoOutput != null)
                    {
                        var options = new VideoDecoderOptions { Fast = _options.Fast };
                        _videoDecoder = new VideoDecoder(videoOutput, options);
                        _videoRenderer.VideoInput = _videoDecoder.VideoOutput;
                        _videoDecoder.Start();
                    }
                    break;
                }

                case nameof(MediaDemultiplexer.BestSubtitleOutput):
                {
                    if (_options.DisableVideo || _options.DisableSubtitling)
                    {
                        break;
                    }

                    var subtitleOutput = _demultiplexer.BestSubtitleOutput;
                    if (subtitleOutput != null)
                    {
                        _subtitleDecoder = new SubtitleDecoder(subtitleOutput);
                        _videoRenderer.SubtitleInput = _subtitleDecoder.SubtitleOutput;
                        _subtitleDecoder.Start();
                    }
                    break;
                }
            }
        }

        private void Render()
        {
            var renderer = CreateRenderer();

            try
            {
                while (_rendering)
                {
                    try
                    {
                        if (_rendererInvalidated)
                        {
                            _rendererInvalidated = false;

                            renderer.Dispose();

                            renderer = CreateRenderer();
                            renderer.DrawColor = new Color(0, 0, 0, 255);
                            renderer.Clear();
                            renderer.DrawVideo(_videoRenderer, true);
                            renderer.Present();

                            _logger.LogInformation($"Initialized {renderer.Info.Name} renderer.");
                        }
                        else
                        {
                            renderer.DrawColor = new Color(0, 0, 0, 255);
                            renderer.Clear();
                            renderer.DrawVideo(_videoRenderer);
                            renderer.Present();
                        }
                    }
                    catch (Error error)
                    {
                        _logger.LogError($"Error while rendering: {error.Message}");

                        _rendererInvalidated = true;
                    }
                }
            }
            finally
            {
                renderer.Dispose();
            }
        }

        private Renderer CreateRenderer()
        {
            const RendererFlags HardwareAcceleratedRendererFlags = RendererFlags.Accelerated | RendererFlags.PresentVSync;

            if (_window.TryCreateRenderer(HardwareAcceleratedRendererFlags, out var renderer, out var error))
            {
                return renderer;
            }

            _logger.LogWarning($"Failed to initialize a hardware accelerated renderer: {error.Message}");

            return _window.CreateRenderer(RendererFlags.None);
        }

        private void ToggleFullScreen()
        {
            var window = _window;
            if (window != null)
            {
                window.IsFullScreenDesktop = !window.IsFullScreenDesktop;
            }
        }

        private void CycleSubtitles()
        {
            var subtitleOutputCount = _demultiplexer.SubtitleOutputs.Count;
            if (subtitleOutputCount > 0)
            {
                if (_subtitleDecoder != null)
                {
                    _subtitleDecoder.Stop();
                }

                var subtitleOutput = _demultiplexer.SubtitleOutputs[_subtitleOutputIndex];
                _subtitleOutputIndex += 1;
                _subtitleOutputIndex %= subtitleOutputCount;

                _subtitleDecoder = new SubtitleDecoder(subtitleOutput);
                _videoRenderer.SubtitleInput = _subtitleDecoder.SubtitleOutput;
                _subtitleDecoder.Start();
            }
        }

        private void ToggleMute()
        {
            var audioRenderer = _audioRenderer;
            if (audioRenderer != null)
            {
                audioRenderer.Muted = !audioRenderer.Muted;
            }
        }

        private void IncreaseVolume()
        {
            var audioRenderer = _audioRenderer;
            if (audioRenderer != null)
            {
                audioRenderer.Volume = Math.Min(audioRenderer.Volume + 1, AudioRenderer.MaxVolume);
            }
        }

        private void DecreaseVolume()
        {
            var audioRenderer = _audioRenderer;
            if (audioRenderer != null)
            {
                audioRenderer.Volume = Math.Max(audioRenderer.Volume - 1, AudioRenderer.MinVolume);
            }
        }
    }
}
