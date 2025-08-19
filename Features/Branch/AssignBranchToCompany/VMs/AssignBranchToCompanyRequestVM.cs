using FluentValidation;

namespace HRSystem.Features.Branch.AssignBranchToCompany.VMs
{
    public record AssignBranchToCompanyRequestVM(Guid CompanyId,Guid BranchId);
    public class AssignBranchToCompanyRequestVMValidator:AbstractValidator<AssignBranchToCompanyRequestVM>
    {
        public AssignBranchToCompanyRequestVMValidator()
        {
            RuleFor(e=>e.BranchId).NotEmpty();
            RuleFor(e=>e.CompanyId).NotEmpty();
        }
    }
}
