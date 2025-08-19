namespace HRSystem.Features.Branch.AssignBranchToCompany.VMs
{
    public class AssignBranchToCompanyResponseVM
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string TimeZone { get; set; }
        public Guid CompanyId { get; set; }
    }
}
