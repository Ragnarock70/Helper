using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Helper.Keyboard;
using Helper.Mouse;

namespace MBox
{
    public partial class Form1 : Form
    {
        private Hook hook;
        private bool IsRunning;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hook = new Hook(rltbOutput.Log);
            
            LoadSettings();

            rltbOutput.WriteRandomShit();
            rltbOutput.WriteQuote();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            hook.Stop(Devices.Both);

            SaveShortcuts();
        }

        private void miQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Main
        private void btnMainWindow_Click(object sender, EventArgs e)
        {
            btnMainWindow.Enabled = false;
            btnSecondaryWindow.Enabled = false;

            new Thread(() =>
            {
                rltbOutput.Log("You have 5 seconds to focus the master window");

                for (int i = 4; i > 0; i--)
                {
                    Thread.Sleep(1000);
                    rltbOutput.Log(i + "...");
                }

                Thread.Sleep(1000);
                var hWnd = Helper.WinAPI.PInvoke.GetForegroundWindow();

                var add = ".";
                if (hook.Slaves.Keys.Contains(hWnd))
                {
                    hook.Slaves.Remove(hWnd);
                    add = " (removed from slaves' list of course).";
                }
                else if (hook.Master == hWnd)
                    add = " (it was already this window, you lost 5 seconds of your life, plus 2 to read that :) ).";

                hook.Master = hWnd;

                rltbOutput.Log(string.Format("You choose '{0}' (0x{1:X}) as master{2}",
                                             Helper.WinAPI.PInvoke.GetText(hook.Master), hook.Master.ToInt32(), add));

                InvokeAction(() =>
                {
                    btnMainWindow.Enabled = true;
                    btnSecondaryWindow.Enabled = true;
                });
            }) { IsBackground = true, Name = "Add master" }.Start();
        }

        private void btnSecondaryWindow_Click(object sender, EventArgs e)
        {
            btnMainWindow.Enabled = false;
            btnSecondaryWindow.Enabled = false;

            new Thread(() =>
            {
                rltbOutput.Log("You have 3 seconds to focus the slave window");

                for (int i = 2; i > 0; i--)
                {
                    Thread.Sleep(1000);
                    rltbOutput.Log(i + "...");
                }

                Thread.Sleep(1000);
                var hWnd = Helper.WinAPI.PInvoke.GetForegroundWindow();

                TryAddSlave(hWnd);

                InvokeAction(() =>
                {
                    btnStart.Enabled = true;
                    btnMainWindow.Enabled = true;
                    btnSecondaryWindow.Enabled = true;
                });
            }) { IsBackground = true, Name = "Add slave" }.Start();
        }

        private void TryAddSlave(IntPtr hWnd)
        {
            if (hook.Master == hWnd)
            {
                rltbOutput.Log("Err... You cannot be slave and master at the same time. Neither do windows :)", RichLogTextBox.OutputMode.Error);
                return;
            }
            if (hook.Slaves.Keys.Contains(hWnd))
            {
                rltbOutput.Log("This window is already in the slavery list. Try Again !", RichLogTextBox.OutputMode.Error);
                return;
            }

            var text = Helper.WinAPI.PInvoke.GetText(hWnd);
            rltbOutput.Log(string.Format("You choose '{0}' (0x{1:X}) as new slave", text, hWnd.ToInt32()));
            InvokeAction(() => lbSlaves.Items.Add(string.Format("{0} (0x{1:X})", text, hWnd.ToInt32())));
            hook.Slaves.Add(hWnd, new Tuple<KeySender, ClickSender>(new KeySender(hWnd), new ClickSender(hWnd)));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnMainWindow.Enabled = false;
            btnSecondaryWindow.Enabled = false;
            IsRunning = true;

            hook.Start(Settings.Instance.DevicesHooked);
        }
        #endregion

        #region Settings

        #region Load
        private void LoadSettings()
        {
            switch (Settings.Instance.DevicesHooked)
            {
                case Devices.Keyboard:
                    rbKeyboard.Checked = true;
                    break;
                case Devices.Mouse:
                    rbMouse.Checked = true;
                    break;
                case Devices.Both:
                    rbBoth.Checked = true;
                    break;
            }

            switch (Settings.Instance.QOTD)
            {
                case Quote.GTFO:
                    rbQOTDNope.Checked = true;
                    break;
                case Quote.English:
                    rbQOTDEnglish.Checked = true;
                    break;
                case Quote.French:
                    rbQOTDFrench.Checked = true;
                    break;
            }

            cbDebugLog.Checked = Settings.Instance.ShowDebugMessages;

            if (Settings.Instance.shortcuts != null)
            {
                foreach (var kvp in Settings.Instance.shortcuts)
                {
                    flpShortcuts.Controls.Add(new Shortcut(kvp.Value.Item1, kvp.Value.Item2));

                    if (Hook.keys.ContainsKey(kvp.Value.Item1))
                    {
                        List<Keys> k;
                        if (Hook.keys.TryGetValue(kvp.Value.Item1, out k))
                            k.Add(kvp.Value.Item2);
                    }
                    else
                        Hook.keys.Add(kvp.Value.Item1, new List<Keys> { kvp.Value.Item2 });
                }
                Settings.Instance.shortcuts = null;
                flpShortcuts.Controls.SetChildIndex(btnAddShortcut, flpShortcuts.Controls.Count - 1);
            }
        }
        #endregion

