using ESBX_MyPLC.Models;
using ESBX_MyPLC.Util;
using ESBX_MyPLC.ViewModel;
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
    public partial class SistemPreporuke : ContentPage
    {
        List<Sastojci> preporuka = new List<Sastojci>();
        KreiranaSalataVM k = new KreiranaSalataVM();
        private WebAPIHelper kreiranjeService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/KreiranjeSalate");

        public SistemPreporuke()
        {
            InitializeComponent();
        }
        public SistemPreporuke(KreiranaSalataVM ks, List<Sastojci> preporuceni)
        {
            k = ks;
            preporuka = preporuceni;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            listSastojci.ItemsSource = preporuka;
            base.OnAppearing();
        }

        private void DodajPreporuceni_Clicked(object sender, EventArgs e)
        {

            var item = (Xamarin.Forms.Button)sender;
            int SastojakId = Convert.ToInt32(item.CommandParameter);
            k.listaIzabranih.Add(SastojakId);
            item.IsVisible = false;
        }

        private void btnDodaj_Clicked(object sender, EventArgs e)
        {
            HttpResponseMessage repsoneDodaj = kreiranjeService.PostResponse(k);
            if (repsoneDodaj.IsSuccessStatusCode)
            {

                DisplayAlert("Uspjeh", "Uspješno ste kreirali salatu.", "OK");

            }
            else
            {
                DisplayAlert("Oprez", "Salata nije kreirana.", "OK");
            }

            this.Navigation.PopAsync();
        }
    }
}