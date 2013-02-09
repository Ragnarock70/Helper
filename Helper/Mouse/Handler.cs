using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helper.Mouse
{
    public delegate bool MouseDownEventHandler(object sender, MouseDownEventArgs e);

    public class MouseDownEventArgs : EventArgs
    {
        public MouseButtons Button { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

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
        public MouseButtons Button { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

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
        public int X { get; set; }
        public int Y { get; set; }
        public int Delta { get; set; }

        public MouseWheeleEventArgs(int x, int y, int delta)
        {
            X = x;
            Y = y;
            Delta = delta;
        }
    }
}
