using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BcTool.DataModels;
using Prism.Mvvm;
using Xamarin.Forms;
using System.Linq;

namespace BcTool.ViewModels
{
    /// <summary>
    /// 掲示板編集ページViewModelクラス
    /// </summary>
    public class BulletinBoardEditPageViewModel : BindableBase
    {
        #region フィールド変数

        /// <summary>
        /// カテゴリー情報コレクション
        /// </summary>
        private List<CategoryInfoDataModel> _CategoryInfos;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BulletinBoardEditPageViewModel()
        {
            // 以下はモック時のコード
            // ページタイトル
            PageTitle = "掲示板(新規)";

            // カテゴリー情報
            _CategoryInfos = new List<CategoryInfoDataModel>
            {
                new CategoryInfoDataModel { CategoryName = "全て" },
                new CategoryInfoDataModel { CategoryName = "お知らせ" },
                new CategoryInfoDataModel { CategoryName = "業務連絡" },
                new CategoryInfoDataModel { CategoryName = "その他" },
            };

            _CategoryNames = _CategoryInfos.Select((x) => x.CategoryName).ToList();

            // グループ情報
            GroupInfos = new ObservableCollection<GroupInfoDataModel>
            {
                new GroupInfoDataModel { GroupName = "全社" },
                new GroupInfoDataModel { GroupName = "東京事業所" },
                new GroupInfoDataModel { GroupName = "長崎事業所" },
                new GroupInfoDataModel { GroupName = "マネージャー" },
                new GroupInfoDataModel { GroupName = "メンバー" },
                new GroupInfoDataModel { GroupName = "第一グループ" },
                new GroupInfoDataModel { GroupName = "第二グループ" },
                new GroupInfoDataModel { GroupName = "第三グループ" },
            };

            // ファイル添付情報
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
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// ファイル追加画像のソース
        /// </summary>
        public string FileAddIconSource { get; } = "BcTool.Resources.Images.FileAdd.png";

        /// <summary>
        /// パネルのクローズ画像のソース
        /// </summary>
        public string PanelCloseIconSource { get; } = "BcTool.Resources.Images.Close.png";

        /// <summary>
        /// ページタイトル
        /// </summary>
        private string _PageTitle;
        /// <summary>
        /// ページタイトル
        /// </summary>
        public string PageTitle
        {
            get
            {
                return _PageTitle;
            }
            set
            {
                _PageTitle = value;
            }
        }

        /// <summary>
        /// カテゴリー名称リスト
        /// </summary>
        private List<string> _CategoryNames;
        /// <summary>
        /// カテゴリー名称リスト
        /// </summary>
        public List<string> CategoryNames
        {
            get
            {
                return _CategoryNames;
            }

            set
            {
                _CategoryNames = value;
            }
        }

        /// <summary>
        /// 公開グループ情報コレクション
        /// </summary>
        private ObservableCollection<GroupInfoDataModel> _GroupInfos;
        /// <summary>
        /// 公開グループ情報コレクション
        /// </summary>
        public ObservableCollection<GroupInfoDataModel> GroupInfos
        {
            get
            {
                return _GroupInfos;
            }

            set
            {
                base.SetProperty(ref _GroupInfos, value);
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

        #endregion
    }
}
