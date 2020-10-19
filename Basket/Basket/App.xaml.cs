using Prism;
using Prism.Ioc;
using Prism.Unity;
using Sharpnado.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Basket
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
            Xamarin.Essentials.VersionTracking.Track();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage,MainPageViewModel>();

            containerRegistry.Register<BasketReader>();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            TaskMonitor.Create(NavigationService.NavigateAsync($"/{nameof(MainPage)}"));
        }
    }
}
