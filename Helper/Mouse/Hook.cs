using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Helper.WinAPI;

namespace Helper.Mouse
{
    public static partial class Mouse
    {
        public class Hook
        {
            private IntPtr _HookId;
            private HookProc hookProc;

            public event MouseDownEventHandler OnMouseLeftButtonDown;
            public event MouseUpEventHandler OnMouseLeftButtonUp;
            public event MouseDownEventHandler OnMouseRightButtonDown;
            public event MouseUpEventHandler OnMouseRightButtonUp;
            public event MouseDownEventHandler OnMouseMiddleButtonDown;
            public event MouseUpEventHandler OnMouseMiddleButtonUp;
            public event MouseDownEventHandler OnMouseXButtonDown;
            public event MouseUpEventHandler OnMouseXButtonUp;
            public event MouseWheeleEventHandler OnMouseWheele;

            public bool IsRunning { get; private set; }

            public Hook(bool start = false)
            {
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
                    _HookId = PInvoke.SetWindowsHookEx((int)HookType.WH_MOUSE_LL, hookProc,
                                                       PInvoke.GetModuleHandle(curModule.ModuleName), 0);
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
                var info = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));



                var process = true;
                var win = PInvoke.GetForegroundWindow();

                switch (WinMsg)
                {
                    case WindowMessages.WM_LBUTTONDOWN:
                        if (OnMouseLeftButtonDown != null)
                            process = OnMouseLeftButtonDown(this,
                                                            new MouseDownEventArgs(MouseButtons.Left, info.pt, win));
                        break;
                    case WindowMessages.WM_LBUTTONUP:
                        if (OnMouseLeftButtonUp != null)
                            process = OnMouseLeftButtonUp(this, new MouseUpEventArgs(MouseButtons.Left, info.pt, win));
                        break;

                    case WindowMessages.WM_RBUTTONDOWN:
                        if (OnMouseRightButtonDown != null)
                            process = OnMouseRightButtonDown(this,
                                                             new MouseDownEventArgs(MouseButtons.Right, info.pt, win));
                        break;
                    case WindowMessages.WM_RBUTTONUP:
                        if (OnMouseRightButtonUp != null)
                            process = OnMouseRightButtonUp(this, new MouseUpEventArgs(MouseButtons.Right, info.pt, win));
                        break;

                    case WindowMessages.WM_MBUTTONDOWN:
                        if (OnMouseMiddleButtonDown != null)
                            process = OnMouseMiddleButtonDown(this,
                                                              new MouseDownEventArgs(MouseButtons.Middle, info.pt, win));
                        break;
                    case WindowMessages.WM_MBUTTONUP:
                        if (OnMouseMiddleButtonUp != null)
                            process = OnMouseMiddleButtonUp(this,
                                                            new MouseUpEventArgs(MouseButtons.Middle, info.pt, win));
                        break;

                    case WindowMessages.WM_XBUTTONDOWN:
                        if (OnMouseXButtonDown != null)
                        {
                            var btnDownData = Utilities.HighWord(info.mouseData);
                            var btnDown = btnDownData == 0x0001 ? MouseButtons.XButton1 : MouseButtons.XButton2;
                            process = OnMouseXButtonDown(this, new MouseDownEventArgs(btnDown, info.pt, win));
                        }
                        break;
                    case WindowMessages.WM_XBUTTONUP:
                        if (OnMouseXButtonUp != null)
                        {
                            var btnUpData = Utilities.HighWord(info.mouseData);
                            var btnUp = btnUpData == 0x0001 ? MouseButtons.XButton1 : MouseButtons.XButton2;
                            process = OnMouseXButtonUp(this, new MouseUpEventArgs(btnUp, info.pt, win));
                        }
                        break;

                    case WindowMessages.WM_MOUSEWHEEL:
                        if (OnMouseWheele != null)
                        {
                            var delta = Utilities.HighWord(info.mouseData);
                            process = OnMouseWheele(this, new MouseWheeleEventArgs(info.pt.x, info.pt.y, delta));
                        }
                        break;
                }

                return process
                           ? PInvoke.CallNextHookEx(_HookId, nCode, wParam, lParam)
                           : (IntPtr)1;
            }
        }
    }
}
