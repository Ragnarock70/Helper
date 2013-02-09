using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Helper.WinAPI
{
    internal static class PInvoke
    {
        public static List<string> sended = new List<string>();
        [DllImport("user32", SetLastError = true, EntryPoint = "PostMessage")]
        internal extern static bool PostMessage2(IntPtr hWnd, WindowMessages message, IntPtr wParam, UIntPtr lParam);

        internal static bool PostMessage(IntPtr hWnd, WindowMessages message, IntPtr wParam, UIntPtr lParam)
        {
            sended.Add(string.Format("MSG: {0}\twParam: {1:X}\tlParam: {2:X}", message, wParam.ToInt32(), lParam.ToUInt32()));
            return PostMessage2(hWnd, message, wParam, lParam);
        }

        internal static void Save()
        {
            File.WriteAllLines("C:\\Bad.txt", sended);
        }

        [DllImport("user32.dll")]
        internal static extern uint MapVirtualKey(Keys uCode, MapVirtualKeyMapTypes uMapType);

        [DllImport("user32")]
        internal extern static short VkKeyScan(char c);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(int idHook,
            HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        internal static extern IntPtr WindowFromPoint(POINT Point);

        [DllImport("user32.dll")]
        internal static extern bool GetCursorPos(out POINT lpPoint);
    }
}
