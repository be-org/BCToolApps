namespace BcTool.Services
{
    /// <summary>
    /// 戻るボタンの表示状態サービスのインターフェース
    /// </summary>
    public interface IBackButtonVisibilityService
    {
        /// <summary>
        /// BackButtonVisibilityの取得
        /// </summary>
        /// <returns>True：表示 / False：非表示</returns>
        bool GetBackButtonVisibility();
    }
}
