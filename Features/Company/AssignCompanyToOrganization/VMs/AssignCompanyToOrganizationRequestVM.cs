using FluentValidation;

namespace HRSystem.Features.Company.AssignCompanyToOrganization.VMs
{
    public record AssignCompanyToOrganizationRequestVM(Guid CompanyId, Guid OrganizationId);
    public class AssignCompanyToOrganizationRequestVMValidator:AbstractValidator<AssignCompanyToOrganizationRequestVM>
    {
        public AssignCompanyToOrganizationRequestVMValidator()
        {
            
        }
    }
}
