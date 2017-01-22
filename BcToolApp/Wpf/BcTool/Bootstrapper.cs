using Microsoft.Practices.Unity;
using Prism.Unity;
using BcTool.Views;
using System.Windows;

namespace BcTool
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
