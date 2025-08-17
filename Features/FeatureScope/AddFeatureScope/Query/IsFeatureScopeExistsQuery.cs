using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.FeatureScope.AddFeatureScope.DTOs;
using MediatR;
using MediatR.Wrappers;

namespace HRSystem.Features.FeatureScope.AddFeatureScope.Query
{
    public record IsFeatureScopeExistsQuery(AddFeatureScopeRequestDTO AddFeatureScopeRequestDTO) :IRequest<RequestResult<bool>>;
    public class IsFeatureScopeExistsQueryHandler : RequestHandlerBase<IsFeatureScopeExistsQuery, bool>
    {
        private IGeneralRepository<HRSystem.Models.FeatureScope> _FeatureScopeRepository;
        public IsFeatureScopeExistsQueryHandler(IGeneralRepository<HRSystem.Models.FeatureScope> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _FeatureScopeRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsFeatureScopeExistsQuery request, CancellationToken cancellationToken)
        {
            var res = await _FeatureScopeRepository.AnyAsync(e=>e.FeatureId== request.AddFeatureScopeRequestDTO.FeatureId&&
               e.DepartmentId==request.AddFeatureScopeRequestDTO.DepartmentId && e.BranchId==request.AddFeatureScopeRequestDTO.BranchId &&
               e.OrganizationId== request.AddFeatureScopeRequestDTO.OrganizationId && e.CompanyId==request.AddFeatureScopeRequestDTO.CompanyId &&
               e.TeamId==request.AddFeatureScopeRequestDTO.TeamId);

            return res ?
                    RequestResult<bool>.Success(true,"Feature already exists!") :
                    RequestResult<bool>.Failure("Feature scope does not exist!");
        }
    }
}
