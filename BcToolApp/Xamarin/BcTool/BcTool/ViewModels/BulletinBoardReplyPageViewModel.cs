using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using BcTool.DataModels;

namespace BcTool.ViewModels
{
    /// <summary>
    /// 掲示板返信ページViewModelクラス
    /// </summary>
    public class BulletinBoardReplyPageViewModel : BindableBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BulletinBoardReplyPageViewModel()
        {
            // 以下はモック時のコード
            var replyInfos = new List<ReplyInfoDataModel>();
            for (int i = 0; i < 10; i++)
            {
                replyInfos.Add(
                    new ReplyInfoDataModel
                    {
                        ReplyUserName = "畑中　拓",
                        ReplyDateTime = DateTime.Now,
                        ReplyContents = string.Empty.PadLeft(100, 'X')
                    });
            }

            ReplyInfos = new ObservableCollection<ReplyInfoDataModel>(replyInfos);
        }

        /// <summary>
        /// 返信情報コレクション
        /// </summary>
        private ObservableCollection<ReplyInfoDataModel> _ReplyInfos;
        /// <summary>
        /// 返信情報コレクション
        /// </summary>
        public ObservableCollection<ReplyInfoDataModel> ReplyInfos
        {
            get
            {
                return _ReplyInfos;
            }
            set
            {
                base.SetProperty(ref _ReplyInfos, value);
            }
        }
    }
}
