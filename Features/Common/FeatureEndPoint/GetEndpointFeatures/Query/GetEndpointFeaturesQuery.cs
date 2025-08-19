using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Common.FeatureEndPoint.DTO;
using HRSystem.Features.EndPoints;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Common.FeatureEndPoint.GetEndpointFeatures.Query
{
    public record GetEndpointFeaturesQuery(Guid Id):IRequest<RequestResult<GetEndPointFeaturesResponseVM>>;
    public class GetEndpointFeaturesQueryHandler : RequestHandlerBase<GetEndpointFeaturesQuery, GetEndPointFeaturesResponseVM>
    {
        private IGeneralRepository<HRSystem.Models.EndPointFeature> _EndPointFeatureRepository;
        public GetEndpointFeaturesQueryHandler(IGeneralRepository<HRSystem.Models.EndPointFeature> generalRepository ,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _EndPointFeatureRepository = generalRepository;
        }

        public override async Task<RequestResult<GetEndPointFeaturesResponseVM>> Handle(GetEndpointFeaturesQuery request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;


            var res = await _EndPointFeatureRepository.Get(e=>e.EndPointActionId== request.Id, userStateOrganizationId).ToListAsync();

            var mapped = new GetEndPointFeaturesResponseVM
            {
               EndPointIds=res.Select(res=>res.EndPointActionId).ToList()
            };
            return res == null ?
                    RequestResult<GetEndPointFeaturesResponseVM>.Failure("no features assigend") :
                    RequestResult<GetEndPointFeaturesResponseVM>.Success(mapped);
        }
    }
}
