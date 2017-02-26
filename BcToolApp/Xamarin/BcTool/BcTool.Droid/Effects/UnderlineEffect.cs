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
    /// Label�ɉ�����t����G�t�F�N�g�N���X
    /// </summary>
    public class UnderlineEffect : PlatformEffect
    {
        /// <summary>
        /// �A�^�b�`
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
        /// �f�^�b�`
        /// </summary>
        protected override void OnDetached()
        {
        }
    }
}