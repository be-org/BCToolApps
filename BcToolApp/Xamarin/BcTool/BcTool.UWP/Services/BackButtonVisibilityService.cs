using BcTool.Services;
using BcTool.UWP.Services;
using Windows.UI.Core;
using Xamarin.Forms;

[assembly: Dependency(typeof(BackButtonVisibilityService))]
namespace BcTool.UWP.Services
{
    /// <summary>
    /// 戻るボタンの表示状態サービスクラス
    /// </summary>
    public class BackButtonVisibilityService : IBackButtonVisibilityService
    {
        /// <summary>
        /// BackButtonVisibilityの取得
        /// </summary>
        /// <returns>True：表示 / False：非表示</returns>
        public bool GetBackButtonVisibility()
        {
            return SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility == AppViewBackButtonVisibility.Visible;
        }
    }
}
