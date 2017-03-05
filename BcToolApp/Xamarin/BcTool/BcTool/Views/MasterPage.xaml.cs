using BcTool.Services;
using Xamarin.Forms;

namespace BcTool.Views
{
    /// <summary>
    /// マスタページクラス
    /// </summary>
	public partial class MasterPage : MasterDetailPage
	{
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MasterPage()
		{
			InitializeComponent();
        }

        #endregion

        #region イベント処理

        /// <summary>
        /// 戻るボタン押下処理
        /// </summary>
        /// <returns>bool</returns>
        protected override bool OnBackButtonPressed()
        {

            if (Device.OS == TargetPlatform.Windows && !DependencyService.Get<IBackButtonVisibilityService>().GetBackButtonVisibility())
            {
                return true;
            }
            else
            {
                return base.OnBackButtonPressed();
            }
        }

        #endregion
    }
}