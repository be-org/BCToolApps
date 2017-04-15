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
    /// Label�ɉ�����t����G�t�F�N�g�N���X
    /// </summary>
    public class UnderlineEffect : PlatformEffect
    {
        /// <summary>
        /// �A�^�b�`
        /// </summary>
        protected override void OnAttached()
        {
            if (base.Control is TextView textView)
            {
                textView.PaintFlags = textView.PaintFlags | PaintFlags.UnderlineText;
            }
        }

        /// <summary>
        /// �f�^�b�`
        /// </summary>
        protected override void OnDetached()
        {
        }
    }
}