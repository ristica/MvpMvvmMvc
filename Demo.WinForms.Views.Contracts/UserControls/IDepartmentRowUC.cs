using System;
using Demo.WinForms.Views.Contracts.Base;

namespace Demo.WinForms.Views.Contracts.UserControls
{
    // ReSharper disable once InconsistentNaming
    public interface IDepartmentRowUC : IBaseUserControl
    {
        event EventHandler DepartmentRowUserControlEditEventRaised;
        event EventHandler DepartmentRowUserControlDeleteEventRaised;
        event EventHandler DepartmentRowUserControlDisposeEventRaised;

        void DisposeMe();
    }
}
