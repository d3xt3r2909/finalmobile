using ESBX_MyPLC.Models;
using ESBX_MyPLC.Util;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
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
        private List<NarudzbeVM> salate = null;
        public HistorijaNarucenih ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            string KorisnikId = Global.logedUser.Id.ToString();
            HttpResponseMessage responseMessage = salateService.GetActionResponse("GetHistorijaNarudzbe", KorisnikId);
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonResponse = responseMessage.Content.ReadAsStringAsync();
                salate = JsonConvert.DeserializeObject<List<NarudzbeVM>>(jsonResponse.Result);
                listHistorija.ItemsSource = salate;
            }

            base.OnAppearing();
        }
        private async void KomentarSalate_Clicked(object sender, EventArgs e)
        {
            var item = (Xamarin.Forms.Button)sender;
            int salataId = Convert.ToInt32(item.CommandParameter);

            if (salataId != 0)
            {
                NarudzbeVM narudzba = salate.FirstOrDefault(salata => salata.SalataId == salataId);

                KomentirajDialog komentirajDialog = new KomentirajDialog(narudzba.SalataId, narudzba.KorpaId ,narudzba.KorisnikId);
                await PopupNavigation.PushAsync(komentirajDialog);
            }
        }
        private void DodajSalatu_Clicked(object sender,EventArgs e)
        {
            var item = (Xamarin.Forms.Button)sender;
            int SalataId = Convert.ToInt32(item.CommandParameter);
            NarudzbeVM nar = new NarudzbeVM();
            nar.SalataId = SalataId;
            nar.KorisnikId = Global.logedUser.Id;
            HttpResponseMessage responseMessage = salateService.PostResponse(nar);
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