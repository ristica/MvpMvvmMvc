using Demo.Asp.Presenter;
using Demo.Asp.Presenter.Contracts;
using Demo.Dependencies.Contracts;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.Models.CustomerDomain;
using Demo.Models.DepartmentDomain;
using Demo.Repository;
using Demo.Repository.Contracts;
using Demo.Services;
using Demo.Services.Common;
using Demo.Services.Contracts;
using Demo.Services.Contracts.Common;

namespace Demo.Bootstrapper.Asp
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DependencyInitializer
    {
        public static void Initialize(IDependencyContainer container)
        {
            RegisterRepositories(container);
            RegisterModel(container);
            RegisterServices(container);
            RegisterPresenters(container);
        }

        private static void RegisterPresenters(IDependencyContainer container)
        {
            container.RegisterType<ICustomerPresenter, CustomerPresenter>();
            container.RegisterType<IDepartmentPresenter, DepartmentPresenter>();
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

        private static void RegisterServices(IDependencyContainer container)
        {
            container.RegisterType(typeof(ICustomerService<>), typeof(CustomerService<>));
            container.RegisterType(typeof(IDepartmentService<>), typeof(DepartmentService<>));

            container.RegisterType<IModelDataAnnotationValidator, ModelDataAnnotationValidator>();
        }
    }
}
