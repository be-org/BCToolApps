using BcTool.Controls;
using BcTool.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderEditor), typeof(BorderEditorRenderer))]
namespace BcTool.Droid.Renderers
{
    public class BorderEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            var editer = e.NewElement as BorderEditor;

            if (base.Control != null)
            {
                if (editer.IsReadOnly)
                {
                    base.Control.KeyListener = null;
                }
            }
        }
    }
}
