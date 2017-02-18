using BcTool.Controls;
using BcTool.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ReadOnlyEntry), typeof(ReadOnlyEntryRenderer))]
namespace BcTool.iOS.Renderers
{
    public class ReadOnlyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (base.Control != null)
            {
                base.Control.Enabled = false;
            }
        }
    }
}
