using HRSystem.Common;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Features.Common.RoleFeature.Queries
{

    public record CheckFeatureRoleByIdsQuery(Guid featureId,Guid roleId) : IRequest<RequestResult<bool>>;
    public class CheckFeatureRoleByIdsQueryHandler : RequestHandlerBase<CheckFeatureRoleByIdsQuery, bool>
    {
        private readonly IGeneralRepository<Models.RoleFeature> _roleFeatureRepository;

        public CheckFeatureRoleByIdsQueryHandler(IGeneralRepository<Models.RoleFeature> roleFeatureRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._roleFeatureRepository = roleFeatureRepository;
        }

        public override async Task<RequestResult<bool>> Handle(CheckFeatureRoleByIdsQuery request, CancellationToken cancellationToken)
        {
            var result = await _roleFeatureRepository.AnyAsync(e=>e.RoleId==request.roleId && e.FeatureId==request.featureId && e.Feature.IsActive);
            return RequestResult<bool>.Success(result);
        }
    }
}
