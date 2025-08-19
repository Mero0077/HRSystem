namespace HRSystem.Features.Common.Department.IsDepartmentAlreadyAssignedToBranch.DTO
{
    public class IsDepartmentAlreadyAssignedToBranchRequestDTO
    {
        public Guid DepartmentId { get; set; }
        public Guid BranchId { get; set; }
    }
}
