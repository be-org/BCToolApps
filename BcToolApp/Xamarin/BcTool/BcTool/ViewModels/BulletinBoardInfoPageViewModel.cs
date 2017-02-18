﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using BcTool.DataModels;
using System.Windows.Input;
using Xamarin.Forms;

namespace BcTool.ViewModels
{
    /// <summary>
    /// 掲示板ページViewModelクラス
    /// </summary>
    public class BulletinBoardInfoPageViewModel : BindableBase
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BulletinBoardInfoPageViewModel()
        {
            // 以下はモック時のコード
            var fileInfos = new List<FileInfoDataModel>();
            for (int i = 0; i < 10; i++)
            {
                fileInfos.Add(
                    new FileInfoDataModel
                    {
                        FileIconSource = "BcTool.Resources.Images.File.png",
                        FileName = $"ファイル{i}.txt"
                    });
            }

            FileInfos = new ObservableCollection<FileInfoDataModel>(fileInfos);

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

        #endregion

        #region プロパティ

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
                base.SetProperty(ref _Category, value);
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
                base.SetProperty(ref _Title, value);
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
                base.SetProperty(ref _PostesUserName, value);
            }
        }

        /// <summary>
        /// 内容
        /// </summary>
        private string _Contents;
        /// <summary>
        /// 内容
        /// </summary>
        public string Contents
        {
            get
            {
                return _Contents;
            }

            set
            {
                base.SetProperty(ref _Contents, value);
            }
        }

        /// <summary>
        /// ビュースレッドパネルの表示制御
        /// </summary>
        private bool _IsViewThreadPanelVisible;
        /// <summary>
        /// ビュースレッドパネルの表示制御
        /// </summary
        public bool IsViewThreadPanelVisible
        {
            get
            {
                return _IsViewThreadPanelVisible;
            }

            set
            {
                base.SetProperty(ref _IsViewThreadPanelVisible, value);
            }
        }

        /// <summary>
        /// View Threadパネルのクローズ画像のソース
        /// </summary>
        public string ViewThreadCloseIconSource { get; } = "BcTool.Resources.Images.Close.png";

        /// <summary>
        /// 添付ファイルパネルの表示制御
        /// </summary>
        private bool _IsAttachmentFilePanelVisible;
        /// <summary>
        /// 添付ファイルパネルの表示制御
        /// </summary
        public bool IsAttachmentFilePanelVisible
        {
            get
            {
                return _IsAttachmentFilePanelVisible;
            }

            set
            {
                base.SetProperty(ref _IsAttachmentFilePanelVisible, value);
            }
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

        /// <summary>
        /// ファイル情報コレクション
        /// </summary>
        private ObservableCollection<FileInfoDataModel> _FileInfos;
        /// <summary>
        /// ファイル情報コレクション
        /// </summary>
        public ObservableCollection<FileInfoDataModel> FileInfos
        {
            get
            {
                return _FileInfos;
            }

            set
            {
                base.SetProperty(ref _FileInfos, value);
            }
        }

        #endregion

        #region コマンド

        /// <summary>
        /// 添付ファイルツールバーアイテムクリックイベントコマンド
        /// </summary>
        private ICommand _ToolbarItemAttachmentFileClickedCommand = null;
        /// <summary>
        /// 添付ファイルツールバーアイテムクリックイベントコマンド
        /// </summary>
        public ICommand ToolbarItemAttachmentFileClickedCommand => _ToolbarItemAttachmentFileClickedCommand ?? (
            _ToolbarItemAttachmentFileClickedCommand = new Command(
                () => ExecuteToolbarItemAttachmentFileClicked()));

        /// <summary>
        /// 添付ファイルパネルクローズ画像タップイベントコマンド
        /// </summary>
        private ICommand _ImageAttachmentFilePanelCloseTappedCommand = null;
        /// <summary>
        /// 添付ファイルパネルクローズ画像タップイベントコマンド
        /// </summary>
        public ICommand ImageAttachmentFilePanelCloseTappedCommand => _ImageAttachmentFilePanelCloseTappedCommand ?? (
            _ImageAttachmentFilePanelCloseTappedCommand = new Command(
                () => ExecuteImageAttachmentFilePanelCloseTapped()));

        /// <summary>
        /// View Threadラベルタップイベントコマンド
        /// </summary>
        private ICommand _LblViewThreadTappedCommand = null;
        /// <summary>
        /// View Threadラベルタップイベントコマンド
        /// </summary>
        public ICommand LblViewThreadTappedCommand => _LblViewThreadTappedCommand ?? (
           _LblViewThreadTappedCommand = new Command(
               () => ExecuteLblViewThreadTapped()));

        /// <summary>
        /// View Threadクローズ画像タップイベントコマンド
        /// </summary>
        private ICommand _ImageViewThreadCloseTappedCommand = null;
        /// <summary>
        /// View Threadクローズ画像タップイベントコマンド
        /// </summary>
        public ICommand ImageViewThreadCloseTappedCommand => _ImageViewThreadCloseTappedCommand ?? (
           _ImageViewThreadCloseTappedCommand = new Command(
               () => ExecuteImageViewThreadCloseTapped()));

        #endregion

        #region メソッド

        /// <summary>
        /// 添付ファイルツールバーアイテムクリックイベント処理
        /// </summary>
        private void ExecuteToolbarItemAttachmentFileClicked()
        {
            IsAttachmentFilePanelVisible = !IsAttachmentFilePanelVisible;
        }

        /// <summary>
        /// 添付ファイルパネルクローズ画像タップイベント処理
        /// </summary>
        private void ExecuteImageAttachmentFilePanelCloseTapped()
        {
            if (IsAttachmentFilePanelVisible)
            {
                IsAttachmentFilePanelVisible = false;
            }
        }

        /// <summary>
        /// View Threadラベルタップイベント処理
        /// </summary>
        private void ExecuteLblViewThreadTapped()
        {
            IsViewThreadPanelVisible = true;
        }

        /// <summary>
        /// View Threadクローズ画像タップイベント処理
        /// </summary>
        private void ExecuteImageViewThreadCloseTapped()
        {
            IsViewThreadPanelVisible = false;
        }

        #endregion
    }
}
