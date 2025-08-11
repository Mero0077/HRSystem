using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.Jwt.interfaces;
using HRSystem.Features.Auth.Login.DTO;
using HRSystem.Features.Common.User.GetUser;
using HRSystem.Features.Common.User.GetUserById;
using HRSystem.Features.Common.User.Queries;
using HRSystem.Features.UserRole.GetUserRole.Query;
using HRSystem.Models;
using MediatR;

namespace HRSystem.Features.Auth.Login.Command
{
    public record LoginCommand(LoginDTO LoginDTO):IRequest<RequestResult<string>>;
    public class LoginCommandHandler : RequestHandlerBase<LoginCommand, string>
    {
        private readonly IGeneralRepository<User> _userRepository;
        private readonly IJwtGenerateHandler _jwtGenerateHandler;
        public LoginCommandHandler(IGeneralRepository<User> generalRepository, IJwtGenerateHandler jwtGenerateHandler, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _userRepository = generalRepository;
            _jwtGenerateHandler = jwtGenerateHandler;
        }

        public async override Task<RequestResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var res = await mediator.Send(new CheckIfUserNameAndPasswordMatchesQuery(request.LoginDTO));
            if (res == null) return RequestResult<string>.Failure("Invalid Username or Pass!",ErrorCodes.UnAuthenticated);

            var user = await mediator.Send(new GetUserByIdQuery(request.LoginDTO.UserName));
            if(user.Data == null)
                return RequestResult<string>.Failure("Invalid Username or Pass!", ErrorCodes.NotFound);

            string token = _jwtGenerateHandler.GenerateToken(user.Data.UserName, user.Data.Id, user.Data.RoleIds.ToList());

            var refreshToken = new RefreshToken()
            {
                Id = Guid.NewGuid()
            };

            return RequestResult<string>.Success(token);
        }
    }
}
