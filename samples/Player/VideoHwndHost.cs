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
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace Player
{
    internal sealed class VideoHwndHost : HwndHost
    {
        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            var windowHandle = CreateWindowEx(
                ExtendedWindowStyle.WS_EX_TRANSPARENT,
                "static",
                string.Empty,
                WindowStyle.WS_CHILD | WindowStyle.WS_VISIBLE,
                0,
                0,
                0,
                0,
                hwndParent.Handle,
                IntPtr.Zero,
                IntPtr.Zero,
                IntPtr.Zero);

            return new HandleRef(this, windowHandle);
        }

        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            DestroyWindow(hwnd.Handle);
        }

        [Flags]
        private enum ExtendedWindowStyle : int
        {
            WS_EX_TRANSPARENT = 0x00000020
        }

        [Flags]
        private enum WindowStyle : int
        {
            WS_CHILD = 0x40000000,

            WS_VISIBLE = 0x10000000
        }


        [DllImport("user32.dll")]
        private static extern IntPtr CreateWindowEx(ExtendedWindowStyle dwExStyle,
                string lpszClassName,
                string lpszWindowName,
                WindowStyle style,
                int x, int y, int width, int height,
                IntPtr hwndParent,
                IntPtr hMenu,
                IntPtr hInst,
                IntPtr lpParam);


        [DllImport("user32.dll")]
        private static extern bool DestroyWindow(IntPtr hwnd);

    }
}
