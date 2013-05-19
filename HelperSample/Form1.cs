using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Helper.Keyboard;
using Helper.Mouse;
using Screen = Helper.Screen.Screen;

namespace HelperSample
{
    public partial class Form1 : Form
    {
        private Keyboard.Hook kbh;
        private Mouse.Hook mh;

        private IntPtr WinHandle = IntPtr.Zero;

        public Form1()
        {
            InitializeComponent();
        }

        private void Output(string msg, params object[] args)
        {
            if (rtbOutput.InvokeRequired)
            {
                rtbOutput.Invoke(new Action(() => Output(msg, args)));
                return;
            }

            rtbOutput.AppendText("\r\n" + string.Format(msg, args ?? new object[] { "" }));
            rtbOutput.Select(rtbOutput.Text.Length, 0);
            rtbOutput.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtbOutput.Text = "Hello ! What a nice day !";

            kbh = new Keyboard.Hook();
            kbh.OnKeyDown += kbh_OnKeyDown;
            kbh.OnKeyUp += kbh_OnKeyUp;


            mh = new Mouse.Hook();
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

        #region Mouse Hook

        private bool mh_OnMouseWheele(object sender, MouseWheeleEventArgs e)
        {
            Output("Wheele: {0} ({1}; {2})", e.Delta, e.X, e.Y);
            return true;
        }

        private bool mh_OnMouseLeftButtonUp(object sender, MouseUpEventArgs e)
        {
            Output("{0}: Up\r\n" +
                   "  On Screen : ({1}; {2})\r\n" +
                   "  On Window 0x{3:X} :" +
                   "    ({4}; {5})",
                   e.Button, e.ScreenPoint.X, e.ScreenPoint.Y, e.WindowHandle, e.WindowPoint.X, e.WindowPoint.Y);
            return true;
        }

        private bool mh_OnMouseLeftButtonDown(object sender, MouseDownEventArgs e)
        {
            Output("{0}: Down\r\n" +
                   "  On Screen : ({1}; {2})\r\n" +
                   "  On Window 0x{3:X} :" +
                   "    ({4}; {5})",
                   e.Button, e.ScreenPoint.X, e.ScreenPoint.Y, e.WindowHandle, e.WindowPoint.X, e.WindowPoint.Y);
            return true;
        }

        #endregion

        #region Keyboard Hook

        private void btnKBHook_Click(object sender, EventArgs e)
        {
            if (kbh.IsRunning)
                kbh.Stop();
            else
                kbh.Start();
            Output("Keyboard Hook : {0}", kbh.IsRunning ? "On" : "Off");
        }

        private bool kbh_OnKeyDown(object sender, KeyEventArgs e)
        {
            Output("{0}: key down", e.KeyCode);
            return true;
        }

        private bool kbh_OnKeyUp(object sender, KeyEventArgs e)
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

        #endregion

        private void btnFindHandle_Click(object sender, EventArgs e)
        {
            Output("Put the mouse over which window you want to send text, you have 5 seconds");
            new Thread(() =>
            {
                var rnd = new Random();
                var sec = 0;
                var hWndMouse = Mouse.Utilities.GetMouseHoverWindowHandle();

                Screen.Window.DrawRectangle(hWndMouse, Color.FromArgb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256)));

                for (int i = 0; i < 100; i++)
                {
                    if (i % 20 == 0)
                        Output("{0}...", ++sec);

                    Thread.Sleep(50);

                    var hWndTemp = Mouse.Utilities.GetMouseHoverWindowHandle();
                    if (hWndMouse == hWndTemp)
                        continue;

                    Screen.Window.ClearRectangle(hWndMouse);
                    Screen.Window.DrawRectangle(hWndTemp, Color.FromArgb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256)));

                    hWndMouse = hWndTemp;
                }

                WinHandle = hWndMouse;
                Screen.Window.ClearRectangle(WinHandle);
                Output("0x{0:X}.. That's a good choice !", WinHandle);
                Output("Now press any key within this textbox to send it.");

            }).Start();
        }

        private void rtbOutput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (WinHandle == IntPtr.Zero)
                return;

            Keyboard.Sender.Send(WinHandle, e.KeyChar.ToString(CultureInfo.InvariantCulture));
            e.Handled = true;
        }

        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            Output("Put the mouse over which window you want to screen, you have 5 seconds");
            new Thread(() =>
            {
                for (int i = 0; i < 5; )
                {
                    Thread.Sleep(1000);
                    Output("{0}...", ++i);
                }

                var hWnd = Mouse.Utilities.GetMouseHoverWindowHandle();
                var bmp = Screen.Pixel.Screenshot(hWnd);

                bmp.Save("Screenshot.jpg", ImageFormat.Jpeg);
                Process.Start("Screenshot.jpg");

            }) { IsBackground = true }.Start();
        }
    }
}
