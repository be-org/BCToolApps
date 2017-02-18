using BcTool.Controls;
using BcTool.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ReadOnlyEntry), typeof(ReadOnlyEntryRenderer))]
namespace BcTool.Droid.Renderers
{
    public class ReadOnlyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (base.Control != null)
            {
                base.Control.KeyListener = null;
            }
        }
    }
}
