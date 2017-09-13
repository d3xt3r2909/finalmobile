
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
        public Login()
        {
            InitializeComponent();
        }

        private void prijavaButton_Clicked(object sender, EventArgs e)
        {
            AccountLoginVm login = new AccountLoginVm();

            login.UserName = emailInput.Text;
            login.Lozinka = lozinkaInput.Text;

            HttpResponseMessage response = loginService.PostResponse(login);

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = response.Content.ReadAsStringAsync();
                Global.logedUser = JsonConvert.DeserializeObject<Korisnici>(jsonResult.Result);

                this.Navigation.PushAsync(new PodesavanjeProfila());
            }
            else
                DisplayAlert("Uspjeh", "Unjeli ste pogresan ime ili lozinku", "OK");
        }

        private void registracijaButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Registracija());
        }
    }
}