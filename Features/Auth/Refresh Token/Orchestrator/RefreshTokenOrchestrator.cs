using HRSystem.Common;
using HRSystem.Common.Constants;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.Jwt.Helper;
using HRSystem.Features.Auth.Jwt.interfaces;
using HRSystem.Features.Auth.Refresh_Token.DTOs;
using HRSystem.Features.Auth.Refresh_Token.Queries;
using HRSystem.Features.Common.User.GetUserById;
using HRSystem.Features.Common.User.Queries;
using HRSystem.Models;
using MediatR;
using System.Security.Cryptography;

namespace HRSystem.Features.Auth.Refresh_Token.Commands
{
    public record RefreshTokenOrchestrator(RefreshTokenRequestDTO RefreshTokenRequestDTO) : IRequest<RequestResult<RefreshTokenResponseDTO>>;
    public class RefreshTokenOrchestratorHandler : RequestHandlerBase<RefreshTokenOrchestrator, RefreshTokenResponseDTO>
    {
        private readonly IJwtGenerateHandler _jwtGenerateHandler;
        private readonly IGeneralRepository<RefreshToken> _refreshTokenRepository;

        public RefreshTokenOrchestratorHandler(IJwtGenerateHandler jwtGenerateHandler,IGeneralRepository<Models.RefreshToken> refreshTokenRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._jwtGenerateHandler = jwtGenerateHandler;
            this._refreshTokenRepository = refreshTokenRepository;
        }

        public override async Task<RequestResult<RefreshTokenResponseDTO>> Handle(RefreshTokenOrchestrator request, CancellationToken cancellationToken)
        {
            var storedToken = await mediator.Send(new GetRefreshTokenQuery(request.RefreshTokenRequestDTO.RefreshTokenId));
            if (storedToken == null || !storedToken.Data.IsActive)
                return RequestResult<RefreshTokenResponseDTO>.Failure("Refresh Token is not found",ErrorCodes.UnAuthorized);

            if(storedToken.Data.Token != request.RefreshTokenRequestDTO.RefreshToken)
            {
                storedToken.Data.RevokedOn = DateTime.UtcNow;
                storedToken.Data.RevokedReason = "Token mismatch - possible theft";
                await _refreshTokenRepository.SaveChangesAsync();
                return RequestResult<RefreshTokenResponseDTO>.Failure("Invalid refresh token.",ErrorCodes.UnAuthorized);
            }

            var user = await mediator.Send(new GetUserByIdQuery(storedToken.Data.User.UserName));
            if (user.Data == null)
                return RequestResult<RefreshTokenResponseDTO>.Failure("User is not found",ErrorCodes.NotFound);

            var newRefreshToken = CreateRefreshToken(user.Data.Id); // refresh token should be hashed
            storedToken.Data.RevokedOn = DateTime.UtcNow;
            storedToken.Data.ReplacedByToken = newRefreshToken.Token;
            storedToken.Data.RevokedReason = "Replaced by rotation";

           await _refreshTokenRepository.AddAsync(newRefreshToken);
           var newAccessToken = _jwtGenerateHandler.GenerateToken(user.Data.UserName,user.Data.Id,user.Data.RoleIds.ToList(),user.Data.OrganizationId);

           await _refreshTokenRepository.SaveChangesAsync();

            RefreshTokenResponseDTO responseDTO = new RefreshTokenResponseDTO()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token,
                RefreshTokenId = newRefreshToken.Id,
                AccessTokenExpiresOn = DateTime.UtcNow.AddHours(Constants.JwtExpiredAcessTokenHours),
                RefreshTokenExpires =  newRefreshToken.ExpiresOn,
            };

            return RequestResult<RefreshTokenResponseDTO>.Success(responseDTO);
        }

        private RefreshToken CreateRefreshToken(Guid userId)
        {
            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpiresOn = DateTime.UtcNow.AddDays(Constants.JwtExpiredRefreshTokenDays),
                CreatedDate = DateTime.UtcNow,
                UserId = userId
            };
            return refreshToken;
        }
    }
}
