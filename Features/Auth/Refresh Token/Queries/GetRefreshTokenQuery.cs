using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Models;
using MediatR;

namespace HRSystem.Features.Auth.Refresh_Token.Queries
{

    public record GetRefreshTokenQuery(Guid refreshTokenId):IRequest<RequestResult<Models.RefreshToken>>;
    public class GetRefreshTokenQueryHandler : RequestHandlerBase<GetRefreshTokenQuery, Models.RefreshToken>
    {
        private readonly IGeneralRepository<RefreshToken> _refreshTokenRepository;

        public GetRefreshTokenQueryHandler(IGeneralRepository<Models.RefreshToken> refreshTokenRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._refreshTokenRepository = refreshTokenRepository;
        }

        public override async Task<RequestResult<Models.RefreshToken>> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var result = await _refreshTokenRepository.GetOneWithTrackingAsync(e=>e.Id == request.refreshTokenId);
            return RequestResult<Models.RefreshToken>.Success(result);
        }
    }
}
