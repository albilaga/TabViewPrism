using Prism;
using Prism.Ioc;
using Prism.Navigation;
using TabView.ViewModels;
using TabView.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TabView
{
    public partial class App
    {
        public App() : this(null)
        {
        }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync(
                $"{nameof(MainPage)}?{KnownNavigationParameters.CreateTab}={nameof(Tab1View)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(MiddleTabView)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(Tab2View)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterTabbedView<Tab1View, Tab1ViewViewModel>();
            containerRegistry.RegisterTabbedView<MiddleTabView, MiddleTabViewViewModel>();
            containerRegistry.RegisterTabbedView<Tab2View, Tab2ViewViewModel>();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}