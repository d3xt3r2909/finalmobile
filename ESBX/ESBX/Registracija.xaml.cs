using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

namespace ESBX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registracija : ContentPage
	{
        ESBX_MyPLC.Util.WebAPIHelper _service = new ESBX_MyPLC.Util.WebAPIHelper(ESBX_MyPLC.Util.WebApiRoutes.URL_ROUTE, ESBX_MyPLC.Util.WebApiRoutes.LOGIN_ROUTE);
        public Registracija ()
		{
			InitializeComponent ();
		}

        private void registracijaButton_Clicked(object sender, EventArgs e)
        {
            HttpResponseMessage response = _service.GetResponse();

            if (response.IsSuccessStatusCode)
            {

            }
        }
    }
}