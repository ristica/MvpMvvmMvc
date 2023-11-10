using Demo.Wpf.Views.Base;
using Demo.Wpf.Views.Contracts;

namespace Demo.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : BaseWindow, IMainWindow
    {
        public MainWindow()
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
