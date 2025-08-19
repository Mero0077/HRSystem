namespace HRSystem.Features.Department.AssignDepartmentToBranch.DTOs
{
    public class AssignDepartmentToBranchResponseDTO
    {
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
        public string Description { get; set; }
        public Guid? ManagerId { get; set; }
        public virtual Guid BranchId { get; set; }
    }
}
