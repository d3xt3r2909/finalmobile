using ESBX_API.Helper;
using ESBX_Client.Util;
using ESBX_Client.Util.ViewModel;
using ESBX_db.Models;
using ESBX_db.ViewModel;
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

namespace ESBX_Client.Osoblje
{
    public partial class frmNarudzbe : Form
    {
        WebAPIHelper _service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_OSOBLJE_KORPA);
        public frmNarudzbe()
        {
            InitializeComponent();
            dgNarudzbe.AutoGenerateColumns = false;

            List<CmbKorpaVm> sourceCombo = new List<CmbKorpaVm>
            {
                new CmbKorpaVm
                {
                    DisplayVerb = "Aktivne narudžbe",
                    Value = true,
                },
                new CmbKorpaVm
                {
                    DisplayVerb = "Historija narudžbi",
                    Value = false,
                }
            };

            cmbNarudzbeStatus.DataSource = sourceCombo;
            cmbNarudzbeStatus.ValueMember = "Value";
            cmbNarudzbeStatus.DisplayMember = "DisplayVerb";
        }

        private void RefreshState(bool? aktivne = true)
        {
            HttpResponseMessage response = _service.GetCustomRouteResponse(WebApiRoutes.GET_OSOBLJE_KORPA, "0/" + aktivne);
            List<KorpaForDgRow> narudzbe = response.Content.ReadAsAsync<List<KorpaForDgRow>>().Result;
            dgNarudzbe.DataSource = narudzbe;
        }

        private void frmNarudzbe_Load(object sender, EventArgs e)
        {
            RefreshState(); 
        }


        private void Filtriraj(object sender, EventArgs e)
        {
            CmbKorpaVm item = (CmbKorpaVm)cmbNarudzbeStatus.SelectedItem;

            RefreshState(item.Value);
        }

        private void dgNarudzbe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string narudzbaId = dgNarudzbe.Rows[e.RowIndex].Cells[0].Value + ""; 

            if (e.ColumnIndex == 6)
            {
                Kupon frm = new Kupon(Convert.ToInt32(narudzbaId));
                frm.ShowDialog();
            }
            else
            {
                if (e.ColumnIndex == 7)
                {
                    HttpResponseMessage korpaResponse =
                        _service.GetCustomRouteResponse(WebApiRoutes.GET_KORISNICI_KORPA, narudzbaId);

                    Korpa korpa = korpaResponse.Content.ReadAsAsync<Korpa>().Result;

                    HttpResponseMessage response =
                        _service.PutCustomRouteResponse(WebApiRoutes.PUT_KORISNICI_POVJERLJIVOST, new { }, korpa.Korisnik.Id + "/false");

                    if (response.IsSuccessStatusCode)
                        RefreshState();
                }
            }
        }
    }
}
