﻿using ESBX_MyPLC.Models;
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
        private WebAPIHelper profilService = new WebAPIHelper("http://hci148.app.fit.ba/", "api/Korisnici");
        private WebAPIHelper service = new WebAPIHelper("http://hci148.app.fit.ba/", "api/Gradovi");
        //@TODO vrati na Global.logedUser
        Korisnici k;
        //Korisnici k = Global.logedUser;
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

        private void sacuvajAcc_Clicked()
        {
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
                DisplayAlert( "Uspjeh", "Uspješno ste izmjenili podatke!","OK");
                FillForm();
            }
            else
            {
                DisplayAlert("Error Code" ,
                response.StatusCode + " : Message - " + response.ReasonPhrase,"OK");
            }
        }

        private void lozinkaButton_Clicked()
        {
            Navigation.PushAsync(new PodesavanjeLozinke());
        }

        private void FillForm()
        {
            //IZBRISI
            HttpResponseMessage responseTemp = profilService.GetResponse(10);
            if (responseTemp.IsSuccessStatusCode)
            {

                var jsonObject = responseTemp.Content.ReadAsStringAsync();
                k = JsonConvert.DeserializeObject<Korisnici>(jsonObject.Result);

            }


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