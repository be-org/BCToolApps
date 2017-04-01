using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;

// コンテンツ ダイアログの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace BcTool.UWP.Dialogs
{
    /// <summary>
    /// プログレスダイアログ
    /// </summary>
    public sealed partial class ProgressDialog : ContentDialog
    {
        #region プロパティ

        /// <summary>
        /// 進捗コンテンツ
        /// </summary>
        public string ProgressContent
        {
            set
            {
                txbContent.Text = value ?? string.Empty;
            }
        }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ProgressDialog()
        {
            this.InitializeComponent();

            // ProgressRingのForegroundにアプリテーマの色を設定
            Background = GetProgressBackgroundColor();
            progress.Foreground = GetProgressRingColor();
        }

        #endregion

        #region メソッド

        /// <summary>
        /// プログレスリングの色のSolidColorBrushを取得
        /// </summary>
        /// <returns>SolidColorBrush</returns>
        private SolidColorBrush GetProgressRingColor()
        {
            // PCL側で定義しているプログレスリングの色を取得
            object keyValue;
            BcTool.App.Current.Resources.TryGetValue("ProgressRingColor", out keyValue);
            var color = (Color)keyValue;

            var brush = new SolidColorBrush(new Windows.UI.Color
            {
                R = (byte)(color.R * 255),
                G = (byte)(color.G * 255),
                B = (byte)(color.B * 255),
                A = (byte)(color.A * 255)
            });

            return brush;
        }

        /// <summary>
        /// プログレスリングの背景色のSolidColorBrushを取得
        /// </summary>
        /// <returns>SolidColorBrush</returns>
        private SolidColorBrush GetProgressBackgroundColor()
        {
            // PCL側で定義しているプログレスリングの背景色を取得
            object keyValue;
            BcTool.App.Current.Resources.TryGetValue("ProgressRingBackgroundColor", out keyValue);
            var color = (Color)keyValue;

            var brush = new SolidColorBrush(new Windows.UI.Color
            {
                R = (byte)(color.R * 255),
                G = (byte)(color.G * 255),
                B = (byte)(color.B * 255),
                A = (byte)(color.A * 255)
            });

            return brush;
        }

        #endregion
    }
}
