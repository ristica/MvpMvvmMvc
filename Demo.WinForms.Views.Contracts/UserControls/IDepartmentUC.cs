using System;
using System.Collections.Generic;
using Demo.WinForms.Views.Contracts.Base;

namespace Demo.WinForms.Views.Contracts.UserControls
{
    // ReSharper disable once InconsistentNaming
    public interface IDepartmentUC : IBaseUserControl
    {
        event EventHandler DepartmentUserControlNewAddedEventRaised;
        event EventHandler UserControlReachedCriticalHeight;
        IList<IDepartmentRowUC> DataContext { get; set; }
    }
}
