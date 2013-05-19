//-----------------------
// Copyright © Ragnarock
//----------------------

using System;
using System.Drawing;
using System.Windows.Forms;
using Helper.WinAPI;

namespace Helper.Mouse
{
    public delegate bool MouseDownEventHandler(object sender, MouseDownEventArgs e);
    public delegate bool MouseUpEventHandler(object sender, MouseUpEventArgs e);
    public delegate bool MouseWheeleEventHandler(object sender, MouseWheeleEventArgs e);

    public class MouseDownEventArgs : EventArgs
    {
        public MouseButtons Button { get; private set; }
        public IntPtr WindowHandle { get; private set; }
        public Point ScreenPoint { get; private set; }
        public Point WindowPoint { get; private set; }

        public MouseDownEventArgs(MouseButtons button, POINT pt, IntPtr hWnd)
        {
            Button = button;
            ScreenPoint = new Point(pt.x, pt.y);

            if (hWnd == IntPtr.Zero)
                return;

            WindowHandle = hWnd;
            PInvoke.ScreenToClient(hWnd, ref pt);
            WindowPoint = new Point(pt.x, pt.y);
        }
    }

    public class MouseUpEventArgs : EventArgs
    {
        public MouseButtons Button { get; private set; }
        public IntPtr WindowHandle { get; private set; }
        public Point ScreenPoint { get; private set; }
        public Point WindowPoint { get; private set; }

        public MouseUpEventArgs(MouseButtons button, POINT pt, IntPtr hWnd)
        {
            Button = button;
            ScreenPoint = new Point(pt.x, pt.y);

            if (hWnd == IntPtr.Zero)
                return;

            WindowHandle = hWnd;
            PInvoke.ScreenToClient(hWnd, ref pt);
            WindowPoint = new Point(pt.x, pt.y);
        }
    }

    public class MouseWheeleEventArgs : EventArgs
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Delta { get; private set; }

        public MouseWheeleEventArgs(int x, int y, int delta)
        {
            X = x;
            Y = y;
            Delta = delta;
        }
    }
}
