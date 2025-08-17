namespace HRSystem.Features.Company.AssignCompanyToOrganization.DTOs
{
    public class AssignCompanyToOrganizationRequestDTO
    {
        public Guid CompanyId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
