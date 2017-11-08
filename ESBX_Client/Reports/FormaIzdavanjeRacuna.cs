using ESBX_db.ViewModel;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESBX_Client.Reports
{
    public partial class frmIzdavanjeRacuna : Form
    {
        List<KorpaForDgRow> narudzbeSource = null;

        public frmIzdavanjeRacuna(List<KorpaForDgRow> narudzbe)
        {
            narudzbeSource = narudzbe;

            InitializeComponent();
        }

        private void FormaIzdavanjeRacuna_Load(object sender, EventArgs e)
        {
            rptIzdavanjeRacunaView.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", narudzbeSource));
            rptIzdavanjeRacunaView.LocalReport.SetParameters(new ReportParameter("Konobar", Global.prijavljeniKorisnik.Ime + " " + Global.prijavljeniKorisnik.Prezime));

            rptIzdavanjeRacunaView.LocalReport.SetParameters(new ReportParameter("TrenutniDatum", DateTime.Now.ToString()));
            // rptViewer.LocalReport.SetParameters(new ReportParameter("TrenutniDatum", DateTime.Now.ToString()));

            rptIzdavanjeRacunaView.RefreshReport();
        }

    }
}
