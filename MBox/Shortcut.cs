using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MBox
{
    public partial class Shortcut : UserControl
    {
        private Keys kMaster, kSlave;

        public Shortcut()
            : this(Keys.None, Keys.None)
        { }

        public Shortcut(Keys master, Keys slave)
        {
            InitializeComponent();
            kMaster = master;
            kSlave = slave;
            tbMasterKey.Text = master.ToString();
            tbSlaveKey.Text = slave.ToString();

            var t = new ToolTip();
            t.SetToolTip(tbMasterKey, "Key in the master window");
            t.SetToolTip(tbSlaveKey, "Key in the slave windows");
            t.SetToolTip(btnDelete, "Delete this shortcut");
            t.SetToolTip(btnUp, "Move this shortcut up");
            t.SetToolTip(btnDown, "Move this shortcut down");
        }

        internal Tuple<Keys, Keys> GetKeysTulpe()
        {
            return new Tuple<Keys, Keys>(kMaster, kSlave);
        }

        private void tbMasterKey_KeyDown(object sender, KeyEventArgs e)
        {

            if (kSlave == Keys.None)
            {
                tbSlaveKey.Text = e.KeyCode.ToString();
                kSlave = e.KeyCode;
            }

            var found = false;
            var delete = false;
            foreach (var kvp in Hook.keys)
            {
                if (kvp.Key == kMaster && kvp.Value.Count == 1)
                    delete = true;
                else if (kvp.Key == e.KeyCode)
                {
                    kvp.Value.Add(kSlave);
                    found = true;
                }
            }
            if (delete)
                Hook.keys.Remove(kMaster);

            kMaster = e.KeyCode;

            if (!found)
                Hook.keys.Add(kMaster, new List<Keys> { kSlave });

            tbMasterKey.Text = e.KeyCode.ToString();
        }

        private void tbSlaveKey_KeyDown(object sender, KeyEventArgs e)
        {
            List<Keys> k;
            if (Hook.keys.TryGetValue(kMaster, out k))
            {
                k.Remove(kSlave);
                k.Add(e.KeyCode);
            }
            //foreach (var kvp in Hook.keys.Where(kvp => kvp.Key == kMaster))
            //{
            //    kvp.Value.Remove(kSlave);
            //    kvp.Value.Add(e.KeyCode);
            //}

            kSlave = e.KeyCode;

            tbSlaveKey.Text = e.KeyCode.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Hook.keys.Remove(kMaster);
            Dispose();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var papa = (FlowLayoutPanel)Parent;
            var index = papa.Controls.GetChildIndex(this);
            if (index == 0)
                return;
            papa.Controls.SetChildIndex(this, index - 1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var papa = (FlowLayoutPanel)Parent;
            var index = papa.Controls.GetChildIndex(this);
            if (index == papa.Controls.Count - 2)
                return;
            papa.Controls.SetChildIndex(this, index + 1);
        }
    }
}
