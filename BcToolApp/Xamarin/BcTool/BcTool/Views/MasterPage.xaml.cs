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
            return true;
        }

        #endregion
    }
}