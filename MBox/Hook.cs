using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Helper.Keyboard;
using Helper.Mouse;

namespace MBox
{
    class Hook
    {
        internal static readonly Dictionary<Keys, List<Keys>> keys = new Dictionary<Keys, List<Keys>>();

        internal IntPtr Master { get; set; }
        internal readonly Dictionary<IntPtr, Tuple<KeySender, ClickSender>> Slaves = new Dictionary<IntPtr, Tuple<KeySender, ClickSender>>();

        private readonly KeyboardHook kbHook = new KeyboardHook();
        internal bool KeyboardHookIsRunning { get { return kbHook.IsRunning; } }

        private readonly MouseHook mHook = new MouseHook();
        internal bool MouseHookIsRunning { get { return mHook.IsRunning; } }

        private readonly Action<string, RichLogTextBox.OutputMode> LogCallback;

        public Hook(Action<string, RichLogTextBox.OutputMode> logCallback)
        {
            LogCallback = logCallback;

            kbHook.OnKeyDown += kbHook_OnKeyDown;
            kbHook.OnKeyUp += kbHook_OnKeyUp;

            mHook.OnMouseLeftButtonDown += mHook_OnMouseLeftButtonDown;
            mHook.OnMouseLeftButtonUp += mHook_OnMouseLeftButtonUp;
            mHook.OnMouseRightButtonDown += mHook_OnMouseLeftButtonDown;
            mHook.OnMouseRightButtonUp += mHook_OnMouseLeftButtonUp;
            mHook.OnMouseMiddleButtonDown += mHook_OnMouseLeftButtonDown;
            mHook.OnMouseMiddleButtonUp += mHook_OnMouseLeftButtonUp;
        }

        internal bool Start(Devices device)
        {
            if (Master == IntPtr.Zero || Slaves.Count == 0)
                return false;

            switch (device)
            {
                case Devices.Keyboard:
                    kbHook.Start();
                    LogCallback("Keyboard hook started", RichLogTextBox.OutputMode.Log);
                    break;
                case Devices.Mouse:
                    mHook.Start();
                    LogCallback("Mouse hook started", RichLogTextBox.OutputMode.Log);
                    break;
                case Devices.Both:
                    kbHook.Start();
                    mHook.Start();
                    LogCallback("Keyboard & Mouse hooks started", RichLogTextBox.OutputMode.Log);
                    break;
            }
            return true;
        }

        internal void Stop(Devices device)
        {
            switch (device)
            {
                case Devices.Keyboard:
                    kbHook.Stop();
                    LogCallback("Keyboard hook stopped", RichLogTextBox.OutputMode.Log);
                    break;
                case Devices.Mouse:
                    mHook.Stop();
                    LogCallback("Mouse hook stopped", RichLogTextBox.OutputMode.Log);
                    break;
                case Devices.Both:
                    kbHook.Stop();
                    mHook.Stop();
                    LogCallback("Keyboard & Mouse hooks stopped", RichLogTextBox.OutputMode.Log);
                    break;
            }
        }

        private bool kbHook_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Helper.WinAPI.PInvoke.GetForegroundWindow() == Master)
                if (Settings.Instance.UseShortcuts)
                {
                    List<Keys> kList;
                    if (keys.TryGetValue(e.KeyCode, out kList))
                        foreach (var slave in Slaves)
                        {
                            var sKeys = string.Empty;
                            foreach (var key in kList)
                            {
                                slave.Value.Item1.KeyDown(key);
                                sKeys += key + ", ";
                            }
                            LogCallback(string.Format("Key down : {0}. Sended {1} to 0x{2:X}", e.KeyCode, sKeys.Remove(sKeys.Length - 2), slave.Key.ToInt32()),
                                        RichLogTextBox.OutputMode.Debug);
                        }
                }
                else
                    foreach (var slave in Slaves)
                    {
                        slave.Value.Item1.KeyDown(e.KeyCode);
                        LogCallback(string.Format("Key down : {0}. Sended to 0x{1:X}", e.KeyCode, slave.Key.ToInt32()),
                                    RichLogTextBox.OutputMode.Debug);
                    }

            return true;
        }

        private bool kbHook_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (Helper.WinAPI.PInvoke.GetForegroundWindow() == Master)
                if (Settings.Instance.UseShortcuts)
                {
                    List<Keys> kList;
                    if (keys.TryGetValue(e.KeyCode, out kList))
                        foreach (var slave in Slaves)
                        {
                            var sKeys = string.Empty;
                            foreach (var key in kList)
                            {
                                slave.Value.Item1.KeyUp(key);
                                sKeys += key + ", ";
                            }
                            LogCallback(string.Format("Key up : {0}. Sended {1} to 0x{2:X}", e.KeyCode, sKeys.Remove(sKeys.Length - 2), slave.Key.ToInt32()),
                                        RichLogTextBox.OutputMode.Debug);
                        }
                }
                else
                    foreach (var slave in Slaves)
                    {
                        slave.Value.Item1.KeyUp(e.KeyCode);
                        LogCallback(string.Format("Key up : {0}. Sended to 0x{1:X}", e.KeyCode, slave.Key.ToInt32()),
                                    RichLogTextBox.OutputMode.Debug);
                    }

            return true;
        }


        private bool mHook_OnMouseLeftButtonDown(object sender, MouseDownEventArgs e)
        {
            if (Helper.WinAPI.PInvoke.GetForegroundWindow() == Master)
                foreach (var slave in Slaves)
                {
                    slave.Value.Item2.MouseDown(e.Button, e.X, e.Y);
                    LogCallback(string.Format("Mouse down : {0} ({1};{2}). Sended to 0x{3:X}", e.Button, e.X, e.Y, slave.Key.ToInt32()), RichLogTextBox.OutputMode.Debug);
                }

            return true;
        }

        private bool mHook_OnMouseLeftButtonUp(object sender, MouseUpEventArgs e)
        {
            if (Helper.WinAPI.PInvoke.GetForegroundWindow() == Master)
                foreach (var slave in Slaves)
                {
                    slave.Value.Item2.MouseUp(e.Button, e.X, e.Y);
                    LogCallback(string.Format("Mouse up : {0} ({1};{2}). Sended to 0x{3:X}", e.Button, e.X, e.Y, slave.Key.ToInt32()), RichLogTextBox.OutputMode.Debug);
                }

            return true;
        }

    }
}
