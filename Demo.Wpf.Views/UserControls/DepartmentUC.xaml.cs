using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for DepartmentUC.xaml
    /// </summary>
    public partial class DepartmentUC : IDepartmentView
    {
        public DepartmentUC()
        {
            InitializeComponent();
        }

        public void SetDataContext<T>(T viewModel)
        {
            this.DataContext = viewModel;
        }
    }
}
