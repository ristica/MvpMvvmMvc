using System.Collections;
using System.Collections.Generic;
using Demo.Asp.Presenter.Base;
using Demo.Asp.Presenter.Contracts;
using Demo.Dependencies.Contracts;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Services.Contracts;

namespace Demo.Asp.Presenter
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CustomerPresenter : BasePresenter, ICustomerPresenter
    {
        private readonly ICustomerService<ICustomerModel> _customerService;

        public CustomerPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            _customerService = dependencyContainer.Resolve<ICustomerService<ICustomerModel>>();
        }

        public IEnumerable<ICustomerModel> GetAll()
        {
            return this._customerService.GetAll();
        }
    }
}
