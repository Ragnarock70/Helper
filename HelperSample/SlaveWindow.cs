using System.Windows.Forms;

namespace HelperSample
{
    public partial class SlaveWindow : Form
    {
        public SlaveWindow()
        {
            InitializeComponent();
        }

        private void SlaveWindow_MouseDown(object sender, MouseEventArgs e)
        {
            Output("{0} : Down @ ({1}; {2})",e.Button, e.X, e.Y);
        }

        private void SlaveWindow_MouseUp(object sender, MouseEventArgs e)
        {
            Output("{0} : Up @ ({1}; {2})", e.Button,e.X, e.Y);
        }

        private void Output(string msg, params object[] args)
        {
            rtbOutput.AppendText("\r\n" + string.Format(msg, args));
            rtbOutput.Select(rtbOutput.Text.Length, 0);
            rtbOutput.ScrollToCaret();
        }
    }
}
