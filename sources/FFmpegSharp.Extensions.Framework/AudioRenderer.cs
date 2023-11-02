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

using System;
using System.Threading;
using FFmpegSharp.Extensions.Collections;
using FFmpegSharp.Extensions.ComponentModel;
using SDL2Sharp;
using SDL2Sharp.Extensions;
using static System.Math;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class AudioRenderer : ObservableObject, IPresentationClockSource, IDisposable
    {
        private const int MinimumBufferSize = 512;

        private const int MaximumCallbacksPerSecond = 30;

        private readonly ElementaryAudioStream _audioInputStream;

        private readonly SwrContext _sampleConverter;

        private readonly AudioDevice _device;

        private readonly CircularBuffer<byte> _sampleBuffer;

        private readonly AVChannelLayout _channelLayout;

        private readonly AVSampleFormat _sampleFormat;

        private readonly int _sampleRate;

        private readonly Clock _internalClock;

        private double _volume;

        private bool _muted;

        private CancellationTokenSource _cancellationTokenSource;

        private bool _disposed;

        public IClock Clock => _internalClock;

        public double Volume
        {
            get => _volume;

            set
            {
                if (_volume < 0d)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"value cannot be less than {0d}");
                }

                if (_volume > 1d)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"value cannot be greater than {1d}");
                }

                _volume = value;
            }
        }

        public bool IsMuted
        {
            get => _muted;

            set => _muted = value;
        }

        public AudioRenderer(ElementaryAudioStream inputStream)
        {
            _audioInputStream = inputStream ?? throw new ArgumentNullException(nameof(inputStream));

            var format = GetAudioFormat(inputStream);
            var channelLayout = GetAudioChannelLayout(inputStream);
            var sampleRate = GetAudioSampleRate(inputStream);
            var sampleCount = (ushort)Max(MinimumBufferSize, 2 << ((int)Log(sampleRate / MaximumCallbacksPerSecond, 2)));
            var deviceSpec = new AudioDeviceSpec(
                sampleRate,
                format,
                channelLayout,
                sampleCount);

            _sampleConverter = new SwrContext();
            _device = new AudioDevice(deviceSpec, OnAudioDeviceCallback, null!, AudioDeviceAllowedChanges.Channels | AudioDeviceAllowedChanges.Frequency);
            _channelLayout = GetAVChannelLayout(_device.ObtainedSpec.Channels);
            _sampleFormat = GetAVSampleFormat(_device.ObtainedSpec.Format);
            _sampleRate = GetSampleRate(_device.ObtainedSpec.Frequency);
            _sampleBuffer = new CircularBuffer<byte>((int)(_device.ObtainedSpec.Size * 8), true);

            _internalClock = new Clock();

            _cancellationTokenSource = null!;
            _volume = 0.5d;
            _muted = false;
            _disposed = false;
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                _sampleConverter?.Dispose();
                _device?.Dispose();
                _cancellationTokenSource?.Dispose();
            }
            finally
            {
                _disposed = true;
            }
        }

        public void Start()
        {
            ThrowIfDisposed();

            if (_cancellationTokenSource is not null)
            {
                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();
            _device.Unpause();
        }

        public void Stop()
        {
            ThrowIfDisposed();

            if (_cancellationTokenSource is null)
            {
                return;
            }

            try
            {
                _cancellationTokenSource.Cancel();
                _device.Pause();
                _cancellationTokenSource.Dispose();
            }
            finally
            {
                _cancellationTokenSource = null!;
            }
        }

        private void OnAudioDeviceCallback(object userdata, Span<byte> stream)
        {
            try
            {
                var cancellationToken = _cancellationTokenSource.Token;
                var audioPresentationTimeStamp = AVRelativeTime.Undefined;
                var audioCallbackTime = AVRelativeTime.Current;

                while (_sampleBuffer.Count < stream.Length)
                {
                    using var audioFrame = _audioInputStream.Read(cancellationToken);
                    using var resampledAudioFrame = new AVFrame();
                    resampledAudioFrame.ChannelLayout = _channelLayout;
                    resampledAudioFrame.SampleFormat = _sampleFormat;
                    resampledAudioFrame.SampleRate = _sampleRate;
                    _sampleConverter.Convert(resampledAudioFrame, audioFrame.Instance);
                    audioFrame.Instance.CopyProps(resampledAudioFrame);

                    audioPresentationTimeStamp = AVTimeStamp.IsUndefined(audioFrame.Instance.Pts) ?
                        AVRelativeTime.Undefined : audioFrame.Instance.Pts * _audioInputStream.TimeBase;

                    unsafe
                    {
                        // NOTE: The resampled audio frame has incorrect linesize parameters; swr_convert_frame
                        // aligns data and extended_data fields with silence. This silence is included in the
                        // linesize parameter. So we need to calculate the correct linesize.
                        var bufferSize = AVUtil.GetBufferSize(
                            resampledAudioFrame.ChannelCount,
                            resampledAudioFrame.SampleCount,
                            resampledAudioFrame.SampleFormat,
                            true);

                        var buffer = new Span<byte>(resampledAudioFrame.Handle->extended_data[0], bufferSize);

                        _sampleBuffer.Enqueue(buffer);
                    }

                    resampledAudioFrame.Unref();
                }

                if (!_muted)
                {
                    stream.Fill(0);
                    var mixBuffer = new Span<byte>(new byte[stream.Length]);
                    _sampleBuffer.Dequeue(mixBuffer);
                    var volume = (int)(_volume * SDL2Sharp.Interop.SDL.SDL_MIX_MAXVOLUME);
                    stream.MixAudioFormat(mixBuffer, _device.ObtainedSpec.Format, volume);
                }
                else
                {
                    stream.Fill(0);
                }

                if (!AVRelativeTime.IsUndefined(audioPresentationTimeStamp))
                {
                    _internalClock.SetTimeAt(audioPresentationTimeStamp, audioCallbackTime);
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        private static int GetSampleRate(int sampleRate)
        {
            return sampleRate;
        }

        private static AVSampleFormat GetAVSampleFormat(AudioFormat sampleFormat)
        {
            switch (sampleFormat)
            {
                case AudioFormat.U8:
                    return AVSampleFormat.Unsigned8;
                case AudioFormat.S16LSB:
                    return AVSampleFormat.Signed16;
                case AudioFormat.S32LSB:
                    return AVSampleFormat.Signed32;
                case AudioFormat.F32LSB:
                    return AVSampleFormat.Float32;
                default:
                    throw new NotSupportedException();
            }
        }

        private static AVChannelLayout GetAVChannelLayout(AudioChannelLayout channelLayout)
        {
            switch (channelLayout)
            {
                case AudioChannelLayout.Mono:
                    return AVChannelLayout.Mono;
                case AudioChannelLayout.Stereo:
                    return AVChannelLayout.Stereo;
                case AudioChannelLayout.Quad:
                    return AVChannelLayout.Quad;
                case AudioChannelLayout.FivePointOne:
                    return AVChannelLayout.FivePointOne;
                default:
                    throw new NotSupportedException();
            }
        }

        private static AudioChannelLayout GetAudioChannelLayout(IElementaryAudioStream codecContext)
        {
            var channelLayout = codecContext.ChannelLayout;
            if (channelLayout <= 0)
            {
                if (codecContext.ChannelCount != 0)
                {
                    channelLayout = AVUtil.GetDefaultChannelLayout(codecContext.ChannelCount);
                }
                else
                {
                    channelLayout = AVChannelLayout.Stereo;
                }
            }

            switch (channelLayout)
            {
                case AVChannelLayout.Mono:
                    return AudioChannelLayout.Mono;
                case AVChannelLayout.Stereo:
                    return AudioChannelLayout.Stereo;
                case AVChannelLayout.Quad:
                    return AudioChannelLayout.Quad;
                case AVChannelLayout.FivePointOne:
                    return AudioChannelLayout.FivePointOne;
                case AVChannelLayout.FivePointOneBack:
                    return AudioChannelLayout.FivePointOne;
                case AVChannelLayout.SevenPointOne:
                    return AudioChannelLayout.Stereo;
                default:
                    throw new NotSupportedException();
            }
        }

        private static int GetAudioSampleRate(IElementaryAudioStream codecContext)
        {
            return codecContext.SampleRate;
        }

        private static AudioFormat GetAudioFormat(IElementaryAudioStream codecContext)
        {
            var packedSampleFormat = codecContext.SampleFormat.ToPackedFormat();
            switch (packedSampleFormat)
            {
                case AVSampleFormat.Unsigned8:
                    return AudioFormat.U8;
                case AVSampleFormat.Signed16:
                    return AudioFormat.S16;
                case AVSampleFormat.Signed32:
                    return AudioFormat.S32;
                case AVSampleFormat.Float32:
                    return AudioFormat.F32;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
