using Prism.Mvvm;

namespace BcTool.DataModels
{
    /// <summary>
    /// グループ情報データモデルクラス
    /// </summary>
    public class GroupInfoDataModel : BindableBase
    {
        #region プロパティ

        /// <summary>
        /// ONフラグ
        /// </summary>
        private bool _IsOn;
        /// <summary>
        /// ONフラグ
        /// </summary>
        public bool IsOn
        {
            get
            {
                return _IsOn;
            }
            set
            {
                base.SetProperty(ref _IsOn, value);
            }
        }

        /// <summary>
        /// グループ名称
        /// </summary>
        private string _GroupName;
        /// <summary>
        /// グループ名称
        /// </summary>
        public string GroupName
        {
            get
            {
                return _GroupName;
            }
            set
            {
                _GroupName = value;
            }
        }

        #endregion
    }
}
