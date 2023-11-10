using System;
using System.Windows.Forms;
using Demo.Bootstrapper.WinForms;
using Demo.Dependencies.Builder;
using Demo.Presenters.Contracts;

namespace Demo.Starter.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DependencyInitializer.Initialize(DependencyContainerFactory.Init());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run((Form)DependencyContainerFactory.Container.Resolve<IMainViewPresenter>().GetView());
        }
    }
}
