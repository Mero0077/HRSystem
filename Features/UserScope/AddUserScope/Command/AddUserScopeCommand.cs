using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Common.UserScope;
using HRSystem.Features.UserScope.AddUserScope.DTOs;
using MediatR;

namespace HRSystem.Features.UserScope.AddUserScope.Command
{
    public record AddUserScopeCommand(AddUserScopeRequestDTO AddUserScopeRequestDTO):IRequest<RequestResult<AddUserScopeResponseDTO>>;
    public class AddUserScopeCommandHandler : RequestHandlerBase<AddUserScopeCommand, AddUserScopeResponseDTO>
    {
        private IGeneralRepository<HRSystem.Models.UserScope> _generalRepository;
        public AddUserScopeCommandHandler(IGeneralRepository<HRSystem.Models.UserScope> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _generalRepository = generalRepository;
        }

        public override async Task<RequestResult<AddUserScopeResponseDTO>> Handle(AddUserScopeCommand request, CancellationToken cancellationToken)
        {
            var exists = await mediator.Send(new IsUserScopeExistsQuery(request.AddUserScopeRequestDTO));
            if(exists.IsSuccess) return RequestResult<AddUserScopeResponseDTO>.Failure(exists.Message);

            var res = await _generalRepository.AddAsync(mapper.Map<HRSystem.Models.UserScope>(request.AddUserScopeRequestDTO));
            return res != null ?
                    RequestResult<AddUserScopeResponseDTO>.Success(mapper.Map<AddUserScopeResponseDTO>(res), "user scope added!") :
                    RequestResult<AddUserScopeResponseDTO>.Failure("user scope could not be added!");
        }
    }
}
