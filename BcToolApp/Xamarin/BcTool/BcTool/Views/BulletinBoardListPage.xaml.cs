using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace BcTool.Views
{
    public partial class BulletinBoardListPage : ContentPage
    {
        public BulletinBoardListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            // iOS、Androidの場合、ツールバーのリフレッシュは削除する
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                if (this.ToolbarItems.Contains(this.tbiRefresh))
                {
                    this.ToolbarItems.Remove(this.tbiRefresh);
                }

                if (this.slFilterContents.Children.Contains(this.slDateFilterUwp))
                {
                    this.slFilterContents.Children.Remove(this.slDateFilterUwp);
                }
            }
            else
            {
                if (this.slFilterContents.Children.Contains(this.slDateFilter))
                {
                    this.slFilterContents.Children.Remove(this.slDateFilter);
                }
            }

            var list = new List<BulletinBoardCategoryInfo>
            {
                new BulletinBoardCategoryInfo("お知らせ")
                {
                    new BulletinBoardInfo
                    {
                        Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                        PostesUserName = "畑中　拓",
                        PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        NewIcon= ImageSource.FromResource("BcTool.Resources.Images.New.png"),
                        ImportantIcon= ImageSource.FromResource("BcTool.Resources.Images.Flag.png")
                    },
                    new BulletinBoardInfo
                    {
                        Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                        PostesUserName = "畑中　拓",
                        PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        NewIcon= ImageSource.FromResource("BcTool.Resources.Images.New.png"),
                        ImportantIcon= ImageSource.FromResource("BcTool.Resources.Images.Flag.png")
                    },
                    new BulletinBoardInfo
                    {
                        Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                        PostesUserName = "畑中　拓",
                        PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    },
                    new BulletinBoardInfo
                    {
                        Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                        PostesUserName = "畑中　拓",
                        PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        NewIcon= ImageSource.FromResource("BcTool.Resources.Images.New.png"),
                    },
                },
                new BulletinBoardCategoryInfo("業務連絡")
                {
                    new BulletinBoardInfo
                    {
                        Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                        PostesUserName = "畑中　拓",
                        PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    },
                    new BulletinBoardInfo
                    {
                        Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                        PostesUserName = "畑中　拓",
                        PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        ImportantIcon= ImageSource.FromResource("BcTool.Resources.Images.Flag.png")
                    },
                    new BulletinBoardInfo
                    {
                        Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                        PostesUserName = "畑中　拓",
                        PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    },
                },
                new BulletinBoardCategoryInfo("その他")
                {
                    new BulletinBoardInfo
                    {
                        Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                        PostesUserName = "畑中　拓",
                        PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        NewIcon= ImageSource.FromResource("BcTool.Resources.Images.New.png"),
                        ImportantIcon= ImageSource.FromResource("BcTool.Resources.Images.Flag.png")
                    },
                    new BulletinBoardInfo
                    {
                        Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                        PostesUserName = "畑中　拓",
                        PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                        LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    },
                },
            };
            
            
            this.lvBulletinBoard.ItemsSource = list;

            var sortItems = new List<string>
            {
                "タイトル（昇順）",
                "タイトル（降順）",
                "投稿日（昇順）",
                "投稿日（降順）",
                "最終更新日時（昇順）",
                "最終更新日時（降順）",
            };

            this.pikSort.ItemsSource = sortItems;

            var categoryItems = new List<string>
            {
                "全て",
                "お知らせ",
                "業務連絡",
                "その他",
            };

            this.pikCategory.ItemsSource = categoryItems;


            this.slFilter.IsVisible = false;
            this.slProgress.IsVisible = false;

            this.lvBulletinBoard.Refreshing += LvBulletinBoard_Refreshing;
            this.tbiRefresh.Clicked += TbiRefresh_Clicked;
            this.tbiFilter.Clicked += TbiFilter_Clicked;
            this.btnAccept.Clicked += BtnAccept_Clicked;
            this.btnCancel.Clicked += BtnCancel_Clicked;
        }

        protected override void OnDisappearing()
        {
        }

        private async void TbiRefresh_Clicked(object sender, EventArgs e)
        {
            try
            {
                this.slProgress.IsVisible = true;

                await Task.Delay(20000);
            }
            finally
            {
                this.slProgress.IsVisible = false;
            }
        }

        private async void LvBulletinBoard_Refreshing(object sender, EventArgs e)
        {
            try
            {
                this.lvBulletinBoard.IsRefreshing = false;
                this.slProgress.IsVisible = true;

                await Task.Delay(20000);
            }
            finally
            {
                this.slProgress.IsVisible = false;
            }
        }

        private void TbiFilter_Clicked(object sender, EventArgs e)
        {
            this.slFilter.IsVisible = true;
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            this.slFilter.IsVisible = false;
        }

        private void BtnAccept_Clicked(object sender, EventArgs e)
        {
            this.slFilter.IsVisible = false;
        }
    }

    public class BulletinBoardCategoryInfo : List<BulletinBoardInfo>
    {
        public BulletinBoardCategoryInfo(string title)
        {
            this.Title = title;
        }

        public string Title
        {
            get;
            set;
        }
    }


    public class BulletinBoardInfo
    {
        public string Title
        {
            get;
            set;
        }

        public string PostesUserName
        {
            get;
            set;
        }

        public string PostedDate
        {
            get;
            set;
        }

        public string LastUpdateDate
        {
            get;
            set;
        }

        public ImageSource NewIcon
        {
            get;
            set;
        }

        public ImageSource ImportantIcon
        {
            get;
            set;
        }

        public bool NewIconVisible
        {
            get
            {
                return NewIcon != null;
            }
        }

        public bool ImportantIconVisible
        {
            get
            {
                return ImportantIcon != null;
            }
        }
    }
}
