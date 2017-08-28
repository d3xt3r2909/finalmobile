using ESBX_Client;
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
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESBX_Client.Opste
{
    public partial class PodesavanjeProfila : Form
    {
        private WebAPIHelper KorisnikService = new WebAPIHelper("http://localhost:58050/", "api/Korisnici");
        private WebAPIHelper GradoviService = new WebAPIHelper("http://localhost:58050/", "api/Gradovi");
        Korisnici k = Global.prijavljeniKorisnik;
        public PodesavanjeProfila()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PodesavanjeLozinke f = new PodesavanjeLozinke();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (this.ValidateChildren())
            {
                k.Ime = ImeTxt.Text;
                k.Prezime = PrezimeTxt.Text;
                k.Email = EmailTxt.Text;
                k.BrojTelefona = TelefonTxt.Text;
                k.Adresa = AdressTxt.Text;
                k.DatumRodjenja = DatumRodjenjaPicker.Value;
                k.GradId = Convert.ToInt32(GradCmb.SelectedValue);

                HttpResponseMessage response = KorisnikService.PutResponse(k.Id, k);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Uspješno ste izmjenili podatke!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    
                }
                else
                {
                    MessageBox.Show("Error Code" +
                    response.StatusCode + " : Message - " + response.ReasonPhrase);
                }
            }
        }

        private void PodesavanjeProfila_Load(object sender, EventArgs e)
        {
            BindGradovi();
            FillForm();
          

        }

        private void BindGradovi()
        {
            HttpResponseMessage response = GradoviService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Grad> gradovi = response.Content.ReadAsAsync<List<Grad>>().Result;
                GradCmb.DataSource = gradovi;
                GradCmb.DisplayMember = "Naziv";
                GradCmb.ValueMember = "Id";
                GradCmb.SelectedValue = Global.prijavljeniKorisnik.GradId;
            }
        }

        private void FillForm()
        {
           
            ImeTxt.Text = k.Ime;
            PrezimeTxt.Text = k.Prezime;
            EmailTxt.Text = k.Email;
            TelefonTxt.Text = k.BrojTelefona;
            AdressTxt.Text = k.Adresa;
            DatumRodjenjaPicker.Value = k.DatumRodjenja;
            GradCmb.SelectedValue = k.GradId;
               
        }

        private void ImeTxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(ImeTxt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(ImeTxt, Messages.ime_req);
            }
        }

        private void PrezimeTxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(PrezimeTxt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(PrezimeTxt, Messages.prezime_req);
            }
        }

        private void TelefonTxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TelefonTxt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(TelefonTxt, Messages.telefon_req);
            }
        }

        private void EmailTxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(EmailTxt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(EmailTxt, Messages.email_req);
            }
            else
            {
                try
                {
                    MailAddress mail = new MailAddress(EmailTxt.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    errorProvider.SetError(EmailTxt, Messages.email_format);
                }
            }
        }

        private void AdressTxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(AdresaTxt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(AdresaTxt, Messages.adresa_req);
            }
        }

        private void GradCmb_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(GradCmb.SelectedValue) == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(GradCmb, Messages.grad_req);
            }
        }
    }
}
