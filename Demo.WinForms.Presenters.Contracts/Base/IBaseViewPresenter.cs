using System;
using Demo.WinForms.Views.Contracts.Base;

namespace Demo.WinForms.Presenters.Contracts.Base
{
    public interface IBaseViewPresenter : IDisposable
    {
        IBaseView GetView();
        void ShowView();
    }
}
