namespace HRSystem.Features.Auth.Refresh_Token.DTOs
{
    public class RefreshTokenRequestDTO
    {
        public Guid RefreshTokenId { get; set; }
        public string RefreshToken { get; set; }
    }
}
