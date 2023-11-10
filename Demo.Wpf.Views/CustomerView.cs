using Demo.Wpf.Views.Base;
using Demo.Wpf.Views.Contracts;

namespace Demo.Wpf.Views
{
    public class CustomerView : BaseView, ICustomerView
    {
        public void SetDataContext<ICustomerViewModel>(ICustomerViewModel vm)
        {
            throw new System.NotImplementedException();
        }
    }
}
