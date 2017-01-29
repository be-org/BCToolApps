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
            var list = new List<TestBulletinBoard>
            {
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd)"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    NewIcon= ImageSource.FromResource("BcTool.Resources.Images.New.png"),
                    ImportantIcon= ImageSource.FromResource("BcTool.Resources.Images.Flag.png")
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd)"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd)"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    NewIcon= ImageSource.FromResource("BcTool.Resources.Images.New.png"),
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd)"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd)"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    ImportantIcon= ImageSource.FromResource("BcTool.Resources.Images.Flag.png")
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd)"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd)"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                    NewIcon= ImageSource.FromResource("BcTool.Resources.Images.New.png"),
                    ImportantIcon= ImageSource.FromResource("BcTool.Resources.Images.Flag.png")
                },
                new TestBulletinBoard
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd)"),
                    LastUpdateDate = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH時mm分ss秒"),
                },
            };

            this.lvBulletinBoard.ItemsSource = list;
            this.activity.IsRunning = false;
            this.activity.IsVisible = false;
            this.lvBulletinBoard.Refreshing += LvBulletinBoard_Refreshing;
        }

        private async void LvBulletinBoard_Refreshing(object sender, EventArgs e)
        {
            this.activity.IsVisible = true;
            this.activity.IsRunning = true;
            this.lvBulletinBoard.IsRefreshing = false;

            await Task.Delay(10000);

            this.activity.IsRunning = false;
            this.activity.IsVisible = false;
        }

        protected override void OnDisappearing()
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
