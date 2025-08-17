using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.UserScope.GetUserScope.DTOs;
using MediatR;

namespace HRSystem.Features.UserScope.GetUserScope.Query
{
    public record GetUserScopeQuery(GetUserScopeRequestDTO GetUserScopeRequestDTO):IRequest<RequestResult<GetUserScopeResponseDTO>>;
    public class GetUserScopeQueryHandler : RequestHandlerBase<GetUserScopeQuery, GetUserScopeResponseDTO>
    {
        private IGeneralRepository<Models.UserScope> _generalRepository;
        public GetUserScopeQueryHandler(IGeneralRepository<Models.UserScope> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _generalRepository = generalRepository;
        }

        public override async Task<RequestResult<GetUserScopeResponseDTO>> Handle(GetUserScopeQuery request, CancellationToken cancellationToken)
        {
            var res = await _generalRepository.GetOneByIdAsync(request.GetUserScopeRequestDTO.Id);
            return res != null ?
                    RequestResult<GetUserScopeResponseDTO>.Success(mapper.Map<GetUserScopeResponseDTO>(res),"Record fetched") :
                    RequestResult<GetUserScopeResponseDTO>.Failure("Record does not exist");
        }
    }
}
