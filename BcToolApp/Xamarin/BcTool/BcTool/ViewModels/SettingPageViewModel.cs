using BcTool.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BcTool.ViewModels
{
	/// <summary>
	/// 設定画面ViewModel
	/// </summary>
	public class SettingPageViewModel : BindableBase
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

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="navigationService">ナビゲーションサービス</param>
		/// <param name="pageDialogService">ダイアログサービス</param>
		public SettingPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
		{
			_navigationService = navigationService;
			_pageDialogService = pageDialogService;

			// 更新履歴のHtmlファイルを読み込む
			Assembly assembly = typeof(SettingPage).GetTypeInfo().Assembly;
			using (Stream stream = assembly.GetManifestResourceStream("BcTool.Resources.Html.ChangeLog.html"))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = reader.ReadToEnd();
					ChangeLogSource = new HtmlWebViewSource
					{
						Html = str
					};
				}
			}
		}
		#endregion

		#region プロパティ

		/// <summary>
		/// 掲示板同期期間リスト
		/// </summary>
		public List<string> SyncPeriodItems
		{
			get
			{
				return new List<string>
				{
					"７日間",
					"１４日間",
					"１ヶ月間",
					"３ヶ月間",
					"６ヶ月間",
					"１年間",
					"すべて",
				};
			}
		}

		private HtmlWebViewSource _changeLogSource;
		/// <summary>
		/// 更新履歴WebViewSource
		/// </summary>
		public HtmlWebViewSource ChangeLogSource
		{
			get
			{
				return _changeLogSource;
			}
			set
			{
				SetProperty(ref _changeLogSource, value);
			}
		}

		#endregion

		#region コマンド

		private ICommand _changePasswordCommand = null;
		/// <summary>
		/// パスワード変更タップコマンド
		/// </summary>
		public ICommand ChangePasswordCommand => _changePasswordCommand ?? (
			_changePasswordCommand = new Command(async () => await ExecuteNavigatePasswordChange()));

		private ICommand _signoutCommand = null;
		/// <summary>
		/// サインアウトタップコマンド
		/// </summary>
		public ICommand SignoutCommand => _signoutCommand ?? (
			_signoutCommand = new Command(() => ExecuteSignout()));

		#endregion

		#region メソッド

		/// <summary>
		/// パスワード変更画面へ遷移する
		/// </summary>
		private async Task ExecuteNavigatePasswordChange()
		{
			// パスワード変更画面に遷移する
			await _navigationService.NavigateAsync(nameof(PasswordChangePage));
		}

		/// <summary>
		/// サインアウトする
		/// </summary>
		/// <returns></returns>
		private void ExecuteSignout()
		{
            // サインイン画面へ遷移する
            App.Current.MainPage = new SigninPage();
		}

		#endregion
	}
}
