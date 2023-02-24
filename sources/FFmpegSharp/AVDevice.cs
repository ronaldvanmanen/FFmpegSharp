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

using System.Collections.Generic;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    public sealed unsafe class AVDevice
    {
        public static IEnumerable<AVInputFormat> AudioInputDevices
        {
            get
            {
                var iterator = new AVInputAudioDeviceIterator();
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        public static IEnumerable<AVOutputFormat> AudioOutputDevices
        {
            get
            {
                var iterator = new AVOutputAudioDeviceIterator();
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        public static IEnumerable<AVInputFormat> VideoInputDevices
        {
            get
            {
                var iterator = new AVInputVideoDeviceIterator();
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        public static IEnumerable<AVOutputFormat> VideoOutputDevices
        {
            get
            {
                var iterator = new AVOutputVideoDeviceIterator();
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        public static void RegisterAll()
        {
            avdevice_register_all();
        }
    }
}
