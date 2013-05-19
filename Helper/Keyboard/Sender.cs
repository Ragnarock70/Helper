//-----------------------
// Copyright © Ragnarock
//----------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helper.WinAPI;

namespace Helper.Keyboard
{
    public static partial class Keyboard
    {
        public static class Sender
        {
            private static readonly HashSet<Keys> keysPressed = new HashSet<Keys>();


            public static void Send(IntPtr hWnd, string msg)
            {
                foreach (var k in msg.Select(Utilities.MapToVirtualKey))
                    KeyPress(hWnd, k);
            }

            public static void KeyPress(IntPtr hWnd, Keys key)
            {
                //var modKeys = key.GetModifiers().ToArray();

                //foreach (var mod in modKeys)
                //    KeyDown(mod);

                KeyDown(hWnd, key);
                KeyUp(hWnd, key);

                //foreach (var mod in modKeys)
                //    KeyUp(mod);
            }

            public static void KeyDown(IntPtr hWnd, Keys key)
            {
                if (hWnd == IntPtr.Zero)
                    throw new ArgumentNullException("hWnd");

                var wParam = new IntPtr((int)(key & Keys.KeyCode)); //VK
                var lParam = LParam(key, 1, false);
                PInvoke.PostMessage(hWnd, WindowMessages.WM_KEYDOWN, wParam, lParam);
                keysPressed.Add(key);
            }

            public static void KeyUp(IntPtr hWnd, Keys key)
            {
                if (hWnd == IntPtr.Zero)
                    throw new ArgumentNullException("hWnd");

                var wParam = new IntPtr((int)(key & Keys.KeyCode)); //VK
                var lParam = LParam(key, 1, true);
                PInvoke.PostMessage(hWnd, WindowMessages.WM_KEYUP, wParam, lParam);
                keysPressed.Remove(key);
            }

            private static UIntPtr LParam(Keys key, uint repeat, bool keyUp)
            {
                var ret = repeat | (uint)Utilities.MapToScanCode(key) << 16;

                if (keysPressed.Contains(key))
                    ret |= 0x40000000; //prev key state = 1
                if (keyUp)
                    ret |= 0x80000000; //transition state = 1

                return new UIntPtr(ret);
            }
        }
    }
}