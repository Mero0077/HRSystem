namespace HRSystem.Models
{
    public class RoleScope : BaseModel
    {
        public Guid OrganizationId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid BranchId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? TeamId { get; set; }
        public bool IsActive { get; set; }
        public Guid RoleId { get; set; }

    }
}
