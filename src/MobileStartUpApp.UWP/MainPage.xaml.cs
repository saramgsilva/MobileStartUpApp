namespace MobileStartUpApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new MobileStartUpApp.App());
        }
    }
}
