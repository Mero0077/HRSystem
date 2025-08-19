using FluentValidation;

namespace HRSystem.Features.Department.AddDepartment.VMs
{
    public record AddDepartmentRequestVM(Guid Name,Guid NumOfEmployees,string Description,Guid BranchId);
    public class AddDepartmentRequestVMValidator:AbstractValidator<AddDepartmentRequestVM>
    {
        public AddDepartmentRequestVMValidator()
        {
            
        }
    }
}
