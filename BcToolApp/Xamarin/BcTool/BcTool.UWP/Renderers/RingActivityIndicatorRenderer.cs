using BcTool.UWP.Renderers;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ActivityIndicator), typeof(RingActivityIndicatorRenderer))]

namespace BcTool.UWP.Renderers
{
    public class RingActivityIndicatorRenderer : ViewRenderer<ActivityIndicator, ProgressRing>
    {
        /// <summary>
        /// Foregroundのデフォルト色
        /// </summary>
        private Brush foregroundDefault;

        /// <summary>
        /// Elementの変更イベント処理
        /// </summary>
        /// <param name="e">Elementの変更時のオブジェクト</param>
        protected override void OnElementChanged(ElementChangedEventArgs<ActivityIndicator> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (this.Control == null)
                {
                    // UWPのProgressRingを配置
                    this.SetNativeControl(new ProgressRing());
                    this.Control.Loaded += this.OnControlLoaded;
                }

                this.UpdateIsRunning();
            }
        }

        /// <summary>
        /// Elementのプロパティ変更イベント処理
        /// </summary>
        /// <param name="sender">イベント元情報</param>
        /// <param name="e">プロパティ変更情報</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ActivityIndicator.IsRunningProperty.PropertyName)
            {
                // ActivityIndicator.IsRunningが変わった時
                this.UpdateIsRunning();
            }
            else if (e.PropertyName == ActivityIndicator.ColorProperty.PropertyName)
            {
                // ActivityIndicator.Colorgが変わった時
                this.UpdateColor();
            }
        }

        /// <summary>
        /// コントロールのロードイベント処理
        /// </summary>
        /// <param name="sender">イベント元情報</param>
        /// <param name="routedEventArgs">イベント引数</param>
        private void OnControlLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            // ProgressRingのForegroundをデフォルト値として保持
            this.foregroundDefault = this.Control.Foreground;

            // 指定した色に更新
            this.UpdateColor();

            // ProgressRingのサイズを変更
            this.Control.Height = 50;
            this.Control.Width = 50;
        }

        /// <summary>
        /// 色の更新処理
        /// </summary>
        private void UpdateColor()
        {
            Color color = Element.Color;
            if (color == Color.Default)
            {
                this.Control.Foreground = foregroundDefault;
            }
            else
            {
                this.Control.Foreground = color.ConvertToBrush();
            }
        }

        /// <summary>
        /// IsRunningの更新処理
        /// </summary>
        private void UpdateIsRunning()
        {
            this.Control.IsActive = Element.IsRunning;
        }
    }

    /// <summary>
    /// Colorの拡張クラス
    /// </summary>
    internal static class ConvertExtensions
    {
        /// <summary>
        /// Xamarin.Forms.ColorをBrushに変換
        /// </summary>
        /// <param name="color">Xamarin.Forms.Colorのインスタンス</param>
        /// <returns>Brush</returns>
        public static Brush ConvertToBrush(this Color color)
        {
            return new SolidColorBrush(color.ConvertToWindowsColor());
        }

        /// <summary>
        /// Xamarin.Forms.ColorをWindows.UI.Colorに変換
        /// </summary>
        /// <param name="color">Xamarin.Forms.Colorのインスタンス</param>
        /// <returns>Windows.UI.Color</returns>
        public static Windows.UI.Color ConvertToWindowsColor(this Color color)
        {
            return Windows.UI.Color.FromArgb((byte)(color.A * 255), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255));
        }
    }
}
