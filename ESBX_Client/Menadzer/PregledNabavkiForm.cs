using ESBX_API.Helper;
using ESBX_Client.Util;
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

namespace ESBX_Client.Menadzer
{
    public partial class PregledNabavkiForm : Form
    {
        private WebAPIHelper DobavljaciService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/Dobavljaci");
        WebAPIHelper service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_NABAVKE);
        List<PregledDobavljaciForDg> sourceList = null;
        public PregledNabavkiForm()
        {
            InitializeComponent();
            
            dgPregledNabavke.AutoGenerateColumns = false;
            dataGridViewSastojciList.AutoGenerateColumns = false;
        }

        private void PregledNabavkiForm_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void dgPregledNabavke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string UlazZalihaId = dgPregledNabavke.Rows[e.RowIndex].Cells[0].Value + "";
            string dobavljacId = dgPregledNabavke.Rows[e.RowIndex].Cells[1].Value + "";

            switch (e.ColumnIndex)
            {
                case 2:
                    PregledDobavljaciForDg stavkaP = sourceList.FirstOrDefault(item => item.UlazZalihaId == Convert.ToInt32(UlazZalihaId));
                    dataGridViewSastojciList.DataSource = stavkaP.SastojciList;

                    break;
                case 4:
                    PregledDobavljaciForDg stavka = sourceList.FirstOrDefault(item => item.UlazZalihaId== Convert.ToInt32(UlazZalihaId));
                    DobavljaciInfo frm = new DobavljaciInfo(stavka);
                    frm.ShowDialog(); 
                    break;
                default:
                    break;
            }
        }

        private void BindDobavljaci()
        {
            HttpResponseMessage response = DobavljaciService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Dobavljaci> dob = response.Content.ReadAsAsync<List<Dobavljaci>>().Result;
                //Insert jer add dodaje na kraj
                dob.Insert(0, new Dobavljaci() { Naziv = "Odaberite dobavljaca" });
                cmbFilterNabavkaDobavljac.DataSource = dob;
                cmbFilterNabavkaDobavljac.DisplayMember = "Naziv";
                cmbFilterNabavkaDobavljac.ValueMember = "Id";
            }
        }

        private void btnOcistiFilter_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnPrimjeniFilter_Click(object sender, EventArgs e)
        {
            int dobavljacId = cmbFilterNabavkaDobavljac.SelectedIndex;
            DateTime datum = FilterNabavkaDatum.Value;
            //pozovi funkciju
            UlazZalihaRequestVM request = new UlazZalihaRequestVM();
            request.DatumFilter = datum;
            request.DobavljacIdFilter = dobavljacId;
            HttpResponseMessage response = service.PostResponse(request);
            sourceList = response.Content.ReadAsAsync<List<PregledDobavljaciForDg>>().Result;
            dgPregledNabavke.DataSource = sourceList;
        }

        private void BindGrid()
        {
            UlazZalihaRequestVM request = null;
            HttpResponseMessage response = service.PostResponse(request);
            sourceList = response.Content.ReadAsAsync<List<PregledDobavljaciForDg>>().Result;
            dgPregledNabavke.DataSource = sourceList;
            BindDobavljaci();
            FilterNabavkaDatum.Value = DateTime.Now;
        }


    }
}
