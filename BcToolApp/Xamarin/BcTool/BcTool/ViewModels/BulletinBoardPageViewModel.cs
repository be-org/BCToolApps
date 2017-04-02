using BcTool.Configs;
using BcTool.DataModels;
using BcTool.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BcTool.ViewModels
{
    /// <summary>
    /// 掲示板情報ページViewModelクラス
    /// </summary>
    public class BulletinBoardPageViewModel : BindableBase
    {
        #region メンバー変数

        /// <summary>
        /// ナビゲーションサービス
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// ダイアログサービス
        /// </summary>
        private readonly IPageDialogService _pageDialogService;

        /// <summary>
        /// ListView選択中イベント処理フラグ
        /// </summary>
        private bool _isExecuteSelected;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService">ナビゲーションサービス</param>
        /// <param name="pageDialogService">ダイアログサービス</param>
        public BulletinBoardPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : this()
        {
            this._navigationService = navigationService;
            this._pageDialogService = pageDialogService;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BulletinBoardPageViewModel()
        {
            // TODO モックの作成
            SortList = new List<string>
            {
                "タイトル（昇順）",
                "タイトル（降順）",
                "投稿日（昇順）",
                "投稿日（降順）",
            };
        }
        
        #endregion

        #region プロパティ

        /// <summary>
        /// 並び替えリスト
        /// </summary>
        public List<string> SortList
        {
            get;
        }

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
        /// 掲示板データモデルコレクション
        /// </summary>
        private ObservableCollection<BulletinBoardDataModel> _BulletinBoardDataModels;
        /// <summary>
        /// 掲示板データモデルコレクション
        /// </summary>
        public ObservableCollection<BulletinBoardDataModel> BulletinBoardDataModels
        {
            get
            {
                return _BulletinBoardDataModels;
            }
            set
            {
                base.SetProperty(ref _BulletinBoardDataModels, value);
            }
        }

        /// <summary>
        /// フィルターパネルの表示制御
        /// </summary>
        private bool _IsFilterPanelVisible;
        /// <summary>
        /// フィルターパネルの表示制御
        /// </summary
        public bool IsFilterPanelVisible
        {
            get
            {
                return _IsFilterPanelVisible;
            }

            set
            {
                base.SetProperty(ref _IsFilterPanelVisible, value);
            }
        }

        /// <summary>
        /// ListViewがリフレッシュ中かどうか
        /// </summary>
        private bool _IsRefreshing;
        /// <summary>
        /// ListViewがリフレッシュ中かどうか
        /// </summary>
        public bool IsRefreshing
        {
            get
            {
                return _IsRefreshing;
            }

            set
            {
                base.SetProperty(ref _IsRefreshing, value);
            }
        }

        /// <summary>
        /// Android・iOSのフィルターパネルの投稿日表示制御
        /// </summary>
        public bool IsFilterPostedDateVisibleNonWindows
        {
            get
            {
                return (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS);
            }
        }

        /// <summary>
        /// UWPのフィルターパネルの投稿日表示制御
        /// </summary>
        public bool IsFilterPostedDateVisibleWindows
        {
            get
            {
                return (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone);
            }
        }


        #endregion

        #region コマンド

        /// <summary>
        /// フィルター設定ボタンクリックイベントコマンド
        /// </summary>
        private ICommand _BtnFilterSettingClickedCommand = null;
        /// <summary>
        /// フィルター設定ボタンクリックイベントコマンド
        /// </summary>
        public ICommand BtnFilterSettingClickedCommand => _BtnFilterSettingClickedCommand ?? (
            _BtnFilterSettingClickedCommand = new Command(() => ExecuteBtnFilterSettingClicked()));

        /// <summary>
        /// フィルターキャンセルボタンクリックイベントコマンド
        /// </summary>
        private ICommand _BtnFilterCancelClickedCommand = null;
        /// <summary>
        /// フィルターキャンセルボタンクリックイベントコマンド
        /// </summary>
        public ICommand BtnFilterCancelClickedCommand => _BtnFilterCancelClickedCommand ?? (
            _BtnFilterCancelClickedCommand = new Command(() => ExecuteBtnFilterCancelClicked()));

        /// <summary>
        /// ListViewのListItemの選択イベントコマンド
        /// </summary>
        private ICommand _SelectedCommand = null;
        /// <summary>
        /// ListViewのListItemの選択イベントコマンド
        /// </summary>
        public ICommand SelectedCommand => _SelectedCommand ?? (
            _SelectedCommand = new Command<BulletinBoardDataModel>((model) => ExecuteSelected(model)));

        /// <summary>
        /// ListViewのコンテキストメニュー編集クリックイベントコマンド
        /// </summary>
        private ICommand _ContextMenuEditClickedCommand = null;
        /// <summary>
        /// ListViewのコンテキストメニュー編集クリックイベントコマンド
        /// </summary>
        public ICommand ContextMenuEditClickedCommand => _ContextMenuEditClickedCommand ?? (
            _ContextMenuEditClickedCommand = new Command<BulletinBoardDataModel>((model) => ExecuteContextMenuEditClicked(model)));

        /// <summary>
        /// ListViewのコンテキストメニュー削除クリックイベントコマンド
        /// </summary>
        private ICommand _ContextMenuDeleteClickedCommand = null;
        /// <summary>
        /// ListViewのコンテキストメニュー削除クリックイベントコマンド
        /// </summary>
        public ICommand ContextMenuDeleteClickedCommand => _ContextMenuDeleteClickedCommand ?? (
            _ContextMenuDeleteClickedCommand = new Command<BulletinBoardDataModel>((model) => ExecuteContextMenuDeleteClicked(model)));

        /// <summary>
        /// ListViewのリフレッシュコマンド
        /// </summary>
        private ICommand _RefreshingCommand = null;
        /// <summary>
        /// ListViewのリフレッシュコマンド
        /// </summary>
        public ICommand RefreshingCommand => _RefreshingCommand ?? (
           _RefreshingCommand = new Command(() => ExecuteRefreshing()));

        #endregion

        #region メソッド

        /// <summary>
        /// フィルター設定ボタンクリックイベント処理
        /// </summary>
        private void ExecuteBtnFilterSettingClicked()
        {
            IsFilterPanelVisible = false;
        }

        /// <summary>
        /// フィルターキャンセルボタンクリックイベント処理
        /// </summary>
        private void ExecuteBtnFilterCancelClicked()
        {
            IsFilterPanelVisible = false;
        }

        /// <summary>
        /// ListViewのListItemの選択イベント処理
        /// </summary>
        /// <param name="model">選択行のViewModelクラス</param>
        private async void ExecuteSelected(BulletinBoardDataModel model)
        {
            if (_isExecuteSelected)
            {
                return;
            }

            try
            {
                _isExecuteSelected = true;
                await _navigationService.NavigateAsync(nameof(BulletinBoardInfoPage));
                await Task.Delay(1000);
            }
            finally
            {
                _isExecuteSelected = false;
            }
        }

        /// <summary>
        /// ListViewのコンテキストメニュー編集クリックイベント処理
        /// </summary>
        /// <param name="model">選択行のViewModelクラス</param>
        public async void ExecuteContextMenuEditClicked(BulletinBoardDataModel model)
        {
            await _navigationService.NavigateAsync(nameof(BulletinBoardEditPage));
        }

        /// <summary>
        /// ListViewのコンテキストメニュー削除クリックイベント処理
        /// </summary>
        /// <param name="model">選択行のViewModelクラス</param>
        public async void ExecuteContextMenuDeleteClicked(BulletinBoardDataModel model)
        {
            await _pageDialogService.DisplayAlertAsync("確認", "選択した掲示板を削除しますか？", "削除", "キャンセル");
        }

        /// <summary>
        ///  ListViewのリフレッシュイベント処理
        /// </summary>
        private async void ExecuteRefreshing()
        {
            try
            {
                IsRefreshing = false;

                MessagingCenter.Send<object, ProgressConfig>(
                   this,
                   "progress_dialog",
                   new ProgressConfig
                   {
                       IsVisible = true,
                       ProgressContent = "同期中..."
                   });

                await Task.Delay(3000);
            }
            finally
            {
                MessagingCenter.Send<object, ProgressConfig>(
                    this,
                    "progress_dialog",
                    new ProgressConfig
                    {
                        IsVisible = false
                    });
            }
        }

        #endregion
    }
}
