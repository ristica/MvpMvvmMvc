using Demo.Views.Contracts.Base;

namespace Demo.Presenters.Contracts.Base
{
    public interface IBaseUserControlPresenter
    {
        IBaseUserControl GetUserControl();
        void Dispose();
    }
}
