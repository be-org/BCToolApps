using BcTool.Controls;
using BcTool.UWP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(BorderEditor), typeof(BorderEditorRenderer))]
namespace BcTool.UWP.Renderers
{
    public class BorderEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            var editer = e.NewElement as BorderEditor;

            if (base.Control != null)
            {
                base.Control.IsReadOnly = editer.IsReadOnly;
            }
        }
    }
}
