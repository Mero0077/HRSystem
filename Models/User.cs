namespace HRSystem.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }
        public string HashedPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Phone {  get; set; }
        public string NationalityId { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string EmrgencyContact { get; set; }
        public string Nationality { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

    }
}
