namespace HRSystem.Features.Common.Branch.GetBranchByIdQuery.DTOs
{
    public class GetBranchByIdQueryResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string TimeZone { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid CompanyId { get; set; }

        public ICollection<Guid> DepartmentIds { get; set; }
    }
}
