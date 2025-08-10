using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.RoleFeature.UnAssignFeatureToRole.cs.Commands;
using HRSystem.Features.RoleFeature.UnAssignFeatureToRole.cs.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.RoleFeature.UnAssignFeatureToRole.cs.Endpoint
{
    public class UnAssignFeatureToRoleController : BaseEndPoint<UnAssignFeatureToRoleRequestViewModel, bool>
    {
        public UnAssignFeatureToRoleController(EndPointBaseParameters<UnAssignFeatureToRoleRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<bool>> UnAssignFeatureToRole([FromBody]UnAssignFeatureToRoleRequestViewModel unAssignFeatureToRoleRequestViewModel)
        {
            var requestDTOMapped = mapper.Map<UnAssignFeatureToRoleRequestDTO>(unAssignFeatureToRoleRequestViewModel);
            var result = await mediator.Send(new UnAssignFeatureToRoleCommand(requestDTOMapped));
            if (result.IsSuccess)
                return EndPointResponse<bool>.Success(result.Data);
            return EndPointResponse<bool>.Failure(result.Message, result.ErrorCodes);
        }
    }
}
