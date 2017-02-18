using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcTool.DataModels
{
    /// <summary>
    /// ファイル情報データモデルクラス
    /// </summary>
    public class FileInfoDataModel
    {
        #region プロパティ

        /// <summary>
        /// ファイルアイコン画像のソース
        /// </summary>
        private string _FileIconSource;
        /// <summary>
        /// ファイルアイコン画像のソース
        /// </summary>
        public string FileIconSource
        {
            get
            {
                return _FileIconSource;
            }

            set
            {
                _FileIconSource = value;
            }
        }

        /// <summary>
        /// ファイル名
        /// </summary>
        private string _FileName;
        /// <summary>
        /// ファイル名
        /// </summary>
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }

        #endregion
    }
}
