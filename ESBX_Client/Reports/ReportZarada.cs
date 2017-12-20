using ESBX_db.ViewModel;
using ESBX_Client.Util;
using Microsoft.Reporting.WinForms;
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
using ESBX_API.Helper;

namespace ESBX_Client.Reports
{
    public partial class ReportZarada : Form
    {
        private WebAPIHelper NarudzbaService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/NarudbaReport");

        public ReportZarada()
        {
            InitializeComponent();
        }

        private void RefreshReport(DateTime DatumOd, DateTime DatumDo)
        {
            HttpResponseMessage response = NarudzbaService.GetActionResponse("GetNarudzbe", DatumOd.ToString("MM-dd-yyyy"), DatumDo.ToString("MM-dd-yyyy"));

            List<Narudzba_ReportResult> sourceList = response.Content.ReadAsAsync<List<Narudzba_ReportResult>>().Result;

            ReportDataSource rds = new ReportDataSource("NarudzbaReport", sourceList);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Menadzer", Global.prijavljeniKorisnik.Ime + " " + Global.prijavljeniKorisnik.Prezime));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("DatumOd", DatumOd.ToString("MM/dd/yyyy")));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("DatumDo", DatumDo.ToString("MM/dd/yyyy")));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("DanasnjiDatum", DateTime.Now.ToString("MM/dd/yyyy")));
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void GenerisiReportBtn_Click(object sender, EventArgs e)
        {
            RefreshReport(DatumOdPicker.Value, DatumDoPicker.Value);
        }

      
    }
}
