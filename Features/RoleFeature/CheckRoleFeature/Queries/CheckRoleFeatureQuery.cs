using HRSystem.Common;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Features.RoleFeature.CheckRoleFeature.Queries
{
    public record CheckRoleFeatureQuery(int featureCode,Guid roleId) : IRequest<RequestResult<bool>>;
    public class CheckRoleFeatureQueryHandler : RequestHandlerBase<CheckRoleFeatureQuery, bool>
    {
        private readonly IGeneralRepository<Models.RoleFeature> _roleFeatureRepository;

        public CheckRoleFeatureQueryHandler(IGeneralRepository<Models.RoleFeature> roleFeatureRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._roleFeatureRepository = roleFeatureRepository;
        }

        public async override Task<RequestResult<bool>> Handle(CheckRoleFeatureQuery request, CancellationToken cancellationToken)
        {
           var result = await _roleFeatureRepository.AnyAsync(
           e=>e.Feature.Code == request.featureCode 
           && e.Feature.IsActive 
           && e.RoleId == request.roleId
           );
          return RequestResult<bool>.Success(result);
        }
    }

}
