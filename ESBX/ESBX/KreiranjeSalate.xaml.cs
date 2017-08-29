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
	public partial class KreiranjeSalate : ContentPage
	{
        private WebAPIHelper kreiranjeService = new WebAPIHelper("http://hci148.app.fit.ba/", "api/KreiranjeSalate");
		public KreiranjeSalate ()
		{
			InitializeComponent ();
		}

        private void btnDodajUKorpu_Clicked(object sender, EventArgs e)
        {

        }
        protected override void OnAppearing()
        {
            HttpResponseMessage repsoneGlavni = kreiranjeService.GetResponse(1);
            if (repsoneGlavni.IsSuccessStatusCode)
            {
                var jsonResult = repsoneGlavni.Content.ReadAsStringAsync();
                List<Sastojci> listG = JsonConvert.DeserializeObject<List<Sastojci>>(jsonResult.Result);
                GlavniPicker.ItemsSource = listG;
                GlavniPicker.ItemDisplayBinding = new Binding("Naziv");
            }



            HttpResponseMessage repsoneDresing = kreiranjeService.GetResponse(3);
            if (repsoneDresing.IsSuccessStatusCode)
            {
                var jsonResult = repsoneDresing.Content.ReadAsStringAsync();
                List<Sastojci> listD = JsonConvert.DeserializeObject<List<Sastojci>>(jsonResult.Result);
                DresingPicker.ItemsSource = listD;
                DresingPicker.ItemDisplayBinding = new Binding("Naziv");
            }


            base.OnAppearing();
        }
    }

       
    
}