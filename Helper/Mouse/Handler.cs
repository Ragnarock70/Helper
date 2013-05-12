using System;
using System.Windows.Forms;

namespace Helper.Mouse
{
    public delegate bool MouseDownEventHandler(object sender, MouseDownEventArgs e);

    public class MouseDownEventArgs : EventArgs
    {
        public MouseButtons Button { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public MouseDownEventArgs(MouseButtons button, int x, int y)
        {
            Button = button;
            X = x;
            Y = y;
        }
    }

    public delegate bool MouseUpEventHandler(object sender, MouseUpEventArgs e);

    public class MouseUpEventArgs : EventArgs
    {
        public MouseButtons Button { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public MouseUpEventArgs(MouseButtons button, int x, int y)
        {
            Button = button;
            X = x;
            Y = y;
        }
    }

    public delegate bool MouseWheeleEventHandler(object sender, MouseWheeleEventArgs e);

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
