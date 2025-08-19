using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRSystem.Features.Department.AssignDepartmentToBranch.DTOs
{
    public class AssignDepartmentToBranchRequestDTO
    {
        public Guid DepartmentId { get; set; }
        public Guid BranchId { get; set; }

    }
}
