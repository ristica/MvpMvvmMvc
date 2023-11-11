using System.Windows.Controls;
using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.Views.UserControls
{
    // ReSharper disable once InconsistentNaming
    public partial class CustomerUC : ICustomerView
    {
        public CustomerUC()
        {
            InitializeComponent();
        }

        public void SetDataContext<T>(T dc)
        {
            this.DataContext = dc;
        }

        public StackPanel GetPanelControl()
        {
            return this.PanelControl;
        }
    }
}
