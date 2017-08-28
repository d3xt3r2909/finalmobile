using ESBX_MyPLC.Util;
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
	public partial class Registracija : ContentPage
	{
        WebAPIHelper _service = new WebAPIHelper(WebApiRoutes.URL_ROUTE, WebApiRoutes.LOGIN_ROUTE);
        public Registracija ()
		{
			InitializeComponent ();
		}

        private void registracijaButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}