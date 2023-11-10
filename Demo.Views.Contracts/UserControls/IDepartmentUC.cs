using Demo.Views.Contracts.Base;
using System;
using System.Collections.Generic;

namespace Demo.Views.Contracts.UserControls
{
    public interface IDepartmentUC : IBaseUserControl
    {
        event EventHandler DepartmentUserControlNewAddedEventRaised;
        event EventHandler UserControlReachedCriticalHeight;
        IList<IDepartmentRowUC> DataContext { get; set; }
    }
}
