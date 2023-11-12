using Demo.WinForms.Views.Contracts.Base;

namespace Demo.WinForms.Presenters.Contracts.Base
{
    public interface IBaseUserControlPresenter
    {
        IBaseUserControl GetUserControl();
        void Dispose();
    }
}
