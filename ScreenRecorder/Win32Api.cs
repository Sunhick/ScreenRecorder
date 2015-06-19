// This file is part of ScreenRecorder
//  
// ScreenRecorder  is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// ScreenRecorder is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with ScreenRecorder.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Runtime.InteropServices;

namespace ScreenRecorder
{
    /// <summary>
    ///     Hook proc
    /// </summary>
    /// <param name="nCode"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    public delegate int HookProc(int nCode, int wParam, keyboardHookStruct lParam);

    /// <summary>
    ///     Pcursor info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PCURSORINFO
    {
        public Int32 Size;
        public Int32 Flags;
        public IntPtr Cursor;
        public POINTAPI ScreenPos;
    }

    /// <summary>
    ///     Point
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINTAPI
    {
        public int x;
        public int y;
    }

    /// <summary>
    ///     keyboard hook struct
    /// </summary>
    public struct keyboardHookStruct
    {
        public int dwExtraInfo;
        public int flags;
        public int scanCode;
        public int time;
        public int vkCode;
    }

    /// <summary>
    ///     Wrapper for windows 32 calls.
    /// </summary>
    public class Win32Api
    {
        public const Int32 CURSOR_SHOWING = 0x00000001;
        public const int WH_KEYBOARD_LL = 13;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_SYSKEYDOWN = 0x104;
        public const int WM_SYSKEYUP = 0x105;

        [DllImport("user32.dll")]
        public static extern bool GetCursorInfo(out PCURSORINFO cinfo);

        [DllImport("user32.dll")]
        public static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        [DllImport("winmm.dll")]
        private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);

        [DllImport("user32")]
        private static extern int GetKeyboardState(byte[] pbKeyState);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern short GetKeyState(int vKey);

        [DllImport("user32")]
        public static extern int ToAscii(
            int uVirtKey,
            int uScanCode,
            byte[] lpbKeyState,
            byte[] lpwTransKey,
            int fuState);

        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(
            IntPtr idHook,
            int nCode,
            int wParam,
            ref keyboardHookStruct lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(
            int idHook,
            HookProc lpfn,
            IntPtr hMod,
            int dwThreadId);

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        //Constants
    } // class Win32
}