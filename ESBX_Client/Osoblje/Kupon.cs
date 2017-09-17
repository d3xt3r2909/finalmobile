using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESBX_Client.Util;
using ESBX_API.Helper;
using ESBX_db.ViewModel;
using ESBX_API.ViewModels;

namespace ESBX_Client.Osoblje
{
    public partial class Kupon : Form
    {
        readonly WebAPIHelper _service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_OSOBLJE_KORPA);
        private readonly List<KorpaForDgRow> narudzbe;
        private readonly int KorpaId; 
        public Kupon(int id)
        {
            KorpaId = id;
            HttpResponseMessage response = _service.GetCustomRouteResponse(WebApiRoutes.GET_OSOBLJE_KORPA, id + "/false");
            narudzbe = response.Content.ReadAsAsync<List<KorpaForDgRow>>().Result;

            InitializeComponent();
            
            dgIzdajRacun.AutoGenerateColumns = false;
        }

        private void Kupon_Load(object sender, EventArgs e)
        {
            dgIzdajRacun.DataSource = narudzbe;

        }

        private void btnIzdaj_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = _service.PostCustomRouteResponse(WebApiRoutes.POST_ZAVRSI_NARUDZBU,
                new IzdajRacunVm {KorpaId = KorpaId, KuponKod = txtPoklonBon.Text});
            
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Poslat email");
                btnDownload.Enabled = true;
;           }
            else
            {
                string poruka = response.Content.ReadAsAsync<string>().Result; 

                MessageBox.Show("Greska: " + poruka);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Process.Start(WebApiRoutes.URL_ROUTE + WebApiRoutes.POST_DOWNLOAD_RACUN + "/" + KorpaId);
        }
    }
}
