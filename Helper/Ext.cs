using System.Collections.Generic;
using System.Windows.Forms;

namespace Helper
{
    internal static class Ext
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
    }
}
