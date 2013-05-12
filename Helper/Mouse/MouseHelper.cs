using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Helper.WinAPI;

namespace Helper.Mouse
{
    public static class MouseHelper
    {
        public static POINT GetMousePos()
        {
            POINT p;
            PInvoke.GetCursorPos(out p);
            return p;
        }

        public static IntPtr GetMouseHoverWindowHandle()
        {
            return PInvoke.WindowFromPoint(GetMousePos());
        }

        public static IntPtr DrawMouseHoverWindowRect()
        {
            var hWnd = GetMouseHoverWindowHandle();
            DrawRect(hWnd);
            return hWnd;
        }


        //http://www.codegod.com/find-window-and-highlight-it-with-win32-AID140.aspx
        public static void DrawRect(IntPtr hWnd)
        {
            const float penWidth = 2F;

            var rc = new RECT();
            PInvoke.GetWindowRect(hWnd, ref rc);

            var hDC = PInvoke.GetWindowDC(hWnd);

            if (hDC != IntPtr.Zero)
            {
                using (var pen = new Pen(Color.Red, penWidth))
                {
                    using (var g = Graphics.FromHdc(hDC))
                    {
                        var transp1 = Color.FromArgb(75, 255, 0, 0);
                        var transp2 = Color.Transparent;
                        var rect = new Rectangle(0, 0, rc.Right - rc.Left - (int)penWidth, rc.Bottom - rc.Top - (int)penWidth);

                        var transBrush = new LinearGradientBrush(rect, transp2, transp1, 45, true);
                        g.DrawRectangle(pen, rect);
                        g.FillRectangle(transBrush, rect);


                    }
                }
            }
            PInvoke.ReleaseDC(hWnd, hDC);
        }
        
        public static void ClearRect(IntPtr hWnd)
        {
            PInvoke.InvalidateRect(hWnd, IntPtr.Zero, 1);

            PInvoke.UpdateWindow(hWnd);

            PInvoke.RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero,
                                 RedrawWindowFlags.Frame | RedrawWindowFlags.Invalidate |
                                 RedrawWindowFlags.UpdateNow | RedrawWindowFlags.AllChildren);

        }
    }
}
