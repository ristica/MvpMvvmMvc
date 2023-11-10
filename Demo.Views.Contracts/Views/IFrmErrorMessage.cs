using Demo.Views.Contracts.Base;

namespace Demo.Views.Contracts.Views
{
    public interface IFrmErrorMessage : IBaseView
    {
        string ErrorMessage { get; set; }
    }
}
