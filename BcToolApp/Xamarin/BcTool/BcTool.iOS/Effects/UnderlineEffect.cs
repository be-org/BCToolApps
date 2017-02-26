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
    /// Label�ɉ�����t����G�t�F�N�g�N���X
    /// </summary>
    public class UnderlineEffect : PlatformEffect
    {
        /// <summary>
        /// �A�^�b�`
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
        /// �f�^�b�`
        /// </summary>
        protected override void OnDetached()
        {
        }
    }
}