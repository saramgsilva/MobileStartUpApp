using MobileStartUpApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileStartUpApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();           
                       
            HandleApp(Connectivity.NetworkAccess);
            HandInternetConnection();
        }
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            HandleApp(e.NetworkAccess);
        }

        private void HandleApp(NetworkAccess networkAccess)
        {
            if (networkAccess == NetworkAccess.Internet)
            {
                MainPage = new NavigationPage(new LoadingScreenPage())
                {
                    BackgroundColor = Color.White,
                    BarBackgroundColor = Color.Crimson,
                    BarTextColor = Color.White,
                    Title = "Mobile Start Up App"
                };
            }
            else
            {
                MainPage = new InternetNotAvailablePage();              
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        private void HandInternetConnection()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }
    }
}