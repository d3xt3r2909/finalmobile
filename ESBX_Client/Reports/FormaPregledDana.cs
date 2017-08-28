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
using Microsoft.Reporting.WinForms;
using ESBX_Client.Util;
using ESBX_db.ViewModel;
using ESBX_API.Helper;
using ESBX_db.Models;

namespace ESBX_Client.Reports
{
    public partial class FormaPregledDana : Form
    {
        private WebAPIHelper _service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_REPORT_PREGLED_DANA);
        private List<PregledDanaRepVm> sourceList;

        public FormaPregledDana()
        {
            InitializeComponent();
            HttpResponseMessage response = _service.GetResponse();
            sourceList = response.Content.ReadAsAsync<List<PregledDanaRepVm>>().Result;
        }

        private void RefreshState(string sifra = "")
        {
            var tmpSource = sifra != "" ? sourceList.Where(item => item.Sifra.ToLower().StartsWith(sifra.ToLower())).ToList() : sourceList;

            ReportDataSource rds = new ReportDataSource("DSPregledDana", tmpSource);
            this.rptPregledDana.LocalReport.DataSources.Clear();
            this.rptPregledDana.LocalReport.DataSources.Add(rds);
            if (Global.prijavljeniKorisnik == null)
            {
                Global.prijavljeniKorisnik = new Korisnici { Ime = "nihad", Prezime = "test" };
            }
            this.rptPregledDana.LocalReport.SetParameters(new ReportParameter("korisnik", Global.prijavljeniKorisnik.Ime + " " + Global.prijavljeniKorisnik.Prezime));
            this.rptPregledDana.LocalReport.SetParameters(new ReportParameter("datum", DateTime.Now.ToString("dd-MM-yyyy")));
            this.rptPregledDana.LocalReport.SetParameters(new ReportParameter("totalNarudzbi", tmpSource.Count.ToString()));
            this.rptPregledDana.LocalReport.Refresh();
            this.rptPregledDana.RefreshReport();
        }

        private void FormaPregledDana_Load(object sender, EventArgs e)
        {
            RefreshState();
        }

        private void txtPregDanaSifra_TextChanged(object sender, EventArgs e)
        {
            RefreshState(txtPregDanaSifra.Text);
        }
    }
}
