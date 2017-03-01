using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BcTool.DataModels;
using Prism.Mvvm;
using Xamarin.Forms;

namespace BcTool.ViewModels
{
    /// <summary>
    /// 掲示板情報ページViewModelクラス
    /// </summary>
    public class BulletinBoardPageViewModel : BindableBase
    {
        #region コンストラクタ

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
                "最終更新日時（昇順）",
                "最終更新日時（降順）",
            };

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

			BulletinBoardDataModels = new ObservableCollection<BulletinBoardDataModel>(list);
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

        ///// <summary>
        ///// フィルターパネルの表示制御（iOS、Android版）
        ///// </summary
        //public bool IsConditionPostedDateTimePanel4iOS2DroidVisible
        //{
        //    get
        //    {
        //        return (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android);
        //    }
        //}

        ///// <summary>
        ///// フィルターパネルの表示制御（UWP版）
        ///// </summary
        //public bool IsConditionPostedDateTimePanel4UWPVisible
        //{
        //    get
        //    {
        //        return (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows);
        //    }
        //}

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
            _BtnFilterSettingClickedCommand = new Command(
                () => ExecuteBtnFilterSettingClickedCommand()));

        /// <summary>
        /// フィルターキャンセルボタンクリックイベントコマンド
        /// </summary>
        private ICommand _BtnFilterCancelClickedCommand = null;
        /// <summary>
        /// フィルターキャンセルボタンクリックイベントコマンド
        /// </summary>
        public ICommand BtnFilterCancelClickedCommand => _BtnFilterCancelClickedCommand ?? (
            _BtnFilterCancelClickedCommand = new Command(
                () => ExecuteBtnFilterCancelClickedCommand()));

        #endregion

        #region メソッド

        /// <summary>
        /// フィルター設定ボタンクリックイベント処理
        /// </summary>
        /// <returns>Task</returns>
        private void ExecuteBtnFilterSettingClickedCommand()
        {
            IsFilterPanelVisible = false;
        }

        /// <summary>
        /// フィルターキャンセルボタンクリックイベント処理
        /// </summary>
        /// <returns>Task</returns>
        private void ExecuteBtnFilterCancelClickedCommand()
        {
            IsFilterPanelVisible = false;
        }

        #endregion
    }
}
