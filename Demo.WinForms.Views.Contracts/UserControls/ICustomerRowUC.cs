using System;
using Demo.Models.Contracts.CustomerDomain;
using Demo.WinForms.Views.Contracts.Base;

namespace Demo.WinForms.Views.Contracts.UserControls
{
    // ReSharper disable once InconsistentNaming
    public interface ICustomerRowUC : IBaseUserControl
    {
        event EventHandler CustomerRowUserControlEditEventRaised;
        event EventHandler CustomerRowUserControlDeleteEventRaised;
        event EventHandler CustomerRowUserControlDisposeEventRaised;

        ICustomerModel DataContext { get; set; }

        void DisposeMe();
    }
}
