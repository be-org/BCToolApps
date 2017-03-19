using Xamarin.Forms;

namespace BcTool.Views
{
    /// <summary>
    /// 掲示板情報ページクラス
    /// </summary>
    public partial class BulletinBoardInfoPage : ContentPage
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BulletinBoardInfoPage()
        {
            InitializeComponent();

            // 遷移先のバックボタンのタイトルを「戻る」にする
            NavigationPage.SetBackButtonTitle(this, "Back");            
        }

        #endregion
    }
}
