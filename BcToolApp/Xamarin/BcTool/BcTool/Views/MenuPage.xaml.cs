using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace BcTool.Views
{
	public class MenuItem
	{
		public string Title { get; set; }
		public ImageSource IconSource { get; set; }
		public Type TargetType { get; set; }
	}

	public partial class MenuPage : ContentPage
	{
		public MenuPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			lvMenu.ItemsSource = new ObservableCollection<MenuItem>()
			{
				new MenuItem()
				{
					Title = "掲示板",
					IconSource = ImageSource.FromResource("BcTool.Resources.Images.Board.png"),
					TargetType = typeof(BulletinBoardTabbedPage)
				},
				new MenuItem()
				{
					Title = "ユーザー管理",
					IconSource = ImageSource.FromResource("BcTool.Resources.Images.People.png"),
					TargetType = typeof(UserManagePage)
				},
			};

			lvMenu.SelectedItem = ((ObservableCollection<MenuItem>)lvMenu.ItemsSource)[0];

			lvSetting.ItemsSource = new ObservableCollection<MenuItem>()
			{
				new MenuItem()
				{
					Title = "設定",
					IconSource = ImageSource.FromResource("BcTool.Resources.Images.Setting.png"),
					TargetType = typeof(SettingPage)
				}
			};
		}

		private void listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MenuItem;

			if (item == null)
			{
				return;
			}

			if (item.TargetType == typeof(SettingPage))
			{
				lvMenu.SelectedItem = null;
			}
			else
			{
				lvSetting.SelectedItem = null;
			}

			(this.Parent as MasterPage).IsPresented = false;
			(this.Parent as MasterPage).Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
		}
	}
}
