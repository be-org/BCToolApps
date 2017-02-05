using BcTool.UWP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Switch), typeof(ContentHideSwitchRenderer))]
namespace BcTool.UWP.Renderers
{
    /// <summary>
    /// SwitchのOn、Offコンテンツを表示しないレンダラークラス
    /// </summary>
    public class ContentHideSwitchRenderer : SwitchRenderer
    {
        /// <summary>
        /// Elementの変更イベント処理
        /// </summary>
        /// <param name="e">Elementの変更時のオブジェクト</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            base.OnElementChanged(e);

            if (base.Control != null)
            {
                base.Control.OnContent = string.Empty;
                base.Control.OffContent = string.Empty;
            }
        }
    }
}
