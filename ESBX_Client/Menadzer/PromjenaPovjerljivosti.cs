using ESBX_API.Helper;
using ESBX_Client.Util;
using ESBX_db.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace ESBX_Client.Menadzer
{
    public partial class PromjenaPovjerljivosti : Form
    {
        private WebAPIHelper KorisniciService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/Korisnici");

        private WebAPIHelper PromjenaService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/PromjenaPovjerljivosti");

        public PromjenaPovjerljivosti()
        {
            InitializeComponent();
            KorisniciGrid.AutoGenerateColumns = false;
        }

        private void TraziBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void BindGrid()
        {
            HttpResponseMessage response = PromjenaService.GetActionResponse("SearchNepovjerljivi", PretragaImePtxt.Text.Trim());
            if (response.IsSuccessStatusCode)
            {
                List<Korisnici_NepovjerljiviResult> korisnici = response.Content.ReadAsAsync<List<Korisnici_NepovjerljiviResult>>().Result;
                KorisniciGrid.DataSource = korisnici;
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void KorisniciGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            HttpResponseMessage response =
                KorisniciService.PutCustomRouteResponse(WebApiRoutes.PUT_KORISNICI_POVJERLJIVOST,
                                                        new { }, 
                                                        KorisniciGrid.Rows[e.RowIndex].Cells[0].Value + "/true");

            if (response.IsSuccessStatusCode)
                BindGrid();
            else
                MessageBox.Show("Nije uspjeli oznaciti korisnika kao povjerljivog.");
           
        }

        private void PromjenaPovjerljivosti_Load(object sender, EventArgs e)
        {

        }
    }
}
