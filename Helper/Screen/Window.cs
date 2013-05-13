using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Helper.WinAPI;

namespace Helper.Screen
{
    public static class Window
    {
        public static void Move(int x, int y, IntPtr hWnd)
        {
            PInvoke.SetWindowPos(hWnd, IntPtr.Zero, x, y, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOACTIVATE);
        }

        public static void Resize(int width, int height, IntPtr hWnd)
        {
            PInvoke.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, width, height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOACTIVATE);
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
