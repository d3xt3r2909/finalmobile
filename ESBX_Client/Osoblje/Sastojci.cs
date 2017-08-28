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
using WebApiRoutes = ESBX_API.Helper.WebApiRoutes;

namespace ESBX_Client.Osoblje
{
    public partial class frmSastojci : Form
    {
        private readonly WebAPIHelper _sastojci = new WebAPIHelper("http://localhost:58050", "/api/sastojci");

        public frmSastojci()
        {
            InitializeComponent();
            dgSastojci.AutoGenerateColumns = false;
        }

        public void RefreshState(string pretraga = "")
        {
            HttpResponseMessage response = _sastojci.GetCustomRouteResponse(WebApiRoutes.GET_SASTOJCI, pretraga);
            List<Sastojci> tmpList = response.Content.ReadAsAsync<List<Sastojci>>().Result;
            List<SastojciPregledVm> sourceList = tmpList.Select(item => new SastojciPregledVm
            {
                Id = item.Id,
                Naziv = item.Naziv,
                Cijena = item.Cijena,
                BrojKalorija = item.BrojKalorija,
                Gramaza = item.Gramaza,
                VrstaSastojka = item.VrstaSastojka.Naziv
            }).ToList();
            dgSastojci.DataSource = sourceList;

        }

        private void Sastojci_Load(object sender, EventArgs e)
        {
            RefreshState(); 
        }

        private void btnSastojciPretraga_Click(object sender, EventArgs e)
        {
            RefreshState(txtSastojciPretragaNaziv.Text); 
        }

        private void txtSastojciPretragaNaziv_TextChanged(object sender, EventArgs e)
        {
            RefreshState(txtSastojciPretragaNaziv.Text);
        }

        private void btnSastojciNovi_Click(object sender, EventArgs e)
        {
            frmUnosSastojka form = new frmUnosSastojka();

            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshState(); 
            }
        }

        private void dgSastojci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                HttpResponseMessage response = _sastojci.DeleteCustomRouteResponse(WebApiRoutes.DELETE_VRSTE_SASTOJAKA,
                    (dgSastojci.Rows[e.RowIndex].Cells[0].Value).ToString());

                if (response.IsSuccessStatusCode)
                {
                    RefreshState();
                }
                else
                {
                    MessageBox.Show("Akcija nije moguca: " + response.StatusCode);
                }
            }
        }
    }
}
