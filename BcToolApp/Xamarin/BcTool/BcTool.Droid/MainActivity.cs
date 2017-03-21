using Android.App;
using Android.Content.PM;
using Android.OS;
using BcTool.Configs;
using BcTool.Droid.Services;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace BcTool.Droid
{
    [Activity(Label = "BcTool", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            // 進捗ダイアログの設定
            SetProgressDialog();

            LoadApplication(new App(new AndroidInitializer()));
        }

        /// <summary>
        /// 進捗ダイアログの設定
        /// </summary>
        private void SetProgressDialog()
        {
            MessagingCenter.Subscribe<object, ProgressConfig>(
                this,
                "progress_dialog",
                (sender, e) =>
                {
                    base.RunOnUiThread(() =>  
                    {
                        if (e.IsVisible)
                        {
                            // 進捗ダイアログの表示
                            ProgressDialogService.Show(this, e);
                        }
                        else
                        {
                            // 進捗ダイアログの非表示
                            ProgressDialogService.Dismiss(this);
                        }
                    });
                });
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}

