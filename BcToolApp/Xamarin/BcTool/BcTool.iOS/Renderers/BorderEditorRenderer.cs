using BcTool.Controls;
using BcTool.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderEditor), typeof(BorderEditorRenderer))]
namespace BcTool.iOS.Renderers
{
    /// <summary>
    /// ボーダー付きEditorのレンダラークラス
    /// </summary>
    public class BorderEditorRenderer : EditorRenderer
    {
        /// <summary>
        /// Elementの変更イベント処理
        /// </summary>
        /// <param name="e">Elementの変更時のオブジェクト</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            var editer = e.NewElement as BorderEditor;
            if (base.Control != null)
            {
                base.Control.Layer.BorderColor = UIColor.FromRGB(204, 204, 204).CGColor;
                base.Control.Layer.BorderWidth = 0.5f;
                base.Control.Layer.CornerRadius = 3f;
                base.Control.Editable = !editer.IsReadOnly;
                
            }
        }
    }
}
