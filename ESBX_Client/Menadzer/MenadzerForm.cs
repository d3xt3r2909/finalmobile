using ESBX_API.Helper;
using ESBX_Client.Util;
using ESBX_Client.Util.ViewModel;
using ESBX_Client.Menadzer;
using ESBX_Client.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESBX_db.Models;

namespace ESBX_Client.Menadzer
{
    public partial class MenadzerForm : Form
    {
        private WebAPIHelper service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_SASTOJCI);
        private List<IstekZalihaVm> alarmForThisItems = null;
        private Control trenutni;
        public MenadzerForm()
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
        private void btnStatistika_Click(object sender, EventArgs e)
        {
            // PregledStatistike f =new PregledStatistike();
           //  PrikaziFormu(f);
        }

        private void btnOsoblje_Click(object sender, EventArgs e)
        {
            OsobljePrikazForm f = new OsobljePrikazForm();
            PrikaziFormu(f);
        }

        private void btnNabavka_Click(object sender, EventArgs e)
        {
            EvidencijaNabavke f = new EvidencijaNabavke();
            PrikaziFormu(f);
        }

        private void btnNepovjerljivi_Click(object sender, EventArgs e)
        {
            PromjenaPovjerljivosti f = new PromjenaPovjerljivosti();
            PrikaziFormu(f);
        }

        private void btnIgra_Click(object sender, EventArgs e)
        {
            NagradnaIgraForm f = new NagradnaIgraForm();
            PrikaziFormu(f);
        }

        private void btnPodesavanjeProfila_Click(object sender, EventArgs e)
        {
            Opste.PodesavanjeProfila f = new Opste.PodesavanjeProfila();
            PrikaziFormu(f);
        }

        private void MenadzerForm_Load(object sender, EventArgs e)
        {
            List<Sastojci> response = service.GetResponse().Content.ReadAsAsync<List<Sastojci>>().Result;

            alarmForThisItems = response.Where(sastojak => sastojak.Stanje < 2000)
                .Select(x => new IstekZalihaVm
                {
                    Naziv = x.Naziv,
                    Stanje = x.Stanje,
                    SastojakId = x.Id,
                    VrstaSastojka = x.VrstaSastojka.Naziv
                }).ToList();

            if (alarmForThisItems.Count > 0)
            {
                string tmpNazivi = "";

                foreach (IstekZalihaVm satojak in alarmForThisItems)
                    tmpNazivi += satojak.Naziv + ", ";

                ntfIconIstek.ShowBalloonTip(10000, "Istek zaliha", tmpNazivi, ToolTipIcon.Error);
            }

            // PregledStatistike f = new PregledStatistike();
           // PrikaziFormu(f);
            DobrodosliLbl.Text = "Dobrodošli, " + Global.prijavljeniKorisnik.Prezime + " " + Global.prijavljeniKorisnik.Ime;
        }

        private void IzvjestajBtn_Click(object sender, EventArgs e)
        {
            // ReportZarada f = new ReportZarada();
            // PrikaziFormu(f);
        }

        private void ntfIconIstek_BalloonTipClicked(object sender, EventArgs e)
        {
            if (alarmForThisItems != null)
            {
                IstekZaliha frm = new IstekZaliha(alarmForThisItems);
                frm.ShowDialog();
            }
        }
    }
}
