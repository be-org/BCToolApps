using System.Windows.Input;
using BcTool.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace BcTool.ViewModels
{
    /// <summary>
    /// サインインページViewModelのクラス
    /// </summary>
    public class SigninPageViewModel : BindableBase
    {
        #region メンバー変数

        /// <summary>
        /// ナビゲーションサービス
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        /// ダイアログサービス
        /// </summary>
        private readonly IPageDialogService pageDialogService;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService">ナビゲーションサービス</param>
        /// <param name="pageDialogService">ダイアログサービス</param>
        public SigninPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            this.navigationService = navigationService;
            this.pageDialogService = pageDialogService;
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// タイトル画像のソース
        /// </summary>
        public string TitleIconSource { get; } = "BcTool.Resources.Images.UserLogin.png";

        /// <summary>
        /// ユーザーID
        /// </summary>
        private string _UserId;
        /// <summary>
        /// ユーザーID
        /// </summary>
        public string UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                base.SetProperty(ref _UserId, value);
            }
        }

        /// <summary>
        /// パスワード
        /// </summary>
        private string _Password;
        /// <summary>
        /// パスワード
        /// </summary>
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                base.SetProperty(ref _Password, value);
            }
        }

        #endregion

        #region コマンド

        /// <summary>
        /// サインインボタンクリックイベントコマンド
        /// </summary>
        private ICommand _BtnSignInClickedCommand = null;
        /// <summary>
        /// サインインボタンクリックイベントコマンド
        /// </summary>
        public ICommand BtnSignInClickedCommand => _BtnSignInClickedCommand ?? (
            _BtnSignInClickedCommand = new Command(
                () => ExecuteBtnSignInClicked()));

        #endregion

        #region メソッド

        /// <summary>
        /// サインインボタンクリック処理
        /// </summary>
        private async void ExecuteBtnSignInClicked()
        {
            await navigationService.NavigateAsync($"/{nameof(MasterPage)}/{nameof(NavigationPage)}/{nameof(BulletinBoardTabbedPage)}");
        }

        #endregion
    }
}
