using Demo.Models.Contracts.DepartmentDomain;
using Demo.Models.DepartmentDomain.Memento;
using Demo.Wpf.Presentation.Shared;

namespace Demo.Models.DepartmentDomain
{
    public class DepartmentModel : CommonBase, IDepartmentModel
    {
        private int _id;
        private string _name;
        private DepartmentMemento _memento;

        public int Id
        {
            get => this._id;
            set
            {
                this._id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => this._name;
            set
            {
                this._name = value;
                OnPropertyChanged();
            }
        }

        private DepartmentMemento Memento
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
            this.Name = this.Memento.Name;
        }

        public IDepartmentModel InitializeOrigin(string name)
        {
            return new DepartmentModel
            {
                Name = name,
                Memento = new DepartmentMemento(name)
            };
        }
    }
}
