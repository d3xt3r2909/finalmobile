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
	public partial class TrenutnoNarucene : ContentPage
	{
        private WebAPIHelper salateService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/Narudzba");
        public TrenutnoNarucene ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            string KorisnikId = Global.logedUser.Id.ToString();
            HttpResponseMessage responseMessage = salateService.GetActionResponse("GetTrenutneNarudzbe", KorisnikId);
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonResponse = responseMessage.Content.ReadAsStringAsync();
                List<NarudzbeVM> salate = JsonConvert.DeserializeObject<List<NarudzbeVM>>(jsonResponse.Result);
                listTrenutne.ItemsSource = salate;
                String Ukupno = (salate.Sum(x => Convert.ToDouble(x.Cijena))).ToString();
                UkupnaCijena.Text = "Ukupno: " + Ukupno+" KM";
            }


            base.OnAppearing();
        }
    }
}