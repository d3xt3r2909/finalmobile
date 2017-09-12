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
            // TODO: PROMIJENITI KADA BUDEMO U PRODUKCIJU STAVLJALI DA SE VUCE OD TRENUTNOG KORISNIKA ID
            HttpResponseMessage response = service.GetResponse(7);

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
    }
}