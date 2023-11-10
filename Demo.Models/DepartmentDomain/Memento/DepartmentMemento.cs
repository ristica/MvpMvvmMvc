namespace Demo.Models.DepartmentDomain.Memento
{
    public class DepartmentMemento
    {
        public string Name { get; set; }

        public DepartmentMemento(string name)
        {
            this.Name = name;
        }
    }
}
