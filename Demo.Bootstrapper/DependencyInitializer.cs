using Demo.Common;
using Demo.Common.Contracts;
using Demo.Dependencies.Contracts;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.Models.CustomerDomain;
using Demo.Models.DepartmentDomain;
using Demo.Presenters;
using Demo.Presenters.Contracts;
using Demo.Presenters.Contracts.UserControls;
using Demo.Presenters.UserControls;
using Demo.Repository;
using Demo.Repository.Contracts;
using Demo.Services;
using Demo.Services.Common;
using Demo.Services.Contracts;
using Demo.Services.Contracts.Common;
using Demo.Views;
using Demo.Views.Contracts.UserControls;
using Demo.Views.Contracts.Views;
using Demo.Views.UserControls;

namespace Demo.Bootstrapper.WinForms
{
    public class DependencyInitializer
    {
        public static void Initialize(IDependencyContainer container)
        {
            RegisterCommonComponents(container);
            RegisterPresenters(container);
            RegisterRepositories(container);
            RegisterModel(container);
            RegisterForms(container);
            RegisterServices(container);
        }

        private static void RegisterCommonComponents(IDependencyContainer container)
        {
            container.RegisterType<IEventHelper, EventHelper>();
            container.RegisterTypeAsSingleton<IMessageNotificationsHelper, MessageNotificationsHelper>();
        }

        private static void RegisterPresenters(IDependencyContainer container)
        {
            container.RegisterType<IMainViewPresenter, MainViewPresenter>();
            container.RegisterType<IErrorMessageViewPresenter, ErrorMessageViewPresenter>();
            container.RegisterType<IHelpViewPresenter, HelpViewPresenter>();

            container.RegisterType<ICustomerViewPresenter, CustomerViewPresenter>();
            container.RegisterType<ICustomerRowViewPresenter, CustomerRowViewPresenter>();

            container.RegisterType<IDepartmentViewPresenter, DepartmentViewPresenter>();
            container.RegisterType<IDepartmentRowViewPresenter, DepartmentRowViewPresenter>();
        }

        private static void RegisterRepositories(IDependencyContainer container)
        {
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
        }

        private static void RegisterModel(IDependencyContainer container)
        {
            container.RegisterType<ICustomerModel, CustomerModel>();
            container.RegisterType<IDepartmentModel, DepartmentModel>();
        }

        private static void RegisterForms(IDependencyContainer container)
        {
            container.RegisterType<IFrmMain, FrmMain>();
            container.RegisterType<IFrmErrorMessage, FrmErrorMessage>();
            container.RegisterType<IFrmHelp, FrmHelp>();

            container.RegisterType<ICustomerUC, CustomerUC>();
            container.RegisterType<ICustomerRowUC, CustomerRowUC>();

            container.RegisterType<IDepartmentUC, DepartmentUC>();
            container.RegisterType<IDepartmentRowUC, DepartmentRowUC>();
        }

        private static void RegisterServices(IDependencyContainer container)
        {
            container.RegisterType(typeof(ICustomerService<>), typeof(CustomerService<>));
            container.RegisterType(typeof(IDepartmentService<>), typeof(DepartmentService<>));
            container.RegisterType<IModelDataAnnotationValidator, ModelDataAnnotationValidator>();
        }
    }
}
