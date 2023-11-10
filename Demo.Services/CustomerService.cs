using System.Collections.Generic;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Repository.Contracts;
using Demo.Services.Contracts;
using Demo.Services.Contracts.Common;

namespace Demo.Services
{
    public class CustomerService<T> : ICustomerService<ICustomerModel> where T : class
    {
        #region FIELDS

        private readonly ICustomerRepository _customerRepository;
        private readonly IModelDataAnnotationValidator _modelDataAnnotationValidator;

        #endregion

        #region C-TOR

        public CustomerService(
            ICustomerRepository customerRepository,
            IModelDataAnnotationValidator modelDataAnnotationValidator)
        {
            _customerRepository = customerRepository;
            _modelDataAnnotationValidator = modelDataAnnotationValidator;
        }

        #endregion

        #region ICustomerRepository IMPLEMENTATION

        public ICustomerModel Get(int id)
        {
            return this._customerRepository.Get(id);
        }

        public void UpdateOrCreate(ICustomerModel model)
        {
            this._customerRepository.UpdateOrCreate(model);
        }

        public void Delete(int id)
        {
            this._customerRepository.Delete(id);
        }

        public IEnumerable<ICustomerModel> GetAll()
        {
            return this._customerRepository.GetAll();
        }

        #endregion

        #region BASE IMPLEMENTATION

        public void ValidateModelDataAnnotations(ICustomerModel model)
        {
            this._modelDataAnnotationValidator.ValidateDataAnnotations(model);
        }

        #endregion
    }
}
