using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.RoleFeature.AssignFeatureToRole.Commands;
using HRSystem.Features.RoleFeature.AssignFeatureToRole.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.RoleFeature.AssignFeatureToRole.Endpoint
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssignFeatureToRoleController : BaseEndPoint<AssignFeatureToRoleRequestViewModel, bool>
    {
        public AssignFeatureToRoleController(EndPointBaseParameters<AssignFeatureToRoleRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<bool>> AssignFeatureToRole([FromBody] AssignFeatureToRoleRequestViewModel assignFeatureToRoleRequestViewModel)
        {
            var requestDTO = mapper.Map<AssignFeatureToRoleRequestDTO>(assignFeatureToRoleRequestViewModel);
            var result = await mediator.Send(new AssignFeatureToRoleCommand(requestDTO));
            return result.IsSuccess ? EndPointResponse<bool>.Success(result.Data) : EndPointResponse<bool>.Failure(result.Message,result.ErrorCodes);
        }
    }
}
