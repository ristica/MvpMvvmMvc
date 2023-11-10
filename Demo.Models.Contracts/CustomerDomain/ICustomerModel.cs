using Demo.Models.Shared;

namespace Demo.Models.Contracts.CustomerDomain
{
    public interface ICustomerModel
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        Gender Gender { get; set; }

        void RevertOrigin();
        ICustomerModel InitializeOrigin(
            string firstname,
            string lastName, 
            int age, 
            string phone,
            string email,
            Gender gender);
    }
}