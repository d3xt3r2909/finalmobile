﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ESBX_MyPLC.ViewModel;
using ESBX_MyPLC.Util;
using System.Net.Http;
using ESBX_MyPLC.Models;
using Newtonsoft.Json;

namespace ESBX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        WebAPIHelper loginService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.LOGIN_ROUTE);
        WebAPIHelper igraService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/NagradnaIgra");
        WebAPIHelper kreiranjeService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/KreiranjeSalate/getsastojci/");

        KreiranaSalataVM kreiranjeSalate = null; 

        public Login(KreiranaSalataVM IntialKreiranaSalata = null)
        {
            kreiranjeSalate = IntialKreiranaSalata; 

            InitializeComponent();
        }

        private void prijavaButton_Clicked(object sender, EventArgs e)
        {
            AccountLoginVm login = new AccountLoginVm();

            if (emailInput.Text == "" || lozinkaInput.Text == "")
            {
                DisplayAlert("Upozorenje", "Podaci nisu validni", "OK");
                return;
            }
            login.UserName = emailInput.Text;
            login.Lozinka = lozinkaInput.Text;

            HttpResponseMessage response = loginService.PostResponse(login);

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = response.Content.ReadAsStringAsync();

                // Dodjeli kreiranog korisnika
                Global.logedUser = JsonConvert.DeserializeObject<Korisnici>(jsonResult.Result);

                // Ukoliko je kreirana salata kada nismo logirani, tu salatu je potrebno dodati u korpu
                if (kreiranjeSalate != null) {

                    kreiranjeSalate.KorisnikId = Global.logedUser.Id;

                    HttpResponseMessage repsoneDodaj = kreiranjeService.PostCustomRouteResponse("api/KreiranjeSalate", kreiranjeSalate);
                    if (repsoneDodaj.IsSuccessStatusCode)
                    {
                        DisplayAlert("Uspjeh", "Vasa salata je dodata u korpu", "UREDU");
                    }
                }

                //NAGRADNA IGRA
                HttpResponseMessage responseIgra = igraService.GetActionResponse("GetKupon",Global.logedUser.Id.ToString());
                var jsonResponse = responseIgra.Content.ReadAsStringAsync();
                NagradnaVM Popust = JsonConvert.DeserializeObject<NagradnaVM>(jsonResponse.Result);
                if (Popust.imaPopust == "da")
                {
                    DisplayAlert("Čestitamo", "Proglašeni ste kupcem mjeseca i osvojili ste " + Popust.Popust 
                        + " popusta prilikom naredne kupovine. Vaš popust vrijedi do: " + Popust.VrijediDo + " , a šifra je: " + Popust.Sifra + " . \n  \n Vaš Exspress Salad Bar.", "OK");
                }


                Application.Current.MainPage = new Navigation.MyPage();

                //this.Navigation.PushAsync(new Navigation.MyPage());
            }
            else
                DisplayAlert("Uspjeh", "Unjeli ste pogresan ime ili lozinku", "OK");
        }

        private void registracijaButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Registracija();

            // this.Navigation.PushAsync(new Registracija());
        }
    }
}