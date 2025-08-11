namespace HRSystem.Features.Auth.Jwt.interfaces
{
    public interface IJwtGenerateHandler
    {
        public string GenerateToken(string userName,Guid userId,Guid roleId);
    }
}
