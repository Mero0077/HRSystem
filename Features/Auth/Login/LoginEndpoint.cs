using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.CreateAccount;
using HRSystem.Features.Auth.Login.Command;
using HRSystem.Features.Auth.Login.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Auth.Login
{
    public class LoginEndpoint : BaseEndPoint<LoginRequestVM, string>
    {
        public LoginEndpoint(EndPointBaseParameters<LoginRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<string>> Login([FromBody] LoginRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;

            var res = await mediator.Send(new LoginCommand(mapper.Map<LoginDTO>(request)));
            return res.IsSuccess ?
                        EndPointResponse<string>.Success(res.Data) :
                        EndPointResponse<string>.Failure("cant log in");
        }
    }
}
