using System.Collections.Generic;
using Demo.Db;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Repository.Contracts;

namespace Demo.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        #region ICustomerRepository IMPLEMENTATION

        public ICustomerModel Get(int id)
        {
            return Database.Instance.GetCustomerById(id);
        }

        public void UpdateOrCreate(ICustomerModel model)
        {
            if (model.Id == 0) this.Create(model);
            else this.Update(model);
        }

        public void Delete(int id)
        {
            Database.Instance.DeleteCustomer(id);
        }

        public IEnumerable<ICustomerModel> GetAll()
        {
            return Database.Instance.GetAllCustomers();
        }

        #endregion

        #region HELPERS

        private void Update(ICustomerModel model)
        {
            Database.Instance.UpdateCustomer(model);
        }

        private void Create(ICustomerModel model)
        {
            Database.Instance.CreateCustomer(model);
        }

        #endregion
    }
}
