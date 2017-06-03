using BcTool.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
namespace BcTool.iOS.Renderers
{
    /// <summary>
    /// Custom view cell renderer.
    /// </summary>
    public class CustomViewCellRenderer : ViewCellRenderer
	{
        /// <summary>
        /// Gets the cell.
        /// </summary>
        /// <returns>The cell.</returns>
        /// <param name="item">Item.</param>
        /// <param name="reusableCell">Reusable cell.</param>
        /// <param name="tv">Tv.</param>
		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var cell = base.GetCell(item, reusableCell, tv);
			
            if (cell != null)
			{
				//iOS8/iOS9対応
				if (!UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
				{
					foreach (UITableViewCell tvCell in tv.VisibleCells)
					{
						tvCell.SeparatorInset = UIEdgeInsets.Zero;
						if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
						{
							tvCell.LayoutMargins = UIEdgeInsets.Zero;
							tvCell.PreservesSuperviewLayoutMargins = false;
						}
					}
				}
			}

			return cell;
		}
	}
}