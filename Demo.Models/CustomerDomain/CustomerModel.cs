using Demo.Models.Contracts.CustomerDomain;
using Demo.Models.CustomerDomain.Memento;
using Demo.Models.Shared;
using Demo.Wpf.Presentation.Shared;

namespace Demo.Models.CustomerDomain
{
    public class CustomerModel : CommonBase, ICustomerModel
    {
        private int _id;
        private string _firstname;
        private string _lastname;
        private int _age;
        private string _email;
        private string _phone;
        private Gender _gender;
        private CustomerMemento _memento;

        public int Id
        {
            get => this._id;
            set
            {
                this._id = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => this._firstname;
            set
            {
                this._firstname = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => this._lastname;
            set
            {
                this._lastname = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get => this._age;
            set
            {
                this._age = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => this._phone;
            set
            {
                this._phone = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => this._email;
            set
            {
                this._email = value;
                OnPropertyChanged();
            }
        }

        public Gender Gender
        {
            get => this._gender;
            set
            {
                this._gender = value;
                OnPropertyChanged();
            }
        }

        private CustomerMemento Memento
        {
            get => this._memento;
            set
            {
                this._memento = value;
                OnPropertyChanged();
            }
        }

        public void RevertOrigin()
        {
            this.Email = this.Memento.Email;
            this.Gender = this.Memento.Gender;
            this.FirstName = this.Memento.FirstName;
            this.LastName = this.Memento.LastName;
            this.Age = this.Memento.Age;
            this.Phone = this.Memento.Phone;
        }

        public ICustomerModel InitializeOrigin(
            string firstname, 
            string lastName, 
            int age,
            string phone, 
            string email,
            Gender gender)
        {
            return new CustomerModel
            {
                FirstName = firstname,
                LastName = lastName,
                Age = age,
                Phone = phone,
                Email = email,
                Gender = gender,
                Memento = new CustomerMemento(firstname, lastName, age, phone, email, gender)
            };
        }
    }
}
