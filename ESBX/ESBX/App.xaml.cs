using Xamarin.Forms;

namespace ESBX
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            // MainPage = new NavigationPage(new ESBX.KreiranjeSalate()); //new Navigation.MyPage();
            Application.Current.MainPage = new Navigation.MyPage();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
