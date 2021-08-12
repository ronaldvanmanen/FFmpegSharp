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
using FFmpegSharp.Internals;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVFormatContext : IDisposable
    {
        private readonly Interop.AVFormatContext* _handle;

        private AVStreamCollection _streams = null!;

        public Interop.AVFormatContext* Handle => _handle;

        public AVStreamCollection Streams => _streams ??= new AVStreamCollection(_handle->streams, _handle->nb_streams);

        public AVFormatFlags Flags => (AVFormatFlags)_handle->flags;

        public long ProbeSize => _handle->probesize;

        public long MaxAnalyzeDuration => _handle->max_analyze_duration;

        public AVFormatContext(string uri)
        : this(uri, AVFormatContextOptions.Default)
        { }

        public AVFormatContext(string uri, AVFormatContextOptions options)
        {
            if (uri is null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            _handle = avformat_alloc_context();

            if (options.Flags.HasValue)
            {
                _handle->flags = (int)options.Flags.Value;
            }

            if (options.MaxAnalyzeDuration.HasValue)
            {
                _handle->max_analyze_duration = options.MaxAnalyzeDuration.Value;
            }

            if (options.ProbeSize.HasValue)
            {
                _handle->probesize = options.ProbeSize.Value;
            }

            fixed (Interop.AVFormatContext** handle = &_handle)
            {
                using var uriString = new MarshaledString(uri);
                AVError.ThrowOnFailure(
                    avformat_open_input(handle, uriString.Value, null, null)
                );
            }
        }

        ~AVFormatContext()
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
            if (_handle != null)
            {
                fixed (Interop.AVFormatContext** handle = &_handle)
                {
                    avformat_close_input(handle);
                }

                if (_handle != null)
                {
                    avformat_free_context(_handle);
                }
            }
        }

        public int FindBestStream(AVMediaType type)
        {
            var retval = av_find_best_stream(_handle, (Interop.AVMediaType)type, -1, -1, null, 0);
            if (retval != AVERROR_STREAM_NOT_FOUND && retval != AVERROR_DECODER_NOT_FOUND)
            {
                AVError.ThrowOnFailure(retval);
            }
            return retval;
        }

        public void FindStreamInfo()
        {
            AVError.ThrowOnFailure(
                avformat_find_stream_info(_handle, null)
            );
        }

        public AVFrameRate GuessFrameRate(AVStream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            return new AVFrameRate(av_guess_frame_rate(_handle, stream, null));
        }

        public AVFrameRate GuessFrameRate(AVStream stream, AVFrame frame)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (frame is null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            return new AVFrameRate(av_guess_frame_rate(_handle, stream, frame));
        }

        public AVRational GuessSampleAspectRatio(AVStream stream, AVFrame frame)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (frame is null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            return av_guess_sample_aspect_ratio(_handle, stream, frame);
        }

        public void InjectGlobalSideData()
        {
            av_format_inject_global_side_data(_handle);
        }

        public int Read(AVPacket packet)
        {
            if (packet is null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            var retval = av_read_frame(_handle, packet);
            if (retval == 0 || retval == AVERROR_EOF)
            {
                return retval;
            }
            else
            {
                throw new AVError(retval);
            }
        }

        public static implicit operator Interop.AVFormatContext*(AVFormatContext value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value._handle;
        }
    }
}
