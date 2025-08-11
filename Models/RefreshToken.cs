namespace HRSystem.Models
{
    public class RefreshToken : BaseModel
    {
        public string Token { get; set; }
        
        public DateTime ExpiresOn { get; set; }

        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;

        public DateTime? RevokedOn { get; set; }
        public bool IsActive => RevokedOn == null && !IsExpired;

        public string? RevokedReason { get; set; }

        public string? ReplacedByToken { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
