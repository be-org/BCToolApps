using System;
using Xamarin.Forms;

namespace BcTool.Views
{
    public partial class BulletinBoardTabbedPage : TabbedPage
    {
        public BulletinBoardTabbedPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Android、iOSは同期ツールバーアイテムを削除
            if (Device.OS == TargetPlatform.Android
                || Device.OS == TargetPlatform.iOS)
            {
                ToolbarItems.Remove(this.tblSynchronize);
            }
        }
    }
}
