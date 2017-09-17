using ESBX_MyPLC.Models;
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
	public partial class KreiranjeSalate : ContentPage
	{
        Sastojci glavni;
        Sastojci dresing;
        int Kol=1;
        string Nap ;
        int broj;
        SelectMultipleBasePage<Sastojci>  multiPage=null;                                 
        private WebAPIHelper kreiranjeService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/KreiranjeSalate/getsastojci/");
        private WebAPIHelper preporukaService = new WebAPIHelper(WebApiRoutes.URL_ROUTE, "api/SistemPreporuke");
        public KreiranjeSalate ()
		{
			InitializeComponent ();
		}
        
        private void btnKreirajSalatu_Clicked(object sender, EventArgs e)
        {
            if (multiPage != null)
            {
                
                if(GlavniPicker.SelectedIndex == -1 || DresingPicker.SelectedIndex == -1 
                    || Kolicina.Text=="" || Int32.TryParse(Kolicina.Text,out broj) == false)
                {
                    DisplayAlert("Upozorenje", "Podaci nisu validni", "OK");
                    return;
                }
                List<Sastojci> izabrani = multiPage.GetSelection();
                if (izabrani.Count() == 0)
                {
                    DisplayAlert("Upozorenje", "Podaci nisu validni", "OK");
                    return;
                }
                glavni= (Sastojci)GlavniPicker.SelectedItem;
                dresing= (Sastojci)DresingPicker.SelectedItem;
                izabrani.Add(glavni);
                izabrani.Add(dresing);
                List<int> SastojciIds = new List<int>();
                foreach(Sastojci i in izabrani)
                {
                    SastojciIds.Add(i.Id);
                }
               
                if (SastojciIds != null)
                {
                    KreiranaSalataVM k = new KreiranaSalataVM
                    {
                        KorisnikId=Global.logedUser.Id,
                        listaIzabranih=SastojciIds,
                        Kolicina = Convert.ToInt32(Kolicina.Text),
                        Napomena = Napomena.Text
                };

                    //SISTEM PREPORUKE
                    HttpResponseMessage repsonePreporuka = preporukaService.PostResponse(k);
                    if (repsonePreporuka.IsSuccessStatusCode)
                    {

                        var jsonResult = repsonePreporuka.Content.ReadAsStringAsync();
                        List<Sastojci>sastojciPreporuka = JsonConvert.DeserializeObject<List<Sastojci>>(jsonResult.Result);

                        if (sastojciPreporuka.Count() != 0)
                        {
                            //Dialog sa ponudenim sastojcima, ako klikne na button, dodaj u izabrane
                            Navigation.PushAsync(new ESBX.SistemPreporuke(k,sastojciPreporuka));
                            OcistiFormu();
                            return;
                        }

                    }

                    //Na kraju 
                    HttpResponseMessage repsoneDodaj = kreiranjeService.PostCustomRouteResponse("api/KreiranjeSalate", k);
                    if (repsoneDodaj.IsSuccessStatusCode)
                    {
                        
                        DisplayAlert("Uspjeh", "Uspješno ste kreirali salatu.", "OK");
                        OcistiFormu();

                    }
                    else
                    {
                        DisplayAlert("Oprez", "Salata nije kreirana.", "OK");
                    }
                }
            }
            else
            {
                DisplayAlert("Upozorenje", "Podaci nisu validni", "OK");
                return;
            }


        }

        private void OcistiFormu()
        {
            GlavniPicker.SelectedIndex = -1;
            glavni = null;
            DresingPicker.SelectedIndex = -1;
            dresing = null;
            Kol = 1;
            Kolicina.Text = "1";
            Nap = "";
            Napomena.Text = "";
        }

        protected override void OnAppearing()
        {
            HttpResponseMessage repsoneGlavni = kreiranjeService.GetResponse(Constants.SastojakGlavni);
            if (repsoneGlavni.IsSuccessStatusCode)
            {
                var jsonResult = repsoneGlavni.Content.ReadAsStringAsync();
                List<Sastojci> listG = JsonConvert.DeserializeObject<List<Sastojci>>(jsonResult.Result);
                GlavniPicker.ItemsSource = listG;
                GlavniPicker.ItemDisplayBinding = new Binding("Naziv");
            }

            HttpResponseMessage repsoneDresing = kreiranjeService.GetResponse(Constants.SastojakDresing);
            if (repsoneDresing.IsSuccessStatusCode)
            {
                var jsonResult = repsoneDresing.Content.ReadAsStringAsync();
                List<Sastojci> listD = JsonConvert.DeserializeObject<List<Sastojci>>(jsonResult.Result);
                DresingPicker.ItemsSource = listD;
                DresingPicker.ItemDisplayBinding = new Binding("Naziv");
            }

            if (glavni != null)
            {
                GlavniPicker.SelectedIndex = glavni.Id;
            }
            if (dresing != null)
            {
                DresingPicker.SelectedIndex = dresing.Id;
            }
            if (Kol != 1)
            {
                Kol =  Convert.ToInt32(Kolicina.Text);
            }
            else
            {
                Kolicina.Text="1";
            }
            if (Nap != "")
            {
                Nap = Napomena.Text;
            }

            base.OnAppearing();
        }


        protected override void OnDisappearing()
        {
            glavni = (Sastojci)GlavniPicker.SelectedItem;
            dresing = (Sastojci)DresingPicker.SelectedItem;
            if( Int32.TryParse(Kolicina.Text,out broj) == true)
            {
                Kol = Convert.ToInt32(Kolicina.Text);
            }
            else
            {
                Kol = 1;
            }
            
            Nap=Napomena.Text;
        }

        private void btnSporedni_Clicked(object sender, EventArgs e)
        {
            List<Sastojci> sporedni = new List<Sastojci>();
             HttpResponseMessage repsone = kreiranjeService.GetResponse(Constants.SastojakSporedni);
            if (repsone.IsSuccessStatusCode)
            {
                var jsonResult = repsone.Content.ReadAsStringAsync();
                sporedni = JsonConvert.DeserializeObject<List<Sastojci>>(jsonResult.Result);

            }
            
            multiPage = new SelectMultipleBasePage<Sastojci>(sporedni);          
            Navigation.PushAsync(multiPage);          
        }
        


    }
}
    