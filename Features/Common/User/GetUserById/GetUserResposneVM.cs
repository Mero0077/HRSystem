namespace HRSystem.Features.Common.User.GetUser
{
    public class GetUserResposneVM
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public string HashedPassword { get; set; }

        public string FirstName { get; set; }

        public Guid OrganizationId { get; set; }
        public Guid CompanyId { get; set; }

        public Guid BranchId { get; set; }
        public Guid DepartmentId { get; set; }

        public Guid? TeamId { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string NationalityId { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string EmrgencyContact { get; set; }
        public string Nationality { get; set; }
        public bool IsActive { get; set; }
    }
}
