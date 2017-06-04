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

            NavigationService.NavigateAsync(nameof(SigninPage));
            //NavigationService.NavigateAsync(nameof(MasterPage));
            //NavigationService.NavigateAsync("NavigationPage/" + nameof(BulletinBoardTabbedPage));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<SigninPage>();
            Container.RegisterTypeForNavigation<MenuPage>();
            Container.RegisterTypeForNavigation<MasterPage>();
            Container.RegisterTypeForNavigation<SettingPage>();
            Container.RegisterTypeForNavigation<BulletinBoardPage>();
            Container.RegisterTypeForNavigation<BulletinBoardEditPage>();
            Container.RegisterTypeForNavigation<BulletinBoardTabbedPage>();
            Container.RegisterTypeForNavigation<BulletinBoardInfoPage>();
            Container.RegisterTypeForNavigation<UserManagePage>();
            Container.RegisterTypeForNavigation<PasswordChangePage>();
        }
    }
}
