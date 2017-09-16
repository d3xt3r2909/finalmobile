using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ESBX_MyPLC.Util;
using ESBX_MyPLC.ViewModel;

using System.Net.Http;
using Newtonsoft.Json;
using System.Globalization;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;

namespace ESBX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KorisnickKorpa : ContentPage
    {
        WebAPIHelper service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_AKTIVNA_KORPA);
        private KorpaMobileVmList source = null;

        public KorisnickKorpa()
        {
            InitializeComponent();
        }

        private List<KorpaMobileVm> getSourceForList()
        {
            HttpResponseMessage response = service.GetResponse(Global.logedUser.Id);

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<KorpaMobileVm>>(jsonObject.Result);
            }

            return null;
        }
        protected override void OnAppearing()
        {
            List<KorpaMobileVm> firstSource = getSourceForList();

            if (firstSource != null)
            {
                lblUkupno.Text =  "Ukupna cijena: " + getSumZarada(firstSource).ToString() + " KM";
                source = new KorpaMobileVmList(firstSource);
                korpaList.ItemsSource = source.Items;
            }

           
            base.OnAppearing();
        }

        public void DeleteClicked(object sender, EventArgs e)
        {
            var item = (Xamarin.Forms.Button)sender;
            KorpaMobileVm listitem = (from itm in source.Items where itm.KorpaId == Convert.ToInt64(item.CommandParameter.ToString()) select itm).FirstOrDefault<KorpaMobileVm>();
            source.Items.Remove(listitem);

            var response = service.DeleteCustomRouteResponse(WebApiRoutes.DELETE_ITEM_KORPA, parameters: "/" + listitem.KorpaId + "/stavke/" + listitem.StavkaId);

            if (!response.IsSuccessStatusCode)
                DisplayAlert("Upozorenje!", "Nije moguce obrisati stavku", "OK");
        }

        public async void NaruciClicked(object sender, EventArgs e)
        {

            var page = new NaruciKorpaDialog();

            // await Navigation.PushPopupAsync(page);
            //// or
            await PopupNavigation.PushAsync(page);
        }
        private float getSumZarada(List<KorpaMobileVm> param)
        {
            float sum = 0;
            foreach (KorpaMobileVm item in param)
                sum += (float.Parse(item.Cijena, CultureInfo.InvariantCulture.NumberFormat)*Convert.ToInt32(item.Kolicina));

            return sum;
        }
    }
}