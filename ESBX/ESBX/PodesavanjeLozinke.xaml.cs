﻿using ESBX_MyPLC.Models;
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
	public partial class PodesavanjeLozinke : ContentPage
	{
        private WebAPIHelper profilService = new WebAPIHelper("http://hci148.app.fit.ba/", "api/Korisnici");
        private HelperPassword h = new HelperPassword();

        Korisnici k;

		public PodesavanjeLozinke ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            //IZBRISI
            HttpResponseMessage responseTemp = profilService.GetResponse(10);
            if (responseTemp.IsSuccessStatusCode)
            {

                var jsonObject = responseTemp.Content.ReadAsStringAsync();
                k = JsonConvert.DeserializeObject<Korisnici>(jsonObject.Result);

            }
            base.OnAppearing();
        }

        private void SacuvajPass_Clicked()
        {

            if (k.LozinkaHash == h.GenerateHash(trenutniPass.Text, k.LozinkaSalt))
            {
                if(noviPass.Text!=null && noviPass.Text == noviPassTwo.Text)
                {
                    k.LozinkaHash = h.GenerateHash(noviPass.Text, k.LozinkaSalt);

                    HttpResponseMessage responseMessage = profilService.PutResponse(k.Id, k);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        DisplayAlert("Uspjeh", "Uspješno ste promijenili lozinku!", "OK");
                    }
                    else
                    {
                        DisplayAlert("Upozorenje",responseMessage.ReasonPhrase, "OK");
                    }

                    
                }
                else
                {
                    DisplayAlert("Upozorenje", "Provjerite novu lozinku!", "OK");
                }
            }
            else
            {
                DisplayAlert("Upozorenje", "Provjerite trenutnu lozinku!", "OK");
            }
        }
    }
}