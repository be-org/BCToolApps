using System.Windows.Input;
using Prism.Mvvm;
using Xamarin.Forms;

namespace BcTool.ViewModels
{
    /// <summary>
    /// パスワード変更ページViewModelクラス
    /// </summary>
    public class PasswordChangePageViewModel : BindableBase
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PasswordChangePageViewModel()
        {

        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 現在のパスワード
        /// </summary>
        private string _CurrentPassword;
        /// <summary>
        /// 現在のパスワード
        /// </summary>
        public string CurrentPassword
        {
            get
            {
                return _CurrentPassword;
            }

            set
            {
                base.SetProperty(ref _CurrentPassword, value);
            }
        }

        /// <summary>
        /// 新しいパスワード
        /// </summary>
        private string _NewPassword;
        /// <summary>
        /// 新しいパスワード
        /// </summary>
        public string NewPassword
        {
            get
            {
                return _NewPassword;
            }

            set
            {
                base.SetProperty(ref _NewPassword, value);
            }
        }

        /// <summary>
        /// 新しいパスワード（確認）
        /// </summary>
        private string _NewPasswordConfirm;
        /// <summary>
        /// 新しいパスワード（確認）
        /// </summary>
        public string NewPasswordConfirm
        {
            get
            {
                return _NewPasswordConfirm;
            }

            set
            {
                base.SetProperty(ref _NewPasswordConfirm, value);
            }
        }

        #endregion

        #region コマンド

        /// <summary>
        /// 変更ボタンクリックイベントコマンド
        /// </summary>
        private ICommand _BtnChangeClickedCommand = null;
        /// <summary>
        /// 変更ボタンクリックイベントコマンド
        /// </summary>
        public ICommand BtnChangeClickedCommand => _BtnChangeClickedCommand ?? (
            _BtnChangeClickedCommand = new Command(
                () => ExecuteBtnChangeClicked()));

        #endregion

        #region メソッド

        /// <summary>
        /// 変更ボタンクリック処理
        /// </summary>
        private void ExecuteBtnChangeClicked()
        {
        }

        #endregion
    }
}
