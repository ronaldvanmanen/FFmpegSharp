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
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVFrame : IDisposable
    {
        private readonly Interop.AVFrame* _handle;

        private readonly bool _ownsHandle;

        public Interop.AVFrame* Handle => _handle;

        public AVTimeStamp BestEffortTimestamp
        {
            get => new(_handle->best_effort_timestamp);

            set => _handle->best_effort_timestamp = (long)value;
        }

        public AVTimeStamp Pts
        {
            get => new(_handle->pts);

            set => _handle->pts = (long)value;
        }

        public AVTimeStamp PacketPts
        {
            get => new(_handle->pkt_pts);

            set => _handle->pkt_pts = (long)value;
        }

        public AVTimeStamp PacketDts
        {
            get => new(_handle->pkt_dts);

            set => _handle->pkt_dts = (long)value;
        }

        public long PacketPosition
        {
            get => _handle->pkt_pos;

            set => _handle->pkt_pos = value;
        }

        public AVRational SampleAspectRatio
        {
            get => _handle->sample_aspect_ratio;

            set => _handle->sample_aspect_ratio = value;
        }

        public int Format
        {
            get => _handle->format;

            set => _handle->format = value;
        }

        public AVSampleFormat SampleFormat
        {
            get => (AVSampleFormat)_handle->format;

            set => _handle->format = (int)value;
        }

        public AVPixelFormat PixelFormat
        {
            get => (AVPixelFormat)_handle->format;

            set => _handle->format = (int)value;
        }

        public int Width
        {
            get => _handle->width;

            set => _handle->width = value;
        }

        public int Height
        {
            get => _handle->height;

            set => _handle->height = value;
        }

        public int ChannelCount
        {
            get => _handle->channels;

            set => _handle->channels = value;
        }

        public AVChannelLayout ChannelLayout
        {
            get => (AVChannelLayout)_handle->channel_layout;

            set => _handle->channel_layout = (ulong)value;
        }

        public int SampleCount
        {
            get => _handle->nb_samples;

            set => _handle->nb_samples = value;
        }

        public int SampleRate
        {
            get => _handle->sample_rate;

            set => _handle->sample_rate = value;
        }

        public AVFrame()
        : this(av_frame_alloc(), true)
        { }

        public AVFrame(Interop.AVFrame* handle, bool ownsHandle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
            _ownsHandle = ownsHandle;
        }

        ~AVFrame()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool _)
        {
            if (_ownsHandle && _handle != null)
            {
                fixed (Interop.AVFrame** handle = &_handle)
                {
                    av_frame_free(handle);
                }
            }
        }

        public void CopyProps(AVFrame destination)
        {
            AVError.ThrowOnError(
                av_frame_copy_props(destination._handle, _handle)
            );
        }

        public void MoveRef(AVFrame destination)
        {
            av_frame_move_ref(destination._handle, _handle);
        }

        public void Unref()
        {
            av_frame_unref(_handle);
        }

        public static implicit operator Interop.AVFrame*(AVFrame value)
        {
            return value._handle;
        }
    }
}
