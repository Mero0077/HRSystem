using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.Login.DTO;
using MediatR;

namespace HRSystem.Features.Common.User.Queries
{
    public record CheckIfUserNameAndPasswordMatchesQuery(LoginDTO LoginDTO) : IRequest<RequestResult<bool>>;

    public class CheckIfUserNameAndPasswordMatchesQueryHandler : RequestHandlerBase<CheckIfUserNameAndPasswordMatchesQuery, bool>
    {
        private IGeneralRepository<HRSystem.Models.User> _userRepository;
        public CheckIfUserNameAndPasswordMatchesQueryHandler(IGeneralRepository<HRSystem.Models.User> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _userRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(CheckIfUserNameAndPasswordMatchesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetOneWithTrackingAsync(e => e.UserName == request.LoginDTO.UserName);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.LoginDTO.Password, user.HashedPassword))
            {
                return RequestResult<bool>.Failure("Invalid username or password");
            }

            return RequestResult<bool>.Success(true);
        }
    }
}
