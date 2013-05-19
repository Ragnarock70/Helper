using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Helper.WinAPI;

namespace Helper.Mouse
{
    public static partial class Mouse
    {
        public static class Sender
        {
            public static void Click(IntPtr hWnd, MouseButtons btn, int x, int y)
            {
                var wParam = Utilities.GetWParam(btn);
                var lParam = Utilities.GetLParam(x, y);

                //var tID = GetWindowThreadProcessId(hWnd, IntPtr.Zero);

                //PostThreadMessage(tID, Utilities.GetDownMessage(btn), wParam, lParam);
                //PostThreadMessage(tID, Utilities.GetUpMessage(btn), wParam, lParam);

                PInvoke.PostMessage(hWnd, Utilities.GetDownMessage(btn), wParam, lParam);
                PInvoke.PostMessage(hWnd, Utilities.GetUpMessage(btn), wParam, lParam);
            }

            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool PostThreadMessage(uint threadId, WindowMessages msg, IntPtr wParam, UIntPtr lParam);

            [DllImport("user32.dll")]
            private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

            public static void MouseDown(IntPtr hWnd, MouseButtons btn, int x, int y)
            {
                PInvoke.PostMessage(hWnd, Utilities.GetDownMessage(btn), Utilities.GetWParam(btn), Utilities.GetLParam(x, y));
            }

            public static void MouseUp(IntPtr hWnd, MouseButtons btn, int x, int y)
            {
                PInvoke.PostMessage(hWnd, Utilities.GetUpMessage(btn), Utilities.GetWParam(btn), Utilities.GetLParam(x, y));
            }
        }
    }
}

