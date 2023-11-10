using System.Collections.Generic;
using Demo.Models.Contracts.DepartmentDomain;

namespace Demo.Repository.Contracts
{
    public interface IDepartmentRepository
    {
        IDepartmentModel Get(int id);
        void UpdateOrCreate(IDepartmentModel model);
        void Delete(int id);
        IEnumerable<IDepartmentModel> GetAll();
    }
}