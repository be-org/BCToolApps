using Prism.Unity;
using BcTool.Views;

namespace BcTool
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(nameof(BulletinBoardListPage));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SigninPage>();
            Container.RegisterTypeForNavigation<BulletinBoardListPage>();
        }
    }
}
