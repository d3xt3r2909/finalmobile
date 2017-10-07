using ESBX_Client.Util.ViewModel;
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
    public partial class FormaIstekZaliha : Form
    {
        List<IstekZalihaVm> _istek = new List<IstekZalihaVm>(); 

        public FormaIstekZaliha(List<IstekZalihaVm> istekZaliha)
        {
            _istek = istekZaliha; 
            InitializeComponent();
        }

        private void FormaIstekZaliha_Load(object sender, EventArgs e)
        {

            rptViewerIstek.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", _istek));
            rptViewerIstek.LocalReport.SetParameters(new ReportParameter("LogedKorisnik", Global.prijavljeniKorisnik.Ime + " " + Global.prijavljeniKorisnik.Prezime));
            rptViewerIstek.LocalReport.SetParameters(new ReportParameter("TrenutniDatum", DateTime.Now.ToString()));

            this.rptViewerIstek.RefreshReport();
        }
    }
}
