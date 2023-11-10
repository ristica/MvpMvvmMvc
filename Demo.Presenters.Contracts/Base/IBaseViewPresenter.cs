using Demo.Views.Contracts.Base;
using System;

namespace Demo.Presenters.Contracts.Base
{
    public interface IBaseViewPresenter : IDisposable
    {
        IBaseView GetView();
        void ShowView();
    }
}
