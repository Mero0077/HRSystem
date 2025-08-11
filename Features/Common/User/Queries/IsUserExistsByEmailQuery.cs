using HRSystem.Common;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Features.Common.User.Queries
{
    public record IsUserExistsByEmailQuery(string email) : IRequest<RequestResult<bool>>;
    public class IsUserExistsByEmailQueryHandler : RequestHandlerBase<IsUserExistsByEmailQuery, bool>
    {
        private IGeneralRepository<HRSystem.Models.User> _repository;
        public IsUserExistsByEmailQueryHandler(IGeneralRepository<HRSystem.Models.User> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _repository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsUserExistsByEmailQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.GetOneWithTrackingAsync(e => e.Email == request.email);
            return res != null ?
                    RequestResult<bool>.Success(true) :
                    RequestResult<bool>.Failure("User with this email does not exist!");
        }
    }
}
