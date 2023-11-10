using Demo.Db;
using System.Collections.Generic;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.Repository.Contracts;

namespace Demo.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        #region ICustomerRepository IMPLEMENTATION

        public IDepartmentModel Get(int id)
        {
            return Database.Instance.GetDepartmentById(id);
        }

        public void UpdateOrCreate(IDepartmentModel model)
        {
            if (model.Id == 0) this.Create(model);
            else this.Update(model);
        }

        public void Delete(int id)
        {
            Database.Instance.DeleteDepartment(id);
        }

        public IEnumerable<IDepartmentModel> GetAll()
        {
            return Database.Instance.GetAllDepartments();
        }

        #endregion

        #region HELPERS

        private void Update(IDepartmentModel model)
        {
            Database.Instance.UpdateDepartment(model);
        }

        private void Create(IDepartmentModel model)
        {
            Database.Instance.CreateDepartment(model);
        }

        #endregion
    }
}
