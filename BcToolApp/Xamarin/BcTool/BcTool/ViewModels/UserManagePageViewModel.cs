using BcTool.DataModels;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace BcTool.ViewModels
{
    /// <summary>
    /// ユーザー管理画面ViewModel
    /// </summary>
    public class UserManagePageViewModel : BindableBase
    {
        private INavigationService _NavigationService;
        private IPageDialogService _PageDialogService;

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UserManagePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _NavigationService = navigationService;
            _PageDialogService = pageDialogService;
            IsViewUserEditPanel = false;
            var users = new List<UserDataModel>
            {
                new UserDataModel { UserName="全社ユーザーＡ全社ユーザーＡ", UserId="aaaaaaaaaaaaaaaaaaaaaaaaaaaaa@be-org.co.jp", Password="xxx", Group="全社" },
                new UserDataModel { UserName="東京ユーザーＢ", UserId="bbbbbbbbbb@be-org.co.jp", Password="xxx", Group="東京事業所"},
                new UserDataModel { UserName="長崎ユーザーＣ", UserId="cccccccccc@be-org.co.jp", Password="xxx", Group="長崎事業所" },
                new UserDataModel { UserName="全社ユーザーＡ", UserId="aaaaaaaaaa@be-org.co.jp", Password="xxx", Group="全社" },
                new UserDataModel { UserName="東京ユーザーＢ", UserId="bbbbbbbbbb@be-org.co.jp", Password="xxx", Group="東京事業所"},
                new UserDataModel { UserName="長崎ユーザーＣ", UserId="cccccccccc@be-org.co.jp", Password="xxx", Group="長崎事業所" },
                new UserDataModel { UserName="全社ユーザーＡ", UserId="aaaaaaaaaa@be-org.co.jp", Password="xxx", Group="全社" },
                new UserDataModel { UserName="東京ユーザーＢ", UserId="bbbbbbbbbb@be-org.co.jp", Password="xxx", Group="東京事業所"},
                new UserDataModel { UserName="長崎ユーザーＣ", UserId="cccccccccc@be-org.co.jp", Password="xxx", Group="長崎事業所" },
                new UserDataModel { UserName="全社ユーザーＡ", UserId="aaaaaaaaaa@be-org.co.jp", Password="xxx", Group="全社" },
                new UserDataModel { UserName="東京ユーザーＢ", UserId="bbbbbbbbbb@be-org.co.jp", Password="xxx", Group="東京事業所"},
                new UserDataModel { UserName="長崎ユーザーＣ", UserId="cccccccccc@be-org.co.jp", Password="xxx", Group="長崎事業所" },
                new UserDataModel { UserName="全社ユーザーＡ", UserId="aaaaaaaaaa@be-org.co.jp", Password="xxx", Group="全社" },
                new UserDataModel { UserName="東京ユーザーＢ", UserId="bbbbbbbbbb@be-org.co.jp", Password="xxx", Group="東京事業所"},
                new UserDataModel { UserName="長崎ユーザーＣ", UserId="cccccccccc@be-org.co.jp", Password="xxx", Group="長崎事業所" },
                new UserDataModel { UserName="全社ユーザーＡ", UserId="aaaaaaaaaa@be-org.co.jp", Password="xxx", Group="全社" },
                new UserDataModel { UserName="東京ユーザーＢ", UserId="bbbbbbbbbb@be-org.co.jp", Password="xxx", Group="東京事業所"},
                new UserDataModel { UserName="長崎ユーザーＣ", UserId="cccccccccc@be-org.co.jp", Password="xxx", Group="長崎事業所" },
                new UserDataModel { UserName="全社ユーザーＡ", UserId="aaaaaaaaaa@be-org.co.jp", Password="xxx", Group="全社" },
                new UserDataModel { UserName="東京ユーザーＢ", UserId="bbbbbbbbbb@be-org.co.jp", Password="xxx", Group="東京事業所"},
                new UserDataModel { UserName="長崎ユーザーＣ", UserId="cccccccccc@be-org.co.jp", Password="xxx", Group="長崎事業所" },
                new UserDataModel { UserName="全社ユーザーＡ", UserId="aaaaaaaaaa@be-org.co.jp", Password="xxx", Group="全社" },
                new UserDataModel { UserName="東京ユーザーＢ", UserId="bbbbbbbbbb@be-org.co.jp", Password="xxx", Group="東京事業所"},
                new UserDataModel { UserName="長崎ユーザーＣ", UserId="cccccccccc@be-org.co.jp", Password="xxx", Group="長崎事業所" },
                new UserDataModel { UserName="全社ユーザーＡ", UserId="aaaaaaaaaa@be-org.co.jp", Password="xxx", Group="全社" },
                new UserDataModel { UserName="東京ユーザーＢ", UserId="bbbbbbbbbb@be-org.co.jp", Password="xxx", Group="東京事業所"},
                new UserDataModel { UserName="長崎ユーザーＣ", UserId="cccccccccc@be-org.co.jp", Password="xxx", Group="長崎事業所" },
                new UserDataModel { UserName="全社ユーザーＡ", UserId="aaaaaaaaaa@be-org.co.jp", Password="xxx", Group="全社" },
                new UserDataModel { UserName="東京ユーザーＢ", UserId="bbbbbbbbbb@be-org.co.jp", Password="xxx", Group="東京事業所"},
                new UserDataModel { UserName="長崎ユーザーＣ", UserId="cccccccccc@be-org.co.jp", Password="xxx", Group="長崎事業所" },
            };

            UserDataModels = new ObservableCollection<UserDataModel>(users);

            // グループ情報
            GroupInfos = new ObservableCollection<GroupInfoDataModel>
            {
                new GroupInfoDataModel { GroupName = "全社" },
                new GroupInfoDataModel { GroupName = "東京事業所" },
                new GroupInfoDataModel { GroupName = "長崎事業所" },
                //new GroupInfoDataModel { GroupName = "マネージャー" },
                //new GroupInfoDataModel { GroupName = "メンバー" },
                //new GroupInfoDataModel { GroupName = "第一グループ" },
                //new GroupInfoDataModel { GroupName = "第二グループ" },
                //new GroupInfoDataModel { GroupName = "第三グループ" },
            };

        }
        #endregion

        #region プロパティ

        /// <summary>
        /// 所属グループ情報コレクション
        /// </summary>
        private ObservableCollection<GroupInfoDataModel> _GroupInfos;
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
        /// 
        /// </summary>
        private string _DisplayUserId;
        public string DisplayUserId
        {
            get { return _DisplayUserId; }
            set
            {
                base.SetProperty(ref _DisplayUserId, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _DisplayUserName;
        public string DisplayUserName
        {
            get { return _DisplayUserName; }
            set
            {
                base.SetProperty(ref _DisplayUserName, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _DisplayPass;
        public string DisplayPass
        {
            get { return _DisplayPass; }
            set
            {
                base.SetProperty(ref _DisplayPass, value);
            }
        }

        /// <summary>
        /// ユーザー編集パネルタイトル
        /// </summary>
        private string _UserEditPanelTitle;
        public string UserEditPanelTitle
        {
            get { return _UserEditPanelTitle; }
            set
            {
                base.SetProperty(ref _UserEditPanelTitle, value);
            }
        }

        /// <summary>
        /// パネルのクローズ画像のソース
        /// </summary>
        public string PanelCloseIconSource { get; } = "BcTool.Resources.Images.Close.png";

        /// <summary>
        /// 編集パネルを開くフラグ
        /// </summary>
        private bool _IsViewUserEditPanel;
        public bool IsViewUserEditPanel
        {
            get { return _IsViewUserEditPanel; }
            set
            {
                base.SetProperty(ref _IsViewUserEditPanel, value);
            }
        }

        /// <summary>
        /// ユーザー追加モードフラグ
        /// </summary>
        private bool _IsAddUser { get; set; }

        /// <summary>
        /// ユーザー一覧選択情報
        /// </summary>
        private UserDataModel _SelectedUser;

        /// <summary>
        /// 表示ユーザー一覧
        /// </summary>
        private ObservableCollection<UserDataModel> _UserDataModels;
        public ObservableCollection<UserDataModel> UserDataModels
        {
            get { return _UserDataModels; }
            set
            {
                base.SetProperty(ref _UserDataModels, value);
            }
        }

        /// <summary>
        /// 編集パネル用ユーザーモデル
        /// </summary>
        private UserDataModel _EditUserDataModel;
        public UserDataModel EdtUserModel
        {
            get { return _EditUserDataModel; }
            set
            {
                _EditUserDataModel = value;

                base.RaisePropertyChanged("EditUserDataModel");
            }
        }

        #endregion

        #region コマンド

        /// <summary>
        /// ユーザー編集ボタンクリックイベントコマンド
        /// </summary>
        private ICommand _BtnUserEditClickedCommand = null;
        /// <summary>
        /// ユーザー編集ボタンクリックイベントコマンド
        /// </summary>
        public ICommand BtnUserEditClickedCommand => _BtnUserEditClickedCommand ?? (
            _BtnUserEditClickedCommand = new Command<UserDataModel>(
                (model) => ExecuteBtnUserEditClickedCommand(model)));

        /// <summary>
        /// パスワードリセットボタンクリックイベントコマンド
        /// </summary>
        private ICommand _BtnPasswordResetClickedCommand = null;
        /// <summary>
        /// パスワードリセットボタンクリックイベントコマンド
        /// </summary>
        public ICommand BtnPasswordResetClickedCommand => _BtnPasswordResetClickedCommand ?? (
            _BtnPasswordResetClickedCommand = new Command<UserDataModel>(
                (model) => ExecuteBtnPasswordResetClickedCommand(model)));

        /// <summary>
        /// ユーザー削除ボタンクリックイベントコマンド
        /// </summary>
        private ICommand _BtnUserDeleteClickedCommand = null;
        /// <summary>
        /// ユーザー削除ボタンクリックイベントコマンド
        /// </summary>
        public ICommand BtnUserDeleteClickedCommand => _BtnUserDeleteClickedCommand ?? (
            _BtnUserDeleteClickedCommand = new Command<UserDataModel>(
                (model) => ExecuteBtnUserDeleteClickedCommand(model)));

        /// <summary>
        /// ユーザー追加クリックイベントコマンド
        /// </summary>
        private ICommand _ToolbarItemAddUserClickedCommand = null;
        /// <summary>
        /// ユーザー追加クリックイベントコマンド
        /// </summary>
        public ICommand ToolbarItemAddUserClickedCommand => _ToolbarItemAddUserClickedCommand ?? (
            _ToolbarItemAddUserClickedCommand = new Command(
                () => ExecuteToolbarItemAddUserClickedCommand()));

        /// <summary>
        /// クローズ画像タップイベントコマンド
        /// </summary>
        private ICommand _CloseTappedCommand = null;
        /// <summary>
        /// View Threadクローズ画像タップイベントコマンド
        /// </summary>
        public ICommand ExecuteCloseTappedCommand => _CloseTappedCommand ?? (
           _CloseTappedCommand = new Command(
               () => ExecuteCloseTapped()));

        /// <summary>
        ///登録ボタンタップイベントコマンド
        /// </summary>
        private ICommand _BtnRegistUserTappedCommand = null;
        /// <summary>
        /// 登録ボタンタップイベントコマンド
        /// </summary>
        public ICommand BtnRegistUserTappedCommand => _BtnRegistUserTappedCommand ?? (
           _BtnRegistUserTappedCommand = new Command(
               () => ExecuteBtnRegistUserTapped()));

        /// <summary>
        /// ListViewのListItemの選択イベントコマンド
        /// </summary>
        private ICommand _SelectedCommand = null;
        /// <summary>
        /// ListViewのListItemの選択イベントコマンド
        /// </summary>
        public ICommand SelectedCommand => _SelectedCommand ?? (
            _SelectedCommand = new Command<UserDataModel>((model) => ExecuteSelected(model)));

        #endregion

        #region メソッド

        /// <summary>
        /// ユーザー編集ボタンクリックイベントコマンド処理
        /// </summary>
        /// <param name="model">選択中のユーザー情報モデルクラス</param>
        private void ExecuteBtnUserEditClickedCommand(UserDataModel model)
        {
            _IsAddUser = false;
            DisplayUserName = model.UserName;
            DisplayUserId = model.UserId;
            DisplayPass = model.Password;

            foreach (var item in GroupInfos)
            {
                item.IsOn = model.Group == item.GroupName;
            }

            IsViewUserEditPanel = true;
        }

        /// <summary>
        /// パスワードリセットボタンクリックイベント処理
        /// </summary>
        /// <param name="model">選択中のユーザー情報モデルクラス</param>
        private async void ExecuteBtnPasswordResetClickedCommand(UserDataModel model)
        {
            await _PageDialogService.DisplayAlertAsync("パスワードリセット", "開発中", "OK");
        }

        /// <summary>
        /// ユーザー削除ボタンクリックイベント処理
        /// </summary>
        /// <param name="model">選択中のユーザー情報モデルクラス</param>
        private async void ExecuteBtnUserDeleteClickedCommand(UserDataModel model)
        {
            string deleteInfo = "ユーザー名：" + model.UserName + "\r\nユーザーアドレス：" + model.UserId;
            bool result = await _PageDialogService.DisplayAlertAsync("ユーザー削除", deleteInfo + "\r\nを削除して宜しいですか？", "はい", "いいえ");

            if (result)
            {
                _UserDataModels.Remove(model);
            }
        }

        /// <summary>
        /// ユーザー管理ダイアログ表示イベント処理
        /// </summary>
        private void ExecuteToolbarItemAddUserClickedCommand()
        {
            _IsAddUser = true;
            UserEditPanelTitle = "ユーザー追加";
            DisplayUserId = string.Empty;
            DisplayUserName = string.Empty;
            DisplayPass = string.Empty;
            foreach (var item in GroupInfos)
            {
                item.IsOn = false;
            }

            IsViewUserEditPanel = true;
            //var result = await Xamarin.Forms.DependencyService.Get<IUserManagementService>().Show(
            //        "Password", "Please enter password.", "OK", "Cancel");
        }

        /// <summary>
        /// View Threadクローズ画像タップイベント処理
        /// </summary>
        private void ExecuteCloseTapped()
        {
            IsViewUserEditPanel = false;
        }

        public void ExecuteBtnRegistUserTapped()
        {
            var group = GroupInfos.FirstOrDefault(x => x.IsOn);
            string groupName = group == null ? string.Empty : group.GroupName;
            var user = new UserDataModel { UserName = DisplayUserName, UserId = DisplayUserId, Password = DisplayPass, Group = groupName };

            if (_IsAddUser)
            {
                UserDataModels.Add(user);
            }
            else
            {
                UserDataModels[UserDataModels.IndexOf(_SelectedUser)] = user;
            }            
            
            IsViewUserEditPanel = false;
        }

        /// <summary>
        /// リストビュー選択コマンド処理
        /// </summary>
        private void ExecuteSelected(UserDataModel model)
        {
            if (model != null)
            {
                _SelectedUser = model;
            }
        }

        #endregion
    }
}
