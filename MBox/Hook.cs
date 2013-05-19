//-----------------------
// Copyright © Ragnarock
//----------------------

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
        internal readonly List<IntPtr> Slaves = new List<IntPtr>();

        private readonly Keyboard.Hook kbHook = new Keyboard.Hook();
        internal bool KeyboardHookIsRunning { get { return kbHook.IsRunning; } }

        private readonly Mouse.Hook mHook = new Mouse.Hook();
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
                                Keyboard.Sender.KeyDown(slave, key);
                                sKeys += key + ", ";
                            }
                            LogCallback(string.Format("Key down : {0}. Sended {1} to 0x{2:X}", e.KeyCode, sKeys.Remove(sKeys.Length - 2), slave.ToInt32()),
                                        RichLogTextBox.OutputMode.Debug);
                        }
                }
                else
                    foreach (var slave in Slaves)
                    {
                        Keyboard.Sender.KeyDown(slave, e.KeyCode);
                        LogCallback(string.Format("Key down : {0}. Sended to 0x{1:X}", e.KeyCode, slave.ToInt32()),
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
                                Keyboard.Sender.KeyUp(slave, key);
                                sKeys += key + ", ";
                            }
                            LogCallback(string.Format("Key up : {0}. Sended {1} to 0x{2:X}", e.KeyCode, sKeys.Remove(sKeys.Length - 2), slave.ToInt32()),
                                        RichLogTextBox.OutputMode.Debug);
                        }
                }
                else
                    foreach (var slave in Slaves)
                    {
                        Keyboard.Sender.KeyUp(slave, e.KeyCode);
                        LogCallback(string.Format("Key up : {0}. Sended to 0x{1:X}", e.KeyCode, slave.ToInt32()),
                                    RichLogTextBox.OutputMode.Debug);
                    }

            return true;
        }

        //TODO: NOT RUNNING
        private bool mHook_OnMouseLeftButtonDown(object sender, MouseDownEventArgs e)
        {
            if (Helper.WinAPI.PInvoke.GetForegroundWindow() == Master)
                foreach (var slave in Slaves)
                {
                    //Mouse.Sender.MouseDown(slave, e.Button, e.WindowPoint.X, e.WindowPoint.Y);
                    LogCallback(string.Format("Mouse down : {0} ({1};{2}). Sended to 0x{3:X}", e.Button, e.WindowPoint.X, e.WindowPoint.Y, slave.ToInt32()), RichLogTextBox.OutputMode.Debug);
                }

            return true;
        }

        private bool mHook_OnMouseLeftButtonUp(object sender, MouseUpEventArgs e)
        {
            if (Helper.WinAPI.PInvoke.GetForegroundWindow() == Master)
                foreach (var slave in Slaves)
                {
                    //Mouse.Sender.MouseUp(slave, e.Button, e.WindowPoint.X, e.WindowPoint.Y);
                    Mouse.Sender.Click(slave, e.Button, e.WindowPoint.X, e.WindowPoint.Y);
                    LogCallback(string.Format("Mouse up : {0} ({1};{2}). Sended to 0x{3:X}", e.Button, e.WindowPoint.X, e.WindowPoint.Y, slave.ToInt32()), RichLogTextBox.OutputMode.Debug);
                }

            return true;
        }

    }
}
