using Demo.Views.Contracts.Base;
using System;

namespace Demo.Views.Contracts.UserControls
{
    public interface IDepartmentRowUC : IBaseUserControl
    {
        event EventHandler DepartmentRowUserControlEditEventRaised;
        event EventHandler DepartmentRowUserControlDeleteEventRaised;
        event EventHandler DepartmentRowUserControlDisposeEventRaised;

        void DisposeMe();
    }
}
