#region File Header
/*[ Compilation unit ----------------------------------------------------------
 
   Component       : ScreenRecorderMP
 
   Name            : Win32Api.cs
 
  Author           : Sunil
 
-----------------------------------------------------------------------------*/
/*] END */
#endregion

using System;
using System.Runtime.InteropServices;

namespace ScreenRecorder
{
    
    /// <summary>
    /// Wrapper for windows 32 calls.
    /// </summary>
    public class Win32Api
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct PCURSORINFO
        {
            public Int32 Size;
            public Int32 Flags;
            public IntPtr Cursor;
            public POINTAPI ScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorInfo(out PCURSORINFO cinfo);

        [DllImport("user32.dll")]
        public static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        [DllImport("winmm.dll")]
        private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);
 


        public const Int32 CURSOR_SHOWING = 0x00000001;
    } // class Win32
}
