using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.FeatureScope.AddFeatureScope.Command;
using HRSystem.Features.FeatureScope.AddFeatureScope.DTOs;
using HRSystem.Features.FeatureScope.AddFeatureScope.VMs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.FeatureScope.AddFeatureScope
{
    public class AddFeatureScopeEndpoint : BaseEndPoint<AddFeatureScopeRequestVM, AddFeatureScopeResponseVM>
   {
        
        public AddFeatureScopeEndpoint(EndPointBaseParameters<AddFeatureScopeRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<AddFeatureScopeResponseVM>> AddFeatureScope([FromBody] AddFeatureScopeRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;

            var res= await mediator.Send(new AddFeatureScopeCommand(mapper.Map<AddFeatureScopeRequestDTO>(request)));
            return res.IsSuccess ?
                    EndPointResponse<AddFeatureScopeResponseVM>.Success(mapper.Map<AddFeatureScopeResponseVM>(res.Data),res.Message) :
                    EndPointResponse<AddFeatureScopeResponseVM>.Failure(res.Message);
        }
    }
}

