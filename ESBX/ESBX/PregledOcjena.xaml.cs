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
        private WebAPIHelper komentariService = new WebAPIHelper("http://hci148.app.fit.ba/", "api/Komentari");
        public PregledOcjena()
        {
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
            }

            base.OnAppearing();
        }
    }
}
