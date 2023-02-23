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

namespace FFmpegSharp
{
    public enum AVClassCategory
    {
        NotAvailable = Interop.AVClassCategory.AV_CLASS_CATEGORY_NA,
        Input = Interop.AVClassCategory.AV_CLASS_CATEGORY_INPUT,
        Output = Interop.AVClassCategory.AV_CLASS_CATEGORY_OUTPUT,
        Muxer = Interop.AVClassCategory.AV_CLASS_CATEGORY_MUXER,
        Demuxer = Interop.AVClassCategory.AV_CLASS_CATEGORY_DEMUXER,
        Encoder = Interop.AVClassCategory.AV_CLASS_CATEGORY_ENCODER,
        Decoder = Interop.AVClassCategory.AV_CLASS_CATEGORY_DECODER,
        Filter = Interop.AVClassCategory.AV_CLASS_CATEGORY_FILTER,
        BitStreamFilter = Interop.AVClassCategory.AV_CLASS_CATEGORY_BITSTREAM_FILTER,
        SoftwareScaler = Interop.AVClassCategory.AV_CLASS_CATEGORY_SWSCALER,
        SoftwareResampler = Interop.AVClassCategory.AV_CLASS_CATEGORY_SWRESAMPLER,
        VideoOutputDevice = Interop.AVClassCategory.AV_CLASS_CATEGORY_DEVICE_VIDEO_OUTPUT,
        VideoInputDevice = Interop.AVClassCategory.AV_CLASS_CATEGORY_DEVICE_VIDEO_INPUT,
        AudioOutputDevice = Interop.AVClassCategory.AV_CLASS_CATEGORY_DEVICE_AUDIO_OUTPUT,
        AudioInputDevice = Interop.AVClassCategory.AV_CLASS_CATEGORY_DEVICE_AUDIO_INPUT,
        OutputDevice = Interop.AVClassCategory.AV_CLASS_CATEGORY_DEVICE_OUTPUT,
        InputDevice = Interop.AVClassCategory.AV_CLASS_CATEGORY_DEVICE_INPUT
    }
}
