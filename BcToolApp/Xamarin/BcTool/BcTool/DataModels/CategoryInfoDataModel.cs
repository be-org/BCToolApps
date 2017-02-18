using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcTool.DataModels
{
    /// <summary>
    /// カテゴリ情報データモデルクラス
    /// </summary>
    public class CategoryInfoDataModel
    {
        #region プロパティ

        /// <summary>
        /// カテゴリ名称
        /// </summary>
        private string _CategoryName;
        /// <summary>
        /// カテゴリ名称
        /// </summary>
        public string CategoryName
        {
            get
            {
                return _CategoryName;
            }
            set
            {
                _CategoryName = value;
            }
        }

        #endregion
    }
}
