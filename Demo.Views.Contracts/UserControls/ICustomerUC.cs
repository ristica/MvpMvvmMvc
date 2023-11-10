using System;
using System.Collections.Generic;
using Demo.Views.Contracts.Base;

namespace Demo.Views.Contracts.UserControls
{
    // ReSharper disable once InconsistentNaming
    public interface ICustomerUC : IBaseUserControl
    {
        event EventHandler CustomerUserControlNewAddedEventRaised;
        event EventHandler UserControlReachedCriticalHeight;
        IList<ICustomerRowUC> DataContext { get; set; }
    }
}
