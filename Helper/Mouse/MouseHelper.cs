using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
