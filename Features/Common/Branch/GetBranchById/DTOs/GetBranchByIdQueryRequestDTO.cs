namespace HRSystem.Features.Common.Branch.GetBranchByIdQuery.DTOs
{
    public class GetBranchByIdQueryRequestDTO
    {
        public Guid OrganizationId { get; set; } 
        public Guid? CompanyId { get; set; } = null;
        public Guid BranchId { get; set; }
    }
}
