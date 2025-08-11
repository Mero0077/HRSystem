using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Features.Common.User.Queries
{

    public record IsUserExistsQuery(Guid userId) : IRequest<RequestResult<bool>>;
    public class IsUserExistsQueryHandler : RequestHandlerBase<IsUserExistsQuery, bool>
    {
        private readonly IGeneralRepository<Models.User> _userRepository;

        public IsUserExistsQueryHandler(IGeneralRepository<Models.User> userRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._userRepository = userRepository;
        }
        public async override Task<RequestResult<bool>> Handle(IsUserExistsQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.AnyAsync(e=>e.Id==request.userId,cancellationToken);
            return result ? RequestResult<bool>.Success(result) : RequestResult<bool>.Failure("User doest not Exist",ErrorCodes.NotFound);
        }
    }

}
