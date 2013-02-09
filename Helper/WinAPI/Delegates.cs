using System;

namespace Helper.WinAPI
{
    internal delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
}
