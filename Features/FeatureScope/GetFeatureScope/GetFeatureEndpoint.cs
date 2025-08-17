using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.FeatureScope.AddFeatureScope.Command;
using HRSystem.Features.FeatureScope.AddFeatureScope.DTOs;
using HRSystem.Features.FeatureScope.AddFeatureScope.VMs;
using HRSystem.Features.FeatureScope.RemoveFeatureScope.Command;
using HRSystem.Features.FeatureScope.RemoveFeatureScope.DTOs;
using HRSystem.Features.FeatureScope.RemoveFeatureScope.VMs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.FeatureScope.GetFeatureScope
{
    public class GetFeatureEndpoint : BaseEndPoint<RemoveFeatureScopeRequestVM, removeFeatureScopeResponseVM>

    {
        public GetFeatureEndpoint(EndPointBaseParameters<RemoveFeatureScopeRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<removeFeatureScopeResponseVM>> RemoveFeatureScope([FromQuery] RemoveFeatureScopeRequestVM removeFeatureScopeRequestVM)
        {
            var validate = ValidateRequest(removeFeatureScopeRequestVM);
            if (!validate.IsSuccess) return validate;

            var res = await mediator.Send(new RemoveFeatureScopeCommand(mapper.Map<RemoveFeatureScopeRequestDTO>(removeFeatureScopeRequestVM)));
            return res.IsSuccess ?
                    EndPointResponse<removeFeatureScopeResponseVM>.Success(mapper.Map<removeFeatureScopeResponseVM>(res), res.Message) :
                    EndPointResponse<removeFeatureScopeResponseVM>.Failure(res.Message);
        }
    }
}
