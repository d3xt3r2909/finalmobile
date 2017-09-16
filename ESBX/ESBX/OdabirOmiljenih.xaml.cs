using ESBX_MyPLC.Util;
using ESBX_MyPLC.ViewModel;
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
	public partial class OdabirOmiljenih : ContentPage
	{
        private WebAPIHelper service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_VRSTE_SASTOJAKA);
        private List<VrstaSastojka> vrstaSource = null;
        private List<OmiljeniSastojci> listSource = null; 
        private int countCondition = 0; 

        public OdabirOmiljenih ()
        {
            HttpResponseMessage response = service.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync();

                vrstaSource = JsonConvert.DeserializeObject<List<VrstaSastojka>>(jsonResponse.Result);
            }

            string path = WebApiRoutes.GET_SASTOJCI_LIST_OMILJENI;

            HttpResponseMessage responseLista = service.GetCustomRouteResponse(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = responseLista.Content.ReadAsStringAsync().Result;

                listSource = JsonConvert.DeserializeObject<List<OmiljeniSastojci>>(jsonObject);

            }

            InitializeComponent ();
		}

        protected override void OnAppearing()
        {

            if (vrstaSource != null)
            {
                vrsteSastojaka.ItemsSource = vrstaSource;
                vrsteSastojaka.ItemDisplayBinding = new Binding("Naziv");
            }

            if(listSource != null)
                listSastojaka.ItemsSource = listSource;

            base.OnAppearing();
        }

        protected void vrsteSastojaka_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vrstaNaziv = null; 

            if (vrsteSastojaka.SelectedItem != null)
            {
                vrstaNaziv = (vrsteSastojaka.SelectedItem as VrstaSastojka).Naziv;
            }

            string path = WebApiRoutes.GET_SASTOJCI_LIST_OMILJENI;

            if (vrstaNaziv != null)
                path += vrstaNaziv;

            HttpResponseMessage response = service.GetCustomRouteResponse(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync().Result;

                listSource = JsonConvert.DeserializeObject<List<OmiljeniSastojci>>(jsonObject);

                listSastojaka.ItemsSource  = listSource;
            }
        }

        protected void btnDodajOmiljene_Clicked(object sender, EventArgs e)
        {
            var item = (Xamarin.Forms.Button)sender;
            int sastojakId = Convert.ToInt32(item.CommandParameter);

            if (sastojakId != 0)
            {
                OmiljeniSastojci sastojak = listSource.FirstOrDefault(salata => salata.SastojakId == sastojakId);

                KorisnikSastojciVm nv = new KorisnikSastojciVm();
                nv.SastojakId = sastojak.SastojakId;
                nv.KorisnikId = Global.logedUser.Id;

                HttpResponseMessage res = service.PostCustomRouteResponse(WebApiRoutes.POST_DODAJ_OMILJENE, nv);

                if (res.IsSuccessStatusCode)
                {
                    countCondition++; 
                    item.IsVisible = false;
                }

            }
        }

        protected void btnNastavi_Clicked(object sender, EventArgs e)
        {
            if (countCondition < 2)
                DisplayAlert("Upozorenje", "Potrebno je odabrati minimalno dva omiljena proizvoda", "OK");
            else
            {
                //this.Navigation.PushAsync(new Navigation.MyPage());

                Global.logedUser = null;
                Application.Current.MainPage = new Navigation.MyPage();
            }

        }

    }
}