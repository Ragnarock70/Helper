using System.Collections.Generic;
using System.Windows.Forms;
using Helper.WinAPI;

namespace Helper.Keyboard
{
    internal static class KeyBoardHelper
    {
        internal static IEnumerable<Keys> GetModifiers(this Keys key)
        {
            if (key.HasFlag(Keys.Alt))
                yield return Keys.Menu;
            if (key.HasFlag(Keys.Control))
                yield return Keys.ControlKey;
            if (key.HasFlag(Keys.Shift))
                yield return Keys.ShiftKey;
        }

        internal static byte MapToScanCode(Keys key)
        {
            var vKey = key & Keys.KeyCode;
            return (byte)PInvoke.MapVirtualKey(vKey, MapVirtualKeyMapTypes.MAPVK_VK_TO_VSC);
        }

        internal static Keys MapToVirtualKey(char c)
        {
            var vkey = PInvoke.VkKeyScan(c);
            var ret = (Keys)(vkey & 0xff);
            var modifiers = vkey >> 8;

            if ((modifiers & 1) != 0)
                ret |= Keys.Shift;
            if ((modifiers & 2) != 0)
                ret |= Keys.Control;
            if ((modifiers & 4) != 0)
                ret |= Keys.Alt;

            return ret;
        }
    }
}
