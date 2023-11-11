using System.Collections.Generic;
using Demo.Models.Contracts.DepartmentDomain;

namespace Demo.Asp.Presenter.Contracts
{
    public interface IDepartmentPresenter
    {
        IEnumerable<IDepartmentModel> GetAll();
    }
}