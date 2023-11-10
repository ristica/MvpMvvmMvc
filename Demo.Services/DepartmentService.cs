using System.Collections.Generic;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.Repository.Contracts;
using Demo.Services.Contracts;

namespace Demo.Services
{
    public class DepartmentService<T> : IDepartmentService<IDepartmentModel> where T : class
    {
        #region FIELDS

        private readonly IDepartmentRepository _departmentRepository;

        #endregion

        #region C-TOR

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        #endregion

        #region IDepartmentService IMPLEMENTATION

        public IDepartmentModel Get(int id)
        {
            return this._departmentRepository.Get(id);
        }

        public void UpdateOrCreate(IDepartmentModel model)
        {
            this._departmentRepository.UpdateOrCreate(model);
        }

        public void Delete(int id)
        {
            this._departmentRepository.Delete(id);
        }

        public IEnumerable<IDepartmentModel> GetAll()
        {
            return this._departmentRepository.GetAll();
        }

        #endregion

        #region BASE IMPLEMENTATION

        public void ValidateModelDataAnnotations(IDepartmentModel model)
        {

        }

        #endregion
    }
}
