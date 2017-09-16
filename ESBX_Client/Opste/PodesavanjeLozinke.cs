using ESBX_API.Helper;
using ESBX_Client.Util;
using ESBX_db.Models;
using ExpressSaladBarDesktop_Client;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Forms;

namespace ESBX_Client.Opste
{
    //Sredi poruke
    public partial class PodesavanjeLozinke : Form
    {
        private WebAPIHelper KorisnikService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/Korisnici");


        public PodesavanjeLozinke()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void SacuvajBtn_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (this.ValidateChildren())
            {
                Korisnici k = Global.prijavljeniKorisnik;
            if (k.LozinkaHash == Util.HelperPassword.GenerateHash(TrenutnaTxt.Text, k.LozinkaSalt))
            {
                
                    if (NovaTxt.Text == PotvrdaTxt.Text)
                    {
                        k.LozinkaHash = Util.HelperPassword.GenerateHash(NovaTxt.Text, k.LozinkaSalt);
                        HttpResponseMessage response = KorisnikService.PutResponse(k.Id, k);
                        MessageBox.Show("Uspješno ste promjenili lozinku!");
                        this.Close();

                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("nije post uspio");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Molimo Vas da provjerite unos nove lozinke.");
                    }
                }
                
            else{
                    MessageBox.Show("Molimo Vas da provjerite unos trenutne lozinke");
                }
            }
        }

        private void NovaTxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(NovaTxt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(NovaTxt, Messages.lozinka_req);
            }
            else
            {
                if (NovaTxt.Text.Length <= 6)
                {
                    e.Cancel = true;
                    errorProvider.SetError(NovaTxt, Messages.lozinka_length);
                }
            }
        }

        private void PodesavanjeLozinke_Load(object sender, EventArgs e)
        {

        }
    }
}
