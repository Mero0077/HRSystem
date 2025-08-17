namespace HRSystem.Features.Common.Department.GetDepartmentById.DTOs
{
    public class GetDepartmentByIdRequestDTO
    {
        public Guid? OrganizationId { get; set; } =null;
        public Guid DepartmentId { get; set; }

        public Guid? CompanyId { get; set; } = null;
        public Guid? BranchId { get; set; } = null;
    }
}
