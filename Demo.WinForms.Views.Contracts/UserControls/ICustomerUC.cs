using System;
using System.Collections.Generic;
using Demo.WinForms.Views.Contracts.Base;

namespace Demo.WinForms.Views.Contracts.UserControls
{
    // ReSharper disable once InconsistentNaming
    public interface ICustomerUC : IBaseUserControl
    {
        event EventHandler CustomerUserControlNewAddedEventRaised;
        event EventHandler UserControlReachedCriticalHeight;
        IList<ICustomerRowUC> DataContext { get; set; }
    }
}
