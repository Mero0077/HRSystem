namespace HRSystem.Features.Common.Department.GetDepartmentById.DTOs
{
    public class GetDepartmentByIdResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
        public int EmployeeId { get; set; }
        public string Description { get; set; }
        public Guid BranchId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
