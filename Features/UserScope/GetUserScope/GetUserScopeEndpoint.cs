using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Common.User.GetUser;
using HRSystem.Features.UserScope.GetUserScope.DTOs;
using HRSystem.Features.UserScope.GetUserScope.Query;
using HRSystem.Features.UserScope.GetUserScope.VMs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.UserScope.GetUserScope
{
    public class GetUserScopeEndpoint : BaseEndPoint<GetUserScopeRequestVM, GetUserScopeResponseVM>
    {

        public GetUserScopeEndpoint(EndPointBaseParameters<GetUserScopeRequestVM> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndPointResponse<GetUserScopeResponseVM>> GetUserScope([FromQuery] GetUserScopeRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;


            var res = await mediator.Send(new GetUserScopeQuery(mapper.Map<GetUserScopeRequestDTO>(request)));
            return res.IsSuccess ?
                    EndPointResponse<GetUserScopeResponseVM>.Success(mapper.Map<GetUserScopeResponseVM>(res), res.Message) :
                    EndPointResponse<GetUserScopeResponseVM>.Failure(res.Message);
        }
    }
}

