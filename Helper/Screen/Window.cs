//-----------------------
// Copyright © Ragnarock
//----------------------

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Helper.WinAPI;

namespace Helper.Screen
{
    public static partial class Screen
    {
        public static class Window
        {

            /// <summary>
            /// Draw a rectangle over a window.
            /// </summary>
            /// <param name="hWnd">Window's handle.</param>
            /// <param name="color">Rectangle's color.</param>
            /// 
            /// <!-- Source: http://www.codegod.com/find-window-and-highlight-it-with-win32-AID140.aspx -->
            public static void DrawRectangle(IntPtr hWnd, Color color)
            {
                const float penWidth = 2F;

                var rc = new RECT();
                PInvoke.GetWindowRect(hWnd, ref rc);

                var hDC = PInvoke.GetWindowDC(hWnd);

                if (hDC != IntPtr.Zero)
                {
                    using (var pen = new Pen(color, penWidth))
                    {
                        using (var g = Graphics.FromHdc(hDC))
                        {
                            var transp1 = Color.FromArgb(122, color.R, color.G, color.B);
                            var transp2 = Color.Transparent;
                            var rect = new Rectangle(0, 0, rc.Right - rc.Left - (int)penWidth,
                                                     rc.Bottom - rc.Top - (int)penWidth);

                            var transBrush = new LinearGradientBrush(rect, transp2, transp1, 45, true);
                            g.DrawRectangle(pen, rect);
                            g.FillRectangle(transBrush, rect);


                        }
                    }
                }
                PInvoke.ReleaseDC(hWnd, hDC);
            }

            /// <summary>
            /// Redraw a window.
            /// </summary>
            /// <param name="hWnd">Window's handle.</param>
            public static void ClearRectangle(IntPtr hWnd)
            {
                PInvoke.InvalidateRect(hWnd, IntPtr.Zero, 1);

                PInvoke.UpdateWindow(hWnd);

                PInvoke.RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero,
                                     RedrawWindowFlags.Frame | RedrawWindowFlags.Invalidate |
                                     RedrawWindowFlags.UpdateNow | RedrawWindowFlags.AllChildren);
            }

            public static void Move(IntPtr hWnd, int x, int y)
            {
                PInvoke.SetWindowPos(hWnd, IntPtr.Zero, x, y, 0, 0,
                                     SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER |
                                     SetWindowPosFlags.SWP_NOACTIVATE);
            }

            public static void Resize(IntPtr hWnd, int width, int height)
            {
                PInvoke.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, width, height,
                                     SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER |
                                     SetWindowPosFlags.SWP_NOACTIVATE);
            }

            public static void BringToTop(IntPtr hWnd)
            {
                PInvoke.SetForegroundWindow(hWnd);
            }

            public static Rectangle GetWindowRectangle(IntPtr hWnd)
            {
                var placement = new WINDOWPLACEMENT();
                placement.length = Marshal.SizeOf(placement);
                PInvoke.GetWindowPlacement(hWnd, ref placement);

                return placement.rcNormalPosition;
            }
        }
    }
}
