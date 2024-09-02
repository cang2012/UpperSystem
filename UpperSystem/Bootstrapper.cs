using Caliburn.Micro;
using System.Windows;
using UpperSystem.ViewModels;

namespace UpperSystem
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<LoginViewModel>();
        }
    }
}
