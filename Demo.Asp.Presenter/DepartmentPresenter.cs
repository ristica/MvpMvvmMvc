using System.Collections.Generic;
using Demo.Asp.Presenter.Base;
using Demo.Asp.Presenter.Contracts;
using Demo.Dependencies.Contracts;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.Services.Contracts;

namespace Demo.Asp.Presenter
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DepartmentPresenter : BasePresenter, IDepartmentPresenter
    {
        private readonly IDepartmentService<IDepartmentModel> _departmentService;

        public DepartmentPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            _departmentService = dependencyContainer.Resolve<IDepartmentService<IDepartmentModel>>();
        }

        public IEnumerable<IDepartmentModel> GetAll()
        {
            return this._departmentService.GetAll();
        }
    }
}
