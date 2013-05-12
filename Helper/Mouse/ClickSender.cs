using System;
using System.Windows.Forms;
using Helper.WinAPI;

namespace Helper.Mouse
{
    public class ClickSender
    {
        public IntPtr hWnd { get; set; }

        public ClickSender(IntPtr winHandle)
        {
            hWnd = winHandle;
        }

        public void MouseDown(MouseButtons btn, int x, int y)
        {
            var msg = WindowMessages.WM_NULL;
            switch (btn)
            {
                case MouseButtons.Left:
                    msg = WindowMessages.WM_LBUTTONDOWN;
                    break;
                case MouseButtons.Right:
                    msg = WindowMessages.WM_RBUTTONDOWN;
                    break;
                case MouseButtons.Middle:
                    msg = WindowMessages.WM_MBUTTONDOWN;
                    break;
                case MouseButtons.XButton1: //TODO: SEPARATE THEM
                case MouseButtons.XButton2:
                    msg = WindowMessages.WM_XBUTTONDOWN;
                    break;
            }
            PInvoke.PostMessage(hWnd, msg, IntPtr.Zero, new UIntPtr((uint)LowWord(x, y)));
        }

        public void MouseUp(MouseButtons btn, int x, int y)
        {
            var msg = WindowMessages.WM_NULL;
            switch (btn)
            {
                case MouseButtons.Left:
                    msg = WindowMessages.WM_LBUTTONUP;
                    break;
                case MouseButtons.Right:
                    msg = WindowMessages.WM_RBUTTONUP;
                    break;
                case MouseButtons.Middle:
                    msg = WindowMessages.WM_MBUTTONUP;
                    break;
                case MouseButtons.XButton1:
                case MouseButtons.XButton2:
                    msg = WindowMessages.WM_XBUTTONUP;
                    break;
            }
            PInvoke.PostMessage(hWnd, msg, IntPtr.Zero, new UIntPtr((uint)LowWord(x, y)));
        }


        private static int LowWord(int number, int newValue)
        {
            return (int)((number & 0xFFFF0000) + (newValue & 0x0000FFFF));
        }

        private static int HighWord(int number, int newValue)
        {
            return (number & 0x0000FFFF) + (newValue << 16);
        }
    }
}
