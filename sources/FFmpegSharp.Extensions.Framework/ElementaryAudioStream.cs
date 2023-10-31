﻿// Copyright (c) 2021-2023 Ronald van Manen
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
using FFmpegSharp.Extensions.Framework;

namespace FFmpegSharp
{
    public sealed class ElementaryAudioStream : ElementaryStream<AVFrame>, IElementaryAudioStream
    {
        private readonly AVCodecContext _codecContext;

        public long BitRate => _codecContext.BitRate;

        public int BitRateTolerance => _codecContext.BitRateTolerance;

        public int ChannelCount => _codecContext.ChannelCount;

        public AVChannelLayout ChannelLayout => _codecContext.ChannelLayout;

        public AVCodec Codec => _codecContext.Codec;

        public AVCodecID CodecID => _codecContext.CodecID;

        public AVMediaType CodecType => _codecContext.CodecType;

        public int CompressionLevel => _codecContext.CompressionLevel;

        public int GlobalQuality => _codecContext.GlobalQuality;

        public AVTimeBase PacketTimeBase => _codecContext.PacketTimeBase;

        public AVSampleFormat SampleFormat => _codecContext.SampleFormat;

        public int SampleRate => _codecContext.SampleRate;

        public AVTimeBase TimeBase => _codecContext.TimeBase;

        internal ElementaryAudioStream(AVCodecContext codecContext, int bufferSize)
        : base(bufferSize)
        {
            _codecContext = codecContext ?? throw new ArgumentNullException(nameof(codecContext));
        }
    }
}
