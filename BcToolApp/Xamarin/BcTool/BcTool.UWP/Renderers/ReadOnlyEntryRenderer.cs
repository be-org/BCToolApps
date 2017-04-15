using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BcTool.Controls;
using BcTool.UWP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ReadOnlyEntry), typeof(ReadOnlyEntryRenderer))]
namespace BcTool.UWP.Renderers
{
    public class ReadOnlyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (base.Control != null)
            {
                base.Control.IsReadOnly = true;
            }
        }
    }
}
