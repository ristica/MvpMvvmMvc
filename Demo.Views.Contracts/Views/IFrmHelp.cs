using Demo.Views.Contracts.Base;

namespace Demo.Views.Contracts.Views
{
    public interface IFrmHelp : IBaseView
    {
        string Product { get; set; }
        string Version { get; set; }
        string Copyright { get; set; }
        string Description { get; set; }
    }
}
