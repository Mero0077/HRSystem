using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.CreateAccount;
using HRSystem.Features.Auth.Login.Command;
using HRSystem.Features.Auth.Login.DTO;
using HRSystem.Features.Auth.Login.Orchestrator;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Auth.Login
{
    public class LoginEndpoint : BaseEndPoint<LoginRequestVM, LoginResponseVM>
    {
        public LoginEndpoint(EndPointBaseParameters<LoginRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<LoginResponseVM>> Login([FromBody] LoginRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;

            var res = await mediator.Send(new LoginOrchestrator(mapper.Map<LoginDTO>(request)));

            return res.IsSuccess ?
                        EndPointResponse<LoginResponseVM>.Success(mapper.Map<LoginResponseVM>(res.Data)) :
                        EndPointResponse<LoginResponseVM>.Failure(res.Message,res.ErrorCodes);
        }
    }
}
