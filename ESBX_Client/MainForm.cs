using System;
using System.Windows.Forms;
using ESBX_Client.Osoblje;

namespace ESBX_Client
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void pregledSastojakaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSastojci frm = new frmSastojci();
            frm.MdiParent = this;
            frm.Show();
        }

        private void narudžbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNarudzbe frm = new frmNarudzbe();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
