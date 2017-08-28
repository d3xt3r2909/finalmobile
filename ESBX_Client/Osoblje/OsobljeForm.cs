using ESBX_Client.Opste;
using ESBX_Client.Reports;
using System;
using System.Windows.Forms;

namespace ESBX_Client.Osoblje
{
    public partial class OsobljeForm : Form
    {
        private Control trenutni;
        public OsobljeForm()
        {
            InitializeComponent();
        }


        private void PrikaziFormu(Form f)
        {
            f.TopLevel = false;
            panelPrikaz.Controls.Remove(trenutni);
            panelPrikaz.Controls.Add(f);
            trenutni = f;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void BtnNarudzbe_Click(object sender, EventArgs e)
        {
            frmNarudzbe f = new frmNarudzbe();
            PrikaziFormu(f);
        }

        private void BtnSastojci_Click(object sender, EventArgs e)
        {
            frmSastojci f = new frmSastojci();
            PrikaziFormu(f);
        }

        private void BtnIzvjestaj_Click(object sender, EventArgs e)
        {
            FormaPregledDana f = new FormaPregledDana();
            PrikaziFormu(f);
        }

        private void BtnPodesavanjeProfila_Click(object sender, EventArgs e)
        {
            PodesavanjeProfila f = new PodesavanjeProfila();
            PrikaziFormu(f);
        }

        private void OsobljeForm_Load(object sender, EventArgs e)
        {
            frmNarudzbe f = new frmNarudzbe();
            PrikaziFormu(f);

            labelDobrodosli.Text = "Dobrodošli, " + Global.prijavljeniKorisnik.Prezime + " " + Global.prijavljeniKorisnik.Ime;

        }
    }
}
