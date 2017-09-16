using ESBX_db.ViewModel;
using ESBX_Client.Util;
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

namespace ESBX_Client.Menadzer
{
    public partial class PregledStatistike : Form
    {

        private WebAPIHelper StatistikaService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/StatistikaZarade");

        public PregledStatistike()
        {
            InitializeComponent();
        }

        private void PregledStatistike_Load(object sender, EventArgs e)
        {

            GodinaLbl.Text = DateTime.Now.Year.ToString();

            HttpResponseMessage responseZarada = StatistikaService.GetResponse();


            List<PregledStatistikeVM> lista = responseZarada.Content.ReadAsAsync<List<PregledStatistikeVM>>().Result;
            ZaradaGrid.DataSource = lista;
            foreach (var i in lista)
            {
                ZaradaChart.Series["Ukupna zarada (KM)"].Points.AddXY(i.RedniBroj, i.Zarada);

            }
        }


    }
}
