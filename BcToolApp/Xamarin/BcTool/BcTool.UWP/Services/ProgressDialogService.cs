using System;
using BcTool.Configs;
using BcTool.UWP.Dialogs;

namespace BcTool.UWP.Services
{
    /// <summary>
    /// 進捗ダイアログサービスクラス
    /// </summary>
    public class ProgressDialogService
    {
        #region メンバー変数

        /// <summary>
        /// 進捗ダイアログのインスタンス
        /// </summary>
        private static ProgressDialog _dialog = null;

        #endregion

        #region 公開メソッド

        /// <summary>
        /// 進捗ダイアログの表示
        /// </summary>
        /// <param name="config">進捗ダイアログの設定クラス</param>
        public static async void ShowAsync(ProgressConfig config)
        {
            _dialog = new ProgressDialog
            {
                ProgressContent = config.ProgressContent
            };

            await _dialog.ShowAsync();
        }

        /// <summary>
        /// 進捗ダイアログの非表示
        /// </summary>
        public static void Dismiss()
        {
            _dialog?.Hide();
        }

        #endregion
    }
}
