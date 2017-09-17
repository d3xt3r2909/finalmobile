using ESBX_MyPLC.Models;
using ESBX_MyPLC.Util;
using ESBX_MyPLC.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESBX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PodesavanjeProfila : ContentPage
    {
        private WebAPIHelper profilService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/Korisnici");
        private WebAPIHelper service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/Gradovi");
       
        Korisnici k = Global.logedUser;
        public PodesavanjeProfila()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
           
            HttpResponseMessage response = service.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<GetGradoviVm> gradoviSource = JsonConvert.DeserializeObject<List<GetGradoviVm>>(jsonObject.Result);
                gradInput.ItemsSource = gradoviSource;
                gradInput.ItemDisplayBinding = new Binding("Naziv");
            }

            FillForm();
           

            base.OnAppearing();
        }

        private void sacuvajAcc_Clicked(object sender, EventArgs e)
        {
            if(imeInput.Text=="" || prezimeInput.Text=="" || telefonInput.Text=="" || emailInput.Text=="" || adresaInput.Text==""
                || gradInput.SelectedIndex == -1)
            {
                DisplayAlert("Upozorenje", "Sva polja su obavezna!", "OK");
                return;
            }
            int broj;
            if(Int32.TryParse(telefonInput.Text,out broj) == false || telefonInput.Text.Count()<9)
            {
                DisplayAlert("Upozorenje", "Polje telefon nije validno!", "OK");
                return;
            }
            if (!HelperMethods.ValidateEmail(emailInput.Text))
            {
                DisplayAlert("Upozorenje", "Polje email nije validno!", "OK");
                return;
            }

            k.Ime = imeInput.Text;
            k.Prezime = prezimeInput.Text;
            k.BrojTelefona = telefonInput.Text;
            k.Email = emailInput.Text;
            k.Adresa = adresaInput.Text;
            k.DatumRodjenja= datumRodjenjaInput.Date;
            k.GradId=gradInput.SelectedIndex;
            HttpResponseMessage response = profilService.PutResponse(k.Id,k);
            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Uspjeh", "Uspješno ste izmjenili podatke!", "OK");
                FillForm();
            }
            else
            {
                string poruka = response.ReasonPhrase;
                if (response.ReasonPhrase == "email_unique")
                {
                    poruka = "Korisnik sa unesenim emailom vec postoji.";
                }
                DisplayAlert("Upozorenje" ,
                response.StatusCode + " : " + poruka,"OK");
            }
        }

        private void lozinkaButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PodesavanjeLozinke());
        }

        private void FillForm()
        {
            imeInput.Text = k.Ime;
            prezimeInput.Text = k.Prezime;
            telefonInput.Text = k.BrojTelefona;
            emailInput.Text = k.Email;
            adresaInput.Text = k.Adresa;
            datumRodjenjaInput.Date = k.DatumRodjenja;
            gradInput.SelectedIndex = k.GradId;
        }
    }
}