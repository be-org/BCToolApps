using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using BcTool.DataModels;
using Prism.Mvvm;
using Xamarin.Forms;

namespace BcTool.ViewModels
{
    /// <summary>
    /// 掲示板ページViewModelクラス
    /// </summary>
    public class BulletinBoardPageViewModel : BindableBase
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BulletinBoardPageViewModel()
        {
            var list = new List<BulletinBoardDataModel> {
                new BulletinBoardDataModel
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now,
                    NewIconVisible = true,
                    ImportantIconVisible = true,
                    Reply = 999
                },
                new BulletinBoardDataModel
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now,
                    NewIconVisible = true,
                    ImportantIconVisible = true,
                },
                new BulletinBoardDataModel
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now,
                },
                new BulletinBoardDataModel
                {
                    Title = "テストテストテストテストテストテストテストテストテストテストテストテストテストテストテスト",
                    PostesUserName = "畑中　拓",
                    PostedDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now,
                    NewIconVisible = false
                },
            };

            var pageVMList = new List<BulletinBoardInfoPageViewModel>
            {
                new BulletinBoardInfoPageViewModel
                {
                    Category = "お知らせ",
                    BulletinBoardDataModels = new ObservableCollection<BulletinBoardDataModel>(list)
                },
                new BulletinBoardInfoPageViewModel
                {
                    Category = "業務連絡",
                    BulletinBoardDataModels = new ObservableCollection<BulletinBoardDataModel>(list)
                },
                new BulletinBoardInfoPageViewModel
                {
                    Category = "その他",
                    BulletinBoardDataModels = new ObservableCollection<BulletinBoardDataModel>(list)
                },
            };

            BulletinBoardInfoPageCollection = new ObservableCollection<BulletinBoardInfoPageViewModel>(pageVMList);
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 掲示板情報ページViewModelのコレクション
        /// </summary>
        private ObservableCollection<BulletinBoardInfoPageViewModel> _BulletinBoardInfoPageCollection;
        /// <summary>
        /// 掲示板情報ページViewModelのコレクション
        /// </summary>
        public ObservableCollection<BulletinBoardInfoPageViewModel> BulletinBoardInfoPageCollection
        {
            get
            {
                return _BulletinBoardInfoPageCollection;
            }
            set
            {
                base.SetProperty(ref _BulletinBoardInfoPageCollection, value);
            }
        }

        /// <summary>
        /// 選択したタブページのViewModel
        /// </summary>
        private BulletinBoardInfoPageViewModel _SelectedPage;
        /// <summary>
        /// 選択したタブページのViewModel
        /// </summary>
        public BulletinBoardInfoPageViewModel SelectedPage
        {
            get
            {
                return _SelectedPage;
            }

            set
            {
                base.SetProperty(ref _SelectedPage, value);
            }
        }



        #endregion

        #region コマンド

        /// <summary>
        /// フィルターツールバーアイテムクリックイベントコマンド
        /// </summary>
        private ICommand _ToolbarItemFilterClickedCommand = null;
        /// <summary>
        /// フィルターツールバーアイテムクリックイベントコマンド
        /// </summary>
        public ICommand ToolbarItemFilterClickedCommand => _ToolbarItemFilterClickedCommand ?? (
            _ToolbarItemFilterClickedCommand = new Command(
                () => ExecuteToolbarItemFilterClickedCommand()));

        #endregion

        #region メソッド

        /// <summary>
        /// フィルターツールバーアイテムクリックイベント処理
        /// </summary>
        /// <returns>Task</returns>
        private void ExecuteToolbarItemFilterClickedCommand()
        {
            if (SelectedPage != null)
            {
                SelectedPage.IsFilterPanelVisible = true;
            }
        }

        #endregion
    }
}
