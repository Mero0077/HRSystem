using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.Refresh_Token.Commands;
using HRSystem.Features.Auth.Refresh_Token.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Auth.Refresh_Token.Endpoint
{

    public class RefreshTokenController : BaseEndPoint<RefreshTokenRequestViewModel, RefreshTokenResponseViewModel>
    {
        public RefreshTokenController(EndPointBaseParameters<RefreshTokenRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<RefreshTokenResponseViewModel>> RefreshToken([FromBody] RefreshTokenRequestViewModel refreshTokenRequestViewModel )
        {
            var requestDTO = mapper.Map<RefreshTokenRequestDTO>(refreshTokenRequestViewModel);
            var result = await mediator.Send(new RefreshTokenOrchestrator(requestDTO));
            if (!result.IsSuccess)
                return EndPointResponse<RefreshTokenResponseViewModel>.Failure(result.Message,result.ErrorCodes);

            var responeViewModel = mapper.Map<RefreshTokenResponseViewModel>(result.Data);
            return EndPointResponse<RefreshTokenResponseViewModel>.Success(responeViewModel);
        }
    }
}
