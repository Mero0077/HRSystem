using HRSystem.Common;

namespace HRSystem.Features.Company.AssignCompanyToOrganization.VMs
{
    public class AssignCompanyToOrganizationResponseVM
    {
        public Guid CompanyId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
