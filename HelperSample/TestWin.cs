using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using Helper.Mouse;
using Screen = Helper.Screen.Screen;

namespace HelperSample
{
    public partial class TestWin : Form
    {
        private string getpixelpath, bitbltpath;
        public TestWin()
        {
            InitializeComponent();
        }

        private void btnScrnShot_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
            Thread.Sleep(2000);

            var bmp = Screen.Pixel.ScreenshotWithGetPixel(Handle);
            getpixelpath = string.Format("ScreenShotGetPixel.{0}_{1}.jpg", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString().Replace(':', '.'));
            bmp.Save(getpixelpath, ImageFormat.Jpeg);

            var bmp2 = Screen.Pixel.Screenshot(Handle);
            bitbltpath = string.Format("ScreenShotBitBlt.{0}_{1}.jpg", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString().Replace(':', '.'));
            bmp2.Save(bitbltpath, ImageFormat.Jpeg);



        }

        private void btnOpenGetPixel_Click(object sender, EventArgs e)
        {
            Process.Start(getpixelpath);
        }

        private void btnBitBlt_Click(object sender, EventArgs e)
        {
            Process.Start(bitbltpath);
        }

        private IntPtr hWnd;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            hWnd = Mouse.Utilities.DrawMouseHoverWindowRect(Color.DeepPink);

            var found = Screen.Pixel.SearchAll(0, 0, 999999, 999999, Color.Red, Handle, 1);
            Thread.Sleep(2000);
            Screen.Window.ClearRectangle(hWnd);
        }

        private void TestWin_Load(object sender, EventArgs e)
        {
            var bmp3 = new Bitmap(Width, Height);
            bmp3.SetPixel(20, 20, Color.Red);
            BackgroundImageLayout = ImageLayout.None;
            BackgroundImage = bmp3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            //hWnd = MouseHelper.DrawMouseHoverWindowRect();
            Screen.Window.BringToTop(Handle);
        }
    }
}
