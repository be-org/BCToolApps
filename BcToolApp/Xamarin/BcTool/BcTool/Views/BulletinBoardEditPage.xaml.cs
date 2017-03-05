using System.Collections.Generic;
using BcTool.ViewModels;
using Xamarin.Forms;

namespace BcTool.Views
{
    /// <summary>
    /// 掲示板（編集・表示）ページクラス
    /// </summary>
    public partial class BulletinBoardEditPage : ContentPage
    {
        #region メンバー変数

        /// <summary>
        /// ViewModel
        /// </summary>
        private BulletinBoardEditPageViewModel _viewModel => BindingContext as BulletinBoardEditPageViewModel;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BulletinBoardEditPage()
        {
            InitializeComponent();

            // 遷移先のバックボタンのタイトルを「戻る」にする
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        #endregion

        #region メソッド

        /// <summary>
        /// ロード処理
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // ルートページ遷移イベントの登録
            _viewModel.PopAsRootAsync += OnPopAsRootAsync;
        }

        /// <summary>
        /// 解放処理
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // ルートページ遷移イベントの削除
            _viewModel.PopAsRootAsync -= OnPopAsRootAsync;
        }

        /// <summary>
        /// ルートぺージ遷移イベント処理
        /// </summary>
        /// <param name="sender">イベント元情報</param>
        /// <param name="e">イベント引数</param>
        private async void OnPopAsRootAsync(object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        #endregion
    }
}
