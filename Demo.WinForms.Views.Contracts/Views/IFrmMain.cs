using System;
using System.Windows.Forms;
using Demo.WinForms.Views.Contracts.Base;

namespace Demo.WinForms.Views.Contracts.Views
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