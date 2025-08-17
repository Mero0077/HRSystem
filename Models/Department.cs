namespace HRSystem.Models
{
    public class Department:BaseModel
    {
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
        public string Description { get; set; }
        public Guid? ManagerId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Guid BranchId { get; set; }
    }
}
