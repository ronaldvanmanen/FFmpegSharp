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
using System.IO;
using System.Threading;
using FFmpegSharp.Extensions.Collections;
using FFmpegSharp.Interop;
using SDL2Sharp;
using SDL2Sharp.Extensions;
using static System.Math;

namespace FFmpegSharp.Extensions.Framework
{
    public sealed class AudioRenderer
    {
        public sealed class AudioInputPort
        {
            private readonly AudioRenderer _owner;

            public AudioInputPort(AudioRenderer owner)
            {
                _owner = owner ?? throw new ArgumentNullException(nameof(owner));
            }

            public void Connect(MediaStream<AVFrame> stream, AVCodecContext streamInfo)
            {
                _owner.OnInputConnected(stream, streamInfo);
            }

            public void Disconnect()
            {
                _owner.OnInputDisconnected();
            }
        }

        public const int MinVolume = 0;

        public const int MaxVolume = SDL2Sharp.Interop.SDL.SDL_MIX_MAXVOLUME;

        private const int MinimumBufferSize = 512;

        private const int MaximumCallbacksPerSecond = 30;

        private readonly AudioInputPort _audioInput;

        private MediaStream<AVFrame> _audioInputStream;

        private SwrContext _audioConverter;

        private AudioDevice _audioDevice;

        private CircularBuffer<byte> _audioBuffer;

        private AVChannelLayout _audioChannelLayout;

        private AVSampleFormat _audioSampleFormat;

        private int _audioSampleRate;

        private CancellationTokenSource _cancellationTokenSource;

        private int _volume;

        private bool _muted;

        public int Volume
        {
            get => _volume;

            set
            {
                if (_volume < MinVolume)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"value cannot be less than {MinVolume}");
                }

                if (_volume > MaxVolume)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"value cannot be greater than {MaxVolume}");
                }

                _volume = value;
            }
        }

        public bool Muted
        {
            get => _muted;

            set => _muted = value;
        }

        public AudioInputPort AudioInput => _audioInput;

        public AudioRenderer()
        {
            _audioInput = new AudioInputPort(this);
            _audioInputStream = null!;
            _audioConverter = null!;
            _audioDevice = null!;
            _audioBuffer = null!; ;
            _cancellationTokenSource = null!;
            _volume = 0;
            _muted = false;
        }

        public void Start()
        {
            if (_cancellationTokenSource is not null)
            {
                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();
            _audioDevice.Unpause();
        }

        public void Stop()
        {
            if (_cancellationTokenSource is null)
            {
                return;
            }

            _cancellationTokenSource.Cancel();
            _audioDevice.Pause();
            _cancellationTokenSource = null!;
        }

        private void OnAudioDeviceCallback(object userdata, Span<byte> stream)
        {
            try
            {
                var cancellationToken = _cancellationTokenSource.Token;

                var audioCallbackTime = AVRelativeTime.Current;

                while (_audioBuffer.Count < stream.Length)
                {
                    using var audioFrame = _audioInputStream.Read(cancellationToken);
                    using var resampledAudioFrame = new AVFrame();
                    resampledAudioFrame.ChannelLayout = _audioChannelLayout;
                    resampledAudioFrame.SampleFormat = _audioSampleFormat;
                    resampledAudioFrame.SampleRate = _audioSampleRate;
                    _audioConverter.Convert(resampledAudioFrame, audioFrame);
                    audioFrame.CopyProps(resampledAudioFrame);

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

                        _audioBuffer.Enqueue(buffer);
                    }

                    resampledAudioFrame.Unref();
                }

                if (!_muted)
                {
                    stream.Fill(0);
                    var mixBuffer = new Span<byte>(new byte[stream.Length]);
                    _audioBuffer.Dequeue(mixBuffer);
                    stream.MixAudioFormat(mixBuffer, _audioDevice.ObtainedSpec.Format, _volume);
                }
                else
                {
                    stream.Fill(0);
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }

        private void OnInputConnected(MediaStream<AVFrame> stream, AVCodecContext streamInfo)
        {
            var audioFormat = GetAudioFormat(streamInfo);
            var audioChannelLayout = GetAudioChannelLayout(streamInfo);
            var audioSampleRate = GetAudioSampleRate(streamInfo);
            var audioSamples = (ushort)Max(MinimumBufferSize, 2 << ((int)Log2(audioSampleRate / MaximumCallbacksPerSecond)));
            var audioSpec = new AudioDeviceSpec(
                audioSampleRate,
                audioFormat,
                audioChannelLayout,
                audioSamples);

            _audioConverter = new SwrContext();
            _audioDevice = new AudioDevice(audioSpec, OnAudioDeviceCallback, null!, AudioDeviceAllowedChanges.Channels | AudioDeviceAllowedChanges.Frequency);
            _audioChannelLayout = GetAVChannelLayout(_audioDevice.ObtainedSpec.Channels);
            _audioSampleFormat = GetAVSampleFormat(_audioDevice.ObtainedSpec.Format);
            _audioSampleRate = GetSampleRate(_audioDevice.ObtainedSpec.Frequency);
            _audioBuffer = new CircularBuffer<byte>((int)(_audioDevice.ObtainedSpec.Size * 8), true);
            _audioInputStream = stream;
        }

        private void OnInputDisconnected()
        {
            _audioConverter.Dispose();
            _audioDevice.Dispose();
            _audioChannelLayout = 0;
            _audioSampleFormat = 0;
            _audioSampleRate = 0;
            _audioBuffer = null!;
            _audioInputStream = null!;
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

        private static AudioChannelLayout GetAudioChannelLayout(AVCodecContext codecContext)
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

        private int GetAudioSampleRate(AVCodecContext codecContext)
        {
            return codecContext.SampleRate;
        }

        private static AudioFormat GetAudioFormat(AVCodecContext codecContext)
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
