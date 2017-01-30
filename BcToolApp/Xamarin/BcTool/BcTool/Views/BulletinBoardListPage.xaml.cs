using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            }

            var list = new List<TestBulletinBoard>
            {
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    NewIcon= ImageSource.FromResource("BcTool.Resources.Images.New.png"),
                    ImportantIcon= ImageSource.FromResource("BcTool.Resources.Images.Flag.png")
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    NewIcon= ImageSource.FromResource("BcTool.Resources.Images.New.png"),
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    ImportantIcon= ImageSource.FromResource("BcTool.Resources.Images.Flag.png")
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    NewIcon= ImageSource.FromResource("BcTool.Resources.Images.New.png"),
                    ImportantIcon= ImageSource.FromResource("BcTool.Resources.Images.Flag.png")
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
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
            this.lvBulletinBoard.Refreshing += LvBulletinBoard_Refreshing;
            this.tbiRefresh.Clicked += TbiRefresh_Clicked;
        }

        protected override void OnDisappearing()
        {
        }

        private async void TbiRefresh_Clicked(object sender, EventArgs e)
        {
        }

        private async void LvBulletinBoard_Refreshing(object sender, EventArgs e)
        {

        }
    }

    public class TestBulletinBoard
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
