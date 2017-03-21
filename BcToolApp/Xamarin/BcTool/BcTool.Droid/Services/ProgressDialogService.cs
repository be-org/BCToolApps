using Android.Content;
using AndroidHUD;
using BcTool.Configs;

namespace BcTool.Droid.Services
{
    /// <summary>
    /// 進捗ダイアログサービスクラス
    /// </summary>
    public class ProgressDialogService
    {
        #region 公開メソッド

        /// <summary>
        /// 進捗ダイアログの表示
        /// </summary>
        /// <param name="context">コンテキスト</param>
        /// <param name="config">進捗ダイアログの設定クラス</param>
        public static void Show(Context context, ProgressConfig config)
        {
            AndHUD.Shared.Show(context, status: config.ProgressContent, maskType: MaskType.Clear);
        }

        /// <summary>
        /// 進捗ダイアログの非表示
        /// </summary>
        /// <param name="context">コンテキスト</param>
        public static void Dismiss(Context context)
        {
            AndHUD.Shared.Dismiss(context);
        }

        #endregion
    }
}