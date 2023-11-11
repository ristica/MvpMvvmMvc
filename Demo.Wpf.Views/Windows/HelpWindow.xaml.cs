using Demo.Wpf.Views.Base;
using Demo.Wpf.Views.Contracts.Windows;

namespace Demo.Wpf.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HelpWindow : BaseWindow, IHelpWindow
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        public void CloseMe()
        {
            this.Close();
        }

        public void ShowModalMe()
        {
            this.ShowDialog();
        }

        public void ShowMe()
        {
            this.Show();
        }

        public void SetDataContext<IBaseViewModelForWindow>(IBaseViewModelForWindow viewModel)
        {
            this.DataContext = viewModel;
        }
    }
}
