namespace HRSystem.Models
{
    public class Department:BaseModel
    {
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
        public int EmployeeId { get; set; }
        public string Description { get; set; }

        public Branch Branch { get; set; }
        public Guid BranchId { get; set; }
    }
}
