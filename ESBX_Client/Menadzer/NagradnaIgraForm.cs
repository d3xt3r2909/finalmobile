using ESBX_Client.Util;
using ESBX_db.Models;
using ESBX_db.ViewModel;
using ESBX_Client;
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
using ExpressSaladBarDesktop_Client;
using ESBX_API.Helper;

namespace ESBX_Client.Menadzer
{
    public partial class NagradnaIgraForm : Form
    {
        private WebAPIHelper IgraService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/NagradnaIgra/GetNagradna");

        NagradnaIgra ng = new NagradnaIgra();
       
        public NagradnaIgraForm()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void btnPokreniIgru_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = IgraService.GetResponse();
            NagradnaIgraVM igra = response.Content.ReadAsAsync<NagradnaIgraVM>().Result;
            if (igra.KorisnikId == 0)
            {
                MessageBox.Show( "Trenuto ne postoji kupac mjeseca jer nije izdat nijedan racun", "Informacija", MessageBoxButtons.OK);
            }
            else
            {
                KorisnikLbl.Text = igra.Korisnik;
                TelefonLbl.Text = igra.Telefon;
                UkupnoLbl.Text = igra.UkupnoPotroseno.ToString();

                ng.KorisniciId = igra.KorisnikId;
            }
            
        }

        private void ObavijestiBtn_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (this.ValidateChildren())
            {
                if (ng.KorisniciId == 0)
                {
                    MessageBox.Show("Molimo Vas da odaberete korisnika.");
                    return;
                }
                ng.Popust = (float)Convert.ToDouble(PopustTxt.Text);
                ng.Napomena = napomenaTxt.Text;
                ng.Iskoristen = false;
                ng.VaziDo = DatumPicker.Value;

                if (ng.KorisniciId != 0)
                {
                    HttpResponseMessage response = IgraService.PostResponse(ng);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Uspješno ste obavjestili korisnika.");
                    }
                    else
                    {
                        MessageBox.Show(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
                else
                {
                    MessageBox.Show("Molimo Vas da odaberete korisnika.");
                }
                

            }


        }

        private void PopustTxt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(PopustTxt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(PopustTxt, Messages.popust_req);
            }

        }

        private void DatumPicker_Validating(object sender, CancelEventArgs e)
        {
            if (DatumPicker.Value<=DateTime.Now){
                e.Cancel = true;
                errorProvider.SetError(DatumPicker, Messages.datum_time);
            }
        }

        
    }
}
