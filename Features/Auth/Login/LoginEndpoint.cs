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

            if (!res.IsSuccess)
                return EndPointResponse<LoginResponseVM>.Failure(res.Message, res.ErrorCodes);

            var responseVM = mapper.Map<LoginResponseVM>(res.Data);

            //  HttpOnly Secure Cookie
            Response.Cookies.Append(
                "refreshToken",                  
                responseVM.RefreshToken,          
                new CookieOptions
                {
                    HttpOnly = true,              
                    Secure = true,                
                    SameSite = SameSiteMode.Strict,
                    Expires = responseVM.RefreshTokenExpiresOn
                }
            );

            return EndPointResponse<LoginResponseVM>.Success(new LoginResponseVM
            {
                AccessToken = responseVM.AccessToken,
                AccessTokenExpiresOn = responseVM.AccessTokenExpiresOn
            });
        }
    }
}
