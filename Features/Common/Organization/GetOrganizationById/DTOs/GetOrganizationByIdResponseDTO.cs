namespace HRSystem.Features.Common.Organization.GetOrganizationById.DTOs
{
    public class GetOrganizationByIdResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Industry { get; set; }
        public ICollection<Guid> CompanyIds { get; set; }
    }
}
