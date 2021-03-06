﻿using System;
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
using System.Collections.ObjectModel;
using ESBX.Navigation;

namespace ESBX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KorisnickKorpa : ContentPage
    {
        WebAPIHelper service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.GET_AKTIVNA_KORPA);
        private KorpaMobileVmList source = null;

        public KorisnickKorpa()
        {
            if (Global.logedUser == null)
            {
                Application.Current.MainPage = new ESBX.Login();
                return;
            }

            InitializeComponent();
        }

        private List<KorpaMobileVm> getSourceForList()
        {
            // dohvacanje listi stavke za korpu odredjenog korisnika
            HttpResponseMessage response = service.GetResponse(Global.logedUser.Id);

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<KorpaMobileVm>>(jsonObject.Result);
            }

            // ukoliko nije pronadjena korpa vratit ce se null vrijednost
            return null;
        }

        protected override void OnAppearing()
        {
            // sa API se povuce source lista koja treba biti ucitana
            List<KorpaMobileVm> firstSource = getSourceForList();

            // ukoliko imaju stavke unutar korpe potrebno je prikazati ih unutar view-a i prikazati ukupnu cijenu 
            if (firstSource != null && firstSource.Count() != 0)
            {
                source = new KorpaMobileVmList(firstSource);
                korpaList.ItemsSource = source.Items;
                lblUkupno.Text = "Ukupna cijena: " + getSumZarada(source.Items).ToString() + " KM";
                lblPraznaKorpa.IsVisible = false;
                bottomControl.IsVisible = true;
            }
            else
            {
                // ukoliko je korpa prazna tada se prikazuje odgovarajuca labela
                lblPraznaKorpa.IsVisible = true;
                bottomControl.IsVisible = false;
            }

            base.OnAppearing();
        }

        public void DeleteClicked(object sender, EventArgs e)
        {
            var item = (Xamarin.Forms.Button)sender;
            // KorpaMobileVm listitem = (from itm in source.Items where itm.KorpaId == Convert.ToInt64(item.CommandParameter.ToString()) select itm).FirstOrDefault<KorpaMobileVm>();
            int korpaFrom = Convert.ToInt32(item.CommandParameter.ToString());
            KorpaMobileVm listitem = source.Items.FirstOrDefault(x => x.StavkaId == korpaFrom);
            source.Items.Remove(listitem);

            var response = service.DeleteCustomRouteResponse(WebApiRoutes.DELETE_ITEM_KORPA, parameters: "/" + listitem.KorpaId + "/stavke/" + listitem.StavkaId);

            if (!response.IsSuccessStatusCode)
                DisplayAlert("Upozorenje!", "Nije moguce obrisati stavku", "OK");
            else
            {
                if (source.Items != null)
                {
                    lblUkupno.Text = "Ukupna cijena: " + getSumZarada(source.Items).ToString() + " KM";
                }
            }
        }

        public async void NaruciClicked(object sender, EventArgs e)
        {
            if (source == null)
            {
                await DisplayAlert("Upozorenje", "Potrebno je kreirati salatu da biste izvršili narudžbu.", "OK");
                return;
            }
            var page = new NaruciKorpaDialog();

            await PopupNavigation.PushAsync(page);
        }

        private float getSumZarada(ObservableCollection<KorpaMobileVm> param)
        {
            float sum = 0;
            foreach (var i in param)
                sum += (float.Parse(i.Cijena, CultureInfo.InvariantCulture.NumberFormat)*Convert.ToInt32(i.Kolicina));

            return sum;
        }
    }
}