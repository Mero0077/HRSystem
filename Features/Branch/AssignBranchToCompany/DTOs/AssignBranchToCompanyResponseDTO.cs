namespace HRSystem.Features.Branch.AssignBranchToCompany.DTOs
{
    public class AssignBranchToCompanyResponseDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string TimeZone { get; set; }
        public Guid CompanyId { get; set; }
    }
}
