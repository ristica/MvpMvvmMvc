using Demo.Wpf.Views.Base;
using Demo.Wpf.Views.Contracts;

namespace Demo.Wpf.Views
{
    public class DepartmentView : BaseView, IDepartmentView
    {
        public void SetDataContext<IDepartmentViewModel>(IDepartmentViewModel vm)
        {
            throw new System.NotImplementedException();
        }
    }
}
