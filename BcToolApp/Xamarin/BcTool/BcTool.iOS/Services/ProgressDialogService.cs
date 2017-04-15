using System;
using BcTool.Configs;
using BigTed;
using UIKit;
using Xamarin.Forms;
using static BigTed.ProgressHUD;

namespace BcTool.iOS.Services
{
    /// <summary>
    /// 進捗ダイアログサービスクラス
    /// </summary>
    public class ProgressDialogService
    {
        #region メンバー変数

        /// <summary>
        /// プログレスダイアログ
        /// </summary>
        private static ProgressHUD _progress = null;

        #endregion

        #region 公開メソッド

        /// <summary>
        /// 進捗ダイアログの表示
        /// </summary>
        /// <param name="config">進捗ダイアログの設定クラス</param>
        public static void Show(ProgressConfig config)
        {
            _progress = new ProgressHUD()
            {
                HudForegroundColor = GetProgressRingColor(),
                HudBackgroundColour = GetProgressRingBackgroundColor()
            };
            _progress.Show(status: config.ProgressContent, maskType: MaskType.Clear);
        }

        /// <summary>
        /// 進捗ダイアログの非表示
        /// </summary>
        public static void Dismiss()
        {
            _progress.Dismiss();
        }

        #endregion

        #region メソッド

        /// <summary>
        /// プログレスリングの色のUIColorを取得
        /// </summary>
        /// <returns>UIColor</returns>
        private static UIColor GetProgressRingColor()
        {
            // PCL側で定義しているプログレスリングの色を取得
            Xamarin.Forms.Application.Current.Resources.TryGetValue("ProgressRingColor", out object keyValue);
            var color = (Color)keyValue;
            return UIColor.FromRGBA((nfloat)color.R, (nfloat)color.G, (nfloat)color.B, (nfloat)color.A);
        }

        /// <summary>
        /// プログレスリングの背景色のUIColorを取得
        /// </summary>
        /// <returns>UIColor</returns>
        private static UIColor GetProgressRingBackgroundColor()
        {
            // PCL側で定義しているプログレスリングの背景色を取得
            Xamarin.Forms.Application.Current.Resources.TryGetValue("ProgressRingBackgroundColor", out object keyValue);
            var color = (Color)keyValue;
            return UIColor.FromRGBA((nfloat)color.R, (nfloat)color.G, (nfloat)color.B, (nfloat)color.A);
        }

        #endregion
    }
}
