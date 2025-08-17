using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.UserScope.AddUserScope.Command;
using HRSystem.Features.UserScope.AddUserScope.DTOs;
using HRSystem.Features.UserScope.AddUserScope.VMs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.UserScope.AddUserScope
{
    public class AddUserScopeEndpoint : BaseEndPoint<AddUserScopeRequestVM, AddUserScopeResponseVM>
    {
        public AddUserScopeEndpoint(EndPointBaseParameters<AddUserScopeRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<AddUserScopeResponseVM>> AddUserScope([FromBody] AddUserScopeRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;

            var res= await mediator.Send(new AddUserScopeCommand(mapper.Map<AddUserScopeRequestDTO>(request)));
            return res.IsSuccess ?
                    EndPointResponse<AddUserScopeResponseVM>.Success(mapper.Map<AddUserScopeResponseVM>(res.Data), res.Message) :
                    EndPointResponse<AddUserScopeResponseVM>.Failure(res.Message);
        }
    }
}
