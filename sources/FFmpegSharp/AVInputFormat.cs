// Copyright (C) 2021-2024 Ronald van Manen
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
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<string> Extensions
        {
            get
            {
                if (_handle->extensions == null)
                {
                    return Enumerable.Empty<string>();
                }

                var commaSeperatedExtensions = new string(_handle->extensions);
                var extensions = commaSeperatedExtensions.Split(',');
                return extensions;
            }
        }

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

        public IEnumerable<string> MimeTypes
        {
            get
            {
                if (_handle->mime_type == null)
                {
                    return Enumerable.Empty<string>();
                }

                var commaSeparatedMimeTypes = new string(_handle->mime_type);
                var mimeTypes = commaSeparatedMimeTypes.Split(',');
                return mimeTypes;
            }
        }

        public AVDeviceInfoList? InputSources
        {
            get
            {
                if (_handle->get_device_list == IntPtr.Zero)
                {
                    return null;
                }

                Interop.AVDeviceInfoList* deviceInfoList = null;

                AVError.ThrowOnError(
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
