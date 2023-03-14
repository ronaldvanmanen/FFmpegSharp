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
using System.Collections.Generic;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe partial class AVInputFormat
    {
        public static IEnumerable<AVInputFormat> All
        {
            get
            {
                var iterator = new AVInputFormatIterator();
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        private readonly Interop.AVInputFormat* _handle;

        public bool IsDevice
        {
            get
            {
                return IsInputDevice || IsOutputDevice;
            }
        }

        public bool IsInputDevice
        {
            get
            {
                var privateClass = PrivateClass;
                if (privateClass == null)
                {
                    return false;
                }

                var category = privateClass.Category;
                return (category == AVClassCategory.VideoInputDevice) ||
                       (category == AVClassCategory.AudioInputDevice) ||
                       (category == AVClassCategory.InputDevice);
            }
        }

        public bool IsOutputDevice
        {
            get
            {
                var privateClass = PrivateClass;
                if (privateClass == null)
                {
                    return false;
                }

                var category = privateClass.Category;
                return (category == AVClassCategory.VideoOutputDevice) ||
                       (category == AVClassCategory.AudioOutputDevice) ||
                       (category == AVClassCategory.OutputDevice);
            }
        }

        public string Name => new(_handle->name);

        public string LongName => new(_handle->long_name);

        public AVClass? PrivateClass
        {
            get
            {
                if (_handle->priv_class == null)
                {
                    return null;
                }
                return new AVClass(_handle->priv_class);
            }
        }

        public AVDeviceInfoList? InputSources
        {
            get
            {
                if (_handle->get_device_list == null)
                {
                    return null;
                }

                Interop.AVDeviceInfoList* deviceInfoList = null;

                AVError.ThrowOnFailure(
                    avdevice_list_input_sources(_handle, null, null, &deviceInfoList)
                );

                return new AVDeviceInfoList(deviceInfoList);
            }
        }

        public unsafe AVInputFormat(Interop.AVInputFormat* handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _handle = handle;
        }
    }
}
