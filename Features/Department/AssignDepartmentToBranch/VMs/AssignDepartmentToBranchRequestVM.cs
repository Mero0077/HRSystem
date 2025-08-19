using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRSystem.Features.Department.AssignDepartmentToBranch.VMs
{
    public record AssignDepartmentToBranchRequestVM(Guid DepartmentId,Guid BranchId);
    public class AssignDepartmentToBranchRequestVMValidator:AbstractValidator<AssignDepartmentToBranchRequestVM>
    {
        public AssignDepartmentToBranchRequestVMValidator()
        {
            RuleFor(e=>e.BranchId).NotEmpty();
            RuleFor(e=>e.DepartmentId).NotEmpty();
        }
    }
}
