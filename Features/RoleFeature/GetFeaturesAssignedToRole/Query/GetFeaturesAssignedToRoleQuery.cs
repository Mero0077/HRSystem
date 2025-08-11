using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Feature.GetAllFeature.DTOs;
using HRSystem.Features.RoleFeature.GetFeaturesAssignedToRole.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.RoleFeature.GetFeaturesAssignedToRole.Query
{
    public record GetFeaturesAssignedToRoleQuery(Guid RoleId):IRequest<RequestResult<GetFeaturesAssignedToRoleResponseVM>>;
    public class GetFeaturesAssignedToRoleQueryHandler : RequestHandlerBase<GetFeaturesAssignedToRoleQuery, GetFeaturesAssignedToRoleResponseVM>
    {
        private IGeneralRepository<HRSystem.Models.RoleFeature> _RoleFeatureRepository;
        public GetFeaturesAssignedToRoleQueryHandler(IGeneralRepository<HRSystem.Models.RoleFeature> generalRepository ,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _RoleFeatureRepository = generalRepository;
        }

        public override async Task<RequestResult<GetFeaturesAssignedToRoleResponseVM>> Handle(GetFeaturesAssignedToRoleQuery request, CancellationToken cancellationToken)
        {
            var res = await _RoleFeatureRepository.Get(e => e.RoleId == request.RoleId).ToListAsync();
            var mapped = new GetFeaturesAssignedToRoleResponseVM
            {
                FeatureIds = res.Select(e => e.RoleId).ToList()
            };
            return res != null ?
                    RequestResult<GetFeaturesAssignedToRoleResponseVM>.Success(mapped) :
                    RequestResult<GetFeaturesAssignedToRoleResponseVM>.Failure("No features for this role");
        }
    }
}