        #region Save
        private void SaveShortcuts()
        {
            Settings.Instance.shortcuts = new SortedDictionary<int, Tuple<Keys, Keys>>();
            foreach (var control in flpShortcuts.Controls.OfType<Shortcut>())
            {
                var pos = flpShortcuts.Controls.IndexOf(control);
                Settings.Instance.shortcuts.Add(pos, control.GetKeysTulpe());
            }
        }

        //private void SaveSettings()
        //{
        //    if (rbKeyboard.Checked)
        //        Settings.Instance.DevicesHooked = Devices.Keyboard;
        //    else if (rbMouse.Checked)
        //        Settings.Instance.DevicesHooked = Devices.Mouse;
        //    else
        //        Settings.Instance.DevicesHooked = Devices.Both;

        //    if (rbQOTDNope.Checked)
        //        Settings.Instance.QOTD = Quote.GTFO;
        //    else if (rbQOTDEnglish.Checked)
        //        Settings.Instance.QOTD = Quote.English;
        //    else
        //        Settings.Instance.QOTD = Quote.French;

        //    Settings.Instance.ShowDebugMessages = cbDebugLog.Checked;
        //}
        #endregion

        #region DebugLog
        private void cbDebugLog_CheckedChanged(object sender, EventArgs e)
        {
            rltbOutput.ShowDebugMessages = cbDebugLog.Checked;
            Settings.Instance.ShowDebugMessages = cbDebugLog.Checked;
        }
        #endregion

        #region Devices
        private void rbKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                if (rbKeyboard.Checked && hook.MouseHookIsRunning)
                    hook.Stop(Devices.Mouse);
                if (!rbKeyboard.Checked && !rbBoth.Checked)
                {
                    hook.Stop(Devices.Keyboard);
                    return;
                }

                if (!hook.KeyboardHookIsRunning)
                    hook.Start(Devices.Keyboard);
            }

            Settings.Instance.DevicesHooked = Devices.Keyboard;
        }

        private void rbMouse_CheckedChanged(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                if (rbMouse.Checked && hook.KeyboardHookIsRunning)
                    hook.Stop(Devices.Keyboard);
                if (!rbMouse.Checked && !rbBoth.Checked)
                {
                    hook.Stop(Devices.Mouse);
                    return;
                }

                if (!hook.MouseHookIsRunning)
                    hook.Start(Devices.Mouse);
            }

            Settings.Instance.DevicesHooked = Devices.Mouse;
        }

        private void rbBoth_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbBoth.Checked)
                return;

            Settings.Instance.DevicesHooked = Devices.Both;

            if (IsRunning)
                hook.Start(!hook.KeyboardHookIsRunning ? Devices.Keyboard : Devices.Mouse);
        }
        #endregion

        #region QOTD
        private void rbQOTDNope_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.QOTD = Quote.GTFO;
        }

        private void rbQOTDEnglish_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.QOTD = Quote.English;
        }

        private void rbQOTDFrench_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.QOTD = Quote.French;
        }
        #endregion

        #region Shortcuts
        private void rbTransferShortcuts_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.UseShortcuts = true;
        }

        private void rbTransferAll_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.UseShortcuts = false;
        }
        #endregion

        #endregion

        #region Shortcuts
        private void btnAddShortcut_Click(object sender, EventArgs e)
        {
            flpShortcuts.Controls.Add(new Shortcut());
            flpShortcuts.Controls.SetChildIndex(btnAddShortcut, flpShortcuts.Controls.Count);
        }
        #endregion

        #region About
        private void llEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("mailto:mbox@hotmail.com");
            }
            catch
            {
                if (MessageBox.Show("No default mail-client found.\r\nCopy adress to clipboard ?", "Error",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    Clipboard.SetText("mbox@hotmail.com");
            }
        }
        #endregion


        #region Life made easy
        private void InvokeAction(Action act)
        {
            Invoke(act);
        }
        #endregion

        private void btnTest_Click(object sender, EventArgs e)
        {
            new TestForm().Show();

        }
    }
}