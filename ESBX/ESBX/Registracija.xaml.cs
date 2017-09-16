using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using ESBX_MyPLC.ViewModel;
using Newtonsoft.Json;
using ESBX_MyPLC.Util;
using ESBX_MyPLC.Models;
using System.Net.Mail;

namespace ESBX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registracija : ContentPage
	{
        ESBX_MyPLC.Util.WebAPIHelper _service = new ESBX_MyPLC.Util.WebAPIHelper(ESBX_MyPLC.Util.WebApiRoutes.URL_ROUTE, ESBX_MyPLC.Util.WebApiRoutes.POST_REGISTER);
        public Registracija ()
		{

            InitializeComponent();
		}

        private void registracijaButton_Clicked(object sender, EventArgs e)
        {

            if (imeInput.Text == "" || prezimeInput.Text == "" || telefonInput.Text == "" || emailInput.Text == "" || adresaInput.Text == ""
               || gradInput.SelectedIndex == -1 || lozinkaInput.Text=="")
            {
                DisplayAlert("Upozorenje", "Sva polja su obavezna!", "OK");
                return;
            }
            int broj;
            if (Int32.TryParse(telefonInput.Text, out broj) == false || telefonInput.Text.Count() < 9)
            {
                DisplayAlert("Upozorenje", "Polje telefon nije validno!", "OK");
                return;
            }
            try
            {
                MailAddress mail = new MailAddress(emailInput.Text);
            }
            catch (Exception)
            {
                DisplayAlert("Upozorenje", "Polje email nije validno!", "OK");
                return;
            }
            if (lozinkaInput.Text.Length < 6)
            {
                DisplayAlert("Upozorenje", "Lozinka mora sadržavati najmanje 6 karaktera!", "OK");
                return;
            }


            AccountRegistrationVm acc = new AccountRegistrationVm();

            acc.Ime = imeInput.Text;
            acc.Prezime = prezimeInput.Text;
            acc.EmailAdresa = emailInput.Text;
            acc.Adresa = adresaInput.Text;
            acc.Telefon = telefonInput.Text;
            acc.Lozinka = lozinkaInput.Text;
            acc.DatumRodjenja = datumRodjenjaInput.Date;

            if (gradInput.SelectedItem != null)
            {
                int gradId = (gradInput.SelectedItem as GetGradoviVm).Id;
                acc.GradId = gradId;

                HttpResponseMessage response = _service.PostResponse(acc);

                if (response.IsSuccessStatusCode)
                {
                    AccountLoginVm login = new AccountLoginVm();
                    login.Lozinka = lozinkaInput.Text;
                    login.UserName = emailInput.Text;

                    HttpResponseMessage responseLogin = _service.PostCustomRouteResponse(WebApiRoutes.LOGIN_ROUTE, login);

                    if (responseLogin.IsSuccessStatusCode)
                    {

                        var jsonObject = responseLogin.Content.ReadAsStringAsync().Result;
                            
                        Global.logedUser = JsonConvert.DeserializeObject<Korisnici>(jsonObject);

                        Navigation.PushAsync(new OdabirOmiljenih());
                    }
                    else
                    {
                        DisplayAlert("Upozorenje!", "Doslo je do greske prilikom prijave na sistem.", "OK");
                    }
                }
                else
                {
                    var json = response.Content.ReadAsStringAsync();

                    List<string> errorList = JsonConvert.DeserializeObject<List<string>>(json.Result);

                    string errors = "";
                    foreach (string error in errorList)
                        errors += error + "\n";

                    DisplayAlert("Upozorenje!", errors, "OK");
                }
            }
            else
            {
                DisplayAlert("Upozorenje!", "Potrebno je izabrati grad", "OK");
            }
        }

        protected override void OnAppearing()
        {
            HttpResponseMessage response = _service.GetCustomRouteResponse(WebApiRoutes.GET_GRADOVI);

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<GetGradoviVm> gradoviSource = JsonConvert.DeserializeObject<List<GetGradoviVm>>(jsonObject.Result);
                gradInput.ItemsSource = gradoviSource;
                gradInput.ItemDisplayBinding = new Binding("Naziv");
            }

            base.OnAppearing();
        }
    }
}