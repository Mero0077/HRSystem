using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.Login.DTO;
using HRSystem.Features.Common.User.GetUser.DTo;
using HRSystem.Features.Common.User.GetUserById.DTO;
using MediatR;

namespace HRSystem.Features.Common.User.GetUser
{
    public record GetUserByIdQuery(GetUserByIdRequestDTO GetUserByIdRequestDTO) : IRequest<RequestResult<GetUserByIdResponseDTO>>;
    public class GetUserByIdQueryHandler : RequestHandlerBase<GetUserByIdQuery, GetUserByIdResponseDTO>
    {
        private IGeneralRepository<HRSystem.Models.User> _userRepository;
        public GetUserByIdQueryHandler(IGeneralRepository<HRSystem.Models.User> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _userRepository = generalRepository;
        }

        public override async Task<RequestResult<GetUserByIdResponseDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _userRepository.GetOneWithTrackingAsync(e => e.Id == request.GetUserByIdRequestDTO.UserId);
            return res != null ?
                        RequestResult<GetUserByIdResponseDTO>.Success(mapper.Map<GetUserByIdResponseDTO>(res)) :
                        RequestResult<GetUserByIdResponseDTO>.Failure("User Is Not Found",ErrorCodes.NotFound);
        }
    }
}
