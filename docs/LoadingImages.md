# Mobile StartUp App

## Loading Images


Install the nugets, in all projects:

* **Xamarin.FFImageLoading**
* **Xamarin.FFImageLoading.Forms**

And then in each platform add the code, to init render called CachedImageRender.

    CachedImageRenderer.Init(~true);

* **Android**


        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            CachedImageRenderer.Init(true);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

* **IOS**


            public override bool FinishedLaunching(UIApplication app, NSDictionary options)
            {
                global::Xamarin.Forms.Forms.Init();
                CachedImageRenderer.Init();
                LoadApplication(new App());

                return base.FinishedLaunching(app, options);
            }
* **UWP**


                protected override void OnLaunched(LaunchActivatedEventArgs e)
                {


                    Frame rootFrame = Window.Current.Content as Frame;

                    // Do not repeat app initialization when the Window already has content,
                    // just ensure that the window is active
                    if (rootFrame == null)
                    {
                        // Create a Frame to act as the navigation context and navigate to the first page
                        rootFrame = new Frame();

                        rootFrame.NavigationFailed += OnNavigationFailed;
                        CachedImageRenderer.Init();
                        Xamarin.Forms.Forms.Init(e);

                        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                        {
                            //TODO: Load state from previously suspended application
                        }

                        // Place the frame in the current Window
                        Window.Current.Content = rootFrame;
                    }

                    if (rootFrame.Content == null)
                    {
                        // When the navigation stack isn't restored navigate to the first page,
                        // configuring the new page by passing required information as a navigation
                        // parameter
                        rootFrame.Navigate(typeof(MainPage), e.Arguments);
                    }
                    // Ensure the current window is active
                    Window.Current.Activate();
                }


Create the folder **images** and add the **offlinelogo.png** image (as **Embedded resource**).

Then open the **InternetNotAvailablePage.xaml** file and add the code

     <ContentPage.Content>
            <StackLayout
                HorizontalOptions="CenterAndExpand"
                Orientation="Vertical"
                VerticalOptions="CenterAndExpand">

                <forms:CachedImage
                    x:Name="internetNotAvailableImage"
                    DownsampleToViewSize="true"
                    HeightRequest="100"
                    HorizontalOptions="Center"
                    VerticalOptions="StartAndExpand"
                    WidthRequest="100" />

                <Label
                    Margin="20,10,20,20"
                    FontAttributes="Bold"
                    FontSize="Medium"
                    HorizontalOptions="CenterAndExpand"
                    HorizontalTextAlignment="Start"
                    Text="Internet connection was lost!"
                    TextColor="Crimson"
                    VerticalOptions="StartAndExpand" />

                <Label
                    Margin="20,10,20,20"
                    FontSize="Medium"
                    HorizontalOptions="CenterAndExpand"
                    HorizontalTextAlignment="Start"
                    Text="Please verify your internet connection."
                    VerticalOptions="StartAndExpand" />
            </StackLayout>
        </ContentPage.Content>


After it, in code be hide, load the image has following:


      public partial class InternetNotAvailablePage : ContentPage
        {
            private ImageSource _imageSource;

            public InternetNotAvailablePage()
            {
                _imageSource = ImageSource.FromResource("MobileStartUpApp.Images.offlinelogo.png");
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

Note: we should dispose the image doing **internetNotAvailableImage.Source = null;**
