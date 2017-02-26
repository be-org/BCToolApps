using Android.Graphics;
using Android.Widget;
using BcTool.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("CustomEffects")]
[assembly: ExportEffect(typeof(UnderlineEffect), "UnderlineEffect")]
namespace BcTool.Droid.Effects
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
            var textView = this.Control as TextView;
            if (textView != null)
            {
                textView.PaintFlags = textView.PaintFlags | PaintFlags.UnderlineText;
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