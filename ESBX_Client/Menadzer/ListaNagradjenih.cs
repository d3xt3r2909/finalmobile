using ESBX_API.Helper;
using ESBX_Client.Util;
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

namespace ESBX_Client.Menadzer
{

    public partial class ListaNagradjenih : Form
    {
        private  WebAPIHelper service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_NAGRADNE_IGRE);
        private List<GetNagradnaIgraResponse> listSource;
        private GetNagradnaIgraRequest request; 

        public ListaNagradjenih()
        {
            request = new GetNagradnaIgraRequest();
            request.GetAll = true;

            InitializeComponent();
            gridNagrade.AutoGenerateColumns = false;
        }

        private void ListaNagradjenih_Load(object sender, EventArgs e)
        {
            inputTimePickerStart.Value = DateTime.Now.AddYears(-1);
            inputTimePickerEnd.Value = DateTime.Now;

            RefreshState();
        }

        private void RefreshState() {

            HttpResponseMessage response = service.PostResponse(request);

            listSource = response.Content.ReadAsAsync<List<GetNagradnaIgraResponse>>().Result;

            gridNagrade.DataSource = listSource;
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {

            if (inputTimePickerStart != null && inputTimePickerEnd != null)
            {
                request.DatumStart = inputTimePickerStart.Value;
                request.DatumEnd = inputTimePickerEnd.Value;
            }

            RefreshState();
        }

        private void inputImePrezime_TextChanged(object sender, EventArgs e)
        {
            request.GetAll = false;
            request.KorisnikImePrezime = inputImePrezime.Text;

            if (inputImePrezime.Text == "")
                request.KorisnikImePrezime = null;

            RefreshState();
        }

        private void inputKuponKod_TextChanged(object sender, EventArgs e)
        {
            request.GetAll = false;
            request.KuponKod = inputKuponKod.Text;

            if (inputKuponKod.Text == "")
                request.KuponKod = null;

            RefreshState();
        }

        private void inputCheckBoxIskoristeni_CheckedChanged(object sender, EventArgs e)
        {
            request.GetAll = false;
            request.Status = inputCheckBoxIskoristeni.Checked;
            RefreshState();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            request.DatumStart = DateTime.Now.AddYears(-1);
            request.DatumEnd = DateTime.Now;
            request.GetAll = true;
            request.KorisnikId = null;
            request.KorisnikImePrezime = null;
            request.KuponKod = null;
            request.Status = false;
            RefreshState();
        }
    }
}
