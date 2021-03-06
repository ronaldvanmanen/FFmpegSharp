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

namespace FFmpegSharp.Interop
{
    public unsafe partial struct AVFilterContext
    {
        [NativeTypeName("const AVClass *")]
        public AVClass* av_class;

        [NativeTypeName("const AVFilter *")]
        public AVFilter* filter;

        [NativeTypeName("char *")]
        public sbyte* name;

        public AVFilterPad* input_pads;

        public AVFilterLink** inputs;

        [NativeTypeName("unsigned int")]
        public uint nb_inputs;

        public AVFilterPad* output_pads;

        public AVFilterLink** outputs;

        [NativeTypeName("unsigned int")]
        public uint nb_outputs;

        public void* priv;

        [NativeTypeName("struct AVFilterGraph *")]
        public AVFilterGraph* graph;

        public int thread_type;

        public AVFilterInternal* @internal;

        [NativeTypeName("struct AVFilterCommand *")]
        public AVFilterCommand* command_queue;

        [NativeTypeName("char *")]
        public sbyte* enable_str;

        public void* enable;

        public double* var_values;

        public int is_disabled;

        public AVBufferRef* hw_device_ctx;

        public int nb_threads;

        [NativeTypeName("unsigned int")]
        public uint ready;

        public int extra_hw_frames;

        public partial struct AVFilterCommand
        {
        }
    }
}
