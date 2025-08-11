using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.Login.DTO;
using MediatR;

namespace HRSystem.Features.Common.User.GetUser
{
    public record GetUserQuery(LoginDTO LoginDTO) : IRequest<RequestResult<GetUserResposneVM>>;
    public class GetUserQueryHandler : RequestHandlerBase<GetUserQuery, GetUserResposneVM>
    {
        private IGeneralRepository<HRSystem.Models.User> _userRepository;
        public GetUserQueryHandler(IGeneralRepository<HRSystem.Models.User> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _userRepository = generalRepository;
        }

        public override async Task<RequestResult<GetUserResposneVM>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var res = await _userRepository.GetOneWithTrackingAsync(e => e.UserName == request.LoginDTO.UserName);
            return res != null ?
                        RequestResult<GetUserResposneVM>.Success(mapper.Map<GetUserResposneVM>(res)) :
                        RequestResult<GetUserResposneVM>.Failure("No user");
        }
    }
}
