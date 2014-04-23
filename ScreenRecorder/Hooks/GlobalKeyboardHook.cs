using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using log4net;
using System.ComponentModel;
using System.Windows.Forms;

namespace ScreenRecorder.Hooks
{
    public class GlobalKeyboardHook
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GlobalKeyboardHook).Name);

        public List<Keys> HookedKeys = new List<Keys>();

        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;
        private static HookProc keyboardProcHook;
        private IntPtr keyboardHook = IntPtr.Zero;

        /// <summary>
        /// ctor
        /// </summary>
        public GlobalKeyboardHook()
        {
            Hook();
        }

        /// <summary>
        /// Keyboard hook proc
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private int KeyboardHookProc(int nCode, int wParam, keyboardHookStruct lParam)
        {
            if (nCode >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                if (HookedKeys.Contains(key))
                {
                    KeyEventArgs kArgs = new KeyEventArgs(key);
                    if ((wParam == Win32Api.WM_KEYDOWN || wParam == Win32Api.WM_SYSKEYDOWN) && (KeyDown != null))
                    {
                        KeyDown(this, kArgs);
                    }
                    else if ((wParam == Win32Api.WM_KEYUP || wParam == Win32Api.WM_SYSKEYUP) && (KeyUp != null))
                    {
                        KeyUp(this, kArgs);
                    }
                    if (kArgs.Handled)
                        return 1;
                }
            }
            return Win32Api.CallNextHookEx(keyboardHook, nCode, wParam, ref lParam);
        }

        /// <summary>
        /// subscribe for Keyboard hook
        /// </summary>
        public void Hook()
        {

            // Create an instance of HookProc.
            keyboardProcHook = new HookProc(KeyboardHookProc);

            IntPtr hInstance = Win32Api.LoadLibrary("User32");

            //install hook
            keyboardHook = Win32Api.SetWindowsHookEx(
                Win32Api.WH_KEYBOARD_LL,
                keyboardProcHook,
                hInstance,
                0);

            //If SetWindowsHookEx fails.
            if (keyboardHook == IntPtr.Zero)
            {
                //Returns the error code returned by the last unmanaged function called using platform invoke that has the DllImportAttribute.SetLastError flag set. 
                int errorCode = Marshal.GetLastWin32Error();

                log.Error("Unable to install keyboard hook.", new Win32Exception(errorCode));
            }
        }

        /// <summary>
        /// Unsubscribe for keyboard hook 
        /// </summary>
        public void Unhook()
        {
            if (keyboardHook != IntPtr.Zero)
            {
                //uninstall hook
                int retKeyboard = Win32Api.UnhookWindowsHookEx(keyboardHook);
                //reset invalid handle
                keyboardHook = IntPtr.Zero;
                //if failed and exception must be thrown
                if (retKeyboard == 0)
                {
                    //Returns the error code returned by the last unmanaged function called using platform invoke that has the DllImportAttribute.SetLastError flag set. 
                    int errorCode = Marshal.GetLastWin32Error();
                    //Initializes and throws a new instance of the Win32Exception class with the specified error. 
                    log.Error("Error while uninstalling keyboard hook", new Win32Exception(errorCode));
                }
            }
        }


    }
}
