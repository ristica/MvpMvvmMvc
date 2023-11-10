using Demo.Views.Contracts.Base;
using System;
using System.Windows.Forms;

namespace Demo.Views.Contracts.Views
{
    public interface IFrmMain : IBaseView
    {
        event EventHandler HelpViewShowEventRaised;
        event EventHandler CustomersViewShowEventRaised;
        event EventHandler DepartmentsViewShowEventRaised;

        Panel GetContentPanel();
        void ResizeMe(EventArgs args);
    }
}