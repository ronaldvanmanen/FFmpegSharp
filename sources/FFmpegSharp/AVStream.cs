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

namespace FFmpegSharp
{
    public sealed unsafe class AVStream
    {
        private readonly Interop.AVStream* _handle;

        private AVCodecParameters _codecParameters;

        private AVDictionary _metadata;

        public int Index => _handle->index;

        public int Id => _handle->id;

        public AVTimeBase TimeBase => new(_handle->time_base);

        public AVTimeStamp StartTime => new AVTimeStamp(_handle->start_time);

        public AVTimeStamp Duration => new AVTimeStamp(_handle->duration);

        public AVTimeStamp EndTime => new AVTimeStamp(_handle->start_time + _handle->duration);

        public long FrameCount => _handle->nb_frames;

        public AVDisposition Disposition => (AVDisposition)_handle->disposition;

        public AVDiscard Discard
        {
            get => (AVDiscard)_handle->discard;

            set => _handle->discard = (Interop.AVDiscard)value;
        }

        public AVRational SampleAspectRatio => _handle->sample_aspect_ratio;

        public AVDictionary Metadata => _metadata ??= new AVDictionary(_handle->metadata);

        public AVRational AverageFrameRate => _handle->avg_frame_rate;

        public AVCodecParameters CodecParameters =>
            _codecParameters ??= new AVCodecParameters(_handle->codecpar, false);

        public AVStream(Interop.AVStream* handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
            _codecParameters = null!;
            _metadata = null!;
        }

        public static implicit operator Interop.AVStream*(AVStream value)
        {
            return value._handle;
        }
    }
}
