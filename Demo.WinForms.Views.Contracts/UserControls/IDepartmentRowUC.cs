using System;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.WinForms.Views.Contracts.Base;

namespace Demo.WinForms.Views.Contracts.UserControls
{
    // ReSharper disable once InconsistentNaming
    public interface IDepartmentRowUC : IBaseUserControl
    {
        IDepartmentModel DataContext { get; set; }

        event EventHandler DepartmentRowUserControlEditEventRaised;
        event EventHandler DepartmentRowUserControlDeleteEventRaised;
        event EventHandler DepartmentRowUserControlDisposeEventRaised;

        void DisposeMe();
    }
}
