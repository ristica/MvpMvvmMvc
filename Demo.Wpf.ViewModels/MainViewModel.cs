using System.Windows.Input;
using Demo.Dependencies.Contracts;
using Demo.Wpf.ViewModels.Base;
using Demo.Wpf.ViewModels.Commands;
using Demo.Wpf.ViewModels.Contracts;
using Demo.Wpf.Views.Contracts;
using Demo.Wpf.Views.Contracts.Base;

namespace Demo.Wpf.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private readonly IMainWindow _window;

        public ICommand HelpCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public MainViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._window = dependencyContainer.Resolve<IMainWindow>();

            this.RegisterCommands();
            this.SetDataContext();
        }

        public IBaseWindow GetWindow() => this._window;

        protected sealed override void SetDataContext()
        {
            this._window.SetDataContext(this);
        }

        private void RegisterCommands()
        {
            this.HelpCommand = new DelegateCommand(ExecuteHelpCommand, CanExecuteHelpCommand);
            this.CloseCommand = new DelegateCommand(ExecuteCloseCommand, CanExecuteCloseCommand);
        }

        private bool CanExecuteHelpCommand(object arg) => true;
        private bool CanExecuteCloseCommand(object arg) => true;

        private void ExecuteHelpCommand(object obj)
        {
            DependencyContainer.Resolve<IHelpViewModel>().GetWindow().ShowModalMe();
        }

        private void ExecuteCloseCommand(object obj)
        {
            this._window.CloseMe();
        }
    }
}
