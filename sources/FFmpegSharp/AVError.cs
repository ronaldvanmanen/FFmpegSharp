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
using System.Runtime.Serialization;
using static FFmpegSharp.Interop.FFmpeg;

namespace FFmpegSharp
{
    [Serializable]
    public sealed class AVError : Exception
    {
        public int ErrorCode { get; private set; }

        public AVError(int errorCode)
        : base(GetErrorMessage(errorCode))
        {
            ErrorCode = errorCode;
        }

        public AVError(int errorCode, Exception inner)
        : base(GetErrorMessage(errorCode), inner)
        {
            ErrorCode = errorCode;
        }

        private AVError(SerializationInfo info, StreamingContext context)
        : base(info, context)
        { }

        public static void ThrowOnError(int returnCode)
        {
            if (returnCode < 0)
            {
                throw new AVError(returnCode);
            }
        }

        public static bool ReturnOnFailure(int returnCode, out AVError? error)
        {
            if (returnCode < 0)
            {
                error = new AVError(returnCode);
                return true;
            }
            error = null;
            return false;
        }

        private static unsafe string GetErrorMessage(int errorCode)
        {
            const int errorBufferSize = 128;
            sbyte* errorBuffer = stackalloc sbyte[errorBufferSize];
            if (av_strerror(errorCode, errorBuffer, (UIntPtr)errorBufferSize) < 0)
            {
                //errbuf_ptr = strerror(AVUNERROR(err));
            }
            return new string(errorBuffer);
        }
    }
}
