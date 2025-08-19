namespace HRSystem.Features.Common.Branch.IsBranchAlreadyAssignedToCompany.DTOs
{
    public class IsBranchAlreadyAssignedToCompanyRequestDTO
    {
        public Guid CompanyId { get; set; }
        public Guid BranchId { get; set; }
    }
}
