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
using System.Collections;
using System.Collections.Generic;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVDeviceInfoList : IReadOnlyList<AVDeviceInfo>, IDisposable
    {
        private readonly Interop.AVDeviceInfoList* _handle;

        public int Count => _handle->nb_devices;

        public int DefaultDeviceIndex => _handle->default_device;

        public AVDeviceInfo DefaultDevice => this[DefaultDeviceIndex];

        public AVDeviceInfo this[int index] => new(_handle->devices[index]);

        public AVDeviceInfoList(Interop.AVDeviceInfoList* handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            _handle = handle;
        }

        ~AVDeviceInfoList()
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
                fixed (Interop.AVDeviceInfoList** deviceInfoList = &_handle)
                {
                    avdevice_free_list_devices(deviceInfoList);
                }
            }
        }

        public IEnumerator<AVDeviceInfo> GetEnumerator()
        {
            for (var index = 0; index < Count; ++index)
            {
                yield return this[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
