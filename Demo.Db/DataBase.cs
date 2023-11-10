using Demo.Models.Contracts.CustomerDomain;
using System.Collections.Generic;
using System.Linq;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.Models.CustomerDomain;
using Demo.Models.DepartmentDomain;
using Demo.Models.Shared;

namespace Demo.Db
{
    public class Database
    {
        #region FIELDS

        private List<CustomerModel> _customers = new List<CustomerModel>();
        private List<DepartmentModel> _departments = new List<DepartmentModel>();

        private static Database _instance;
        private static readonly object Lock = new object();

        #endregion

        #region PROPERTIES

        public static Database Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (Lock)
                {
                    _instance = new Database();
                    return _instance;
                }
            }
        }

        #endregion

        #region C-TOR

        private Database()
        {
            this.CreateCustomerTestData();
            this.CreateDepartmentTestData();
        }

        #endregion

        #region CUSTOMER CRUDs

        public void CreateCustomer(ICustomerModel model)
        {
            this._customers.Add(
                new CustomerModel
                {
                    Id = GetCustomersNewId(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Gender = model.Gender,
                    Phone = model.Phone,
                    Email = model.Email
                });
        }

        public void UpdateCustomer(ICustomerModel model)
        {
            var c = this._customers.SingleOrDefault(cust => cust.Id == model.Id);
            if (c == null) return;

            c.FirstName = model.FirstName;
            c.LastName = model.LastName;
            c.Age = model.Age;
            c.Gender = model.Gender;
            c.Phone = model.Phone;
            c.Email = model.Email;
        }

        public ICustomerModel GetCustomerById(int id)
        {
            return this._customers.SingleOrDefault(cust => cust.Id == id);
        }

        public IEnumerable<ICustomerModel> GetAllCustomers()
        {
            return this._customers;
        }

        public void DeleteCustomer(int id)
        {
            var c = this._customers.SingleOrDefault(cust => cust.Id == id);
            if (c == null) return;
            this._customers.Remove(c);
        }

        #endregion

        #region DEPARTMENT CRUDs

        public void CreateDepartment(IDepartmentModel model)
        {
            this._departments.Add(new DepartmentModel { Id = GetDepartmentsNewId(), Name = model.Name });
        }

        public void UpdateDepartment(IDepartmentModel model)
        {
            IDepartmentModel d = this._departments.SingleOrDefault(dept => dept.Id == model.Id);
            if (d == null) return;

            d.Name = model.Name;
        }

        public IDepartmentModel GetDepartmentById(int id)
        {
            return this._departments.SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<IDepartmentModel> GetAllDepartments()
        {
            return this._departments;
        }

        public void DeleteDepartment(int id)
        {
            var c = this._departments.SingleOrDefault(cust => cust.Id == id);
            if (c == null) return;
            this._departments.Remove(c);
        }

        #endregion

        #region HELPERS

        private int GetCustomersNewId()
        {
            return this._customers.Max(c => c.Id) + 1;
        }

        private int GetDepartmentsNewId()
        {
            return this._departments.Max(c => c.Id) + 1;
        }

        private void CreateCustomerTestData()
        {
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 1",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 1,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 2",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 2,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 3",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 3,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 4",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 4,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 5",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 5,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 6",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 6,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 7",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 7,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 8",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 8,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 9",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 9,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 10",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 10,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 11",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 11,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 12",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 12,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 13",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 13,
                    Email = "max.mustermann@gmx.at"
                });
            this._customers.Add(
                new CustomerModel
                {
                    FirstName = "Max 14",
                    LastName = "Mustermann",
                    Age = 50,
                    Gender = Gender.Male,
                    Phone = "06557123456",
                    Id = 14,
                    Email = "max.mustermann@gmx.at"
                });
        }

        private void CreateDepartmentTestData()
        {
            this._departments.Add(new DepartmentModel { Id = 1, Name = "Department 1"});
            this._departments.Add(new DepartmentModel { Id = 2, Name = "Department 2" });
            this._departments.Add(new DepartmentModel { Id = 3, Name = "Department 3" });
            this._departments.Add(new DepartmentModel { Id = 4, Name = "Department 4" });
            this._departments.Add(new DepartmentModel { Id = 5, Name = "Department 5" });
            this._departments.Add(new DepartmentModel { Id = 6, Name = "Department 6" });
            this._departments.Add(new DepartmentModel { Id = 7, Name = "Department 7" });
            this._departments.Add(new DepartmentModel { Id = 8, Name = "Department 8" });
            //this._departments.Add(new DepartmentModel { Id = 9, Name = "Department 9" });
            //this._departments.Add(new DepartmentModel { Id = 10, Name = "Department 10" });
            //this._departments.Add(new DepartmentModel { Id = 11, Name = "Department 11" });
            //this._departments.Add(new DepartmentModel { Id = 12, Name = "Department 12" });
            //this._departments.Add(new DepartmentModel { Id = 13, Name = "Department 13" });
        }

        #endregion
    }
}
