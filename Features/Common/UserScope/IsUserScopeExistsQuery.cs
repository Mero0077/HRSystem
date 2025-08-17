using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.UserScope.AddUserScope.Command;
using HRSystem.Features.UserScope.AddUserScope.DTOs;
using MediatR;

namespace HRSystem.Features.Common.UserScope
{
    public record IsUserScopeExistsQuery(AddUserScopeRequestDTO AddUserScopeRequestDTO):IRequest<RequestResult<bool>>;
    public class IsUserScopeExistsQueryHandler : RequestHandlerBase<IsUserScopeExistsQuery, bool>
    {
        private IGeneralRepository<HRSystem.Models.UserScope> _generalRepository;
        public IsUserScopeExistsQueryHandler(IGeneralRepository<HRSystem.Models.UserScope> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _generalRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsUserScopeExistsQuery request, CancellationToken cancellationToken)
        {
            var res = await _generalRepository.AnyAsync(e => e.UserId == request.AddUserScopeRequestDTO.UserId
            && e.FeatureId == request.AddUserScopeRequestDTO.FeatureId && e.OrganizationId == request.AddUserScopeRequestDTO.OrganizationId
            && e.CompanyId == request.AddUserScopeRequestDTO.CompanyId && e.BranchId == request.AddUserScopeRequestDTO.BranchId
            && e.DepartmentId == request.AddUserScopeRequestDTO.BranchId && e.TeamId == request.AddUserScopeRequestDTO.TeamId);

            return res ?
                    RequestResult<bool>.Success(true, "Userscope exists") :
                    RequestResult<bool>.Failure("Userscope does not exist");
        }

       
    }
}
