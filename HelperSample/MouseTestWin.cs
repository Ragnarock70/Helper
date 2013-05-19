using System;
using System.Windows.Forms;
using Helper.Mouse;
using Helper.WinAPI;

namespace HelperSample
{
    public partial class MouseTestWin : Form
    {
        public MouseTestWin()
        {
            InitializeComponent();
        }

        private Mouse.Hook hook;

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            hook = new Mouse.Hook();
            hook.OnMouseLeftButtonDown += hook_OnMouseLeftButtonDown;
            hook.OnMouseLeftButtonUp += hook_OnMouseLeftButtonUp;
            hook.OnMouseXButtonUp += hook_OnMouseXButtonUp;
            hook.Start();
        }

        bool hook_OnMouseXButtonUp(object sender, MouseUpEventArgs e)
        {
            Output("\r\n{0}: Up" +
                   "\r\n  On Screen :" +
                   "\r\n    ({1}; {2})" +
                   "\r\n  On Window {3} :" +
                   "\r\n    ({4}; {5})",
                   e.Button, e.ScreenPoint.X, e.ScreenPoint.Y, PInvoke.GetText(e.WindowHandle), e.WindowPoint.X, e.WindowPoint.Y);

            Mouse.Sender.Click(IntPtr.Zero, e.Button, e.WindowPoint.X, e.WindowPoint.Y);

            return true;
        }

        bool hook_OnMouseLeftButtonUp(object sender, MouseUpEventArgs e)
        {
            Output("\r\n{0}: Up" +
                   "\r\n  On Screen :" +
                   "\r\n    ({1}; {2})" +
                   "\r\n  On Window {3} :" +
                   "\r\n    ({4}; {5})",
                   e.Button, e.ScreenPoint.X, e.ScreenPoint.Y, PInvoke.GetText(e.WindowHandle), e.WindowPoint.X, e.WindowPoint.Y);

            Mouse.Sender.Click(IntPtr.Zero, e.Button, e.WindowPoint.X, e.WindowPoint.Y);

            return true;
        }

        bool hook_OnMouseLeftButtonDown(object sender, MouseDownEventArgs e)
        {
            Output("\r\n{0}: Down" +
                   "\r\n  On Screen :" +
                   "\r\n    ({1}; {2})" +
                   "\r\n  On Window {3} :" +
                   "\r\n    ({4}; {5})",
                   e.Button, e.ScreenPoint.X, e.ScreenPoint.Y, PInvoke.GetText(e.WindowHandle), e.WindowPoint.X, e.WindowPoint.Y);

            //Sender.Click(IntPtr.Zero, e.Button, e.WindowPoint.X, e.WindowPoint.Y);


            return true;
        }

        private void Output(string msg, params object[] args)
        {
            rtbOutput.AppendText("\r\n" + string.Format(msg, args));
            rtbOutput.Select(rtbOutput.Text.Length, 0);
            rtbOutput.ScrollToCaret();
        }

        private SlaveWindow slave;
        private void btnSlave_Click(object sender, EventArgs e)
        {
            slave = new SlaveWindow();
            slave.Show();
        }
    }
}
