using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.CreateAccount.Command;
using HRSystem.Features.Auth.CreateAccount.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Auth.CreateAccount
{
    public class CreateAccountEndpoint : BaseEndPoint<CreateAccountRequestVM, CreateAccountResponseVM>
    {
        public CreateAccountEndpoint(EndPointBaseParameters<CreateAccountRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<CreateAccountResponseVM>> CreateAccount([FromBody] CreateAccountRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;

            var res= await mediator.Send(new CreateAccountCommand(mapper.Map<CreateAccountDTO>(request)));
            return res.IsSuccess ?
                        EndPointResponse<CreateAccountResponseVM>.Success(res.Data,"Account Created") :
                        EndPointResponse<CreateAccountResponseVM>.Failure("Can't create account");
        }
    }
}
