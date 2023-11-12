using System;

namespace Demo.WinForms.Views.Contracts.Base
{
    public interface IBaseView
    {
        event EventHandler FormLoadEventRaised;
        event EventHandler FormCloseEventRaised;

        string WindowTitle { get; set; }
        void ShowMe();
    }
}
