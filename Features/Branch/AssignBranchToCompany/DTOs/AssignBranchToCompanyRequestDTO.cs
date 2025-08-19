namespace HRSystem.Features.Branch.AssignBranchToCompany.DTOs
{
    public class AssignBranchToCompanyRequestDTO
    {
        public Guid CompanyId { get; set; }
        public Guid BranchId { get; set; }
    }
}
