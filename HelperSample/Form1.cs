using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Helper.WinAPI;

namespace HelperSample
{
    public partial class Form1 : Form
    {
        private Helper.Keyboard.KeyboardHook kbh;
        private Helper.Mouse.MouseHook mh;
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

            kbh = new Helper.Keyboard.KeyboardHook();
            kbh.OnKeyDown += kbh_OnKeyDown;
            kbh.OnKeyUp += kbh_OnKeyUp;


            mh = new Helper.Mouse.MouseHook();
            mh.OnMouseLeftButtonDown += mh_OnMouseLeftButtonDown;
            mh.OnMouseRightButtonDown += mh_OnMouseLeftButtonDown;
            mh.OnMouseMiddleButtonDown += mh_OnMouseLeftButtonDown;
            mh.OnMouseXButtonDown += mh_OnMouseLeftButtonDown;

            mh.OnMouseLeftButtonUp += mh_OnMouseLeftButtonUp;
            mh.OnMouseRightButtonUp += mh_OnMouseLeftButtonUp;
            mh.OnMouseMiddleButtonUp += mh_OnMouseLeftButtonUp;
            mh.OnMouseXButtonUp += mh_OnMouseLeftButtonUp;

            mh.OnMouseWheele += mh_OnMouseWheele;

            //Helper.Screen.Pixel.Search(0, 0, this.Size.Width, this.Size.Height, 0x0);

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
            //Helper.Mouse.MouseHelper.DrawBorder();
            hWnd = Helper.Mouse.MouseHelper.GetMouseHoverWindowHandle();
            var pos = Helper.Mouse.MouseHelper.GetMousePos();
            Output("X: {0}\r\nY: {1}", pos.x, pos.y);
            Output("0x{0:X}.. That's a good choice !", hWnd);
            Output("Now press any key within this textbox to send it.");
        }

        private void rtbOutput_KeyPress(object sender, KeyPressEventArgs e)
        {
            BtnClickMe_Click(null, null);
            if (hWnd == IntPtr.Zero)
                return;

            if (kSender == null)
                kSender = new Helper.Keyboard.KeySender(hWnd);

            kSender.hWnd = hWnd;

            kSender.Send(e.KeyChar.ToString());
            e.Handled = true;
        }

        private void BtnClickMe_Click(object sender, EventArgs e)
        {
            //var rnd = new Random();
            //var procs =Process.GetProcesses();
            //var hWnd = procs[rnd.Next(0, procs.Length)].MainWindowHandle;

            var points = Helper.Screen.Pixel.SearchAll(0, 0, Size.Width, Size.Height, 0xFF0000, Handle);
            var ret = new List<Point>();
            foreach (var pt in points)
            {
                var pt2 = new POINT { x = pt.X, y = pt.Y };
                ClientToScreen(Handle, ref pt2);
                ret.Add(new Point(pt2.x, pt2.y));
            }
            //Helper.Screen.Pixel.Screenshot(hWnd);
            //var rnd = new Random();
            //this.BackColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
        }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            Output("Click");
            var s = new Helper.Mouse.ClickSender(hWnd);
            var pos = Helper.Mouse.MouseHelper.GetMousePos();
            Output("X: {0}\r\nY: {1}", pos.x, pos.y);
            ScreenToClient(hWnd, ref pos);
            Output("X2: {0}\r\nY2: {1}", pos.x, pos.y);
            s.MouseDown(MouseButtons.Left, pos.x, pos.y);
            s.MouseUp(MouseButtons.Left, pos.x, pos.y);
        }

        [DllImport("user32.dll")]
        static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);
        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);
    }
}
