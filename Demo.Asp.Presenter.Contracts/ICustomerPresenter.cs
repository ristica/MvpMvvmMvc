using System.Collections.Generic;
using Demo.Models.Contracts.CustomerDomain;

namespace Demo.Asp.Presenter.Contracts
{
    public interface ICustomerPresenter
    {
        IEnumerable<ICustomerModel> GetAll();
    }
}