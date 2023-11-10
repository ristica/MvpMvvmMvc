namespace Demo.Models.Contracts.DepartmentDomain
{
    public interface IDepartmentModel
    {
        int Id { get; set; }
        string Name { get; set; }

        void RevertOrigin();
        IDepartmentModel InitializeOrigin(string name);
    }
}