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
	public partial class HistorijaNarucenih : ContentPage
	{
        private WebAPIHelper salateService = new WebAPIHelper("http://hci148.app.fit.ba/", "api/Narudzba");

        public HistorijaNarucenih ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {

            //KORISNIK ID PROMJENI
            HttpResponseMessage responseMessage = salateService.GetActionResponse("GetHistorijaNarudzbe", "10");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonResponse = responseMessage.Content.ReadAsStringAsync();
                List<NarudzbeVM> salate = JsonConvert.DeserializeObject<List<NarudzbeVM>>(jsonResponse.Result);
                listHistorija.ItemsSource = salate;
            }

            base.OnAppearing();
        }

        private void DodajSalatu_Clicked(object sender,EventArgs e)
        {
            var item = (Xamarin.Forms.Button)sender;
            int SalataId = Convert.ToInt32(item.CommandParameter);
            HttpResponseMessage responseMessage = salateService.PostResponse(SalataId);
            if (responseMessage.IsSuccessStatusCode)
            {
                DisplayAlert("Uspjesh", "Uspješno ste dodali salatu u korpu", "OK");
            }
            else
            {
                DisplayAlert("Upozorenje",  "Dodgodila se greška. Salata nije dodana u korpu.", "OK");
            }
        }


     }
}