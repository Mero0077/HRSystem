using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Branch.Create_Branch.Command;
using HRSystem.Features.Branch.Create_Branch.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Branch.Create_Branch.Endpoint
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreateBranchController : BaseEndPoint<CreateBranchRequestViewModel, CreateBranchResponseViewModel>
    {
        public CreateBranchController(EndPointBaseParameters<CreateBranchRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<CreateBranchResponseViewModel>> CreateBranch([FromBody] CreateBranchRequestViewModel request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess)
                return validate;

            var requestDTO = mapper.Map<CreateBranchRequestDTO>(request);

            var result = await mediator.Send(new CreateBranchCommand(requestDTO));

            if (!result.IsSuccess)
                return EndPointResponse<CreateBranchResponseViewModel>.Failure("Cannot Create Branch",result.ErrorCodes);

            var responseEntity = mapper.Map<Models.Branch>(requestDTO);

            var responseViewModel = mapper.Map<CreateBranchResponseViewModel>(responseEntity);

            return EndPointResponse<CreateBranchResponseViewModel>.Success(responseViewModel);
          
        }
    }
}
