using Xamarin.Forms;

namespace BcTool.Views
{
    public partial class BulletinBoardPage : TabbedPage
    {
        public BulletinBoardPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // iOS、Androidの場合、ツールバーのリフレッシュは削除する
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                if (this.ToolbarItems.Contains(this.tbiRefresh))
                {
                    this.ToolbarItems.Remove(this.tbiRefresh);
                }
            }
        }
    }
}
