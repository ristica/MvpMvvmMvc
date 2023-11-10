using System.Linq;
using System.Reflection;
using Demo.Dependencies.Contracts;
using Demo.Presenters.Base;
using Demo.Presenters.Contracts;
using Demo.Views.Contracts.Base;
using Demo.Views.Contracts.Views;

namespace Demo.Presenters
{
    public class HelpViewPresenter : Presenter, IHelpViewPresenter
    {
        private readonly IFrmHelp _view;

        public IBaseView GetView() => this._view;

        public HelpViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IFrmHelp>();
            this.SubscribeToUserInterfaceEvents();
        }

        public void ShowView()
        {
            this._view.ShowMe();
        }

        protected sealed override void SubscribeToUserInterfaceEvents()
        {
            this._view.FormLoadEventRaised += (sender, args) =>
            {
                this._view.WindowTitle = GetAssemblyTitle();
                this._view.Description = GetAssemblyDescription();
                this._view.Product = GetAssemblyProduct();
                this._view.Version = GetAssemblyVersion();
                this._view.Copyright = GetAssemblyCopyright();
            };

            this._view.FormCloseEventRaised += (sender, args) =>
            {
                this.Dispose();
            };
        }

        private string GetAssemblyCopyright()
        {
            dynamic attribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)
                .First();

            return attribute.Copyright;
        }

        private string GetAssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private string GetAssemblyProduct()
        {
            dynamic attribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyProductAttribute), false)
                .First();

            return attribute.Product;
        }

        private string GetAssemblyDescription()
        {
            dynamic attribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                .First();

            return attribute.Description;
        }

        private string GetAssemblyTitle()
        {
            dynamic attribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyTitleAttribute), false)
                .First();

            return attribute.Title;
        }

        /// <summary>
        /// On Form Closing
        /// </summary>
        public void Dispose()
        {
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.FormLoadEventRaised -= (sender, args) => { };
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.FormCloseEventRaised -= (sender, args) => { };
        }
    }
}
