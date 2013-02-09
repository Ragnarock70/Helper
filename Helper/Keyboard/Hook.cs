using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Helper.WinAPI;

namespace Helper.Keyboard
{
    public delegate bool KeyEventHandler(object sender, KeyEventArgs e);

    public class Hook
    {
        private IntPtr _HookId;
        private HookProc hookProc;

        public bool InterceptKeys { get; set; }
        public bool IsRunning { get; private set; }
        public event KeyEventHandler OnKeyDown;
        public event KeyEventHandler OnKeyUp;

        public Hook(bool interceptKeys, bool start = false)
        {
            InterceptKeys = interceptKeys;

            if (start)
                Start();
        }

        ~Hook()
        {
            Stop();
        }

        public bool Start()
        {
            if (IsRunning)
                return true;

            hookProc = HookCallBack;

            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                _HookId = PInvoke.SetWindowsHookEx((int)HookType.WH_KEYBOARD_LL, hookProc, PInvoke.GetModuleHandle(curModule.ModuleName), 0);
            }
            return IsRunning = _HookId != IntPtr.Zero;
        }

        public bool Stop()
        {
            if (!IsRunning || _HookId == IntPtr.Zero)
                return true;

            IsRunning = !PInvoke.UnhookWindowsHookEx(_HookId);
            return !IsRunning;
        }

        private IntPtr HookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
                return PInvoke.CallNextHookEx(_HookId, nCode, wParam, lParam);

            var WinMsg = (WindowMessages)wParam;
            var info = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));

            var process = true;

            if (WinMsg == WindowMessages.WM_KEYDOWN ||
                WinMsg == WindowMessages.WM_SYSKEYDOWN)
            {
                if (OnKeyDown != null)
                    process = OnKeyDown(this, new KeyEventArgs((Keys)info.vkCode));
            }
            else if (OnKeyUp != null)
                process = OnKeyUp(this, new KeyEventArgs((Keys)info.vkCode));

            return process ? PInvoke.CallNextHookEx(_HookId, nCode, wParam, lParam)
                           : (IntPtr)1;
        }
    }
}
