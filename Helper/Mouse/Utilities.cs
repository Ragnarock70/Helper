using System;
using System.Drawing;
using System.Windows.Forms;
using Helper.WinAPI;

namespace Helper.Mouse
{
    public static partial class Mouse
    {
        public static class Utilities
        {
            #region Public

            /// <summary>
            /// Gets the current mouse position.
            /// </summary>
            /// <returns>A POINT with the mouse coordinates.</returns>
            public static POINT GetMousePos()
            {
                POINT p;
                PInvoke.GetCursorPos(out p);
                return p;
            }

            /// <summary>
            /// Gets the mouse hover's window.
            /// </summary>
            /// <returns>The mouse hover's window.</returns>
            public static IntPtr GetMouseHoverWindowHandle()
            {
                return PInvoke.WindowFromPoint(GetMousePos());
            }

            /// <summary>
            /// Draw a rectangle over the mouse hover's window.
            /// </summary>
            /// <param name="c">Rectangle's color.</param>
            /// <returns>Handle to the window</returns>
            public static IntPtr DrawMouseHoverWindowRect(Color c)
            {
                var hWnd = GetMouseHoverWindowHandle();
                Screen.Screen.Window.DrawRectangle(hWnd, c);
                return hWnd;
            }

            #endregion

            #region internal

            #region WindowMessages

            internal static WindowMessages GetDownMessage(MouseButtons btn)
            {
                switch (btn)
                {
                    case MouseButtons.Left:
                        return WindowMessages.WM_LBUTTONDOWN;
                    case MouseButtons.Right:
                        return WindowMessages.WM_RBUTTONDOWN;
                    case MouseButtons.Middle:
                        return WindowMessages.WM_MBUTTONDOWN;
                    case MouseButtons.XButton1:
                    case MouseButtons.XButton2:
                        return WindowMessages.WM_XBUTTONDOWN;
                    default:
                        return WindowMessages.WM_NULL;
                }
            }

            internal static WindowMessages GetUpMessage(MouseButtons btn)
            {
                switch (btn)
                {
                    case MouseButtons.Left:
                        return WindowMessages.WM_LBUTTONUP;
                    case MouseButtons.Right:
                        return WindowMessages.WM_RBUTTONUP;
                    case MouseButtons.Middle:
                        return WindowMessages.WM_MBUTTONUP;
                    case MouseButtons.XButton1:
                    case MouseButtons.XButton2:
                        return WindowMessages.WM_XBUTTONUP;
                    default:
                        return WindowMessages.WM_NULL;
                }
            }

            #endregion

            #region wParam/lParam

            internal static IntPtr GetWParam(MouseButtons btn)
            {
                switch (btn)
                {
                    case MouseButtons.XButton1:
                        return new IntPtr(0x00000001);
                    case MouseButtons.XButton2:
                        return new IntPtr(0x00000002);
                    default:
                        return IntPtr.Zero;
                }
            }

            internal static UIntPtr GetLParam(int x, int y)
            {
                return new UIntPtr((uint)Utilities.LowWord(x, y));
            }

            #endregion

            #region Word

            internal static short HighWord(object value)
            {
                return (short)((int)value >> 16);
            }

            internal static int HighWord(int number, int newValue)
            {
                return (number & 0x0000FFFF) + (newValue << 16);
            }

            internal static short LowWord(object value)
            {
                return (short)value;
            }

            internal static int LowWord(int number, int newValue)
            {
                return (int)((number & 0xFFFF0000) + (newValue & 0x0000FFFF));
            }

            #endregion

            #endregion
        }
    }
}