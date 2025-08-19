namespace HRSystem.Features.Company.AddCompany.DTOs
{
    public class AddCompanyResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
