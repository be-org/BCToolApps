using BcTool.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ListView), typeof(CustomListViewRenderer))]
namespace BcTool.iOS.Renderers
{
    /// <summary>
    /// Custom list view renderer.
    /// </summary>
    public class CustomListViewRenderer : ListViewRenderer
    {
        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">E.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);

            if (Control == null)
            {
                return;
            }

			// ListViewのセパレータの余白をゼロにします。
			Control.SeparatorInset = UIEdgeInsets.Zero;
			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
			{
				Control.LayoutMargins = UIEdgeInsets.Zero;
			}
			if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
			{
				Control.CellLayoutMarginsFollowReadableWidth = false;
			}

			// ListView Separator - データが無い部分の線を消します。
			Control.TableFooterView = new UIView();
		}
    }
}
