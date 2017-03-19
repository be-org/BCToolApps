using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BcTool.DataModels;
using BcTool.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using System.Text;

namespace BcTool.ViewModels
{
    /// <summary>
    /// 掲示板ページViewModelクラス
    /// </summary>
    public class BulletinBoardInfoPageViewModel : BindableBase
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
        public BulletinBoardInfoPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            this.navigationService = navigationService;
            this.pageDialogService = pageDialogService;

            // 以下はモック時のコード
            FileInfos = new ObservableCollection<FileInfoDataModel>();
            for (int i = 0; i < 10; i++)
            {
                FileInfos.Add(
                    new FileInfoDataModel
                    {
                        FileIconSource = "BcTool.Resources.Images.File.png",
                        FileName = $"ファイル{i}.txt"
                    });
            }

            ReplyInfos = new ObservableCollection<ReplyInfoDataModel>();
            for (int i = 0; i < 10; i++)
            {
                ReplyInfos.Add(
                    new ReplyInfoDataModel
                    {
                        ReplyUserName = "畑中　拓",
                        ReplyDateTime = DateTime.Now,
                        ReplyContents = string.Empty.PadLeft(100, 'X')
                    });
            }

            Category = "お知らせ";
            Title = "定例会のお知らせ";
            IsImportant = true;
            SetImportantLabelColor();
            PostesUserName = "畑中　拓";


            var sb = new StringBuilder();
            sb.AppendLine("定例会のお知らせです。");
            sb.AppendLine();
            sb.AppendLine("定例会を2/17（金）19時から行います。");
            sb.AppendLine("各自、調整を宜しくお願い致します。");
            sb.AppendLine("参加出来ない場合は連絡ください。");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("以上、宜しくお願い致します。");
            Contents = sb.ToString();
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// パネルのクローズ画像のソース
        /// </summary>
        public string PanelCloseIconSource { get; } = "BcTool.Resources.Images.Close.png";

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
        /// 重要フラグ
        /// </summary>
        private bool _IsImportant;
        /// <summary>
        /// 重要フラグ
        /// </summary>
        public bool IsImportant
        {
            get
            {
                return _IsImportant;
            }
            set
            {
                base.SetProperty(ref _IsImportant, value);
            }
        }

        /// <summary>
        /// 重要ラベルの色
        /// </summary>
        private Color _ImportantLabelColor;
        /// <summary>
        /// 重要ラベルの色
        /// </summary>
        public Color ImportantLabelColor
        {
            get
            {
                return _ImportantLabelColor;
            }
            set
            {
                base.SetProperty(ref _ImportantLabelColor, value);
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

        /// <summary>
        /// 掲示板編集ツールバーアイテムクリックイベントコマンド
        /// </summary>
        private ICommand _ToolbarItemBulletinBoardEditClickedCommand = null;
        /// <summary>
        /// 掲示板編集ツールバーアイテムクリックイベントコマンド
        /// </summary>
        public ICommand ToolbarItemBulletinBoardEditClickedCommand => _ToolbarItemBulletinBoardEditClickedCommand ?? (
            _ToolbarItemBulletinBoardEditClickedCommand = new Command(() => ExecuteToolbarItemBulletinBoardEditClicked()));
        
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

        /// <summary>
        /// 編集ツールバーアイテムクリックイベント処理
        /// </summary>
        private async void ExecuteToolbarItemBulletinBoardEditClicked()
        {
            await navigationService.NavigateAsync(nameof(BulletinBoardEditPage));
        }

        /// <summary>
        /// 重要フラグのラベル色の設定
        /// </summary>
        private void SetImportantLabelColor()
        {
            // 重要スイッチのON/OFFで重要ラベルの色を返す
            string resourceKey = IsImportant ? "AppThemeColor" : "AppDarkTextColor";

            object keyValue;
            App.Current.Resources.TryGetValue(resourceKey, out keyValue);
            ImportantLabelColor = (Color)keyValue;
        }

        #endregion
    }
}
