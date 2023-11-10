using System;
using System.Windows.Controls;
using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CustomerRowUC.xaml
    /// </summary>
    public partial class CustomerRowUC : UserControl, ICustomerRowView
    {
        public CustomerRowUC()
        {
            InitializeComponent();
        }

        public void SetDataContext<T>(T viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
