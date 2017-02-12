using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace BcTool.Views
{
	public partial class SettingPage : TabbedPage
	{
		public SettingPage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			pcrSyncPeriod.ItemsSource = new List<string>()
			{
				"７日間",
				"１４日間",
				"１ヶ月間",
				"３ヶ月間",
				"６ヶ月間",
				"１年間",
				"すべて"
			};

			Assembly assembly = typeof(SettingPage).GetTypeInfo().Assembly;
			using (Stream stream = assembly.GetManifestResourceStream("BcTool.Resources.Html.ChangeLog.html"))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = await reader.ReadToEndAsync();
					wvChangeLog.Source = new HtmlWebViewSource
					{
						Html = str
					};
				}
			}
		}
	}
}
