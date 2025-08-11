using HRSystem.Common.Constants;

namespace HRSystem.Features.Auth.Refresh_Token
{
    public class RefreshTokenResponseViewModel
    {
        public string AccessToken { get; set; }
        public Guid RefreshTokenId { get; set; }
        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpires { get; set; }
        public DateTime AccessTokenExpiresOn { get; set; }
    }
}
