namespace HRSystem.Features.Department.AddDepartment.DTOs
{
    public class AddDepartmentResponseDTO
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
        public Guid? ManagerId { get; set; }
        public string? Description { get; set; }
        public virtual Guid BranchId { get; set; }
    }
}
