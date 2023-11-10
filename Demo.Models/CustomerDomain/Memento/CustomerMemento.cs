using Demo.Models.Shared;

namespace Demo.Models.CustomerDomain.Memento
{
    public class CustomerMemento
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }

        public CustomerMemento(string firstname, string lastName, int age, string phone, string email, Gender gender)
        {
            this.FirstName = firstname;
            this.LastName = lastName;
            this.Age = age;
            this.Phone = phone;
            this.Email = email;
            this.Gender = gender;
        }
    }
}
