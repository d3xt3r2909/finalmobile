using ESBX_db.Models;
using ESBX_Client.Util;
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
using ExpressSaladBarDesktop_Client;

namespace ESBX_Client.Menadzer
{
    public partial class AddOsobljeForm : Form
    {
        private WebAPIHelper OsobljeService = new WebAPIHelper("http://localhost:58050/", "api/Korisnici");
        private WebAPIHelper UlogaService = new WebAPIHelper("http://localhost:58050/", "api/Uloge");
        private WebAPIHelper GradoviService = new WebAPIHelper("http://localhost:58050/", "api/Gradovi");

        public AddOsobljeForm()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void AddOsobljeForm_Load(object sender, EventArgs e)
        {
            BindGradovi();
        }
        private void BindGradovi()
        {
            HttpResponseMessage response = GradoviService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Grad> gradovi = response.Content.ReadAsAsync<List<Grad>>().Result;
                gradovi.Insert(0, new Grad() { Naziv = "Odaberite grad" });
                GradCmb.DataSource = gradovi;
                GradCmb.DisplayMember = "Naziv";
                GradCmb.ValueMember = "Id";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (this.ValidateChildren())
            {
                Korisnici k = new Korisnici();
                k.Ime = ImeTxt.Text;
                k.Prezime = PrezimeTxt.Text;
                k.Email = EmailTxt.Text;
                k.Adresa = AdresaTxt.Text;
                k.BrojTelefona = TelefonTxt.Text;
                k.DatumKreiranja = DateTime.Now;
                k.DatumRodjenja = DatumRodjenjaPicker.Value;
                k.GradId = Convert.ToInt32(GradCmb.SelectedValue);
                k.LozinkaSalt = Util.HelperPassword.GenerateSalt();
                k.LozinkaHash = LozinkaTxt.Text;
                HttpResponseMessage responseKorisnik = OsobljeService.PostResponse(k);

                string uspjesno = null;

                if (responseKorisnik.IsSuccessStatusCode)
                {
                    KorisniciUloge ku = new KorisniciUloge();
                    ku.DatumDodjele = DateTime.Now;
                    Korisnici temp = responseKorisnik.Content.ReadAsAsync<Korisnici>().Result;
                    ku.KorisnikId = temp.Id;
                    ku.UlogaId = 3;

                    HttpResponseMessage responseUloge = UlogaService.PostResponse(ku);

                    if (responseUloge.IsSuccessStatusCode)
                        MessageBox.Show("Uspješno ste dodali korisnika.");
                    else
                        uspjesno = responseUloge.ReasonPhrase;

                }
                else
                    uspjesno = responseKorisnik.ReasonPhrase;

                if (!String.IsNullOrEmpty(uspjesno))
                {
                    if (!String.IsNullOrEmpty(Messages.ResourceManager.GetString(uspjesno)))
                    {
                        MessageBox.Show(Messages.ResourceManager.GetString(uspjesno));
                    }
                    else
                    {
                        MessageBox.Show(uspjesno);
                    }
                }
            }
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

        private void AdresaTxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(AdresaTxt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(AdresaTxt, Messages.adresa_req);
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

        private void LozinkaTxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(LozinkaTxt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(LozinkaTxt, Messages.lozinka_req);
            }
            else
            {
                if (LozinkaTxt.Text.Length <= 6)
                {
                    e.Cancel = true;
                    errorProvider.SetError(LozinkaTxt, Messages.lozinka_length);
                }
            }
        }

        private void GradCmb_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(GradCmb.SelectedValue)==0)
            {
                e.Cancel = true;
                errorProvider.SetError(GradCmb, Messages.grad_req);
            }
        }
    }
}
