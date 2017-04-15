using Xamarin.Forms;

namespace BcTool.Views
{
    /// <summary>
    /// 掲示板一覧タブページクラス
    /// </summary>
    public partial class BulletinBoardTabbedPage : TabbedPage
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BulletinBoardTabbedPage()
        {
            InitializeComponent();

            // このページに戻る際は、戻るボタンを表示しない
            NavigationPage.SetHasBackButton(this, false);
            // 遷移先のバックボタンのタイトルを「戻る」にする
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        /// <summary>
        /// ロード処理
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Android、iOSは同期ツールバーアイテムを削除
            if (Device.RuntimePlatform == Device.Android
                || Device.RuntimePlatform == Device.iOS)
            {
                ToolbarItems.Remove(this.tblSynchronize);
            }
        }
    }
}
