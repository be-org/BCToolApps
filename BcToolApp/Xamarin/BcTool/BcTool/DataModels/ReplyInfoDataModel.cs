using System;
using Xamarin.Forms;

namespace BcTool.DataModels
{
    /// <summary>
    /// 返信情報データモデルクラス
    /// </summary>
    public class ReplyInfoDataModel
    {
        #region プロパティ

        /// <summary>
        /// 返信者名
        /// </summary>
        private string _ReplyUserName;
        /// <summary>
        /// 返信者名
        /// </summary>
        public string ReplyUserName
        {
            get
            {
                return _ReplyUserName;
            }
            set
            {
                _ReplyUserName = value;
            }
        }

        /// <summary>
        /// 返信日時
        /// </summary>
        private DateTime _ReplyDateTime;
        /// <summary>
        /// 返信日時
        /// </summary>
        public DateTime ReplyDateTime
        {
            get
            {
                return _ReplyDateTime;
            }
            set
            {
                _ReplyDateTime = value;
            }
        }

        /// <summary>
        /// 返信内容
        /// </summary>
        private string _ReplyContents;
        /// <summary>
        /// 返信内容
        /// </summary>
        public string ReplyContents
        {
            get
            {
                return _ReplyContents;
            }
            set
            {
                _ReplyContents = value;
            }
        }

        /// <summary>
        /// UWPのフィルターパネルの投稿日表示制御
        /// </summary>
        public bool IsSeparatorBoxViewVisible
        {
            get
            {
                return (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone);
            }
        }

        #endregion
    }
}
