using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Helper.WinAPI;

namespace HelperSample
{
    public partial class Form1 : Form
    {
        private Helper.Keyboard.Hook kbh;
        private Helper.Mouse.Hook mh;
        private Helper.Keyboard.KeySender kSender;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnKBHook_Click(object sender, EventArgs e)
        {
            if (kbh.IsRunning)
                kbh.Stop();
            else
                kbh.Start();
            Output("Keyboard Hook : {0}", kbh.IsRunning ? "On" : "Off");
        }

        private void Output(string msg, params object[] args)
        {
            Output(string.Format(msg, args));
        }

        private void Output(string msg)
        {
            rtbOutput.AppendText("\r\n" + msg);
            rtbOutput.Select(rtbOutput.Text.Length, 0);
            rtbOutput.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtbOutput.Text = "Hello ! What a nice day !";

            kbh = new Helper.Keyboard.Hook(true);
            kbh.OnKeyDown += kbh_OnKeyDown;
            kbh.OnKeyUp += kbh_OnKeyUp;


            mh = new Helper.Mouse.Hook();
            mh.OnMouseLeftButtonDown += mh_OnMouseLeftButtonDown;
            mh.OnMouseRightButtonDown += mh_OnMouseLeftButtonDown;
            mh.OnMouseMiddleButtonDown += mh_OnMouseLeftButtonDown;
            mh.OnMouseXButtonDown += mh_OnMouseLeftButtonDown;

            mh.OnMouseLeftButtonUp += mh_OnMouseLeftButtonUp;
            mh.OnMouseRightButtonUp += mh_OnMouseLeftButtonUp;
            mh.OnMouseMiddleButtonUp += mh_OnMouseLeftButtonUp;
            mh.OnMouseXButtonUp += mh_OnMouseLeftButtonUp;

            mh.OnMouseWheele += mh_OnMouseWheele;

        }

        bool mh_OnMouseWheele(object sender, Helper.Mouse.MouseWheeleEventArgs e)
        {
            Output("Wheele: {0} ({1}; {2})", e.Delta, e.X, e.Y);
            return true;
        }

        bool mh_OnMouseLeftButtonUp(object sender, Helper.Mouse.MouseUpEventArgs e)
        {
            Output("{0}: Up ({1}; {2})", e.Button, e.X, e.Y);
            return true;
        }

        bool mh_OnMouseLeftButtonDown(object sender, Helper.Mouse.MouseDownEventArgs e)
        {
            Output("{0}: Down ({1}; {2})", e.Button, e.X, e.Y);
            return true;
        }

        bool kbh_OnKeyDown(object sender, KeyEventArgs e)
        {
            Output("{0}: key down", e.KeyCode);
            return true;
        }

        bool kbh_OnKeyUp(object sender, KeyEventArgs e)
        {
            Output("{0}: key up", e.KeyCode);
            return true;
        }

        private void btnMouseHook_Click(object sender, EventArgs e)
        {
            if (mh.IsRunning)
                mh.Stop();
            else
                mh.Start();
            Output("Mouse Hook : {0}", mh.IsRunning ? "On" : "Off");
        }

        private IntPtr hWnd = IntPtr.Zero;
        private void btnFindHandle_Click(object sender, EventArgs e)
        {
            Output("Put the mouse over which control you want to send some text, you have 3 seconds");
            for (int i = 0; i < 3; )
            {
                Application.DoEvents();
                Thread.Sleep(666);
                Output("{0}...", ++i);
                Thread.Sleep(333);
            }
            hWnd = Helper.Mouse.MouseHelper.GetMouseHoverWindowHandle();
            Output("0x{0:X}.. That's a good choice !", hWnd);
            Output("Now press any key within this textbox to send it.");
        }

        private void rtbOutput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (hWnd == IntPtr.Zero)
                return;

            if (kSender == null)
                kSender = new Helper.Keyboard.KeySender(hWnd);

            kSender.hWnd = hWnd;

            kSender.Send(e.KeyChar.ToString());
            e.Handled = true;
        }
    }
}
