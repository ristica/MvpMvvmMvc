using System;
using System.Windows.Controls;
using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerUC : UserControl, ICustomerView
    {
        public CustomerUC()
        {
            InitializeComponent();
        }

        public void SetDataContext<T>(T viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
