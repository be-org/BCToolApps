﻿using System.Collections.Generic;
using Xamarin.Forms;

namespace BcTool.Views
{
    /// <summary>
    /// 掲示板（編集・表示）ページクラス
    /// </summary>
    public partial class BulletinBoardEditPage : ContentPage
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BulletinBoardEditPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // 以下、モック生成用のコード
            var categoryItems = new List<string>
            {
                "全て",
                "お知らせ",
                "業務連絡",
                "その他",
            };

            this.pikCategory.ItemsSource = categoryItems;

            var groupInfoItems = new List<GroupInfo>
            {
                new GroupInfo { GroupName = "全社" },
                new GroupInfo { GroupName = "東京事業所" },
                new GroupInfo { GroupName = "長崎事業所" },
                new GroupInfo { GroupName = "マネージャー" },
                new GroupInfo { GroupName = "メンバー" },
                new GroupInfo { GroupName = "第一グループ" },
                new GroupInfo { GroupName = "第二グループ" },
                new GroupInfo { GroupName = "第三グループ" },
            };

            this.lvGroupSetting.ItemsSource = groupInfoItems;

            var fileInfoItems = new List<FileInfo>();

            for (int i = 0; i < 10; i++)
            {
                fileInfoItems.Add(
                    new FileInfo
                    {
                        FileIcon = ImageSource.FromResource("BcTool.Resources.Images.File.png"),
                        FileName = $"ファイル{i}.txt"
                    });
            }

            this.lvAttachmentFile.ItemsSource = fileInfoItems;
            this.slAttachmentFile.IsVisible = false;

            this.tiAttachmentFile.Clicked += TiAttachmentFile_Clicked;
            this.btnFileAdd.Clicked += BtnFileAdd_Clicked;
            this.btnClose.Clicked += BtnClose_Clicked;
        }

        private void BtnFileAdd_Clicked(object sender, System.EventArgs e)
        {
            this.slAttachmentFile.IsVisible = false;
        }

        private void BtnClose_Clicked(object sender, System.EventArgs e)
        {
            this.slAttachmentFile.IsVisible = false;
        }

        private void TiAttachmentFile_Clicked(object sender, System.EventArgs e)
        {
            this.slAttachmentFile.IsVisible = true;
        }
    }

    internal class GroupInfo
    {
        public string GroupName
        {
            get;
            set;
        }
    }

    internal class FileInfo
    {
        public ImageSource FileIcon
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }
    }
}
