using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helper.WinAPI;

namespace Helper.Keyboard
{
    public class KeySender
    {
        public IntPtr hWnd { get; set; }
        private readonly HashSet<Keys> keysPressed = new HashSet<Keys>();

        public KeySender(IntPtr winHandle)
        {
            hWnd = winHandle;
        }

        public void Send(string msg)
        {
            foreach (var k in msg.Select(KeyboardHelper.MapToVirtualKey))
                KeyPress(k);
        }

        public void KeyPress(Keys key)
        {
            //var modKeys = key.GetModifiers().ToArray();

            //foreach (var mod in modKeys)
            //    KeyDown(mod);

            KeyDown(key);
            KeyUp(key);

            //foreach (var mod in modKeys)
            //    KeyUp(mod);
        }

        public void KeyDown(Keys key)
        {
            var wParam = new IntPtr((int)(key & Keys.KeyCode)); //VK
            var lParam = LParam(key, 1, false);
            PInvoke.PostMessage(hWnd, WindowMessages.WM_KEYDOWN, wParam, lParam);
            keysPressed.Add(key);
        }

        public void KeyUp(Keys key)
        {
            var wParam = new IntPtr((int)(key & Keys.KeyCode)); //VK
            var lParam = LParam(key, 1, true);
            PInvoke.PostMessage(hWnd, WindowMessages.WM_KEYUP, wParam, lParam);
            keysPressed.Remove(key);
        }


        private UIntPtr LParam(Keys key, uint repeat, bool keyUp)
        {
            var ret = repeat | (uint)KeyboardHelper.MapToScanCode(key) << 16;

            if (keysPressed.Contains(key))
                ret |= 0x40000000; //prev key state = 1
            if (keyUp)
                ret |= 0x80000000; //transition state = 1

            return new UIntPtr(ret);
        }

    }
}
