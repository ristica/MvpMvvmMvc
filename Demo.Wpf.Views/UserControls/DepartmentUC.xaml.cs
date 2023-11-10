using System;
using System.Windows.Controls;
using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for DepartmentUC.xaml
    /// </summary>
    public partial class DepartmentUC : UserControl, IDepartmentView
    {
        public DepartmentUC()
        {
            InitializeComponent();
        }

        public void SetDataContext<T>(T viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
