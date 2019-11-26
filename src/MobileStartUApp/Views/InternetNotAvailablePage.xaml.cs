﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileStartUApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InternetNotAvailablePage : ContentPage
    {
        private ImageSource _imageSource;

        public InternetNotAvailablePage()
        {
            _imageSource = ImageSource.FromResource("MobileStartUApp.Images.offlinelogo.png");
            InitializeComponent();

            internetNotAvailableImage.Source = _imageSource;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CleanUp();
        }

        public void CleanUp()
        {
            _imageSource = null;
            internetNotAvailableImage.Source = null;
        }
    }
}