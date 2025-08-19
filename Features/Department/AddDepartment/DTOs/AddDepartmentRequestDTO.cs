namespace HRSystem.Features.Department.AddDepartment.DTOs
{
    public class AddDepartmentRequestDTO
    {
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
        public string? Description { get; set; }
        public virtual Guid BranchId { get; set; }
    }
}
