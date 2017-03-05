﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BcTool.DataModels;
using BcTool.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace BcTool.ViewModels
{
    /// <summary>
    /// 掲示板ページViewModelクラス
    /// </summary>
    public class BulletinBoardTabbedPageViewModel : BindableBase, INavigationAware
    {
        #region メンバー変数

        /// <summary>
        /// ナビゲーションサービス
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        /// ダイアログサービス
        /// </summary>
        private readonly IPageDialogService pageDialogService;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService">ナビゲーションサービス</param>
        /// <param name="pageDialogService">ダイアログサービス</param>
        public BulletinBoardTabbedPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            this.navigationService = navigationService;
            this.pageDialogService = pageDialogService;

            // 画面モック用のコード
            var list = new List<BulletinBoardDataModel> {
                new BulletinBoardDataModel
                {
                    Title = "テストですよー",
                    PostesUserName = "畑中　拓",
                    PostedDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now,
                    NewIconVisible = true,
                    ImportantIconVisible = true,
                    Reply = 999
                },
                new BulletinBoardDataModel
                {
                    Title = "テストですよーテストですよー",
                    PostesUserName = "畑中　拓",
                    PostedDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now,
                    NewIconVisible = true,
                    ImportantIconVisible = true,
                },
                new BulletinBoardDataModel
                {
                    Title = "テストですよーテストですよーテストですよー",
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
                new BulletinBoardDataModel
                {
                    Title = "テストですよー",
                    PostesUserName = "畑中　拓",
                    PostedDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now,
                    NewIconVisible = true,
                    ImportantIconVisible = true,
                    Reply = 999
                },
                new BulletinBoardDataModel
                {
                    Title = "テストですよーテストですよー",
                    PostesUserName = "畑中　拓",
                    PostedDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now,
                    NewIconVisible = true,
                    ImportantIconVisible = true,
                },
                new BulletinBoardDataModel
                {
                    Title = "テストですよーテストですよーテストですよー",
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

            var pageVMList = new List<BulletinBoardPageViewModel>
            {
                new BulletinBoardPageViewModel(navigationService, pageDialogService)
                {
                    Category = "お知らせ",
                    BulletinBoardDataModels = new ObservableCollection<BulletinBoardDataModel>(list)
                },
                new BulletinBoardPageViewModel(navigationService, pageDialogService)
                {
                    Category = "業務連絡",
                    BulletinBoardDataModels = new ObservableCollection<BulletinBoardDataModel>(list)
                },
                new BulletinBoardPageViewModel(navigationService, pageDialogService)
                {
                    Category = "その他",
                    BulletinBoardDataModels = new ObservableCollection<BulletinBoardDataModel>(list)
                },
            };

            BulletinBoardPageCollection = new ObservableCollection<BulletinBoardPageViewModel>(pageVMList);
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 掲示板情報ページViewModelのコレクション
        /// </summary>
        private ObservableCollection<BulletinBoardPageViewModel> _BulletinBoardPageCollection;
        /// <summary>
        /// 掲示板情報ページViewModelのコレクション
        /// </summary>
        public ObservableCollection<BulletinBoardPageViewModel> BulletinBoardPageCollection
        {
            get
            {
                return _BulletinBoardPageCollection;
            }
            set
            {
                base.SetProperty(ref _BulletinBoardPageCollection, value);
            }
        }

        /// <summary>
        /// 選択したタブページのViewModel
        /// </summary>
        private BulletinBoardPageViewModel _SelectedPage;
        /// <summary>
        /// 選択したタブページのViewModel
        /// </summary>
        public BulletinBoardPageViewModel SelectedPage
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

        /// <summary>
        /// 掲示板新規ツールバーアイテムクリックイベントコマンド
        /// </summary>
        private ICommand _ToolbarItemBulletinBoardNewClickedCommand = null;
        /// <summary>
        /// 掲示板新規ツールバーアイテムクリックイベントコマンド
        /// </summary>
        public ICommand ToolbarItemBulletinBoardNewClickedCommand => _ToolbarItemBulletinBoardNewClickedCommand ?? (
            _ToolbarItemBulletinBoardNewClickedCommand = new Command(() => ExecuteToolbarItemBulletinBoardNewClicked()));

        #endregion

        #region 公開メソッド

        /// <summary>
        /// 当画面から遷移された時の処理
        /// </summary>
        /// <param name="parameters">遷移パラメータ</param>
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        /// <summary>
        /// 当画面に遷移した時の処理
        /// </summary>
        /// <param name="parameters">遷移パラメータ</param>
        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

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

        /// <summary>
        /// 掲示板新規ツールバーアイテムクリックイベント処理
        /// </summary>
        private async void ExecuteToolbarItemBulletinBoardNewClicked()
        {
            await navigationService.NavigateAsync(nameof(BulletinBoardEditPage));
        }

        #endregion
    }
}
