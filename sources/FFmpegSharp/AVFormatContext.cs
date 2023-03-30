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
    public sealed unsafe partial class AVFormatContext : IDisposable
    {
        private readonly Interop.AVFormatContext* _handle;

        private AVStreamCollection _streams = null!;

        public AVRelativeTime StartTime => AVRelativeTime.FromMicroSeconds(_handle->start_time);

        public AVRelativeTime EndTime => AVRelativeTime.FromMicroSeconds(_handle->start_time + _handle->duration);

        public AVStreamCollection Streams => _streams ??= new AVStreamCollection(_handle->streams, _handle->nb_streams);

        public AVFormatContext(string uri)
        : this(uri, null)
        { }

        public AVFormatContext(string uri, Options? options)
        {
            if (uri is null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            _handle = avformat_alloc_context();

            if (options is not null)
            {
                _handle->flags = (int)options.Flags;
                _handle->max_analyze_duration = options.MaxAnalyzeDuration;
                _handle->probesize = options.ProbeSize;
            }

            fixed (Interop.AVFormatContext** handle = &_handle)
            {
                using var uriString = new MarshaledString(uri);
                AVError.ThrowOnError(
                    avformat_open_input(handle, uriString, null, null)
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
            if (retval == AVERROR_STREAM_NOT_FOUND)
            {
                return -1;
            }
            AVError.ThrowOnError(retval);
            return retval;
        }

        public void FindStreamInfo()
        {
            AVError.ThrowOnError(
                avformat_find_stream_info(_handle, null)
            );
        }

        public void InjectGlobalSideData()
        {
            av_format_inject_global_side_data(_handle);
        }

        public bool Read(ref AVPacket packet)
        {
            var retval = av_read_frame(_handle, packet);
            if (retval == 0)
            {
                return true;
            }
            else if (retval == AVERROR_EOF)
            {
                return false;
            }
            else
            {
                throw new AVError(retval);
            }
        }
    }
}
