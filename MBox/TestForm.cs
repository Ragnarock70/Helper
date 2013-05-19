using System.Windows.Forms;

namespace MBox
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0100: //WM_KEYDOWN
                    {
                        //var info = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(m.LParam, typeof(KBDLLHOOKSTRUCT));
                        rtbMain.AppendText("Down : " + (Keys)m.WParam + "\r\n");
                        break;
                    }
                case 0x0101: //WM_KEYUP
                    {
                        //var info = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(m.LParam, typeof(KBDLLHOOKSTRUCT));
                        rtbMain.AppendText("Up : " + (Keys)m.WParam + "\r\n");
                        break;
                    }
            }
            base.WndProc(ref m);
        }

        private int i;
        private void btnClick_Click(object sender, System.EventArgs e)
        {
            rtbMain.Text = (++i).ToString();
        }
    }
}
