using ESBX_MyPLC.Models;
using ESBX_MyPLC.Util;
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
    public partial class PregledOcjena : ContentPage
    {
        private WebAPIHelper komentariService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/Komentari");
        public PregledOcjena()
        {
            if (Global.logedUser == null)
            {
                Application.Current.MainPage = new ESBX.Login();
                return;
            }

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            HttpResponseMessage response = komentariService.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync();
                List<OcjeneKomentari> komentari = JsonConvert.DeserializeObject<List<OcjeneKomentari>>(jsonResponse.Result);
                listKomentari.ItemsSource = komentari;

                if (komentari.Count() == 0)
                    lblPregledOcjenaPrazno.IsVisible = true;
                else
                    lblPregledOcjenaPrazno.IsVisible = false;
            }

            base.OnAppearing();
        }
    }
}
