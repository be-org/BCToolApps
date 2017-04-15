using Android.Graphics;
using Android.Widget;
using BcTool.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("CustomEffects")]
[assembly: ExportEffect(typeof(UnderlineEffect), nameof(UnderlineEffect))]
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
            if (base.Control is TextView textView)
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