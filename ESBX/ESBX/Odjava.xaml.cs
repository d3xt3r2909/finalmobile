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
	public partial class Odjava : ContentPage
	{
		public Odjava ()
		{
            Global.logedUser = null;
            Application.Current.MainPage = new NavigationPage(new Login());
            InitializeComponent ();
		}
        
    }
}