namespace BcTool.Configs
{
    /// <summary>
    /// 進捗ダイアログの設定クラス
    /// </summary>
    public class ProgressConfig
    {
        /// <summary>
        /// 表示制御
        /// </summary>
        public bool IsVisible
        {
            get;
            set;
        }

        /// <summary>
        /// 進捗コンテンツ
        /// </summary>
        public string ProgressContent
        {
            get;
            set;
        }
    }
}
