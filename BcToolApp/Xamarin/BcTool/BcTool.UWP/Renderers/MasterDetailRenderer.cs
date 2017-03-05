using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BcTool.UWP.Renderers;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(MasterDetailRenderer))]
namespace BcTool.UWP.Renderers
{
    public class MasterDetailRenderer : MasterDetailPageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<MasterDetailPage> e)
        {
            base.OnElementChanged(e);

            var control = base.Control;
            control.Background = new SolidColorBrush(
                Windows.UI.Color.FromArgb(0xff, 0xff, 0x79, 0x00)
                );
            control.ToolbarBackground = new SolidColorBrush(
                Windows.UI.Color.FromArgb(0xff, 0xff, 0x79, 0x00)
                );
        }
    }
}
