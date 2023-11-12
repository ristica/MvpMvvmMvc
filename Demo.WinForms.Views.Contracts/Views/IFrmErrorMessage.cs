using Demo.WinForms.Views.Contracts.Base;

namespace Demo.WinForms.Views.Contracts.Views
{
    public interface IFrmErrorMessage : IBaseView
    {
        string ErrorMessage { get; set; }
    }
}
