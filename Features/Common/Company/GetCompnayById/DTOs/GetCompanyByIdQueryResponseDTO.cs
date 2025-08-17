namespace HRSystem.Features.Common.Company.GetCompnayByIdQuery.DTOs
{
    public class GetCompanyByIdQueryResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public  Guid OrganizationId { get; set; }

        public ICollection<Guid> BranchIds { get; set; } 

    }
}
