using System;
using System.Windows.Controls;
using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for DepartmentRowUC.xaml
    /// </summary>
    public partial class DepartmentRowUC : UserControl, IDepartmentRowView
    {
        private IDepartmentRowView _departmentRowViewImplementation;

        public DepartmentRowUC()
        {
            InitializeComponent();
        }

        public void SetDataContext<T>(T viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
