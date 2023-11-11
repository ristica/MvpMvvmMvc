using Demo.Wpf.Views.Contracts.UserControls;
using System.Windows.Controls;

namespace Demo.Wpf.Views.UserControls
{
    // ReSharper disable once InconsistentNaming
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

        public StackPanel GetPanelControl()
        {
            return this.PanelControl;
        }
    }
}
