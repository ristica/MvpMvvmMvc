using System.Windows;
using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.Views.UserControls
{
    // ReSharper disable once InconsistentNaming
    public partial class CustomerRowUC : ICustomerRowView
    {
        public CustomerRowUC()
        {
            InitializeComponent();
        }

        public void SetDataContext<T>(T dc)
        {
            this.DataContext = dc;
            this.BtnDetailsOnClicked(null, null);
        }

        private void BtnDetailsOnClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.DetailsStackPanel.Visibility = this.DetailsStackPanel.Visibility == Visibility.Collapsed
                ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
