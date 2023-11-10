using System.Collections.Generic;
using Demo.Models.Contracts.CustomerDomain;

namespace Demo.Repository.Contracts
{
    public interface ICustomerRepository
    {
        ICustomerModel Get(int id);
        void UpdateOrCreate(ICustomerModel model);
        void Delete(int id);
        IEnumerable<ICustomerModel> GetAll();
    }
}