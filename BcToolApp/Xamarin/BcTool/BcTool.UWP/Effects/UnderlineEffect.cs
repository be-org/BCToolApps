using BcTool.UWP.Effects;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("CustomEffects")]
[assembly: ExportEffect(typeof(UnderlineEffect), nameof(UnderlineEffect))]
namespace BcTool.UWP.Effects
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
            if (base.Control is TextBlock textBlock)
            {
                // 下線の用意
                var run = new Run
                {
                    Text = textBlock.Text
                };

                var underline = new Underline();
                underline.Inlines.Add(run);

                // テキストブロックのテキストをクリアしてから下線をセット
                // ※クリアしないと重複してテキストが出る
                textBlock.Text = string.Empty;
                textBlock.Inlines.Add(underline);
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
