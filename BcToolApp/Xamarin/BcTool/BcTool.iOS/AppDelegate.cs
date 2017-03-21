using BcTool.Configs;
using BcTool.iOS.Services;
using Foundation;
using Microsoft.Practices.Unity;
using Prism.Unity;
using UIKit;
using Xamarin.Forms;

namespace BcTool.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // 進捗ダイアログの設定
            SetProgressDialog();

            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
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
                    base.InvokeOnMainThread(() =>
                    {
                        if (e.IsVisible)
                        {
                            // 進捗ダイアログの表示
                            ProgressDialogService.Show(e);
                        }
                        else
                        {
                            // 進捗ダイアログの非表示
                            ProgressDialogService.Dismiss();
                        }
                    });
                });
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }

}
