using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Feature.GetAllFeature.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Feature.GetAllFeature.Endpoint
{

    public class GetAllFeaturesController : BaseEndPoint<GetAllFeaturesQuery, IEnumerable<GetAllFeaturesResponseViewModel>>
    {
        public GetAllFeaturesController(EndPointBaseParameters<GetAllFeaturesQuery> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndPointResponse<IEnumerable<GetAllFeaturesResponseViewModel>>> GetAllFeatures()
        {
            var result = await mediator.Send(new GetAllFeaturesQuery());

            if (result?.Data == null)
                return EndPointResponse<IEnumerable<GetAllFeaturesResponseViewModel>>.Failure(ErrorCodes.Null);


            if (!result.Data.Any())
                return EndPointResponse<IEnumerable<GetAllFeaturesResponseViewModel>>.Failure("The feature list is empty",ErrorCodes.NotFound);

            var responseViewModel = mapper.Map<IEnumerable<GetAllFeaturesResponseViewModel>>(result.Data);

            return EndPointResponse<IEnumerable<GetAllFeaturesResponseViewModel>>.Success(responseViewModel);
        }
    }
}
