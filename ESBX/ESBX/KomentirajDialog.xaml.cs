using ESBX_MyPLC.Util;
using ESBX_MyPLC.ViewModel;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Pages;
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
	public partial class KomentirajDialog : PopupPage
    {
        WebAPIHelper service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.POST_KOMENTAR_SALATA);
        int SalataId = 0, KorpaId = 0, KorisnikId = 0;
        KomentarResponseVm komentari = null;
        public KomentirajDialog(int SalataId, int KorpaId,  int KorisnikId)
        {
            this.SalataId = SalataId;
            this.KorpaId = KorpaId;
            this.KorisnikId = KorisnikId;

            HttpResponseMessage result = service.GetCustomRouteResponse(WebApiRoutes.GET_KOMENTAR, parameters: SalataId + "/korisnik/" + KorisnikId);

            if (result.IsSuccessStatusCode)
            {
                var objectJson = result.Content.ReadAsStringAsync().Result;
                komentari = JsonConvert.DeserializeObject<KomentarResponseVm>(objectJson);
            }


            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (komentari != null)
            {
                inputKomentar.Text = komentari.Komentar;
                inputOcjena.Text = komentari.Ocjena.ToString();
            }

            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // Method for animation child in PopupPage
        // Invoced after custom animation end
        protected override Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        protected override Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1);
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            //return base.OnBackButtonPressed();
            return true;
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return default value - CloseWhenBackgroundIsClicked
            return base.OnBackgroundClicked();
        }

        public void btnKomentiraj_Clicked(object sender, EventArgs arg)
        {
            if (KorisnikId != 0 && KorpaId != 0 && SalataId != 0)
            {
                KomentarVm komentar = new KomentarVm();
                komentar.SalataId = SalataId;
                komentar.KorpaId = KorpaId;
                komentar.KorisnikId = KorisnikId;

                komentar.Komentar = inputKomentar.Text;
                komentar.Ocjena = Convert.ToInt32(inputOcjena.Text);

                HttpResponseMessage result = service.PostCustomRouteResponse(WebApiRoutes.POST_KOMENTAR_SALATA, komentar);

                if (result.IsSuccessStatusCode)
                {
                    DisplayAlert("Obavijest", "Poruka je uspjesno aplicirana", "OK");
                }
                else
                {
                    DisplayAlert("Obavijest", "Poruka nije aplicirana, pokusajte poslije", "OK");

                }
            }
        }
    }
}