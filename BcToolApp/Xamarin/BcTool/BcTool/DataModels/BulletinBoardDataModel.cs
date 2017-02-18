using System;
using Prism.Mvvm;

namespace BcTool.DataModels
{
    /// <summary>
    /// 掲示板データモデルクラス
    /// </summary>
    public class BulletinBoardDataModel
    {
        #region プロパティ

        /// <summary>
        /// 新着アイコン画像のソース
        /// </summary>
        public string NewIconSource { get; } = "BcTool.Resources.Images.New.png";

        /// <summary>
        /// 重要アイコン画像のソース
        /// </summary>
        public string ImportantIconSource { get; } = "BcTool.Resources.Images.Flag.png";

        /// <summary>
        /// カテゴリ
        /// </summary>
        private string _Category;
        /// <summary>
        /// カテゴリ
        /// </summary>
        public string Category
        {
            get
            {
                return _Category;
            }

            set
            {
                _Category = value;
            }
        }

        /// <summary>
        /// タイトル
        /// </summary>
        private string _Title;
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title
        {
            get
            {
                return _Title;
            }

            set
            {
                _Title = value;
            }
        }

        /// <summary>
        /// 投稿者ユーザー名
        /// </summary>
        private string _PostesUserName;
        /// <summary>
        /// 投稿者ユーザー名
        /// </summary>
        public string PostesUserName
        {
            get
            {
                return _PostesUserName;
            }
            set
            {
                _PostesUserName = value;
            }
        }

        /// <summary>
        /// 返信数
        /// </summary>
        private int _Reply;
        /// <summary>
        /// 返信数
        /// </summary>
        public int Reply
        {
            get
            {
                return _Reply;
            }
            set
            {
                _Reply = value;
            }
        }

        /// <summary>
        /// 投稿日時
        /// </summary>
        private DateTime _PostedDateTime;
        /// <summary>
        /// 投稿日時
        /// </summary>
        public DateTime PostedDateTime
        {
            get
            {
                return _PostedDateTime;
            }
            set
            {
                _PostedDateTime = value;
            }
        }

        /// <summary>
        /// 最終更新日時
        /// </summary>
        private DateTime _LastUpdateDateTime;
        /// <summary>
        /// 最終更新日時
        /// </summary>
        public DateTime LastUpdateDateTime
        {
            get
            {
                return _LastUpdateDateTime;
            }
            set
            {
                _LastUpdateDateTime = value;
            }
        }

        /// <summary>
        /// 新着アイコン画像の表示
        /// </summary>
        private bool _NewIconVisible;
        /// <summary>
        /// Newアイコン画像の表示
        /// </summary>
        public bool NewIconVisible
        {
            get
            {
                return _NewIconVisible;
            }
            set
            {
                _NewIconVisible = value;
            }
        }

        /// <summary>
        /// 重要アイコン画像の表示
        /// </summary>
        private bool _ImportantIconVisible;
        /// <summary>
        /// 重要アイコン画像の表示
        /// </summary>
        public bool ImportantIconVisible
        {
            get
            {
                return _ImportantIconVisible;
            }
            set
            {
                _ImportantIconVisible = value;
            }
        }

        #endregion
    }
}
