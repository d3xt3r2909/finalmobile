using ESBX_API.Helper;
using ESBX_Client.Util;
using ESBX_db.Models;
using ExpressSaladBarDesktop_Client;
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
    public partial class frmUnosSastojka : Form
    {
        WebAPIHelper _sastojci = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.POST_SASTOJCI);

        public frmUnosSastojka()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void AddSastojak_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = _sastojci.GetCustomRouteResponse(WebApiRoutes.GET_VRSTE_SASTOJAKA);

            if (response.IsSuccessStatusCode)
            {
                List<VrstaSastojka> vrsteSastojaka = response.Content.ReadAsAsync<List<VrstaSastojka>>().Result;
                cmbAddSasVrsta.DataSource = vrsteSastojaka;
                cmbAddSasVrsta.DisplayMember = "Naziv";
                cmbAddSasVrsta.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("Error code: ", response.StatusCode + "Message: " + response.ReasonPhrase);
            }
        }

        private void btnAddSasSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                Sastojci noviSastojak = new Sastojci();
                noviSastojak.Naziv = txtAddSasNaziv.Text;
                noviSastojak.Cijena = (float) Convert.ToDecimal(txtAddSasCijena.Text);
                noviSastojak.Gramaza = (float) Convert.ToDecimal(txtAddSasGramaza.Text);
                noviSastojak.BrojKalorija = (float) Convert.ToDecimal(txtAddSasKalorije.Text);
                noviSastojak.IsDeleted = false;
                noviSastojak.Napomena = txtAddSasNapomena.Text;
                noviSastojak.VrstaSastojkaId = Convert.ToInt32(cmbAddSasVrsta.SelectedValue);

                HttpResponseMessage response = _sastojci.PostResponse(noviSastojak);

                if (response.IsSuccessStatusCode)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }
        }

        private void txtAddSasNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAddSasNaziv.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtAddSasNaziv, Messages.naziv_sastojak_req);
            }
            else
            {
                errorProvider.SetError(txtAddSasNaziv, null);
            }
        }
    }
}
