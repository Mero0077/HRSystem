namespace HRSystem.Features.Auth.Login.DTO
{
    public class LoginResponseDTOs
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiresOn { get; set; }
        public Guid RefreshTokenId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiresOn { get; set; }
    }
}
