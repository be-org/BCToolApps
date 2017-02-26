using BcTool.iOS.Effects;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("CustomEffects")]
[assembly: ExportEffect(typeof(UnderlineEffect), nameof(UnderlineEffect))]
namespace BcTool.iOS.Effects
{
    /// <summary>
    /// Labelに下線を付けるエフェクトクラス
    /// </summary>
    public class UnderlineEffect : PlatformEffect
    {
        /// <summary>
        /// アタッチ
        /// </summary>
        protected override void OnAttached()
        {
            var label = this.Control as UILabel;
            if (label != null)
            {
                label.AttributedText = new NSAttributedString(label.Text, underlineStyle: NSUnderlineStyle.Single);
            }
        }

        /// <summary>
        /// デタッチ
        /// </summary>
        protected override void OnDetached()
        {
        }
    }
}