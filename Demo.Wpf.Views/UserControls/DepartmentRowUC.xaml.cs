using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.Views.UserControls
{
    public partial class DepartmentRowUC : IDepartmentRowView
    {
        public DepartmentRowUC()
        {
            InitializeComponent();
        }

        public void SetDataContext<T>(T viewModel)
        {
            this.DataContext = viewModel;
        }
    }
}
