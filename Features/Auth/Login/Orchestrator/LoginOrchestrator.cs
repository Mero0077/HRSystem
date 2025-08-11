using HRSystem.Common;
using HRSystem.Common.Constants;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.Jwt.interfaces;
using HRSystem.Features.Auth.Login.DTO;
using HRSystem.Features.Common.User.GetUserById;
using HRSystem.Features.Common.User.Queries;
using HRSystem.Models;
using MediatR;
using System.Security.Cryptography;

namespace HRSystem.Features.Auth.Login.Orchestrator
{
    public record LoginOrchestrator(LoginDTO LoginDTO) : IRequest<RequestResult<LoginResponseDTOs>>;

    public class LoginOrchestratorHandler : RequestHandlerBase<LoginOrchestrator, LoginResponseDTOs>
    {
        private readonly IGeneralRepository<RefreshToken> _refreshRepository;
        private readonly IGeneralRepository<User> _userRepository;
        private readonly IJwtGenerateHandler _jwtGenerateHandler;

        public LoginOrchestratorHandler(IGeneralRepository<RefreshToken> refreshRepository,IGeneralRepository<User> userRepository, IJwtGenerateHandler jwtGenerateHandler,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._refreshRepository = refreshRepository;
            this._userRepository = userRepository;
            this._jwtGenerateHandler = jwtGenerateHandler;
        }

        public override async Task<RequestResult<LoginResponseDTOs>> Handle(LoginOrchestrator request, CancellationToken cancellationToken)
        {
            var res = await mediator.Send(new CheckIfUserNameAndPasswordMatchesQuery(request.LoginDTO));

            if (res == null) return RequestResult<LoginResponseDTOs>.Failure("Invalid Username or Pass!", ErrorCodes.UnAuthenticated);

            var user = await mediator.Send(new GetUserByIdQuery(request.LoginDTO.UserName));
            if (user.Data == null)
                return RequestResult<LoginResponseDTOs>.Failure("Invalid Username or Pass!", ErrorCodes.NotFound);

            string token = _jwtGenerateHandler.GenerateToken(user.Data.UserName, user.Data.Id, user.Data.RoleIds.FirstOrDefault());

            var refreshToken = new RefreshToken()
            {
                Id = Guid.NewGuid(),
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpiresOn = DateTime.UtcNow.AddDays(Constants.JwtExpiredRefreshTokenDays),
                CreatedDate = DateTime.UtcNow,
                UserId = user.Data.Id,
            };
            await _refreshRepository.AddAsync(refreshToken);
            await _refreshRepository.SaveChangesAsync();    
            var loginResponse = new LoginResponseDTOs()
            {
                AccessToken = token,
                AccessTokenExpiresOn=DateTime.UtcNow.AddHours(Constants.JwtExpiredAcessTokenHours),
                RefreshToken = refreshToken.Token,
                RefreshTokenId =refreshToken.Id,
                RefreshTokenExpiresOn=refreshToken.ExpiresOn
            };
            return RequestResult<LoginResponseDTOs>.Success(loginResponse);
        }
    }


}
