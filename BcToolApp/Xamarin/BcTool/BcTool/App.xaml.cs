using Prism.Unity;
using BcTool.Views;
using Xamarin.Forms;

namespace BcTool
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            
            //NavigationService.NavigateAsync(nameof(MasterPage));
            NavigationService.NavigateAsync("NavigationPage/" + nameof(BulletinBoardListPage));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SigninPage>();
            Container.RegisterTypeForNavigation<BulletinBoardListPage>();
			Container.RegisterTypeForNavigation<MenuPage>();
			Container.RegisterTypeForNavigation<MasterPage>();
			Container.RegisterTypeForNavigation<SettingPage>();
            Container.RegisterTypeForNavigation<BulletinBoardPage>();
        }
    }
}
