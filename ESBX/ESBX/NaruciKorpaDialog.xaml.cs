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
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NaruciKorpaDialog : PopupPage
    {
        WebAPIHelper service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.POST_NARUCI_KORPU); 

        public NaruciKorpaDialog()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
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

        public void btnNaruciKorpu_clicked(object sender, EventArgs arg)
        {
            NaruciVm naruciObjekt = new NaruciVm();
            naruciObjekt.KorisnikId = 7;
            naruciObjekt.DatumDolaska = datumDolaska.Date + vrijemeDolaska.Time;

            HttpResponseMessage response =  service.PostResponse(naruciObjekt);

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Uspjesno", "Uspjesno ste narucili salatu, provjerite email koji smo Vam proslijedili.", "OK");
            }
            else
            {
                DisplayAlert("Upozorenje!", response.ReasonPhrase, "OK");

            }
        }
    }
}