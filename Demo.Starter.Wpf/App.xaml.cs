using System.Windows;
using Demo.Bootstrapper.Wpf;
using Demo.Dependencies.Builder;
using Demo.Wpf.ViewModels.Contracts;

namespace Demo.Starter.Wpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DependencyInitializer.Initialize(DependencyContainerFactory.Init());
            DependencyContainerFactory.Container.Resolve<IMainViewModel>().GetWindow().ShowMe();
        }
    }
}
