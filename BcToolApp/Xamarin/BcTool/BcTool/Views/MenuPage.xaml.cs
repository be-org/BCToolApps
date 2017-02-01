using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace BcTool.Views
{
	public class MenuItem
	{
		public string Title { get; set; }
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

			var list = new ObservableCollection<MenuItem>()
			{
				new MenuItem()
				{
					Title = "掲示板",
					TargetType = typeof(BulletinBoardListPage)
				},
				new MenuItem()
				{
					Title = "設定",
					TargetType = typeof(SettingPage)
				},
			};

			listview.ItemsSource = list;
			listview.SelectedItem = ((ObservableCollection<MenuItem>)listview.ItemsSource)[0];
		}

		private void listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MenuItem;

			(this.Parent as MasterPage).Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
		}
	}
}
