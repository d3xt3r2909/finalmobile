using ESBX_MyPLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        List<Sastojci> odabrani = new List<Sastojci>();
        public SistemPreporuke()
        {
            InitializeComponent();
        }
        public SistemPreporuke(List<Sastojci> preporuceni)
        {
            preporuka = preporuceni;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            listSastojci.ItemsSource = preporuka;
            base.OnAppearing();
        }

        private void DodajPreporuceni_Clicked()
        {

        }
    }
}