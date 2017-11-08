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
    public partial class PregledNabavkiForm : Form
    {
        WebAPIHelper service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_NABAVKE);
        List<PregledDobavljaciForDg> sourceList = null;
        public PregledNabavkiForm()
        {
            HttpResponseMessage response = service.GetCustomRouteResponse(WebApiRoutes.GET_NABAVKE);
            sourceList = response.Content.ReadAsAsync<List<PregledDobavljaciForDg>>().Result;
            InitializeComponent();
        }

        private void PregledNabavkiForm_Load(object sender, EventArgs e)
        {
            dgPregledNabavke.AutoGenerateColumns = false;

            dgPregledNabavke.DataSource = sourceList;
        }

        private void dgPregledNabavke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sastojakId = dgPregledNabavke.Rows[e.RowIndex].Cells[0].Value + "";
            string dobavljacId = dgPregledNabavke.Rows[e.RowIndex].Cells[1].Value + "";

            switch (e.ColumnIndex)
            {
                case 6:
                    PregledDobavljaciForDg stavka = sourceList.FirstOrDefault(item => item.SastojakId == Convert.ToInt32(sastojakId));
                    DobavljaciInfo frm = new DobavljaciInfo(stavka);
                    frm.ShowDialog(); 
                    break;
                default:
                    break;
            }
        }
    }
}
