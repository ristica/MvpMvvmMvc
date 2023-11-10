using Demo.Common;
using Demo.Common.Contracts;
using Demo.Dependencies.Contracts;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.Models.CustomerDomain;
using Demo.Models.DepartmentDomain;
using Demo.Repository;
using Demo.Repository.Contracts;
using Demo.Services;
using Demo.Services.Contracts;
using Demo.Wpf.ViewModels;
using Demo.Wpf.ViewModels.Contracts;
using Demo.Wpf.Views;
using Demo.Wpf.Views.Contracts;
using Demo.Wpf.Views.Contracts.UserControls;
using Demo.Wpf.Views.UserControls;

namespace Demo.Bootstrapper.Wpf
{
    public class DependencyInitializer
    {
        public static void Initialize(IDependencyContainer container)
        {
            RegisterCommonComponents(container);
            RegisterViewModels(container);
            RegisterRepositories(container);
            RegisterModel(container);
            RegisterViews(container);
            RegisterServices(container);
        }

        private static void RegisterCommonComponents(IDependencyContainer container)
        {
            container.RegisterTypeAsSingleton<IMessageNotificationsHelper, MessageNotificationsHelper>();
        }

        private static void RegisterViewModels(IDependencyContainer container)
        {
            container.RegisterType<IMainViewModel, MainViewModel>();
            container.RegisterType<IHelpViewModel, HelpViewModel>();
            container.RegisterType<ICustomerViewModel, CustomerViewModel>();
            container.RegisterType<IDepartmentViewModel, DepartmentViewModel>();
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

        private static void RegisterViews(IDependencyContainer container)
        {
            container.RegisterType<IMainWindow, MainWindow>();
            container.RegisterType<IHelpWindow, HelpWindow>();
            container.RegisterType<ICustomerView, CustomerUC>();
            container.RegisterType<IDepartmentView, DepartmentUC>();
            container.RegisterType<ICustomerRowView, CustomerRowUC>();
            container.RegisterType<IDepartmentRowView, DepartmentRowUC>();
        }

        private static void RegisterServices(IDependencyContainer container)
        {
            container.RegisterType(typeof(ICustomerService<>), typeof(CustomerService<>));
            container.RegisterType(typeof(IDepartmentService<>), typeof(DepartmentService<>));
        }
    }
}
